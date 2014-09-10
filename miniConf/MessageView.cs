using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace miniConf {
    class MessageView : WebBrowser {
        public event HtmlElementEventHandler OnRealKeyDown;

        public string highlightString = "";
        public bool imagePreview = false;

        public MessageView() {

        }

        protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e) {
            this.Document.Write("<html><head><style id='st'></style></head>" +
                 "<body><p id='tb'>Eile mit Weile ...</p><div id='m'></div></body></html>");
            this.Document.Body.KeyDown += Body_KeyDown;

            this.loadStylesheet();

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
                mshtml.IHTMLDocument3 doc = (mshtml.IHTMLDocument3)this.Document.DomDocument;
                mshtml.IHTMLStyleElement styleEl = (mshtml.IHTMLStyleElement)doc.getElementById("st");
                styleEl.styleSheet.cssText = style + "\n" + style2;
            } catch (Exception e) {
                Console.WriteLine("Error applying stylesheet: " + e.Message);
            }
        }

        public void addMessageToView(string from, string text, DateTime time, HtmlElementInsertionOrientation where = HtmlElementInsertionOrientation.BeforeEnd) {
            var div = this.Document.CreateElement("p");
            text = text.Replace("<", "&lt;");
            if (!string.IsNullOrEmpty(highlightString)) text = Regex.Replace(text, highlightString, "<em>$0</em>");
            text = text.Replace("\n", "\n<br>");
            var imageLink = Regex.Match(text, "https?://[\\w.-]+/[\\w_.,/+?&%$!=)(\\[\\]{}-]*\\.(png|jpg|gif)");
            text = Regex.Replace(text, "(?i)\\b((?:[a-z][\\w-]+:(?:/{1,3}|[a-z0-9%])|www\\d{0,3}[.]|[a-z0-9.\\-]+[.][a-z]{2,4}/)(?:[^\\s()<>]+|\\(([^\\s()<>]+|(\\([^\\s()<>]+\\)))*\\))+(?:\\(([^\\s()<>]+|(\\([^\\s()<>]+\\)))*\\)|[^\\s`!()\\[\\]{};:'\".,<>?«»“”‘’]))",
                         "<a href=\"$0\">$0</a>");
            var me = Regex.Match(text, "^/me\\s+");
            var timeEl = "<i title=" + time.ToShortDateString() + " " + time.ToLongTimeString() + ">" + (highlightString != "" ? time.ToShortDateString() : "") + " " + time.ToLongTimeString() + "</i>";
            div.SetAttribute("className", "from_" + from);
            if (me.Success) {
                div.InnerHtml = timeEl + "<span> *** <strong>" + from + "</strong> " + text.Substring(me.Length) + "</span>";
            } else {
                div.SetAttribute("className", "msg from_" + from);
                if (imagePreview && imageLink.Success) {
                    text += "<br><img src=\"" + imageLink.Value + "\" class=\"imprev\" style='max-width:150px;'>";
                }
                div.InnerHtml = timeEl + "<strong>" + from + ":</strong> <span>" + text + "</span>";

            }
            //this.Document.Body.AppendChild(div);
            this.Document.GetElementById("m").InsertAdjacentElement(where, div);
            if (where == HtmlElementInsertionOrientation.BeforeEnd)
                scrollDown();
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

        public delegate void SpecialUrlEvent(string url);
        public event SpecialUrlEvent OnSpecialUrl;

        protected override void OnNavigating(WebBrowserNavigatingEventArgs e) {
            string url = e.Url.ToString();
            if (url == "about:blank") return;
            e.Cancel = true;
            
            if (url.StartsWith("special:") || url.StartsWith("about:")) {
                if (OnSpecialUrl != null) OnSpecialUrl(url);
            } else if (url.StartsWith("http://") || url.StartsWith("https://")) {
                System.Diagnostics.Process.Start(url);
            } else {
                if (MessageBox.Show("Link clicked: " + e.Url + "\n\nOpen with default application?", "Link", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK) {
                    System.Diagnostics.Process.Start(url);
                }
            }
            base.OnNavigating(e);
        }


    }
}
