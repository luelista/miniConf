using agsXMPP;
using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace miniConf {
    class Jingle {

        public delegate void OnFileReceivedEvent(Jid fromJid, string filename, string status);
        public event OnFileReceivedEvent OnFileReceived;

        Dictionary<string, JingleSession> ongoingTransports = new Dictionary<string, JingleSession>();

        XmppClientConnection conn;

        public Jingle(agsXMPP.XmppClientConnection client) {
            this.conn = client;
            client.OnIq += OnJingleIq;
        }


        public void OnJingleIq(object sender, agsXMPP.protocol.client.IQ iq) {
            if (!iq.HasTag("jingle")) return;
            var jingle = iq.SelectSingleElement("jingle");

            switch (jingle.GetAttribute("action")) {
                case "session-initiate":
                    SendIqResult(iq);

                    var ses = new JingleSession(iq, conn);
                    ongoingTransports[ses.transportSid] = ses;
                    ses.OnFileReceived += ses_OnFileReceived;
                    var ack = ses.BuildSessionAccept();
                    conn.Send(ack);

                    var cFirst = ses.transportIn.FirstChild;
                    var cUsed = ses.BuildCandidateUsed(cFirst.GetAttribute("cid"), "candidate-used");
                    conn.Send(cUsed);

                    ses.DoReceive(cFirst);
                    
                    break;

                case "transport-info":

                    var contentIn = jingle.SelectSingleElement("content");
                    var transportIn = contentIn.SelectSingleElement("transport");
                    var sid = transportIn.GetAttribute("sid");
                    if (!ongoingTransports.ContainsKey(sid)) {
                        SendIqerror(iq); return;
                    }

                    var session = ongoingTransports[sid];
                    if (transportIn.HasTag("candidate-used")) {
                        var cid = transportIn.SelectSingleElement("candidate-used").GetAttribute("cid");
                        var info = session.GetTransportCandidate(cid);
                        var ok = session.DoReceive(info);
                        if (ok) SendIqResult(iq); else SendIqerror(iq);
                    } else if (transportIn.HasTag("candidate-error")) {
                        SendIqResult(iq);
                    }
                    
                    

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

        class JingleSession {
            public event OnFileReceivedEvent OnFileReceived;

            XmppClientConnection conn;

            agsXMPP.protocol.client.IQ initiateIq;
            Element initiateJingle;
            Element contentIn;
            public Element transportIn;
            public string transportSid;

            public JingleSession(agsXMPP.protocol.client.IQ initIq, XmppClientConnection xmppClient) {
                this.conn = xmppClient;
                this.initiateIq = initIq;
                this.initiateJingle = initIq.SelectSingleElement("jingle");
                this.contentIn = initiateJingle.SelectSingleElement("content");
                this.transportIn = contentIn.SelectSingleElement("transport");
                this.transportSid = (string)transportIn.Attributes["sid"];
            }

            public agsXMPP.protocol.client.IQ BuildSessionAccept() {
                if (OnFileReceived != null) OnFileReceived(initiateIq.From, "", "starting");

                var ack = BuildJingleTransportInfo();
                ack.SelectSingleElement("jingle").SetAttribute("action", "session-accept");
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
                var ack = BuildJingleTransportInfo();
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

                query.SetTag("activate", initiateIq.From.ToString());

                return ack;
            }


            public agsXMPP.protocol.client.IQ BuildJingleTransportInfo() {
                var ack = new agsXMPP.protocol.client.IQ(agsXMPP.protocol.client.IqType.set, initiateIq.To, initiateIq.From);
                ack.GenerateId();
                var jingle = new Element("jingle", null, "urn:xmpp:jingle:1");
                ack.AddChild(jingle);
                jingle.Attributes["action"] = "transport-info";
                jingle.Attributes["initiator"] = initiateJingle.Attributes["initiator"];
                jingle.Attributes["sid"] = initiateJingle.Attributes["sid"];

                var content = new Element("content");
                content.Attributes["creator"] = "initiator";
                content.Attributes["name"] = contentIn.Attributes["name"];
                jingle.AddChild(content);

                var transport = new Element("transport", null, "urn:xmpp:jingle:transports:s5b:1");
                transport.Attributes["sid"] = transportIn.Attributes["sid"];
                content.AddChild(transport);

                return ack;
            }

            public agsXMPP.protocol.client.IQ BuildSessionTerminate() {
                var ack = new agsXMPP.protocol.client.IQ(agsXMPP.protocol.client.IqType.set, initiateIq.To, initiateIq.From);
                ack.GenerateId();
                var jingle = new Element("jingle", null, "urn:xmpp:jingle:1");
                ack.AddChild(jingle);
                jingle.Attributes["action"] = "session-terminate";
                jingle.Attributes["initiator"] = initiateJingle.Attributes["initiator"];
                jingle.Attributes["sid"] = initiateJingle.Attributes["sid"];

                var content = new Element("reason");
                content.AddTag("success");
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

            public bool DoReceive(Element transportCandidate) {
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
                var filename = contentIn.SelectSingleElement("file", true).GetTag("name");
                var filespec = Program.dataDir + "received files\\" + filename;

                if (OnFileReceived != null) OnFileReceived(initiateIq.From, filespec, "loading");

                Element info = (Element)infoEl;
                var client = new System.Net.Sockets.TcpClient(info.GetAttribute("host"), info.GetAttributeInt("port"));

                var stream = client.GetStream();

                //TODO swap to/from for socks initiated by remote end (neccessary when sending files to other client)
                var socksid = Socks5.GetSHA1Hash(initiateJingle.Attributes["sid"] + initiateIq.From.ToString() + initiateIq.To.ToString());
                Console.WriteLine("Socks shaid=" + socksid + ";");
                Socks5.WriteSocksHeader(stream, socksid);
                stream.Flush();
                Thread.Sleep(100);
                /*
                var proxyActivate = this.BuildActivateBytestream(info.GetAttributeJid("jid"));
                conn.Send(proxyActivate);

                var cActivated = this.BuildCandidateUsed(info.GetAttribute("cid"), "activated");
                conn.Send(cActivated);
                */
                Socks5.ReadSocksHeaderAnswer(stream);

                int fileSize = this.contentIn.SelectSingleElement("file", true).GetTagInt("size");

                using (var fileStream = File.Create(filespec)) {

                    CopyStream(stream, fileStream, fileSize);

                }

                stream.Close();
                client.Client.Close();

                var sesTerm = BuildSessionTerminate();
                conn.Send(sesTerm);

                if (OnFileReceived != null) OnFileReceived(initiateIq.From, filespec, "done");

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
