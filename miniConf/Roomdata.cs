using agsXMPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace miniConf {
    public class Roomdata {
        public Jid jid;
        public HashSet<String> users = new HashSet<string>();
        public int unreadMsgCount = 0;

        public Roomdata(Jid myjid) {
            jid = myjid;
        }

        public string roomName() {
            return jid.Bare;
        }





    }
}
