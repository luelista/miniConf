using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.protocol.extensions.commands;
using agsXMPP.protocol.iq.disco;
using agsXMPP.protocol.x.data;
using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public partial class AdhocCommandForm : Form {
        DiscoManager discoManager;
        public Jid responderJid;

        string commandNode, sessionId;

        public AdhocCommandForm() {
            InitializeComponent();
        }

        private void AdhocCommandForm_Load(object sender, EventArgs e) {
            discoManager = new DiscoManager(Program.Jabber.conn);
            this.responderJid = new Jid(Program.Jabber.conn.Server);
        }

        public void loadCommandList() {
            discoManager.DiscoverItems(responderJid, 
                "http://jabber.org/protocol/commands",
                new IqCB(OnCommandlistResult));
        }


        /// <summary>
        /// Callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="iq"></param>
        /// <param name="data"></param>
        private void OnCommandlistResult(object sender, IQ iq, object data) {
            if (iq.Type == IqType.result) {
                Element query = iq.Query;
                if (query != null && query.GetType() == typeof(DiscoItems)) {
                    DiscoItems items = query as DiscoItems;
                    this.Invoke(new Action<DiscoItems>(displayCommandlistForm), items);
                }
            }
        }

        private void onCommandResult_threadsafe(object sender, IQ iq, object data) {
            this.Invoke(new Action<IQ>(onCommandResult), iq);
        }
        private void onCommandResult(IQ iq) {
            Element commandResult = iq.SelectSingleElement("command");

            if (iq.Type == IqType.result && commandResult != null) {
                Element note = commandResult.SelectSingleElement("note");
                if (note != null) {
                    MessageBox.Show(note.Value, "Command result", MessageBoxButtons.OK, 
                        note.GetAttribute("type") == "error" ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information);
                }
                Element result = commandResult.SelectSingleElement("x", "jabber:x:data");
                if (result != null) {
                    clearButtons();
                    clearForm();

                    Element actions = commandResult.SelectSingleElement("actions");
                    if (actions != null) {
                        sessionId = commandResult.GetAttribute("sessionid");
                        string execute = actions.GetAttribute("execute");
                        foreach (Node node in actions.ChildNodes) {
                            if (node.NodeType == NodeType.Element)
                                addButton(((Element)node).TagName, execute == ((Element)node).TagName);
                        }
                    }
                    addFormInfoLabel(iq.InnerXml, 8);
                    addFormInfoLabel("-----------------------------------------------", 8);

                    ListView lv;
                    foreach (Node child in result.ChildNodes) {
                        if (child.NodeType != NodeType.Element) continue;
                        Element ch = (Element)child;
                        switch (ch.TagName.ToUpper()) {
                            case "REPORTED":
                                lv = new ListView();
                                pnlForm.Controls.Add(lv);
                                lv.Dock = DockStyle.Fill; lv.View = View.Details;
                                foreach (Element field in ch.SelectElements("field")) {
                                    lv.Columns.Add(field.GetAttribute("var"), field.GetAttribute("label"));
                                }
                                break;
                            case "ITEM":
                                var item = new ListViewItem();
                                foreach (Element field in ch.SelectElements("field")) {
                                    if (item.Text == null) item.Text = field.GetTag("value");
                                    else item.SubItems.Add(field.GetTag("value"));
                                }
                                break;
                            case "TITLE":
                                addFormInfoLabel(ch.Value, FONT_TITLE);
                                break;
                            case "INSTRUCTIONS":
                                addFormInfoLabel(ch.Value, FONT_INSTRUCTIONS);
                                break;
                            case "FIELD":
                                switch (ch.GetAttribute("type")) {
                                    case "list-single":
                                        ElementList optionList = ch.SelectElements("option");
                                        ListItem[] options = new ListItem[optionList.Count];
                                        for (int i = 0; i < options.Length; i++)
                                            options[i] = new ListItem(optionList.Item(i).GetAttribute("label"), optionList.Item(i).GetTag("value"));
                                        addFormListSingle(ch.GetAttribute("var"), ch.GetAttribute("label"), options, ch.GetTag("value"));
                                        break;
                                    case "boolean":
                                        addFormBoolean(ch.GetAttribute("var"), ch.GetAttribute("label"), ch.GetTag("value"));
                                        break;
                                    case "fixed":
                                        addFormInfoLabel(ch.GetTag("value"), FONT_INSTRUCTIONS);
                                        break;
                                    case "text-multi":
                                        string text = "";
                                        foreach (Element value in ch.SelectElements("value")) {
                                            if (text != "") text += "\r\n";
                                            text += value.Value;
                                        }
                                        addFormText(ch.GetAttribute("var"), ch.GetAttribute("label"), "text-multi", text);
                                        break;
                                    default:
                                        addFormText(ch.GetAttribute("var"), ch.GetAttribute("label"), ch.GetAttribute("type"), ch.GetTag("value"));
                                        break;
                                }
                                break;
                        }
                    }

                    this.Height = Math.Min(Screen.PrimaryScreen.WorkingArea.Height - 60, formY + 100);
                }
                focusFirstElement();
            }
        }


        private void displayCommandlistForm(DiscoItems items) {
            commandNode = null; sessionId = null;
            DiscoItem[] itms = items.GetDiscoItems();
            clearButtons();
            addButton("execute", true);
            clearForm();
            addFormInfoLabel("Select ad hoc command:", FONT_TITLE);
            ListItem[] list = new ListItem[itms.Length];
            for (int i = 0; i < itms.Length; i++) {
                list[i] = new ListItem(itms[i].Name, itms[i].Node);
            }
            addFormListSingle("command", "Command:", list, null);
            this.Height = formY + 100;
            focusFirstElement();
        }

        private void focusFirstElement() {
            foreach (Control ctrl in pnlForm.Controls)
                if (!(ctrl is Label)) { ctrl.Focus(); return; }
        }


        int buttonX = 470;
        private void clearButtons() {
            pnlButtons.Controls.Clear();
            buttonX = 440;
        }

        private void addButton(string command, bool execute) {
            Button b = new Button();
            b.Text = command;
            b.Top = 10; b.Left = buttonX; b.Width = 80;
            pnlButtons.Controls.Add(b);
            b.Click += b_Click;
            if (execute) this.AcceptButton = b;
            buttonX -= 90;
        }

        void b_Click(object sender, EventArgs e) {
            IQ iq = new IQ(IqType.set, null, responderJid);
            iq.GenerateId();
            if (pnlForm.Controls.ContainsKey("field_command")) commandNode = getControlValue("command");
            var cmd = new Command(commandNode, sessionId);
            cmd.SetAttribute("action", ((Button)sender).Text);
            cmd.SetAttribute("sessionid", sessionId);
            iq.ChildNodes.Add(cmd);
            
            cmd.Data = new Data();
            foreach(Control ctrl in pnlForm.Controls) {
                string value = getControlValue(ctrl);
                if (value == null || !(ctrl.Tag is string[])) continue;
                string[] tag = (string[])ctrl.Tag;
                var fld = new Field(tag[1], value, FieldType.Unknown);
                fld.SetTag("value", value);
                cmd.Data.AddField(fld);
                if (tag[0] == "text-single" || tag[0] == "jid-single") Program.db.AddToMru("adhoc-txt", value);
               // if (tag[0] == "jid-single") Program.db.AddToMru("jid", value);

            }
            Program.Jabber.conn.IqGrabber.SendIq(iq, new IqCB(onCommandResult_threadsafe));
        }

        private string getControlValue(Control ctrl) {
            try {
                if (ctrl is CheckBox) return ((CheckBox)ctrl).Checked ? "true" : "false";
                if (ctrl is ComboBox) return ((ListItem)((ComboBox)ctrl).SelectedItem).value;
                if (ctrl is TextBox) return ((TextBox)ctrl).Text;
            } catch (Exception ex) { }
            return null;
        }

        private string getControlValue(string var) {
            return getControlValue(pnlForm.Controls["field_" + var]);
        }

        int formY = 10;
        private void clearForm() {
            pnlForm.Controls.Clear();
            formY = 10;
        }

        private void addFormBoolean(string var, string label, string def) {
            CheckBox c = new CheckBox();
            c.Text = label; c.Name = "field_" + var;
            c.Tag = new String[]{"boolean",var};
            c.Top = formY; c.Left = 20; formY += 40;
            c.Checked = (def == "true");
            pnlForm.Controls.Add(c);
        }

        private const int FONT_TITLE = 14;
        private const int FONT_INSTRUCTIONS = 10;

        private void addFormInfoLabel(string label, int fontSize) {
            Label l = new Label();
            l.MaximumSize = new Size(520, 100); l.AutoSize = true;
            l.Font = new Font("Helvetica", fontSize);
            l.Text = label; l.Left = 10; l.Top = formY;
            pnlForm.Controls.Add(l);
            formY += l.Height + 10;
        }

        private void addFormControlLabel(string label) {
            Label l = new Label();
            l.TextAlign = ContentAlignment.MiddleRight;
            l.Width = 150; l.Height = 20; l.BackColor = Color.Teal;
            l.Top = formY; l.Left = 10;
            l.Text = label;
            pnlForm.Controls.Add(l);
        }

        private void addFormText(string var, string label, string textType, string def) {
            addFormControlLabel(label);
            TextBox t = new TextBox(); t.Name = "field_" + var;
            t.Width = 350; t.Top = formY; t.Left = 170;
            if (textType == "text-multi") { t.Multiline = true; t.Height = 90; t.ScrollBars = ScrollBars.Both; }
            t.Tag = new String[] { textType, var };
            t.Text = def;
            pnlForm.Controls.Add(t);
            formY += t.Height + 10;
            t.AutoCompleteMode = AutoCompleteMode.Suggest;
            t.AutoCompleteSource = AutoCompleteSource.CustomSource;
            t.AutoCompleteCustomSource.AddRange(Program.db.GetMru("adhoc-txt", 25));
        }

        private void addFormListSingle(string var, string label, ListItem[] options, string def) {
            addFormControlLabel(label);
            ComboBox sel = new ComboBox(); sel.Name = "field_" + var;
            sel.Items.AddRange(options); sel.DropDownStyle = ComboBoxStyle.DropDownList;
            sel.Width = 350; sel.Top = formY; sel.Left = 170;
            sel.Tag = new String[] { "list-single", var };
            pnlForm.Controls.Add(sel);
            formY += sel.Height + 10;
        }

        class ListItem {
            string label;
            public string value { get; private set; }
            public ListItem(string _label, string _value) { 
                this.label = String.IsNullOrEmpty( _label) ? _value : _label;
                this.value = _value; 
            }
            public override string ToString() {
                return label;
            }
        }

        private void AdhocCommandForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F8) {
                var f = new AdhocCommandForm();
                f.Show();
                f.loadCommandList();
            }
            if (e.KeyCode == Keys.F5) {
                this.loadCommandList();
            }
            if (e.KeyCode == Keys.F6) {
                string resp = Microsoft.VisualBasic.Interaction.InputBox("Modify Responder JID","",responderJid.ToString());
                if (!String.IsNullOrEmpty(resp)) {
                    responderJid = new Jid(resp);
                    this.loadCommandList();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
