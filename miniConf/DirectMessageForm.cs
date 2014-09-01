using agsXMPP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public partial class DirectMessageForm : Form {
        public Jid otherEnd;

        private agsXMPP.protocol.client.Message beforeLoadedMessage = null;
        private bool loaded = false;

        public DirectMessageForm() {
            InitializeComponent();
        }

        private void DirectMessageForm_Load(object sender, EventArgs e) {
            messageView1.loadStylesheet(Program.appDir, Program.dataDir);
            
        }

        public void onMessage(agsXMPP.protocol.client.Message msg) {
            if (loaded == false) { beforeLoadedMessage = msg; return; }

            messageView1.addMessageToView(msg.From, msg.GetTag("body"), DateTime.Now);
        }

        private void sendMessage(string text) {
            var msg = new agsXMPP.protocol.client.Message(this.otherEnd.Bare, Program.conn.MyJID, agsXMPP.protocol.client.MessageType.chat, text);
            msg.Id = Guid.NewGuid().ToString();

            Program.conn.Send(msg);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && !e.Shift && !e.Alt && !e.Control) {
                sendMessage(textBox1.Text);
                messageView1.addMessageToView("self", textBox1.Text, DateTime.Now);
                textBox1.Text = "";
                e.SuppressKeyPress = true; e.Handled = true;
            }
        }

        private void messageView1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            loaded = true;
            if (beforeLoadedMessage != null) onMessage(beforeLoadedMessage);
            messageView1.Document.GetElementById("tb").InnerHtml = "Private conversation started at " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }


    }
}
