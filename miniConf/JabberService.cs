using agsXMPP;
using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;

using System.Text;
using agsXMPP.protocol.client;

namespace miniConf {
    class JabberService {

        public const string URN_CARBONS = "urn:xmpp:carbons:2";
        public const string URN_MESSAGE_CORRECT = "urn:xmpp:message-correct:0";

        public XmppClientConnection conn;
        public Jingle jingle;
        public MucService muc;
        public JabberAvatars avatar;

        public List<string> serverFeatures = new List<string>();

        public Dictionary<string, JabberContact> contacts = new Dictionary<string, JabberContact>();

        public event EventHandler<JabberEventArgs> OnContactPresence;
        public event EventHandler OnServerFeaturesUpdated;

        public class JabberEventArgs : EventArgs {
            public Jid jabberId;
            public JabberEventArgs(Jid jid) { jabberId = jid; }
        }

        public JabberService() {
            this.avatar = new JabberAvatars();
            this.jingle = new Jingle();
            this.muc = new MucService();
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

        public static string GetMessageDt(Message message) {
            string dt;
            agsXMPP.Xml.Dom.Element el;
            if (message.HasTag("delay")) {
                dt = message.SelectSingleElement("delay").GetAttribute("stamp");
            } else if (null != (el = message.SelectSingleElement("x", "jabber:x:tstamp"))) {
                dt = el.GetAttribute("tstamp");
            } else {
                dt = ChatDatabase.GetNowString();
            }
            return dt;
        }

        /// <summary>
        /// XEP-0280, Message Carbons
        /// </summary>
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

        public void addContact(Jid contactJid) {
            // 2.3.1. Add Roster Item
            var iq = new agsXMPP.protocol.iq.roster.RosterIq(IqType.set);
            iq.Query.AddRosterItem(new agsXMPP.protocol.iq.roster.RosterItem(contactJid));
            iq.GenerateId();
            conn.Send(iq);

            // 3.1.1 Subscription Request
            var pres1 = new Presence();
            pres1.Type = PresenceType.subscribe;
            pres1.To = contactJid;
            pres1.GenerateId();
            conn.Send(pres1);

            // 3.4.1. Subscription Pre-Approval
            var pres2 = new Presence();
            pres2.Type = PresenceType.subscribed;
            pres2.To = contactJid;
            conn.Send(pres2);
        }
        public void removeContact(Jid contactJid) {
            // 2.5.1. Delete Roster Item
            var iq = new agsXMPP.protocol.iq.roster.RosterIq(IqType.set);
            var item = new agsXMPP.protocol.iq.roster.RosterItem(contactJid);
            item.Subscription = agsXMPP.protocol.iq.roster.SubscriptionType.remove;
            iq.Query.AddRosterItem(item);
            iq.GenerateId();
            conn.Send(iq);

            var pres1 = new Presence();
            pres1.Type = PresenceType.unsubscribe;
            pres1.To = contactJid;
            pres1.GenerateId();
            conn.Send(pres1);

            var pres2 = new Presence();
            pres2.Type = PresenceType.unsubscribed;
            pres2.To = contactJid;
            conn.Send(pres2);
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
                if (!contact.resources.Contains(pres.From.Resource))
                    contact.resources.Add(pres.From.Resource);
                if (pres.Type == agsXMPP.protocol.client.PresenceType.unavailable) {
                    contact.available = false;
                } else {
                    contact.available = true;
                }
                if (OnContactPresence != null) OnContactPresence(this, new JabberEventArgs(pres.From.Bare));
            } else if (pres.Type == PresenceType.subscribe || pres.Type == PresenceType.subscribed
                || pres.Type == PresenceType.unsubscribe || pres.Type == PresenceType.unsubscribed) {
                Program.MainWnd.Invoke(new Action<object>((x) => {
                    var f = new InvitationForm();
                    switch (pres.Type) {
                    case PresenceType.subscribe:
                        f.setContactRequest(pres.From);
                        break;
                    case PresenceType.subscribed:
                        f.setContactSubscriptionApproved(pres.From);
                        break;
                    case PresenceType.unsubscribe:
                        f.setContactUnsubscribe(pres.From);
                        break;
                    case PresenceType.unsubscribed:
                        f.setContactSubscriptionCancelled(pres.From);
                        break;
                    }
                    f.Show();
                }), this);
            }
        }



    }
}
