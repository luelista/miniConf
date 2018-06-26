using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.protocol.iq.disco;
using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace miniConf
{
    public partial class DiscoForm : Form
    {
        const string PLACEHOLDER_STR = "Bitte warten ... ";
        DiscoManager discoManager;

        class DiscoNodeInfo
        {
            public bool LazyLoad;
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public DiscoItem Item { get; set; }
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public DiscoInfo Info { get; set; }
            public Jid Jid { get; set; }
            public DiscoNodeInfo(DiscoItem item) {
                LazyLoad = true; Item = item; if (item != null) Jid = Item.Jid;
            }
            public DiscoNodeInfo(Jid jid) {
                LazyLoad = true; Jid = jid;
            }
        }

        public DiscoForm() {
            InitializeComponent();
        }

        private void DiscoForm_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
            discoManager = new DiscoManager(Program.Jabber.conn);
            string[] roots = Program.glob.para("DiscoForm__rootNodes").Split(';');
            foreach (string root in roots) if (root != "") addRootNode(root);
        }

        private void btnNewRoot_Click(object sender, EventArgs e) {
            var rootName = UgbDatabaseConnection.InputDlg.InputBox("Root node:", Program.Jabber.conn.MyJID.Server);
            if (!string.IsNullOrEmpty(rootName))
                addRootNode(rootName);
            string[] roots = new string[treeView1.Nodes.Count];
            for (int i = 0; i < roots.Length; i++) roots[i] = treeView1.Nodes[i].Text;
            Program.glob.setPara("DiscoForm__rootNodes", string.Join(";", roots));
        }

        void addRootNode(string name) {
            var n =treeView1.Nodes.Add(name);
            n.Tag = new DiscoNodeInfo(new Jid(name));
            n.Nodes.Add(PLACEHOLDER_STR);
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            var info = (DiscoNodeInfo)e.Node.Tag;
            if (info.LazyLoad) {
                loadSubNodes(e.Node);
            }
        }
        void loadSubNodes(TreeNode node) {
            var info = (DiscoNodeInfo)node.Tag;
            if (info.Item != null && !String.IsNullOrEmpty(info.Item.Node))
                discoManager.DiscoverItems(new Jid(info.Jid), info.Item.Node, new IqCB(OnDiscoItemsResult), node);
            else
                discoManager.DiscoverItems(new Jid(info.Jid), new IqCB(OnDiscoItemsResult), node);

        }

        string getAttrString(Element itm) {
            string s = "";
            foreach (System.Collections.DictionaryEntry attr in itm.Attributes) {
                s += attr.Key + "=" + attr.Value + "; ";
            }
            return s;
        }
        /// <summary>
        /// Callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="iq"></param>
        /// <param name="data"></param>
        private delegate void delegateOnDiscoResult(object sender, IQ iq, object data);
        private void OnDiscoItemsResult(object sender, IQ iq, object data) {
            if (InvokeRequired) { this.Invoke(new delegateOnDiscoResult(OnDiscoItemsResult), sender, iq, data); return; }
            var node = (TreeNode)data;
            var info = (DiscoNodeInfo)node.Tag;
            if (iq.Type == IqType.error) {
                node.Nodes.Clear();
                node.Nodes.Add("ERROR: " + iq.Error.ErrorText);
            } else if (iq.Type == IqType.result && iq.Query != null && iq.Query.GetType() == typeof(DiscoItems)) {
                DiscoItems items = iq.Query as DiscoItems;
                DiscoItem[] itms = items.GetDiscoItems();
                node.Nodes.Clear();
                foreach (DiscoItem itm in itms) {
                    var n = node.Nodes.Add(getAttrString(itm));
                    n.Tag = new DiscoNodeInfo(itm);
                    n.Nodes.Add(PLACEHOLDER_STR);
                }
                info.LazyLoad = false;
            }
        }
        private void OnDiscoInfoResult(object sender, IQ iq, object data) {
            if (InvokeRequired) { this.Invoke(new delegateOnDiscoResult(OnDiscoInfoResult), sender, iq, data); return; }
            var node = (TreeNode)data;
            var info = (DiscoNodeInfo)node.Tag;
            if (iq.Type == IqType.error) {
                textEditorControl2.Text = iq.ToString(System.Xml.Formatting.Indented, 4);
            } else if (iq.Type == IqType.result && iq.Query != null && iq.Query.GetType() == typeof(DiscoInfo)) {
                DiscoInfo discoInfo = iq.Query as DiscoInfo;
                info.Info = discoInfo;
                textEditorControl2.Text = info.Info.ToString(System.Xml.Formatting.Indented, 4);
                
            }
            textEditorControl2.Refresh();
            if(ctx.Visible) fillContextmenu(node);
        }

        void fillContextmenu(TreeNode node) {
            ctx.Items.Clear();
            DiscoNodeInfo info = node.Tag as DiscoNodeInfo;
            if (info.Info != null) {
                if (info.Info.HasFeature("http://jabber.org/protocol/commands")) {
                    ctx.Items.Add("Ad-Hoc Commands", null, (ss, ee) => {
                        AdhocCommandForm frm = new AdhocCommandForm();
                        frm.Show();
                        frm.responderJid = info.Jid;
                        frm.loadCommandList();
                    });
                }
                if (info.Info.HasFeature("http://jabber.org/protocol/muc")) {
                    if (info.Jid.User != null && info.Jid.Resource == null) {
                        ctx.Items.Add("Join room", null, (ss, ee) => {
                            Program.MainWnd.joinChatroom(info.Jid);
                        });
                    }
                }
            }
            ctx.Items.Add("Reload items", null, (ss, ee) => { loadSubNodes(node); });
            
            if (info.Info != null) {
                ctx.Items.Add("-");
                foreach (var tag in info.Info.GetIdentities()) {
                    ctx.Items.Add("Identities: " + getAttrString(tag));
                }
                ctx.Items.Add("-");
                foreach (var tag in info.Info.GetFeatures()) {
                    ctx.Items.Add("Feature: " + getAttrString(tag));
                }

            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            DiscoNodeInfo info = e.Node.Tag as DiscoNodeInfo;
            
            propertyGrid1.SelectedObject = info;
            if (info == null)return;
            if (info.Item == null) textEditorControl1.Text = ""; else textEditorControl1.Text = info.Item.ToString(System.Xml.Formatting.Indented, 4);
            textEditorControl1.Refresh();

            if (info.Info == null) {
                if (info.Item != null && !String.IsNullOrEmpty(info.Item.Node))
                    discoManager.DiscoverInformation(info.Jid, info.Item.Node, new IqCB(OnDiscoInfoResult), e.Node);
                else
                    discoManager.DiscoverInformation(info.Jid, new IqCB(OnDiscoInfoResult), e.Node);
                textEditorControl2.Text = "Wird geladen";
            } else {
                textEditorControl2.Text = info.Info.ToString(System.Xml.Formatting.Indented, 4);
                
            }

            if (e.Button == MouseButtons.Right) {
                fillContextmenu(e.Node);
                ctx.Show(Cursor.Position);
                treeView1.SelectedNode = e.Node;
            }

            textEditorControl2.Refresh();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            
        }
    }
}
