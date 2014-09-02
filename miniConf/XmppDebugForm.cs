using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public partial class XmppDebugForm : Form {
        public XmppDebugForm() {
            InitializeComponent();
        }

        private void XmppDebugForm_Load(object sender, EventArgs e) {
            Program.conn.OnReadXml += conn_OnReadXml;
            Program.conn.OnPresence += conn_OnPresence;
            Program.conn.OnMessage += conn_OnMessage;
            Program.conn.OnIq += conn_OnIq;
            textEditorControl1.Document.DocumentChanged += Document_DocumentChanged;
            textEditorControl1.SetHighlighting("XML");
        }


        void conn_OnIq(object sender, agsXMPP.protocol.client.IQ iq) {
            this.Invoke(new OnStanzaDelegate(OnStanza), iq);
        }

        void conn_OnMessage(object sender, agsXMPP.protocol.client.Message msg) {
            this.Invoke(new OnStanzaDelegate(OnStanza), msg);
        }

        void conn_OnPresence(object sender, agsXMPP.protocol.client.Presence pres) {
            this.Invoke(new OnStanzaDelegate(OnStanza), pres);
        }

        void conn_OnReadXml(object sender, string xml) {
            //listView1.Items.Add(xml);

        }


        delegate void OnStanzaDelegate(agsXMPP.protocol.Base.Stanza stanza);
        private void OnStanza(agsXMPP.protocol.Base.Stanza stanza) {
            var item = listView1.Items.Add(stanza.ToString());
            item.EnsureVisible();
            item.Tag = stanza;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listView1.SelectedItems.Count != 1) return;
            
            agsXMPP.protocol.Base.Stanza stanza = 
                (agsXMPP.protocol.Base.Stanza) listView1.SelectedItems[0].Tag;

            listBox1.SelectedIndex = -1;
            setEditorText(stanza.ToString(System.Xml.Formatting.Indented, 2));
            
        }

        private void textEditorControl1_Load(object sender, EventArgs e) {

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e) {
            string txt = (string)listBox1.SelectedItem;
            if (txt == "[ new template ]") txt = "";
            setEditorText(txt);
        }

        bool blockDocumentUpdate = false;
        private void setEditorText(string tx) {
            blockDocumentUpdate = true;
            textEditorControl1.Text = tx;
            textEditorControl1.Refresh();
            blockDocumentUpdate = false;
        }

        void Document_DocumentChanged(object sender, DocumentEventArgs e) {
            if (blockDocumentUpdate) return;
            if (listBox1.SelectedIndex == -1 || listBox1.SelectedItem == "[ new template ]") {
                listBox1.Items.Insert(1, textEditorControl1.Text);
                listBox1.SelectedIndex = 1;
            } else {
                listBox1.Items[listBox1.SelectedIndex] = textEditorControl1.Text;
            }
        }

        private void XmppDebugForm_FormClosing(object sender, FormClosingEventArgs e) {
            Program.glob.setPara("showXmppDebugOnStartup", "TRUE");
        }

    }
}
