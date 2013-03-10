using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace aIWServerParser4.Classes
{
    public class QueryMaster
    {
        public static void Start()
        {
            if (!Variables.Favourites)
            {
                const string masterserver = "iw5.prod.fourdeltaone.net";
                //const string masterserver = "master.alterrev.net";
#if !DEBUG
                /*if (masterserver.Contains("alter" + "re " + "v.net") || masterserver.Length != 25 ||
                    !masterserver.Contains("fou" + "rdel" + "taone"))
                {
                    MessageBox.Show(
                        "You are using a ripped copy of Server Parser and aIW. Please head over to fourdeltaone.net for the real version.");
                    Process.Start("http://fourdeltaone.net");
                    Environment.Exit(0);
                }*/
#endif
                var client = new UdpClient(masterserver, 27950) { Client = { ReceiveTimeout = 1000 } };
                //var query = Encoding.ASCII.GetBytes("    getservers IW4 61586 full empty");
                var query = Encoding.ASCII.GetBytes("    getservers IW5 19816 full empty");
                query[0] = 0xFF;
                query[1] = 0xFF;
                query[2] = 0xFF;
                query[3] = 0xFF;
                client.Send(query, query.Length);
                while (true)
                {
                    try
                    {
                        var EP = new IPEndPoint(IPAddress.Any, 0);
                        byte[] receivedata = client.Receive(ref EP);
                        ParseResponse(receivedata);
                        if (Encoding.ASCII.GetString(receivedata).Contains("EOT"))
                            break;
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            else
            {
                if (!File.Exists("favourites.txt"))
                    File.WriteAllText("favourites.txt", "");
                var raw = File.ReadAllLines("favourites.txt");
                foreach (var line in raw)
                {
                    var parts = line.Split(':');
                    if (parts.Length != 2) continue;
                    int port;
                    if (!int.TryParse(parts[1], out port)) continue;
                    Variables.Servers.Add(new Server {QueryEP = new IPEndPoint(IPAddress.Parse(parts[0]), port)});
                }
            }
        }
        private static void ParseResponse(byte[] data)
        {
            var strData = Encoding.UTF7.GetString(data).Substring(4).Split('\\');
            for (int i = 0; i < strData.Length; i++)
            {
                if (strData[i].Contains("serverresponse"))
                    continue;
                if (strData[i].Contains("EOT"))
                    break;
                var ip = new int[8];
                if (strData[i] != "")
                {
                    if (strData[i].Length == 8)
                    {
                        for (int h = 0; h < strData[i].Length; h++)
                            ip[h] = strData[i][h];
                        var queryport = (256 * ip[4] + ip[5]);
                        var gameport = (256 * ip[6] + ip[7]);
                        var ipaddr = string.Format("{0}.{1}.{2}.{3}", ip[0], ip[1], ip[2], ip[3]);
                        var server = new Server()
                                         {
                                             QueryEP =
                                                 new IPEndPoint(
                                                 IPAddress.Parse(ipaddr.ToLower().Trim()), queryport),
                                             GameEP =
                                                 new IPEndPoint(
                                                 IPAddress.Parse(ipaddr.ToLower().Trim()), gameport)
                                         };
                        Variables.Servers.Add(server);
                    }
                }
                if (strData[i] == "")
                    strData[i + 1] = strData[i] + "\\" + strData[i + 1];
            }
        }
    }
}
