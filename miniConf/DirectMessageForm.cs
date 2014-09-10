using agsXMPP;
using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public partial class DirectMessageForm : Form {
        public Jid otherEnd;

        private agsXMPP.protocol.client.Message beforeLoadedMessage = null;
        private bool loaded = false;

        private agsXMPP.protocol.extensions.chatstates.Chatstate lastChatstate;

        public DirectMessageForm() {
            InitializeComponent();
            messageView1.Navigate("about:blank");
        }

        private void DirectMessageForm_Load(object sender, EventArgs e) {
            messageView1.loadStylesheet();
            
        }

        public void onNotice(string text) {
            try {
                messageView1.addNoticeToView(text);

            } catch (NullReferenceException nu) { }
        }

        public void onMessage(agsXMPP.protocol.client.Message msg) {
            if (loaded == false) { beforeLoadedMessage = msg; return; }

            // XEP-0280, Message Carbons
            var carbonsSent = msg.SelectSingleElement("sent", Jabber.URN_CARBONS);
            var carbonsReceived = msg.SelectSingleElement("received", Jabber.URN_CARBONS);
            if (carbonsSent != null) {
                msg = (agsXMPP.protocol.client.Message)carbonsSent.SelectSingleElement("message", true);
            } else if (carbonsReceived != null) {
                msg = (agsXMPP.protocol.client.Message)carbonsReceived.SelectSingleElement("message", true);
            }
            if (msg.HasTag("body")) {
                messageView1.addMessageToView(msg.From, msg.GetTag("body"), DateTime.Now);
            }
            if (msg.Chatstate != agsXMPP.protocol.extensions.chatstates.Chatstate.None) {
                labChatstate.Text = msg.Chatstate.ToString();
            }
        }

        private void sendMessage(string text) {
            var msg = new agsXMPP.protocol.client.Message(this.otherEnd.Bare, Program.conn.MyJID, agsXMPP.protocol.client.MessageType.chat, text);
            msg.Id = Guid.NewGuid().ToString();
            msg.Chatstate = agsXMPP.protocol.extensions.chatstates.Chatstate.active;
            Program.conn.Send(msg);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && !e.Shift && !e.Alt && !e.Control) {
                sendMessage(textBox1.Text);
                messageView1.addMessageToView("self", textBox1.Text, DateTime.Now);
                textBox1.Text = "";
                e.SuppressKeyPress = true; e.Handled = true;
            } else {
                
            }
        }

        private void sendChatstate(agsXMPP.protocol.extensions.chatstates.Chatstate state) {
            lastChatstate = state;
            var msg = new agsXMPP.protocol.client.Message(new Jid(this.otherEnd.Bare), Program.conn.MyJID);
            msg.Type = agsXMPP.protocol.client.MessageType.chat;
            msg.Chatstate = state;
            Program.conn.Send(msg);
        }

        private void messageView1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            loaded = true;
            if (beforeLoadedMessage != null) onMessage(beforeLoadedMessage);
            messageView1.Document.GetElementById("tb").InnerHtml = "Private conversation started at " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            var newState = agsXMPP.protocol.extensions.chatstates.Chatstate.active;
            tmrChatstatePaused.Stop();
            if (textBox1.Text != "") {
                newState = agsXMPP.protocol.extensions.chatstates.Chatstate.composing;
                 tmrChatstatePaused.Start();
            }
            if (lastChatstate != newState) {
                sendChatstate(newState);
            }
        }

        private void messageView1_OnSpecialUrl(string url) {
            if (url.StartsWith("special:openjpg:") && url.EndsWith(".jpg")) {
                Process.Start(url.Substring(16));
            }
            switch (url) {
                case "special:open_recv_files_dir":
                    Process.Start("explorer.exe", "/e,\"" + Program.dataDir + "Received Files\"");
                    break;
            }
        }

        private void tmrChatstatePaused_Tick(object sender, EventArgs e) {
            tmrChatstatePaused.Stop();
            sendChatstate(agsXMPP.protocol.extensions.chatstates.Chatstate.paused);
        }


    }
}
