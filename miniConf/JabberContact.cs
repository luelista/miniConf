using agsXMPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace miniConf {

    public class JabberContact {
        public Jid jid;
        public bool available;
        public HashSet<string> resources = new HashSet<string>();
        public JabberContact(Jid newJid) {
            jid = new Jid(newJid.Bare);
            if (!string.IsNullOrEmpty(newJid.Resource)) resources.Add(newJid.Resource);
        }
    }

}
