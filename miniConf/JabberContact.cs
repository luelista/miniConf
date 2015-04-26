using agsXMPP;
using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;

namespace miniConf {

    public class JabberContact {
        public Jid jid;
        public bool available;
        public bool inRoster;
        public string groupName, displayName;
        public List<string> resources = new List<string>();
        public JabberContact(Jid newJid) {
            jid = new Jid(newJid.Bare);
            if (!string.IsNullOrEmpty(newJid.Resource) && !resources.Contains(newJid.Resource)) 
                resources.Add(newJid.Resource);
        }

        public static uint ReHash(int srcHash) {
            unchecked {
                uint h = (uint)srcHash;
                h += (h << 15) ^ 0xffffcd7d;
                h ^= (h >> 10);
                h += (h << 3);
                h ^= (h >> 6);
                h += (h << 2) + (h << 14);
                return (uint)(h ^ (h >> 16));
            }
        }
        public static Color getColorForNickname(string nick) {
            double hue = (ReHash(nick.GetHashCode() >> 1) % 720) / 360.0;
            return WindowHelper.getColorForHSL(hue, 1, 0.4);
        }
        public Color getColor() {
            return getColorForNickname(jid);
        }
        public static Image getColoredImage(Color c, int size) {
            Bitmap b = new Bitmap(size, size);
            using (Graphics draw = Graphics.FromImage(b)) {
                draw.Clear(c);
            }
            return b;
        }
    }

}
