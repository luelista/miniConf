using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace miniConf {
    class DebugTests {
        
        public static void PrintDnsServers() {

            Console.WriteLine("Network interfaces:");
            foreach (var iface in NetworkInterface.GetAllNetworkInterfaces()) {
                try {
                    Console.WriteLine(iface.Id + "\t" + iface.ToString() + "\t" + iface.OperationalStatus.ToString() + "\t" + iface.NetworkInterfaceType.ToString());
                    Console.WriteLine(iface.Name + "\t" + iface.Description);
                    Console.WriteLine(iface.GetPhysicalAddress().ToString());
                    var ip = iface.GetIPProperties();
                    foreach (var dns in ip.DnsAddresses) {
                        Console.WriteLine("DNS:"+dns.ToString());
                    }
                    foreach (var dns in ip.UnicastAddresses) {
                        Console.WriteLine("IP:"+dns.Address.ToString());
                    }
                } catch (Exception ex) {
                    Console.WriteLine("ERR " + ex.ToString());
                }
            }

            Console.WriteLine("DNS Servers:");
            foreach (var server in agsXMPP.Net.Dns.IPConfigurationInformation.DnsServers) {
                Console.WriteLine("\t" + server.AddressFamily.ToString() + "\t" + server.ToString());
                //Console.WriteLine(server.Address.ToString());
            }
        }
    }
}
