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
                dmfrm = new DirectMessageForm();
                dmSessions[from.Bare] = dmfrm;
                dmfrm.Text = from; dmfrm.otherEnd = from;
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
            // XEP-0280, Message Carbons
            var carbonsSent = msg.SelectSingleElement("sent", JabberService.URN_CARBONS);
            var carbonsReceived = msg.SelectSingleElement("received", JabberService.URN_CARBONS);
            if (carbonsSent != null)
            {
                msg = (agsXMPP.protocol.client.Message)carbonsSent.SelectSingleElement("message", true);
            }
            else if (carbonsReceived != null)
            {
                msg = (agsXMPP.protocol.client.Message)carbonsReceived.SelectSingleElement("message", true);
            }

            DirectMessageForm dmfrm = GetWindow(msg.From);
            dmfrm.onMessage(msg); dmfrm.Show();
            if (msg.HasTag("body")) dmfrm.Activate();
        }

    }
}
