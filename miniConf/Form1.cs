using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using agsXMPP;
using System.Data.SQLite;
using System.Threading;

namespace miniConf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XmppClientConnection conn;
        agsXMPP.protocol.x.muc.MucManager muc;
        cls_globPara glob;
        Chatlogs logs;
        Dictionary<string, Roomdata> rooms = new Dictionary<string, Roomdata>();
        Roomdata currentRoom = null;

        private delegate void XmppMessageDelegate(agsXMPP.protocol.client.Message msg);
        private delegate void XmppPresenceDelegate(agsXMPP.protocol.client.Presence msg);

        private void jabberConnect()
        {
            conn = new XmppClientConnection(txtPrefServer.Text, 5222);
            conn.OnAuthError += conn_OnAuthError;
            conn.OnXmppConnectionStateChanged += conn_OnXmppConnectionStateChanged;
            conn.OnSocketError += conn_OnSocketError;
            conn.OnError += conn_OnError;
            conn.OnLogin += conn_OnLogin;
            conn.Open(txtPrefUsername.Text, txtPrefPassword.Text, "miniConf-" + Environment.MachineName, 0);

            muc = new agsXMPP.protocol.x.muc.MucManager(conn);

            conn.OnPresence += conn_OnPresence;
            conn.OnMessage += conn_OnMessage;
        }

        void conn_OnSocketError(object sender, Exception ex)
        {
            MessageBox.Show("SOCKET ERR: " + ex.Message);
        }

        void conn_OnXmppConnectionStateChanged(object sender, XmppConnectionState state)
        {
            Console.WriteLine("Conn State Changed: " + state.ToString());
        }

        void conn_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e)
        {
            MessageBox.Show("AUTH ERROR: " + e.ToString());
        }

        void conn_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {
            Console.WriteLine(msg);
            if (msg.HasAttribute("type") && msg.GetAttribute("type") == "groupchat")
            {
                this.Invoke(new XmppMessageDelegate(OnMucMessage), msg);
            }
        }

        void conn_OnPresence(object sender, agsXMPP.protocol.client.Presence pres)
        {
            Console.WriteLine(pres);

            if (pres.HasTag(typeof(agsXMPP.protocol.x.muc.User), true))
            {
                Console.WriteLine("Is MUC Presence: " + pres.From + " ," + pres.To);
                this.Invoke(new XmppPresenceDelegate(OnMucPresence), pres);
            }
        }

        void conn_OnLogin(object sender)
        {
            var rooms = txtChatrooms.Text.Split('\n');
            foreach (var room in rooms)
            {
                joinRoom(room.Trim());
            }
        }

        private void OnMucPresence(agsXMPP.protocol.client.Presence pres)
        {
            var xChild = pres.SelectSingleElement("x", "http://jabber.org/protocol/muc#user");
            foreach (agsXMPP.Xml.Dom.Element el in xChild.SelectElements("status"))
            {
                if (el.GetAttribute("code") == "110")
                {
                    OnMucSelfPresence(pres, xChild);
                    break;
                }
            }

            logs.SetOnlineStatus(pres.From.Bare, pres.From.Resource, "online");
            if (currentRoom != null && pres.From.Bare == currentRoom.jid.Bare)
            {
                updateMemberList();
            }
        }
        private void OnMucSelfPresence(agsXMPP.protocol.client.Presence pres, agsXMPP.Xml.Dom.Element xChild)
        {
            var roomname = pres.From.Bare;
            if (!rooms.ContainsKey(roomname))
            {
                rooms.Add(roomname, new Roomdata(pres.From));
            }
            this.Invoke(new ThreadStart(updateRoomList));
        }

        private void OnMucMessage(agsXMPP.protocol.client.Message msg)
        {
            string dt;
            if (msg.HasTag("delay"))
            {
                dt = msg.SelectSingleElement("delay").GetAttribute("stamp");
            }
            else
            {
                dt = Chatlogs.GetNowString();
            }
            if (msg.HasTag("subject"))
            {
                string subject = msg.GetTag("subject");
                logs.SetSubject(msg.From.Bare, subject);
                if (currentRoom != null && msg.From.Bare == currentRoom.jid.Bare)
                {
                    addNoticeToView("The subject was set by " + msg.From.Resource + ": " + subject);
                    txtSubject.Text = subject;
                }
            }
            else if (msg.HasTag("body"))
            {
                logs.InsertMessage(msg.From.Bare, msg.GetAttribute("id"), msg.From.Resource, msg.GetTag("body"), dt);
                logs.SetLastmessageDatetime(msg.From.Bare, dt);
                if (currentRoom != null && msg.From.Bare == currentRoom.jid.Bare && !msg.HasTag("delay"))
                {
                    addMessageToView(msg.From.Resource, msg.GetTag("body"));
                }
            }
        }

        private void joinRoom(string roomName)
        {
            Jid roomJid = new Jid(roomName);

            logs.SetOnlineStatus(roomJid.Bare, "off");

            /// Setup Room
            agsXMPP.protocol.client.Presence MUCpresence = new agsXMPP.protocol.client.Presence();
            MUCpresence.From = conn.MyJID;
            MUCpresence.To = roomJid;
            var xMuc = new agsXMPP.protocol.x.muc.Muc();
            MUCpresence.AddChild(xMuc);

            agsXMPP.protocol.x.muc.History historyChild = new agsXMPP.protocol.x.muc.History(100);
            try
            {
                string since = logs.GetLastmessageDatetime(roomJid.Bare);
                if (!String.IsNullOrEmpty(since))
                {
                    historyChild.RemoveAttribute("maxstanzas");
                    historyChild.SetAttribute("since", since);
                    //addNoticeToView("Requesting since " + since);
                }
            }
            catch (Exception e)
            {
            }

            xMuc.AddChild(historyChild);
            conn.Send(MUCpresence);

        }

        private void sendMessage(string text)
        {
            var msg = new agsXMPP.protocol.client.Message(currentRoom.roomName(), conn.MyJID, agsXMPP.protocol.client.MessageType.groupchat, text);
            msg.Id = Guid.NewGuid().ToString();

            conn.Send(msg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Document.Write("<html><head><style> html,body {margin:0;padding: 0;} div{padding:5px; border-bottom: 1px solid #ccc; font:10pt 'Segoe UI',sans-serif; color: #333; } div strong { color: #373; } div strong.me{color:#555;} div.notice { color: #999; background-color: #eee; } </style></head><body></body></html>");

            glob = new cls_globPara();
            glob.readFormPos(this);
            glob.readTuttiFrutti(this);

            logs = new Chatlogs(glob.appPath() + "chatlogs.db");

            if (txtPrefUsername.Text != "")
            {
                jabberConnect();
            }

            
        }

        void conn_OnError(object sender, Exception ex)
        {
            MessageBox.Show("ERROR: " + ex.Message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            jabberConnect();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            glob.saveFormPos(this);
            glob.saveTuttiFrutti(this);
        }

        private void addMessageToView(string from, string text)
        {
            var div = webBrowser1.Document.CreateElement("div");
            text = text.Replace("<", "&lt;");
            div.InnerHtml = "<strong>" + from + ":</strong> " + text + "";
            webBrowser1.Document.Body.AppendChild(div);
            webBrowser1.Document.Body.ScrollTop = 99999;
        }
        private void addNoticeToView( string text)
        {
            var div = webBrowser1.Document.CreateElement("div");
            div.SetAttribute("className", "notice");
            div.InnerHtml = "*** " + text + "";
            webBrowser1.Document.Body.AppendChild(div);
            webBrowser1.Document.Body.ScrollTop = 99999;
        }

        private void updateRoomList()
        {
            lbChatrooms.Items.Clear();
            foreach (var r in rooms)
            {
                lbChatrooms.Items.Add(r.Key);
            }
            try {
                lbChatrooms.SelectedItem = glob.para("currentRoom"); 
                if (currentRoom == null)lbChatrooms_Click(null, null); }
            catch (Exception ex) { }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lbChatrooms_Click(object sender, EventArgs e)
        {
            try
            {
                currentRoom = rooms[(string)lbChatrooms.SelectedItem];
            }
            catch (Exception ex)
            {
                currentRoom = null;
            }
            
            updateMemberList();
            histAmount = 20;
            showLastMessages();
            if (currentRoom != null)
            {
                txtSubject.Text = logs.GetSubject(currentRoom.roomName());
                glob.setPara("currentRoom", currentRoom.roomName());
            }
        }

        private void updateMemberList()
        {
            lvOnlineStatus.Items.Clear();
            if (currentRoom == null) return;
            var onlines = logs.GetMembers(currentRoom.roomName());
            foreach (System.Data.Common.DbDataRecord k in onlines)
            {
                string nick = k.GetString(0);
                lvOnlineStatus.Items.Add(nick + "(" + k.GetString(2) + ")");
            }
        }
        private void showLastMessages()
        {
            if (currentRoom == null) return;
            webBrowser1.Document.Body.InnerHtml = "";
            var msgs = logs.GetLogs(currentRoom.roomName(), histAmount);
            foreach (System.Data.Common.DbDataRecord k in msgs)
            {
                addMessageToView(k.GetString(0), k.GetString(1));
            }
            addNoticeToView("Subject is: " + logs.GetSubject(currentRoom.roomName()));
        }

        int histAmount = 20;
        private void button3_Click(object sender, EventArgs e)
        {
            histAmount += 40;
            showLastMessages();
        }

        private void txtSendmessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Control && !e.Shift && !e.Alt)
            {
                sendMessage(txtSendmessage.Text.TrimEnd());
                txtSendmessage.Text = "";
            }
        }



    }
}
