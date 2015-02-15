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

namespace miniConf {
    public partial class RoomListForm : Form {

        DiscoManager discoManager;
        //HashSet<string> rooms = new HashSet<string>();

        public RoomListForm() {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            /*foreach (string room in roomList) {
                Jid r = new Jid(room);
                rooms.Add(r.Bare);
            }*/
        }

        private void RoomListForm_Load(object sender, EventArgs e) {
            this.Show();
            try {
                discoManager = new DiscoManager(Program.Jabber.conn);
                discoManager.DiscoverItems(new Jid(Program.Jabber.conn.Server), new IqCB(OnDiscoServerResult), null);
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Error loading chat room list", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Hide();
            }

        }

        /// <summary>
        /// Callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="iq"></param>
        /// <param name="data"></param>
        private void OnDiscoServerResult(object sender, IQ iq, object data) {
            if (iq.Type == IqType.result) {
                Element query = iq.Query;
                if (query != null && query.GetType() == typeof(DiscoItems)) {
                    DiscoItems items = query as DiscoItems;
                    DiscoItem[] itms = items.GetDiscoItems();
                    foreach (DiscoItem itm in itms) {
                        if (itm.Jid != null)
                            discoManager.DiscoverInformation(itm.Jid, new IqCB(OnDiscoInfoResult), itm);
                    }
                }
            }
        }
        private void OnDiscoInfoResult(object sender, IQ iq, object data) {
            // <iq from='proxy.cachet.myjabber.net' to='gnauck@jabber.org/Exodus' type='result' id='jcl_19'>
            // <query xmlns='http://jabber.org/protocol/disco#info'>
            // <identity category='proxy' name='SOCKS5 Bytestreams Service' type='bytestreams'/>
            // <feature var='http://jabber.org/protocol/bytestreams'/>
            // <feature var='http://jabber.org/protocol/disco#info'/>
            // </query>
            // </iq>
            if (iq.Type == IqType.result) {
                if (iq.Query is DiscoInfo) {
                    DiscoInfo di = iq.Query as DiscoInfo;
                    if (di.HasFeature(agsXMPP.Uri.MUC)) {
                        Jid jid = iq.From;
                        listView1.Groups.Add(jid.ToString(),   jid.ToString());
                        discoManager.DiscoverItems(jid, new IqCB(OnDiscoRoomlist), null);

                    }
                }
            }
            
        }

        private void OnDiscoRoomlist(object sender, IQ iq, object data) {
            if (iq.Type == IqType.result) {
                Element query = iq.Query;
                if (query != null && query.GetType() == typeof(DiscoItems)) {
                    DiscoItems items = query as DiscoItems;
                    DiscoItem[] itms = items.GetDiscoItems();
                    string server = "";
                    listView1.BeginUpdate();
                    foreach (DiscoItem itm in itms) {
                        if (itm.Jid != null) {
                            var lvi = listView1.Items.Add(itm.Jid.Bare, itm.Jid.User, -1);
                            try { lvi.Group = listView1.Groups[itm.Jid.Server]; } catch (Exception e) { }
                            server = itm.Jid.Server;
                            lvi.SubItems.Add(itm.Name); lvi.Tag = itm.Jid.Bare;
                            //if (rooms.Contains(itm.Jid.Bare)) lvi.Checked = true;
                        }
                        
                    }
                    if (server != "") {
                        var lvi2 = listView1.Items.Add("@"+server, "< other room >", -1);
                        try { lvi2.Group = listView1.Groups[server]; } catch (Exception e) { }
                        lvi2.Tag = "@" + server;
                    }

                    listView1.Sort();
                    UseWaitCursor = false;
                    listView1.EndUpdate();
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            button1.Enabled = (listView1.SelectedItems.Count == 1);
        }

        private void listView1_DoubleClick(object sender, EventArgs e) {
            if (listView1.SelectedItems.Count == 1) this.DialogResult = DialogResult.OK;
        }
       
    }
}
