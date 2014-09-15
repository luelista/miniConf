using agsXMPP;
using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace miniConf {
    class JabberService {

        public const string URN_CARBONS = "urn:xmpp:carbons:2";
        public const string URN_MESSAGE_CORRECT = "urn:xmpp:message-correct:0";

        public XmppClientConnection conn;
        public Jingle jingle;
        public JabberAvatars avatar;

        public HashSet<string> serverFeatures = new HashSet<string>();

        public Dictionary<string, JabberContact> contacts = new Dictionary<string,JabberContact>();

        public event EventHandler<JabberEventArgs> OnContactPresence;
        public event EventHandler OnServerFeaturesUpdated;

        public class JabberEventArgs : EventArgs {
            public Jid jabberId;
            public JabberEventArgs(Jid jid) { jabberId = jid;  }
        }

        public JabberService() {
            this.avatar = new JabberAvatars();
        }

        public void CheckServerFeatures() {
            var iq = new agsXMPP.protocol.client.IQ(agsXMPP.protocol.client.IqType.get, conn.MyJID, new Jid(conn.MyJID.Server));
            iq.AddChild(new agsXMPP.protocol.iq.disco.DiscoInfo()); iq.GenerateId();
            conn.IqGrabber.SendIq(iq, delegate(object a, agsXMPP.protocol.client.IQ b, object c) {
                serverFeatures.Clear();
                foreach (Element child in b.SelectSingleElement("query").SelectElements("feature")) {
                    serverFeatures.Add(child.GetAttribute("var"));
                }
                SendCarbonsEnableIq();
                if (OnServerFeaturesUpdated != null) OnServerFeaturesUpdated(this, EventArgs.Empty);
            });
            var iq2 = new agsXMPP.protocol.client.IQ(agsXMPP.protocol.client.IqType.get, conn.MyJID, new Jid(conn.MyJID.Server));
            iq2.AddChild(new agsXMPP.protocol.iq.disco.DiscoItems()); iq2.GenerateId();
            conn.IqGrabber.SendIq(iq2, delegate(object a, agsXMPP.protocol.client.IQ b, object c) {
                var queryResult = b.SelectSingleElement("query");
                Console.WriteLine("server items: " + queryResult);

            });
        }

        /**
         * XEP-0280, Message Carbons
         **/
        private void SendCarbonsEnableIq() {
            if (serverFeatures.Contains(JabberService.URN_CARBONS)) {
                var iq = new agsXMPP.protocol.client.IQ(agsXMPP.protocol.client.IqType.set);
                iq.From = conn.MyJID; iq.GenerateId();
                iq.AddChild(new agsXMPP.Xml.Dom.Element("enable", "", JabberService.URN_CARBONS));
                conn.Send(iq);
            }
        }

        public void listenToRoster() {
            conn.OnPresence += conn_OnPresence;
        }

        void conn_OnPresence(object sender, agsXMPP.protocol.client.Presence pres) {
            if (pres.HasTag(typeof(agsXMPP.protocol.x.muc.User), true) ||
                (pres.Type == agsXMPP.protocol.client.PresenceType.error && pres.HasTag(typeof(agsXMPP.protocol.x.muc.Muc), true))) {
                return;
            }
            if (pres.Type == agsXMPP.protocol.client.PresenceType.available || pres.Type == agsXMPP.protocol.client.PresenceType.unavailable) {
                if (!contacts.ContainsKey(pres.From.Bare)) {
                    contacts.Add(pres.From.Bare, new JabberContact(pres.From));
                }
                JabberContact contact = contacts[pres.From.Bare];
                contact.resources.Add(pres.From.Resource);
                if (pres.Type == agsXMPP.protocol.client.PresenceType.unavailable) {
                    contact.available = false;
                } else {
                    contact.available = true;
                }
                if (OnContactPresence != null) OnContactPresence(this, new JabberEventArgs(pres.From.Bare));
            }
        }


    }
}
