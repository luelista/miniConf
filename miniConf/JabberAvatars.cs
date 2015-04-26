using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.protocol.extensions.pubsub;
using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace miniConf {
    class JabberAvatars : BackgroundWorker {

        public List<string> dontRequestIds = new List<string>();

        public delegate void RequestAvatarCallback(bool success, string fileName);

        protected override void OnDoWork(DoWorkEventArgs e) {
            

        }

        public string GetAvatarIfAvailabe(string userId) {
            if (string.IsNullOrEmpty(userId)) return null;
            Jid jid = new Jid(userId);
            string fileName = GetAvatarFilename(jid.Bare);
            if (File.Exists(fileName)) return fileName;
            RequestAvatar(jid.Bare, (bool success, string fileName2) => { });
            return null;
        }

        public string GetAvatarFilename(string userId) {
			return Program.dataDir + "Avatars" + Path.PathSeparator + Regex.Replace(userId, "[^a-zA-Z0-9@_.-]", ",") + ".png";
        }

        public void RequestAvatar(Jid userId, RequestAvatarCallback finished) {
            if (dontRequestIds.Contains(userId.ToString())) return;

            dontRequestIds.Add(userId.ToString());
            PubSubIq metaiq = new PubSubIq(IqType.get, userId, Program.Jabber.conn.MyJID);
            metaiq.PubSub.Items = new Items("urn:xmpp:avatar:metadata");
            Program.Jabber.conn.IqGrabber.SendIq(metaiq, (IqCB)((object unused_1, IQ result, object unused_2) => {
                if (result.Type != IqType.result) { finished(false, null); return; }
                Element info = result.SelectSingleElement("info", true);
                if (info == null || !info.HasAttribute("id") || !info.HasAttribute("type")) { finished(false, null); return; }

                this.DownloadAvatar(userId, info.GetAttribute("id"), info.GetAttribute("type"), finished);

            }));

        }

        public void DownloadAvatar(Jid userId, string avatarId, string avatarType, RequestAvatarCallback finished) {
            PubSubIq dataiq = new PubSubIq(IqType.get, userId, Program.Jabber.conn.MyJID);
            dataiq.PubSub.Items = new Items("urn:xmpp:avatar:data");
            dataiq.PubSub.Items.AddItem(new Item(avatarId));
            Program.Jabber.conn.IqGrabber.SendIq(dataiq, (IqCB)((object sender_3, IQ result2, object unused_4) => {
                if (result2.Type != IqType.result) { finished(false, null); return; }

                Element data = result2.SelectSingleElement("data", true);

                byte[] imageBytes = Convert.FromBase64String(data.Value);

                Image img;
                switch (avatarType) {
                    case "image/webp":
                        var dec = new Imazen.WebP.SimpleDecoder();
                        img = dec.DecodeFromBytes(imageBytes, imageBytes.Length);
                        break;
                    default:
                        img = Image.FromStream(new MemoryStream(imageBytes));
                        break;
                }
                string fileName = GetAvatarFilename(userId);

                img.Save(fileName, ImageFormat.Png);
                finished(true, fileName);
            }));

        }
    }
}
