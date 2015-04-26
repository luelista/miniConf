using System;
using System.Collections.Generic;

using System.Security.Cryptography;
using System.Text;

namespace miniConf {
    class Socks5 {

        public static void WriteSocksHeader(System.Net.Sockets.NetworkStream stream, string hostname) {
            byte[] buff = new byte[3];
            buff[0] = 0x05; //Version 5
            buff[1] = 0x01; buff[2] = 0x00;   // Authentication type 00 - no auth

            stream.Write(buff, 0, buff.Length);

            byte version = (byte)stream.ReadByte();
            byte authType = (byte)stream.ReadByte();
            Console.WriteLine("Socks version: " + version + "  auth=" + authType);

            byte hostbytes = (byte)System.Text.Encoding.ASCII.GetByteCount(hostname);
            byte[] connrq = new byte[7+hostbytes];
            connrq[0] = 0x05; //version 5
            connrq[1] = 0x01; //command 1: TCP connect
            connrq[2] = 0x00; //reserved
            connrq[3] = 0x03; //address type 3: domain name
            connrq[4] = hostbytes; //domain name length
            System.Text.Encoding.ASCII.GetBytes(hostname, 0, hostname.Length, connrq, 5);
            connrq[5+hostbytes] = 0x00; //port number low
            connrq[6+hostbytes] = 0x00; //port number high

            stream.Write(connrq, 0, connrq.Length);

        }

        public static string ReadSocksHeaderAnswer(System.Net.Sockets.NetworkStream stream) {

            byte version2 = (byte)stream.ReadByte();
            byte status = (byte)stream.ReadByte();
            byte reserved = (byte)stream.ReadByte();
            byte addrType = (byte)stream.ReadByte();
            byte addrLength = (byte)stream.ReadByte();
            byte[] resultBuf = new byte[addrLength];
            stream.Read(resultBuf, 0, addrLength);
            byte[] port = new byte[2];
            stream.Read(port, 0, 2);
            Console.WriteLine("Socks status: " + status + "  addrType: " + addrType + "  addr: " + System.Text.Encoding.ASCII.GetString(resultBuf));
            return System.Text.Encoding.ASCII.GetString(resultBuf);
        }

        /// <summary>
        /// Gets the SH a1 hash.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string GetSHA1Hash(string text) {
            var SHA1 = new SHA1CryptoServiceProvider();

            byte[] arrayData;
            byte[] arrayResult;
            string result = null;
            string temp = null;

            arrayData = Encoding.ASCII.GetBytes(text);
            arrayResult = SHA1.ComputeHash(arrayData);
            for (int i = 0; i < arrayResult.Length; i++) {
                temp = Convert.ToString(arrayResult[i], 16);
                if (temp.Length == 1)
                    temp = "0" + temp;
                result += temp;
            }
            return result;
        }
    }
}
