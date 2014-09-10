using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.protocol.iq.disco;
using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public partial class RoomListForm : Form {

        DiscoManager discoManager;
        HashSet<string> rooms = new HashSet<string>();

        public RoomListForm(string[] roomList) {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            foreach (string room in roomList) {
                Jid r = new Jid(room);
                rooms.Add(r.Bare);
            }
        }

        private void RoomListForm_Load(object sender, EventArgs e) {
            discoManager = new DiscoManager(Program.conn);
            discoManager.DiscoverItems(new Jid(Program.conn.Server), new IqCB(OnDiscoServerResult), null);


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
                    foreach (DiscoItem itm in itms) {
                        if (itm.Jid != null) {
                            var lvi = listView1.Items.Add(itm.Jid.Bare, itm.Jid.User, -1);
                            try { lvi.Group = listView1.Groups[itm.Jid.Server]; } catch (Exception e) { }
                            lvi.SubItems.Add(itm.Name); lvi.Tag = itm.Jid.Bare;
                            if (rooms.Contains(itm.Jid.Bare)) lvi.Checked = true;
                        }
                        
                    }
                    listView1.Sort();
                }
            }
        }
       
    }
}
