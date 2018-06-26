using mshtml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace miniConf {
    class MessageView : WebBrowser {
        public event HtmlElementEventHandler OnRealKeyDown;
        public event EventHandler QuoteMessage;

        public string highlightString = "";
        public string selfNickname = "";
        public agsXMPP.Jid selfJid = "";
        public bool imagePreview = false;
        public Dictionary<string,string> smileys = new Dictionary<string,string>();


        public DateTime lastTimeTop=DateTime.MinValue, lastTimeBottom=DateTime.MinValue;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem miCopyMessage;
        private ToolStripMenuItem miQuoteMessage;
        private ToolStripMenuItem miWvl;
        private ToolStripMenuItem miCopySelection;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem miSelectAll;

        public MessageView() {
            InitializeComponent();
        }

        protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e) {
            this.Document.Write("<html><head><style id='st'></style></head>" +
                 "<body><p id='tb'>Eile mit Weile ...</p><p class='notice date' id='firstdate'></p><div id='m'></div></body></html>");
            this.Document.Body.KeyDown += Body_KeyDown;
            this.Document.Body.MouseUp += Body_MouseUp;
            
            this.loadStylesheet();
            this.loadSmileyTheme();

            base.OnDocumentCompleted(e);
        }


        void Body_KeyDown(object sender, HtmlElementEventArgs e) {
            if (OnRealKeyDown != null) OnRealKeyDown(sender, e);
        }


        public void loadStylesheet() {
            string appDir = Program.appDir, dataDir = Program.dataDir,
                themeName = Program.glob.para("messageView__theme", "Default");
            string style = "", style2 = "";
            try {
                style = File.ReadAllText(appDir + "style-global.txt");
                if (File.Exists(appDir + "themes/" + themeName + ".txt")) style2 = File.ReadAllText(appDir + "themes/" + themeName + ".txt");
                else if (File.Exists(dataDir + "style.txt") && themeName=="Custom") style2 = File.ReadAllText(dataDir + "style.txt");

            } catch (Exception e) {
                Console.WriteLine("Error loading stylesheet: " + e.Message);
            }
            try {
                IHTMLDocument3 doc = (IHTMLDocument3)this.Document.DomDocument;
                IHTMLStyleElement styleEl = (IHTMLStyleElement)doc.getElementById("st");
                styleEl.styleSheet.cssText = style + "\n" + style2;
            } catch (Exception e) {
                Console.WriteLine("Error applying stylesheet: " + e.Message);
            }
        }
        public void loadSmileyTheme() {
            string dataDir = Program.dataDir,
                   themeName = Program.glob.para("Form1__cmbSmileyTheme", "(none)"),
                   themeDir = dataDir+"Emoticons\\"+themeName;
            smileys = new Dictionary<string,string>();
            if (themeName == "(none)" || themeName == "" || !Directory.Exists(themeDir)) return;
            string[] themeIni = File.ReadAllLines(themeDir + "\\theme");
            string category = null;
            foreach (string lineIter in themeIni) {
                string line = lineIter.Trim();
                if (String.IsNullOrEmpty(line) || line.StartsWith(";") || line.StartsWith("#") || line.StartsWith("//")) continue;
                if (line.StartsWith("[") && line.EndsWith("]")) { category = line; continue; }

                if (category != null) {
                    string[] info = line.Split(' ', '\t');
                    string fn = themeDir + "\\" + info[0];
                    for (int i = 1; i < info.Length; i++) {
                        if (info[i] == "") continue;
                        smileys[info[i]] = fn;
                    }
                }
            }
        }


        public bool updateMessage(string oldId, string newId, string newBody, DateTime editTimestamp) {
            var el = Document.GetElementById("MSGID_" + oldId);
            if (el == null) return false;
            var spans = el.GetElementsByTagName("SPAN");
            spans[0].InnerHtml = prepareInnerHtml(newBody) + "<br><small> (Edited) </small>"; 
            el.Id = "MSGID_" + newId;
            return true;
        }

        public void clear() {
            this.Document.GetElementById("m").InnerHtml = "";
            this.Document.GetElementById("firstdate").InnerHtml = "";
            lastTimeTop = DateTime.MinValue;
            lastTimeBottom = DateTime.MinValue;
        }
        public bool updateLastTime(HtmlElementInsertionOrientation where, DateTime newTime) {
            if (lastTimeTop == DateTime.MinValue && lastTimeBottom == DateTime.MinValue) {
                this.Document.GetElementById("firstdate").InnerHtml = newTime.ToLongDateString();
                lastTimeBottom = newTime; lastTimeTop = newTime; return true;
            }
            if (where == HtmlElementInsertionOrientation.AfterBegin) {
                if (lastTimeTop.Date != newTime.Date) {
                    addDateToView(lastTimeTop.ToLongDateString(), where);
                    this.Document.GetElementById("firstdate").InnerHtml = newTime.ToLongDateString();
                    lastTimeTop = newTime;
                    return true;
                } else {
                    return false;
                }
            } else {
                if (lastTimeBottom.Date != newTime.Date) {
                    addDateToView(newTime.ToLongDateString(), where);
                    lastTimeBottom = newTime;
                    return true;
                } else {
                    return false;
                }
            }
        }

        public void addMessageToView(ChatMessage message, HtmlElementInsertionOrientation where = HtmlElementInsertionOrientation.BeforeEnd) {
            updateLastTime(where, message.Date);
            var div = this.Document.CreateElement("p");
            div.MouseUp += Body_MouseUp;
            div.Id = "MSGID_" + message.Id;
            string text = message.Body;
            if (!message.HasFlag(ChatMessage.MessageFlags.UnsafeAllowHtml)) text = prepareInnerHtml(message.Body);
            var me = Regex.Match(text, "^/me\\s+");
            var timeEl = "<i title=" + message.Date.ToShortDateString() + " " + message.Date.ToLongTimeString() + "><u>[</u>" + (highlightString != "" ? message.Date.ToShortDateString() : "") + " " + message.Date.ToLongTimeString() + "<u>] </u></i>";
            if (!String.IsNullOrEmpty(message.EditDt)) timeEl += "<i class='edited' title='" + message.EditDt + "'>(Edited)</i>";
            var color = JabberContact.getColorForNickname(message.SenderName);
            string cssColor = ColorTranslator.ToHtml(color);
            string classNames = "from_" + message.SenderName + " ";
            if (message.SenderName == "self" || (!String.IsNullOrEmpty(message.SenderJid) && message.SenderJid.StartsWith( this.selfJid.Bare))) classNames += "self ";
            if (message.HasFlag(ChatMessage.MessageFlags.SystemNotice)) {
                div.InnerHtml = timeEl + "<span> *** " + text + "</span>";
                classNames += "notice ";
            } else if (me.Success) {
                div.InnerHtml = timeEl + "<span> *** <strong>" + message.SenderName + "</strong> " + text.Substring(me.Length) + "</span>";
            } else {
                classNames += "msg ";
                string avatar = "<tt class='avatar' style='background-color: " + cssColor + "; '></tt>";
                string avatarFilename = Program.Jabber.avatar.GetAvatarIfAvailabe(message.SenderJid);
                if (!string.IsNullOrEmpty(avatarFilename))
                    avatar = "<tt class='avatar'><img src='" + avatarFilename + "'></tt>";
                    
                div.InnerHtml = avatar + "<span class='wrap'>" + timeEl + 
                    "<strong style='color: "+cssColor+"'>" + message.SenderName + ":</strong><span class='body'> " 
                    + text + "</span></span>";

            }
            div.SetAttribute("className", classNames);
            //this.Document.Body.AppendChild(div);
            this.Document.GetElementById("m").InsertAdjacentElement(where, div);
            if (where == HtmlElementInsertionOrientation.BeforeEnd)
                scrollDown();
        }
        public static string EscapeHtmlTags(string text) {
            text = text.Replace("&", "&amp;");
            text = text.Replace("<", "&lt;");
            return text;
        }
        protected string prepareInnerHtml(string text) {
            text = EscapeHtmlTags(text);
            if (!String.IsNullOrEmpty(highlightString)) text = Regex.Replace(text, highlightString, "<em>$0</em>");
            text = Regex.Replace(text, "^>(.*)$",
                         (match) => ("<q>&gt;" + match.Groups[1].Value + "</q>"), RegexOptions.Multiline);
            text = text.Replace("\n", "\n<br>");
            var imageLink = Regex.Match(text, "https?://[\\w.-]+/[\\w_.,/+?&%$!=)(\\[\\]{}-]*\\.(png|jpg|gif|webp)");
            text = Regex.Replace(text, "(?i)\\b((?:[a-z][\\w-]+:(?:/{1,3})|www\\d{0,3}[.]|[a-z0-9.\\-]+[.][a-z]{2,4}/)(?:[^\\s()<>]+|\\(([^\\s()<>]+|(\\([^\\s()<>]+\\)))*\\))+(?:\\(([^\\s()<>]+|(\\([^\\s()<>]+\\)))*\\)|[^\\s`!()\\[\\]{};:'\".,<>?«»“”‘’]))",
                         (match) => ("<a href=\"" 
                                + (match.Value.StartsWith("www.")?"http://":"") + match.Value.Replace("\"", "&quot;") + "\">" 
                                + match.Value + "</a>"));
            if (imagePreview && imageLink.Success) {
                string link = imageLink.Value; 
                //HACK HACK HACK
                if (link.EndsWith(".webp")) link = link.Replace(".webp", ".png");

                text += "<br><a href=\""+link+"\"><img src=\"" + link + "\" class=\"imprev\" style='max-width:150px;'></a>";
            }
            string[] parts = text.Split(' ');
            string replacement;
            for (int i = 0; i < parts.Length; i++) {
                if (smileys.TryGetValue(parts[i],out replacement)) {
                    parts[i] = "<img src='"+ replacement+"' title='"+parts[i].Replace("'","&#39;")+"'>";
                }
            }
            text = string.Join(" ", parts);
            return text;
        }
        public void addDateToView(string text, HtmlElementInsertionOrientation where) {
            var div = this.Document.CreateElement("p");
            div.SetAttribute("className", "date notice");
            div.InnerHtml = "* " + text + "";
            this.Document.GetElementById("m").InsertAdjacentElement(where, div);
        }
        public void addNoticeToView(string text) {
            var div = this.Document.CreateElement("p");
            div.SetAttribute("className", "notice");
            div.InnerHtml = "* " + text + "";
            this.Document.GetElementById("m").AppendChild(div);
            scrollDown();
        }
        public void scrollDown() {
            this.Document.Body.ScrollTop = 99999;
        }

        public string getLastMessageId(string from) {
            var msgs = this.Document.GetElementsByTagName("p");
            for (int i = msgs.Count - 1; i > 0; i--) {
                if (!String.IsNullOrEmpty(msgs[i].Id) 
                    && msgs[i].GetAttribute("className").Contains("from_"+from) 
                    && msgs[i].Id.StartsWith("MSGID_")) {
                    return msgs[i].Id.Substring(6);
                }
            }
            return null;
        }

        public void setMessageEditing(string id, bool on) {
            var msg = this.Document.GetElementById("MSGID_" + id);
            if (msg==null)return;
            if (on) {
                msg.SetAttribute("className", msg.GetAttribute("className") + " editing");
            } else {
                msg.SetAttribute("className", msg.GetAttribute("className").Replace(" editing", ""));
            }
        }

        public delegate void SpecialUrlEvent(string url);
        public event SpecialUrlEvent OnSpecialUrl;

        protected override void OnNavigating(WebBrowserNavigatingEventArgs e) {
            string url = e.Url.ToString();
            if (url == "about:blank") return;
            e.Cancel = true;
            
            if (url.StartsWith("special:") || url.StartsWith("about:")) {
                if (OnSpecialUrl != null) OnSpecialUrl(url);
            } else if (url.StartsWith("http://") || url.StartsWith("https://")) {
                runDefaultBrowser(url);
            } else {
                if (MessageBox.Show("Link clicked: " + e.Url + "\n\nOpen with default application?", "Link", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK) {
                    runDefaultBrowser(url);
                }
            }
            base.OnNavigating(e);
        }

        protected void runDefaultBrowser(string url) {
            if (Program.glob.para("defaultBrowser") != "") {
                System.Diagnostics.Process.Start(Program.glob.para("defaultBrowser"), url);
            } else {
                System.Diagnostics.Process.Start(url);
            }
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCopyMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.miQuoteMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.miWvl = new System.Windows.Forms.ToolStripMenuItem();
            this.miSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.miCopySelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCopyMessage,
            this.miQuoteMessage,
            this.miWvl,
            this.toolStripSeparator1,
            this.miCopySelection,
            this.miSelectAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 120);
            // 
            // miCopyMessage
            // 
            this.miCopyMessage.Name = "miCopyMessage";
            this.miCopyMessage.Size = new System.Drawing.Size(169, 22);
            this.miCopyMessage.Text = "Copy Message";
            this.miCopyMessage.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // miQuoteMessage
            // 
            this.miQuoteMessage.Name = "miQuoteMessage";
            this.miQuoteMessage.Size = new System.Drawing.Size(169, 22);
            this.miQuoteMessage.Text = "Quote Message";
            this.miQuoteMessage.Click += new System.EventHandler(this.miQuoteMessage_Click);
            // 
            // miWvl
            // 
            this.miWvl.Name = "miWvl";
            this.miWvl.Size = new System.Drawing.Size(169, 22);
            this.miWvl.Text = "Store in To Do List";
            this.miWvl.Click += new System.EventHandler(this.miWvl_Click);
            // 
            // miSelectAll
            // 
            this.miSelectAll.Name = "miSelectAll";
            this.miSelectAll.Size = new System.Drawing.Size(169, 22);
            this.miSelectAll.Text = "Select All";
            this.miSelectAll.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // miCopySelection
            // 
            this.miCopySelection.Name = "miCopySelection";
            this.miCopySelection.Size = new System.Drawing.Size(169, 22);
            this.miCopySelection.Text = "Copy Selection";
            this.miCopySelection.Click += new System.EventHandler(this.miCopySelection_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #region Context MENU
        HtmlElement contextElement;
        void Body_MouseUp(object sender, HtmlElementEventArgs e) {
            if (e.MouseButtonsPressed == System.Windows.Forms.MouseButtons.Right) {
                /*var el = e.FromElement;
                while (el != null && el.Parent != null && el.TagName.ToUpper() != "P")
                    el = el.Parent;*/
                contextElement = (HtmlElement) sender;

                bool isMsg = false;
                bool isMsgWithId = false;
                if (contextElement.TagName.ToUpper() == "P") {
                    isMsg=true;
                    isMsgWithId = !string.IsNullOrEmpty(contextElement.Id) && contextElement.Id.StartsWith("MSGID_") && contextElement.Id.Length > 6;
                }
                miCopyMessage.Enabled = isMsg;
                miQuoteMessage.Enabled = isMsg;
                miWvl.Enabled = isMsgWithId;


                string selection = getSelectedText();
                bool hasSelection = !String.IsNullOrEmpty(selection);
                miCopySelection.Enabled = hasSelection;
                miQuoteMessage.Text = hasSelection ? "Quote Selected Message" : "Quote Message";

                contextMenuStrip1.Show(System.Windows.Forms.Cursor.Position);
                e.BubbleEvent = false;
            }
        }

        public string getSelectedText() {
            IHTMLDocument2 htmlDocument = this.Document.DomDocument as IHTMLDocument2;
            IHTMLSelectionObject selection = htmlDocument.selection;
            if (selection != null) {
                var range = selection.createRange() as IHTMLTxtRange;
                if (range != null) {
                    return range.text;
                }
            }
            return null;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            Clipboard.Clear();
            Clipboard.SetText( contextElement.InnerText);

        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e) {
            this.Document.ExecCommand("SelectAll", true, null);
        }

        private void miCopySelection_Click(object sender, EventArgs e) {
            this.Document.ExecCommand("Copy", true, null);

        }

        private void miWvl_Click(object sender, EventArgs e) {
            string xmppid = contextElement.Id.Substring(6);
            Program.db.ExecSQL("UPDATE messages SET wvl = '1' WHERE xmppid = ?", xmppid);
            Program.wvl.ShowMe();
        }
        #endregion

        private void miQuoteMessage_Click(object sender, EventArgs e) {
            IHTMLDocument2 htmlDocument = this.Document.DomDocument as IHTMLDocument2;
            IHTMLSelectionObject selection = htmlDocument.selection;
            string str = "> " + contextElement.InnerText.Replace("\n", "\n> ");
            if (selection != null) {
                var range = selection.createRange() as IHTMLTxtRange;
                if (range != null && !String.IsNullOrEmpty(range.text)) {
                    str = "> " + range.text.Replace("\n", "\n> ");
                }
            }

            if (QuoteMessage != null) QuoteMessage(str, EventArgs.Empty);
        }



    }
}
