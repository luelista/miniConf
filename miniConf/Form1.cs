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
using System.Text.RegularExpressions;
using System.Media;
using System.IO;

namespace miniConf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string dataDir;

        #region Jabber Connection

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
            this.Invoke(new ThreadStart(updateWinTitle));
        }

        void conn_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e)
        {
            //MessageBox.Show("AUTH ERROR: " + e.ToString());
            string errMes = "Error while logging in to the server: " + e.ToString();
            if (e.HasTag("not-authorized"))
            {
                errMes = "The provided username and password were not accepted by the server. Did you mistype your password? Otherwise, you could create a new acocunt by clicking \"Create Account\".";

            }
            this.Invoke(new ParameterizedThreadStart(showConfigPanel), errMes );
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
            this.Invoke(new ThreadStart(hideConfigPanel));
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

            string online = "online";
            if (pres.Type == agsXMPP.protocol.client.PresenceType.unavailable) online = "off";

            logs.SetOnlineStatus(pres.From.Bare, pres.From.Resource, online, pres.MucUser.Item.Affiliation.ToString(), pres.MucUser.Item.Role.ToString());
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
                if (currentRoom != null && msg.From.Bare == currentRoom.jid.Bare)
                {
                    addMessageToView(msg.From.Resource, msg.GetTag("body"), DateTime.Parse(dt));
                }
                if (!msg.HasTag("delay"))
                {
                    if (enableSoundToolStripMenuItem.Checked)
                    {
                        SoundPlayer dingdong = new SoundPlayer("C:\\Windows\\Media\\chimes.wav");
                        dingdong.Play();
                    }
                    if (enableNotificationsToolStripMenuItem.Checked && !String.IsNullOrEmpty(msg.GetTag("body")))
                    {
                        notifyIcon1.ShowBalloonTip(30000, msg.From.Resource + " in " + msg.From.User + ":", msg.GetTag("body"), ToolTipIcon.Info);
                    }
                }
            }
        }

        private void joinRoom(string roomName, bool loadAllHistory = false)
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

            if (loadAllHistory)
                historyChild = new agsXMPP.protocol.x.muc.History(10000);

            xMuc.AddChild(historyChild);
            conn.Send(MUCpresence);

        }

        private void sendMessage(string text)
        {
            var msg = new agsXMPP.protocol.client.Message(currentRoom.roomName(), conn.MyJID, agsXMPP.protocol.client.MessageType.groupchat, text);
            msg.Id = Guid.NewGuid().ToString();

            conn.Send(msg);
        }

        void conn_OnError(object sender, Exception ex)
        {
            MessageBox.Show("ERROR: " + ex.Message);
        }


        #endregion







        #region GUI

        private void Form1_Load(object sender, EventArgs e)
        {
            WinSparkle.win_sparkle_set_appcast_url("http://downloads.luelista.net/miniconf/miniconf.xml");
            //WinSparkle.win_sparkle_set_app_details("Company","App", "Version"); // THIS CALL NOT IMPLEMENTED YET
            WinSparkle.win_sparkle_init();
            
            dataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\miniConf\\";
            System.IO.Directory.CreateDirectory(dataDir);

            if (!File.Exists(dataDir + "style.txt"))
            {
                File.Copy("style.txt", dataDir + "style.txt");
            }
            webBrowser1.Document.Write("<html><head><style id='st'></style></head>" +
                 "<body><p id='tb'>Eile mit Weile ...</p><div id='m'></div></body></html>");
            loadStylesheet();

            
            glob = new cls_globPara(dataDir + "miniConf.ini");
            glob.readFormPos(this);
            glob.readTuttiFrutti(this);

            enableNotificationsToolStripMenuItem.Checked = glob.para("enableNotifications") != "FALSE";
            enableSoundToolStripMenuItem.Checked = glob.para("enableSound") != "FALSE";

            logs = new Chatlogs(dataDir + "chatlogs.db");

            if (txtPrefUsername.Text != "")
            {
                jabberConnect();
            }
            else
            {
                pnlConfig.Visible = true;
            }
        }

        private void updateWinTitle()
        {

            this.Text = Application.ProductName + " " + Application.ProductVersion + ((conn!=null) ? (" (" + conn.XmppConnectionState.ToString() + ")") : "");
        }

        private void loadStylesheet()
        {
            string style = File.ReadAllText(dataDir + "style.txt");
            mshtml.IHTMLDocument3 doc = (mshtml.IHTMLDocument3)webBrowser1.Document.DomDocument;
            mshtml.IHTMLStyleElement styleEl = (mshtml.IHTMLStyleElement)doc.getElementById("st");
            styleEl.styleSheet.cssText = style;

            //.SetAttribute("cssText", style);
            //webBrowser1.Document.GetElementById("st").
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlConfig.Visible = !pnlConfig.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            jabberConnect();

            pnlConfig.Visible = false;
        }
        private void hideConfigPanel()
        {
            pnlConfig.Visible = false;
            pnlErrMes.Visible = false;
        }
        private void showConfigPanel(object errmes)
        {
            pnlConfig.Visible = true;
            if (!String.IsNullOrEmpty((string)errmes))
            {
                pnlErrMes.Show();
                labErrMes.Text = (string)errmes;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            glob.saveFormPos(this);
            glob.saveTuttiFrutti(this);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void addMessageToView(string from, string text, DateTime time, HtmlElementInsertionOrientation where = HtmlElementInsertionOrientation.BeforeEnd)
        {
            var div = webBrowser1.Document.CreateElement("p");
            text = text.Replace("<", "&lt;");
            text = text.Replace("\n", "\n<br>");
            var imageLink = Regex.Match(text, "https?://[\\w.-]+/[\\w_.,/+?&%$!=)(\\[\\]{}-]*\\.(png|jpg|gif)");
            text = Regex.Replace(text, "(?i)\\b((?:[a-z][\\w-]+:(?:/{1,3}|[a-z0-9%])|www\\d{0,3}[.]|[a-z0-9.\\-]+[.][a-z]{2,4}/)(?:[^\\s()<>]+|\\(([^\\s()<>]+|(\\([^\\s()<>]+\\)))*\\))+(?:\\(([^\\s()<>]+|(\\([^\\s()<>]+\\)))*\\)|[^\\s`!()\\[\\]{};:'\".,<>?«»“”‘’]))",
                         "<a href=\"$0\">$0</a>");
            var me = Regex.Match(text, "^/me\\s+");
            var timeEl = "<i title="+time.ToShortDateString()+" "+time.ToLongTimeString()+">"+time.ToLongTimeString()+"</i>";
            div.SetAttribute("className", "from_" + from);
            if (me.Success)
            {
                div.InnerHtml = timeEl + "<span> ∗∗∗ <strong>" + from + "</strong> " + text.Substring(me.Length) + "</span>";
            }
            else
            {
                div.SetAttribute("className", "msg from_" + from);
                if (chkEnableImagePreview.Checked && imageLink.Success)
                {
                    text += "<br><img src=\"" + imageLink.Value + "\" class=\"imprev\" style='max-width:150px;'>";
                }
                div.InnerHtml = timeEl + "<strong>" + from + ":</strong> <span>" + text + "</span>";

            }
            //webBrowser1.Document.Body.AppendChild(div);
            webBrowser1.Document.GetElementById("m").InsertAdjacentElement(where, div);
            if (where == HtmlElementInsertionOrientation.BeforeEnd)
                scrollDown();
        }
        private void addNoticeToView( string text)
        {
            var div = webBrowser1.Document.CreateElement("p");
            div.SetAttribute("className", "notice");
            div.InnerHtml = "∗ " + text + "";
            webBrowser1.Document.GetElementById("m").AppendChild(div);
            scrollDown();
        }
        private void scrollDown()
        {
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
            histAmount = 0;
            clearMessageView();
            showLastMessages(30);
            if (currentRoom != null)
            {
                txtSubject.Text = logs.GetSubject(currentRoom.roomName());
                glob.setPara("currentRoom", currentRoom.roomName());
            }
            addNoticeToView("Subject is: " + logs.GetSubject(currentRoom.roomName()));
            scrollDown();
        }

        private void updateMemberList()
        {
            lvOnlineStatus.Items.Clear();
            if (currentRoom == null) return;
            var onlines = logs.GetMembers(currentRoom.roomName());
            foreach (System.Data.Common.DbDataRecord k in onlines)
            {
                string nick = k.GetString(0);
                var item = lvOnlineStatus.Items.Add(nick, k.GetString(2));
                item.ToolTipText = k.GetString(2) + " - last seen: " +  DateTime.FromBinary( k.GetInt64(1)).ToString() + " - affiliation: " + k.GetString(3) + " - role: "+k.GetString(4);
            }
        }
        private void clearMessageView()
        {
            webBrowser1.Document.GetElementById("m").InnerHtml = "";
            webBrowser1.Document.GetElementById("tb").InnerHtml = "history: <a href='special:show_more_history'> 25 more</a> | <a href='special:show_more_more_history'> 100 more</a>";
            
        }
        int histAmount = 0;
        private void showLastMessages(int count)
        {
            if (currentRoom == null) return;
            var length = logs.GetLogLength(currentRoom.roomName());
            if (histAmount+count > length)
            {
                webBrowser1.Document.GetElementById("tb").InnerHtml = "End of local history | <a href='special:load_all'>Try loading server history</a>";
            }
            var msgs = logs.GetLogs(currentRoom.roomName(), histAmount, count);
            foreach (System.Data.Common.DbDataRecord k in msgs)
            {
                addMessageToView(k.GetString(0), k.GetString(1), DateTime.Parse(k.GetString(2)), HtmlElementInsertionOrientation.AfterBegin);
            }
            histAmount += count;
        }


        private void txtSendmessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Control && !e.Shift && !e.Alt)
            {
                
                if (String.IsNullOrEmpty(txtSendmessage.Text.Trim())) return;
                sendMessage(txtSendmessage.Text.TrimEnd());
                txtSendmessage.Text = "";
            }
        }
        private void txtSendmessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Control && !e.Shift && !e.Alt)
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.A && e.Control)
            {
                txtSendmessage.SelectAll();
            }
        }

        private void btnToggleSidebar_Click(object sender, EventArgs e)
        {
            
        }

        private void chkToggleSidebar_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = chkToggleSidebar.Checked;
            //chkToggleSidebar.Text = splitContainer1.Panel2Collapsed ? "<" : ">";
        }

        #endregion

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = true;
            string url = e.Url.ToString();
            switch (url)
            {
                case "special:show_more_history":
                    showLastMessages(30);
                    //webBrowser1.Document.Body.ScrollTop = 0;
                    break;
                case "special:show_more_more_history":
                    showLastMessages(100);
                    //webBrowser1.Document.Body.ScrollTop = 0;
                    break;
                case "special:load_all":
                    if (MessageBox.Show("Loading the server-side history can take several minutes depending on your internet connection. Do you want to start downloading?", "History", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK)
                    {
                        joinRoom(currentRoom.jid.ToString(), true);
                    }
                    break;
                default:
                    if (url.StartsWith("http://") || url.StartsWith("https://"))
                    {
                        System.Diagnostics.Process.Start(url);
                    }
                    else
                    {
                        if (MessageBox.Show("Link clicked: " + e.Url + "\n\nOpen with default application?", "Link", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(url);
                        }
                    }
                    //
                    break;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            WinSparkle.win_sparkle_cleanup();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit miniConf?", "miniConf", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.Q:
                    beendenToolStripMenuItem_Click(null, null);
                    return true;
                case Keys.Escape:
                    this.Close();
                    return true;
                case Keys.F1:
                    try { if (lbChatrooms.SelectedIndex > 0) lbChatrooms.SelectedIndex -= 1; lbChatrooms_Click(null, null); }
                    catch (Exception ex) { }
                    return true;
                case Keys.F2:
                    try { lbChatrooms.SelectedIndex += 1; lbChatrooms_Click(null, null); }
                    catch (Exception ex) { }
                    return true;
                case Keys.Control | Keys.B:
                case Keys.F4:
                    chkToggleSidebar.Checked = !chkToggleSidebar.Checked;
                    break;
                case Keys.Control | Keys.Oemcomma:
                    pnlConfig.Visible = !pnlConfig.Visible;
                    break;
                case Keys.Control | Keys.Shift | Keys.R:
                    loadStylesheet();
                    break;
                case Keys.Control | Keys.Shift | Keys.E:
                    System.Diagnostics.Process.Start(dataDir + "style.txt");
                    break;
            }
            return false;
        }


        private void openMiniConfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show(); this.Activate();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            openMiniConfToolStripMenuItem.Visible = true;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                openMiniConfToolStripMenuItem_Click(null, null);
            }
        }

        private void enableNotificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            glob.setPara("enableNotifications", ((ToolStripMenuItem)sender).Checked ? "TRUE" : "FALSE");

        }

        private void enableSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            glob.setPara("enableSound", ((ToolStripMenuItem)sender).Checked ? "TRUE" : "FALSE");

        }

        private void searchForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            WinSparkle.win_sparkle_check_update_with_ui();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openMiniConfToolStripMenuItem.Visible = false;
            contextMenuStrip1.Show((Control)sender, 0, ((Control)sender).Height);
        }

        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void lvOnlineStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvOnlineStatus_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvOnlineStatus.SelectedItems.Count == 0) return;
            txtSendmessage.Text = lvOnlineStatus.SelectedItems[0].Text + ": " + txtSendmessage.Text;
            txtSendmessage.Focus();
            txtSendmessage.SelectionLength = 0;
            txtSendmessage.SelectionStart = lvOnlineStatus.SelectedItems[0].Text.Length + 2;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://home.luelista.net/programme/miniconf/hilfe/");
        }




    }
}
