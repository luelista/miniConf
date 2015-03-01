using System;
using System.Collections.Generic;
using System.Text;

namespace miniConf {
    class DebugTests {
        
        public static void PrintDnsServers() {
            Console.WriteLine("DNS Servers:");
            foreach (var server in agsXMPP.Net.Dns.IPConfigurationInformation.DnsServers) {
                Console.WriteLine(server.Address.ToString() + "\t" + server.AddressFamily.ToString() + "\t" + server.ToString());
            }
        }
    }
}
