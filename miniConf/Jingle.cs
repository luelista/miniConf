using agsXMPP;
using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace miniConf {
    class Jingle {

        public delegate void OnFileReceivedEvent(Jid fromJid, string filename, string status);
        public event OnFileReceivedEvent OnFileReceived;


        public bool AutoAccept = true;

        Dictionary<string, JingleSession> ongoingTransports = new Dictionary<string, JingleSession>();

        XmppClientConnection conn;

        public Jingle() {
            
        }

        public void init(agsXMPP.XmppClientConnection client) {
            this.conn = client;
            client.OnIq += OnJingleIq;
        }


        public void OnJingleIq(object sender, agsXMPP.protocol.client.IQ iq) {
            if (!iq.HasTag("jingle")) return;
            var jingle = iq.SelectSingleElement("jingle");

            Element contentIn,transportIn;
            string sid;
            JingleSession session;
                    
            switch (jingle.GetAttribute("action")) {
                    // incoming, first step
                case "session-initiate":
                    session = new JingleSession(conn, iq);

                    var fileName = "";
                    try { fileName = jingle.SelectSingleElement("file", true).GetTag("name"); } catch (Exception exx) { }
                    if (!AutoAccept) { // && MessageBox.Show("Incoming File Transfer from " + iq.From.ToString() + "\n\n" +fileName, "Jingle file-transfer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel) {
                        SendIqResult(iq);
                        var sesTerm = session.BuildSessionTerminate("decline");
                        conn.Send(sesTerm);
                        return;
                    }
                    SendIqResult(iq);

                    ongoingTransports[session.transportSid] = session;
                    session.OnFileReceived += ses_OnFileReceived;
                    var ack = session.BuildSessionAccept();
                    conn.Send(ack);

                    var cFirst = session.transportIn.FirstChild;
                    var cUsed = session.BuildCandidateUsed(cFirst.GetAttribute("cid"), "candidate-used");
                    conn.Send(cUsed);

                    session.DoTransmission(cFirst);
                    
                    break;

                    // incoming AND sending, second step
                case "transport-info":

                    contentIn = jingle.SelectSingleElement("content");
                    transportIn = contentIn.SelectSingleElement("transport");
                    sid = transportIn.GetAttribute("sid");
                    if (!ongoingTransports.ContainsKey(sid)) {
                        SendIqerror(iq); return;
                    }

                    session = ongoingTransports[sid];
                    if (transportIn.HasTag("candidate-used")) {
                        var cid = transportIn.SelectSingleElement("candidate-used").GetAttribute("cid");
                        var info = session.GetTransportCandidate(cid);
                        bool ok = session.DoTransmission(info);
                        if (ok) SendIqResult(iq); else SendIqerror(iq);
                    } else if (transportIn.HasTag("candidate-error")) {
                        SendIqResult(iq);
                    }
                    
                    break;


                    // sending, first step
                case "session-accept":
                    contentIn = jingle.SelectSingleElement("content");
                    transportIn = contentIn.SelectSingleElement("transport");
                    sid = transportIn.GetAttribute("sid");
                    if (!ongoingTransports.ContainsKey(sid)) {
                        SendIqerror(iq); return;
                    }
                    session = ongoingTransports[sid];
                    var cFirst1 = session.transportIn.FirstChild;
                    var cUsed1 = session.BuildCandidateUsed(cFirst1.GetAttribute("cid"), "candidate-used");
                    conn.Send(cUsed1);

                    break;
            }
        }

        void ses_OnFileReceived(Jid fromJid, string filename, string status) {
            if (OnFileReceived != null) OnFileReceived(fromJid, filename, status);
        }

        public void SendIqResult(agsXMPP.protocol.client.IQ iq) {
            var ack = new agsXMPP.protocol.client.IQ(agsXMPP.protocol.client.IqType.result, iq.To, iq.From);
            ack.Attributes["id"] = iq.Attributes["id"];
            conn.Send(ack);
        }

        public void SendIqerror(agsXMPP.protocol.client.IQ iq) {
            var ack = new agsXMPP.protocol.client.IQ(agsXMPP.protocol.client.IqType.error, iq.To, iq.From);
            ack.Attributes["id"] = iq.Attributes["id"];
            conn.Send(ack);
        }

        public void SendFile(string to, string fileName) {
            string proxyServer = "proxy.teamwiki.de";
            string proxyPort = "5000";
            JingleSession session = new JingleSession(conn, to, fileName, proxyServer, proxyPort);
            ongoingTransports[session.transportSid] = session;

        }

        class JingleSession {
            public event OnFileReceivedEvent OnFileReceived;

            XmppClientConnection conn;

            agsXMPP.protocol.client.IQ initiateIq;
            Element initiateJingle;
            Element contentIn;
            public Element transportIn;
            public string transportSid;

            public bool selfInitiated;

            public string jingle_initiator, jingle_sid, content_name;
            public Jid iq_from, iq_to;

            public string localFilespec;

            /// <summary>
            /// make incoming Jingle session
            /// </summary>
            /// <param name="xmppClient"></param>
            /// <param name="initIq"></param>
            public JingleSession(XmppClientConnection xmppClient, agsXMPP.protocol.client.IQ initIq) {
                selfInitiated = false;
                this.conn = xmppClient;

                this.initiateIq = initIq;
                this.initiateJingle = initIq.SelectSingleElement("jingle");
                this.contentIn = initiateJingle.SelectSingleElement("content");
                this.transportIn = contentIn.SelectSingleElement("transport");
                this.transportSid = (string)transportIn.Attributes["sid"];
                jingle_initiator = initiateJingle.GetAttribute("initiator");
                jingle_sid = initiateJingle.GetAttribute("sid");
                content_name = contentIn.GetAttribute("name");
                iq_from = initiateIq.To;
                iq_to = initiateIq.From;

                var filename = contentIn.SelectSingleElement("file", true).GetTag("name");
                localFilespec = Program.dataDir + "received files\\" + filename;

            }

            /// <summary>
            /// make outgoing Jingle Session
            /// </summary>
            /// <param name="xmppClient"></param>
            /// <param name="to"></param>
            /// <param name="fileName"></param>
            /// <param name="proxy"></param>
            /// <param name="proxyPort"></param>
            public JingleSession(XmppClientConnection xmppClient, string to, string fileName, string proxy, string proxyPort) {
                selfInitiated = true;
                localFilespec = fileName;
                this.conn = xmppClient;

                iq_to = new Jid(to); iq_from = Program.Jabber.conn.MyJID;
                content_name = Guid.NewGuid().ToString();
                jingle_initiator = iq_from;
                jingle_sid = Guid.NewGuid().ToString();
                transportSid = Guid.NewGuid().ToString();

                initiateIq = BuildSessionInitiate(fileName);
                this.initiateJingle = initiateIq.SelectSingleElement("jingle");
                this.contentIn = initiateJingle.SelectSingleElement("content");
                this.transportIn = contentIn.SelectSingleElement("transport");

                Element candidate = new Element("candidate");
                candidate.SetAttribute("priority", "999999"); candidate.SetAttribute("jid", proxy);
                candidate.SetAttribute("cid", "1000"); candidate.SetAttribute("type", "proxy");
                candidate.SetAttribute("host", proxy); candidate.SetAttribute("port", proxyPort);
                transportIn.AddChild(candidate);

                conn.Send(initiateIq);


            }

            /// <summary>
            /// initiate: first step for sending
            /// </summary>
            /// <param name="fileName"></param>
            /// <returns></returns>
            public agsXMPP.protocol.client.IQ BuildSessionInitiate(string fileName) {
                var ack = BuildJingleIQPacket("session-initiate");
                ack.SelectSingleElement("jingle").SetAttribute("action", "session-initiate");
                Element content = ack.SelectSingleElement("content", true), transport = content.SelectSingleElement("transport");

                Element desc = new Element("description", null, "urn:xmpp:jingle:apps:file-transfer:3"),
                     offer = new Element("offer"), file = new Element("file");
                content.AddChild(desc); desc.AddChild(offer); offer.AddChild(file);
                FileInfo info = new FileInfo(fileName);
                file.SetTag("name", info.Name);
                file.SetTag("size", info.Length);
                
                return ack;
            }

            /// <summary>
            /// accept: first step for receiving
            /// </summary>
            /// <returns></returns>
            public agsXMPP.protocol.client.IQ BuildSessionAccept() {
                if (OnFileReceived != null) OnFileReceived(initiateIq.From, "", "starting");

                var ack = BuildJingleIQPacket("session-accept");
                Element content = ack.SelectSingleElement("content", true), transport = content.SelectSingleElement("transport");

                Element fileIn = contentIn.SelectSingleElement("file", true),
                     desc = new Element("description", null, "urn:xmpp:jingle:apps:file-transfer:3"),
                     offer = new Element("offer"), file = new Element("file");
                content.AddChild(desc); desc.AddChild(offer); offer.AddChild(file);
                foreach (Element el in fileIn.SelectElements<Element>())
                    file.SetTag(el.TagName, el.Value);

                return ack;
            }

            public agsXMPP.protocol.client.IQ BuildCandidateUsed(string cid, string statusTag) {
                var ack = BuildJingleIQPacket("transport-info");
                var transport = ack.SelectSingleElement("transport", true);

                var candUsed = new Element(statusTag);
                candUsed.SetAttribute("cid", cid);
                transport.AddChild(candUsed);

                return ack;
            }


            public agsXMPP.protocol.client.IQ BuildActivateBytestream(Jid proxy_jid) {
                var ack = new agsXMPP.protocol.client.IQ(agsXMPP.protocol.client.IqType.set, conn.MyJID, proxy_jid);
                ack.GenerateId();
                var query = new Element("query", null, "http://jabber.org/protocol/bytestreams");
                ack.AddChild(query);
                query.Attributes["sid"] = initiateJingle.Attributes["sid"];

                query.SetTag("activate", iq_to);

                return ack;
            }


            public agsXMPP.protocol.client.IQ BuildJingleIQPacket(string action) {
                var ack = new agsXMPP.protocol.client.IQ(agsXMPP.protocol.client.IqType.set, iq_from, iq_to);
                ack.GenerateId();
                var jingle = new Element("jingle", null, "urn:xmpp:jingle:1");
                ack.AddChild(jingle);
                jingle.Attributes["action"] = action;
                jingle.Attributes["initiator"] = jingle_initiator;
                jingle.Attributes["sid"] = jingle_sid;

                var content = new Element("content");
                content.Attributes["creator"] = "initiator";
                content.Attributes["name"] = content_name;
                jingle.AddChild(content);

                var transport = new Element("transport", null, "urn:xmpp:jingle:transports:s5b:1");
                transport.Attributes["sid"] = transportSid;
                content.AddChild(transport);

                return ack;
            }

            public agsXMPP.protocol.client.IQ BuildSessionTerminate(string reason) {
                var ack = new agsXMPP.protocol.client.IQ(agsXMPP.protocol.client.IqType.set, iq_from, iq_to);
                ack.GenerateId();
                var jingle = new Element("jingle", null, "urn:xmpp:jingle:1");
                ack.AddChild(jingle);
                jingle.Attributes["action"] = "session-terminate";
                jingle.Attributes["initiator"] = initiateJingle.Attributes["initiator"];
                jingle.Attributes["sid"] = initiateJingle.Attributes["sid"];

                var content = new Element("reason");
                content.AddTag(reason);
                jingle.AddChild(content);

                return ack;
            }


            public Element GetTransportCandidate(string cid) {
                foreach (Node node in transportIn.ChildNodes) {
                    if (node is Element) {
                        var el = (Element)node;
                        if (el.GetAttribute("cid") == cid) {
                            return el;
                        }
                    }
                }
                return null;
            }

            public bool DoTransmission(Element transportCandidate) {
                if (transportCandidate == null) return false;

                switch (transportCandidate.GetAttribute("type")) {
                    case "proxy":
                        Thread t = new Thread(SocksThread);
                        t.Start(transportCandidate);

                        return true;
                    default:
                        return false;
                }

            }


            private void SocksThread(object infoEl) {
                try {
                    if (OnFileReceived != null) OnFileReceived(iq_to, localFilespec, "loading");

                    Element info = (Element)infoEl;
                    var client = new System.Net.Sockets.TcpClient(info.GetAttribute("host"), info.GetAttributeInt("port"));

                    var stream = client.GetStream();

                    //TODO swap to/from for socks initiated by remote end (neccessary when sending files to other client)
                    var socksid = Socks5.GetSHA1Hash(initiateJingle.Attributes["sid"] + initiateIq.From.ToString()  + initiateIq.To.ToString());
                    Console.WriteLine("Socks shaid=" + socksid + ";");
                    Socks5.WriteSocksHeader(stream, socksid);
                    stream.Flush();
                    Thread.Sleep(100);

                    if (selfInitiated) {
                        var proxyActivate = this.BuildActivateBytestream(info.GetAttributeJid("jid"));
                        conn.Send(proxyActivate);

                        var cActivated = this.BuildCandidateUsed(info.GetAttribute("cid"), "activated");
                        conn.Send(cActivated);
                    }

                    Socks5.ReadSocksHeaderAnswer(stream);

                    int fileSize = this.contentIn.SelectSingleElement("file", true).GetTagInt("size");
                    if (selfInitiated) {
                        using (var fileStream = File.OpenRead(localFilespec)) {
                            CopyStream(fileStream, stream, fileSize);
                        }
                    } else {
                        using (var fileStream = File.Create(localFilespec)) {
                            CopyStream(stream, fileStream, fileSize);
                        }
                    }
                    
                    stream.Close();
                    client.Client.Close();

                    var sesTerm = BuildSessionTerminate("success");
                    conn.Send(sesTerm);

                    if (OnFileReceived != null) OnFileReceived(iq_to, localFilespec, "done");

                } catch (Exception ex) {
                    if (OnFileReceived != null) OnFileReceived(iq_to, ex.ToString(), "failed");

                }
            }


            /// <summary>
            /// Copies the contents of input to output. Doesn't close either stream.
            /// </summary>
            public static void CopyStream(Stream input, Stream output, int maxBytes) {
                byte[] buffer = new byte[8 * 1024];
                int len;
                while ( maxBytes>0 &&  (len = input.Read(buffer, 0,Math.Min(maxBytes, buffer.Length))) > 0 ) {
                    output.Write(buffer, 0, len);
                    maxBytes -= len;
                }
            }
        }

    }
}
