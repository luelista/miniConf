using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using agsXMPP;

namespace miniConf
{
    class DirectMessageManager
    {

        Dictionary<string, DirectMessageForm> dmSessions = new Dictionary<string, DirectMessageForm>();

        public DirectMessageForm GetWindow(Jid from)
        {
            DirectMessageForm dmfrm;
            if (dmSessions.ContainsKey(from.Bare))
            {
                dmfrm = dmSessions[from.Bare];
            }
            else
            {
                dmfrm = new DirectMessageForm(from);
                dmSessions[from.Bare] = dmfrm;
                dmfrm.Show(); dmfrm.Activate();
                dmfrm.FormClosed += OnMessageFormClosed;
            }
            return dmfrm;
        }

        private void OnMessageFormClosed(object sender, FormClosedEventArgs e)
        {
            dmSessions.Remove(((DirectMessageForm)sender).otherEnd.Bare);
        }

        public void OnPrivateMessage(agsXMPP.protocol.client.Message msg)
        {
            Jid relevantJid = msg.From;
            // XEP-0280, Message Carbons
            var carbonsSent = msg.SelectSingleElement("sent", JabberService.URN_CARBONS);
            var carbonsReceived = msg.SelectSingleElement("received", JabberService.URN_CARBONS);
            if (carbonsSent != null)
            {
                msg = (agsXMPP.protocol.client.Message)carbonsSent.SelectSingleElement("message", true);
                relevantJid = msg.To;
            }
            else if (carbonsReceived != null)
            {
                msg = (agsXMPP.protocol.client.Message)carbonsReceived.SelectSingleElement("message", true);
                relevantJid = msg.From;
            }

            string dt = JabberService.GetMessageDt(msg);
            if (msg.HasTag("body"))
                Program.db.InsertMessage(relevantJid.Bare, msg.Id, msg.From, msg.Body, dt);

            DirectMessageForm dmfrm = GetWindow(relevantJid);
            dmfrm.onMessage(msg); dmfrm.Show();
            if (msg.HasTag("body")) {
                dmfrm.Activate();
            } else {
                if (!String.IsNullOrEmpty(msg.Subject)) dmfrm.onNotice("Subject set: " + msg.Subject.Replace("<", "&lt;"));
                else if (msg.Error != null) dmfrm.onNotice("An error occured: " + msg.Error.ToString().Replace("<", "&lt;"));
                //else dmfrm.onNotice("Unknown message stanza: " + msg.ToString().Replace("<", "&lt;"));
            }
        }

    }
}
