using MSHTML;
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

        public string highlightString = "";
        public string selfNickname = "";
        public bool imagePreview = false;
        public Dictionary<string,string> smileys = new Dictionary<string,string>();


        public DateTime lastTimeTop=DateTime.MinValue, lastTimeBottom=DateTime.MinValue;

        public MessageView() {

        }

        protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e) {
            this.Document.Write("<html><head><style id='st'></style></head>" +
                 "<body><p id='tb'>Eile mit Weile ...</p><p class='notice date' id='firstdate'></p><div id='m'></div></body></html>");
            this.Document.Body.KeyDown += Body_KeyDown;
            
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
            addMessageToView(message.Sender, message.Body, message.Date, message.Editdt, 
                message.SenderJid, message.Id, where);

        }

        public void addMessageToView(string from, string text, DateTime time, string editDt, string jabberId, string id, HtmlElementInsertionOrientation where = HtmlElementInsertionOrientation.BeforeEnd) {
            updateLastTime(where, time);
            var div = this.Document.CreateElement("p");
            div.Id = "MSGID_" + id;
            text = prepareInnerHtml(text);
            var me = Regex.Match(text, "^/me\\s+");
            var timeEl = "<i title=" + time.ToShortDateString() + " " + time.ToLongTimeString() + "><u>[</u>" + (highlightString != "" ? time.ToShortDateString() : "") + " " + time.ToLongTimeString() + "<u>] </u></i>";
            if (!String.IsNullOrEmpty(editDt)) timeEl += "<i class='edited' title='" + editDt + "'>(Edited)</i>";
            var color = JabberContact.getColorForNickname(from);
            string cssColor = ColorTranslator.ToHtml(color);
            string classNames = "from_" + from + " ";
            if (from == "self" || (!String.IsNullOrEmpty(jabberId) && jabberId.StartsWith( this.selfNickname))) classNames += "self ";
            if (me.Success) {
                div.InnerHtml = timeEl + "<span> *** <strong>" + from + "</strong> " + text.Substring(me.Length) + "</span>";
            } else {
                classNames += "msg ";
                string avatar = "<tt class='avatar' style='background-color: " + cssColor + "; '></tt>";
                string avatarFilename = Program.Jabber.avatar.GetAvatarIfAvailabe(jabberId);
                if (!string.IsNullOrEmpty(avatarFilename))
                    avatar = "<tt class='avatar'><img src='" + avatarFilename + "'></tt>";
                    
                div.InnerHtml = avatar + "<span class='wrap'>" + timeEl + 
                    "<strong style='color: "+cssColor+"'>" + from + ":</strong><span class='body'> " 
                    + text + "</span></span>";

            }
            div.SetAttribute("className", classNames);
            //this.Document.Body.AppendChild(div);
            this.Document.GetElementById("m").InsertAdjacentElement(where, div);
            if (where == HtmlElementInsertionOrientation.BeforeEnd)
                scrollDown();
        }
        protected string prepareInnerHtml(string text) {
            text = text.Replace("&", "&amp;");
            text = text.Replace("<", "&lt;");
            if (!String.IsNullOrEmpty(highlightString)) text = Regex.Replace(text, highlightString, "<em>$0</em>");
            text = text.Replace("\n", "\n<br>");
            var imageLink = Regex.Match(text, "https?://[\\w.-]+/[\\w_.,/+?&%$!=)(\\[\\]{}-]*\\.(png|jpg|gif|webp)");
            text = Regex.Replace(text, "(?i)\\b((?:[a-z][\\w-]+:(?:/{1,3}|[a-z0-9%])|www\\d{0,3}[.]|[a-z0-9.\\-]+[.][a-z]{2,4}/)(?:[^\\s()<>]+|\\(([^\\s()<>]+|(\\([^\\s()<>]+\\)))*\\))+(?:\\(([^\\s()<>]+|(\\([^\\s()<>]+\\)))*\\)|[^\\s`!()\\[\\]{};:'\".,<>?«»“”‘’]))",
                         (match) => ("<a href=\"" + match.Value.Replace("\"", "&quot;") + "\">" + match.Value + "</a>"));
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


    }
}
