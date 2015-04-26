using agsXMPP;
using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public partial class DirectMessageForm : Form {
        public Jid otherEnd;
        public Roomdata room;

        private agsXMPP.protocol.client.Message beforeLoadedMessage = null;
        private bool loaded = false;

        private agsXMPP.protocol.extensions.chatstates.Chatstate lastChatstate;

        //OTR.Interface.OTRSessionManager otr_ses;

        public DirectMessageForm(Jid jid) : this() {
            this.otherEnd = jid;
            this.room = new Roomdata(jid);
            this.Text = jid;
        }

        public DirectMessageForm() {
            InitializeComponent();
            messageView1.Navigate("about:blank");
            messageView1.selfNickname = Program.Jabber.conn.MyJID.Bare;

            /*otr_ses = new OTR.Interface.OTRSessionManager(Program.Jabber.conn.MyJID.ToString());
            otr_ses.OnOTREvent += otr_ses_OnOTREvent;
            */
        }
        /*
        void otr_ses_OnOTREvent(object source, OTR.Interface.OTREventArgs e) {
            switch (e.GetOTREvent()) {
                case OTR.Interface.OTR_EVENT.MESSAGE:
                    messageView1.addMessageToView("otr_message", e.GetMessage(), DateTime.Now, null, null, "");
                    break;
                case OTR.Interface.OTR_EVENT.SEND:
                    var msg = new agsXMPP.protocol.client.Message(this.otherEnd.Bare, Program.Jabber.conn.MyJID, 
                        agsXMPP.protocol.client.MessageType.chat, e.GetMessage());
                    msg.Id = Guid.NewGuid().ToString();
                    msg.Chatstate = agsXMPP.protocol.extensions.chatstates.Chatstate.active;
                    
                    Program.Jabber.conn.Send(msg);
                    break;
                case OTR.Interface.OTR_EVENT.ERROR:
                    messageView1.addNoticeToView("Error: " + e.GetErrorMessage());
                    break;
            }
        }*/

        private void DirectMessageForm_Load(object sender, EventArgs e) {
            messageView1.loadStylesheet();
            Program.Jabber.OnContactPresence += Jabber_OnContactPresence;
            messageView1.imagePreview = Program.glob.para("Form1__chkEnableImagePreview", "TRUE") == "TRUE";
        }

        void Jabber_OnContactPresence(object sender, miniConf.JabberService.JabberEventArgs e) {
            if (e.jabberId == otherEnd.Bare) {
                updateResources();
            }
        }

        void updateResources() {
            cmbResources.Items.Clear();
            JabberContact contact;
            if (Program.Jabber.contacts.TryGetValue(otherEnd.Bare, out contact) == false) return;
            foreach (string res in contact.resources)
                cmbResources.Items.Add(otherEnd.Bare + "/" + res);
        }

        private List<string> noticeStack = new List<string>();
        public void onNotice(string text) {
            try {
                if(!loaded) { noticeStack.Add(text); return;}

                messageView1.addNoticeToView(text);

            } catch (NullReferenceException nu) { }
        }



        public void onMessage(agsXMPP.protocol.client.Message msg) {
            if (loaded == false) return;

            if (msg.HasTag("body")) {
                string body = msg.Body;
                //if (body.StartsWith("?OTR"))
                //    otr_ses.ProcessOTRMessage(msg.From.ToString(), body);
                //else
                    messageView1.addMessageToView(msg.From, body, DateTime.Now, null,
                    Program.Jabber.avatar.GetAvatarIfAvailabe(msg.From), msg.Id);
            }
            if (msg.Chatstate != agsXMPP.protocol.extensions.chatstates.Chatstate.None) {
                labChatstate.Text = msg.Chatstate.ToString();
            }
        }

        private string sendMessage(string text) {
            //if (checkBox1.Checked) {
            //    otr_ses.EncryptMessage(this.otherEnd.ToString(), text);
            //} else {
                var msg = new agsXMPP.protocol.client.Message(this.otherEnd.Bare, Program.Jabber.conn.MyJID, agsXMPP.protocol.client.MessageType.chat, text);
                msg.Id = Guid.NewGuid().ToString();
                msg.Chatstate = agsXMPP.protocol.extensions.chatstates.Chatstate.active;
                Program.Jabber.conn.Send(msg);
            //}

            Program.db.InsertMessage(room.RoomName, msg.Id, msg.From, msg.Body, ChatDatabase.GetNowString());
            messageView1.addMessageToView(msg.From, msg.Body, DateTime.Now, null, msg.From, msg.Id);
            return msg.Id;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && !e.Shift && !e.Alt && !e.Control) {
                var id = sendMessage(textBox1.Text);
                textBox1.Text = "";
                e.SuppressKeyPress = true; e.Handled = true;
            } else {
                
            }
        }

        private void sendChatstate(agsXMPP.protocol.extensions.chatstates.Chatstate state) {
            lastChatstate = state;
            var msg = new agsXMPP.protocol.client.Message(new Jid(this.otherEnd.Bare), Program.Jabber.conn.MyJID);
            msg.Type = agsXMPP.protocol.client.MessageType.chat;
            msg.Chatstate = state;
            Program.Jabber.conn.Send(msg);
        }

        private void messageView1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            loaded = true;

            messageView1.Document.GetElementById("tb").InnerHtml = "Private conversation started at " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();

            var msgs = room.GetLogs(0, 10);
            foreach (ChatMessage msg in msgs) {
                msg.SenderJid = msg.Sender;
                messageView1.addMessageToView(msg, HtmlElementInsertionOrientation.AfterBegin);
            }
            foreach (string note in noticeStack) onNotice(note);

            messageView1.scrollDown();

            updateResources();
            cmbResources.Text = otherEnd.ToString();
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

        private bool isImageDrop(IDataObject data) {
            if (data.GetDataPresent("FileDrop")) {
                string[] files = (string[])data.GetData("FileDrop");
                if (files.Length == 1 && (files[0].ToLower().EndsWith(".jpg")
                    || files[0].ToLower().EndsWith(".jpeg")
                    || files[0].ToLower().EndsWith(".png")
                    || files[0].ToLower().EndsWith(".webp"))) {
                    return true;
                }
            }
            return false;
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e) {
            if (isImageDrop(e.Data)) {

                        e.Effect = DragDropEffects.Copy;

            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e) {
            if (!isImageDrop(e.Data)) return;

            string fileName = ((string[])e.Data.GetData("FileDrop"))[0];
            Program.Jabber.jingle.SendFile(cmbResources.Text, fileName);
            messageView1.addNoticeToView("<img src=\"" + fileName + "\" style='width:240px'><br>Sending image ...");
        }


    }
}
