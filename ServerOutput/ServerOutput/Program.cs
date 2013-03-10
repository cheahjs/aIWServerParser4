#define IW4
//#define IW5
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerOutput
{
    internal class Program
    {
        public static List<Server> Servers = new List<Server>();
		public static List<string> Serverss = new List<string>();
        public static GeoIPCountry Geo = new GeoIPCountry("GeoIP.dat");
        private static void Main(string[] args)
        {
            //while (true)
            //{
                File.Delete("serverinfo.txt");
                File.AppendAllText("serverinfo.txt", "");
                Start();
                StartServerQuery();
                Thread.Sleep(4000);
                /*_connection.Close();
                Servers.Clear();
                Serverss.Clear();*/
            //}
        }

        public static void Start()
        {
            Console.WriteLine("Starting master server query.");
#if IW4
            const string masterserver = "iw4.prod.fourdeltaone.net";
            const int port = 20810;
#endif
#if IW5
            const string masterserver = "iw5.prod.fourdeltaone.net";
            const int port = 27950;
#endif
            var client = new UdpClient(masterserver, port) {Client = {ReceiveTimeout = 1000}};
#if IW4
			var query = Encoding.ASCII.GetBytes("    getservers IW4 61586 full empty");
#endif
#if IW5
            var query = Encoding.ASCII.GetBytes("    getservers IW5 19816 full empty");
#endif
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
                catch (Exception ex)
                {
					Console.WriteLine(ex);
                    break;
                }
            }
            Console.WriteLine("Got {0} servers from master server", Servers.Count);
			File.WriteAllText("serverlist.txt", string.Join(" ", Serverss.ToArray()));
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
#if IW4
                    if (strData[i].Length == 6)
#endif
#if IW5
                    if (strData[i].Length == 8)
#endif
                    {
                        for (int h = 0; h < 6; h++)
                            ip[h] = strData[i][h];
                        var queryport = (256*ip[4] + ip[5]);
#if IW5
                        var gameport = (256*ip[6] + ip[7]);
#endif
                        var ipaddr = string.Format("{0}.{1}.{2}.{3}", ip[0], ip[1], ip[2], ip[3]);
                        var server = new Server()
                                         {
                                             QueryEP =
                                                 new IPEndPoint(
                                                 IPAddress.Parse(ipaddr.ToLower().Trim()), queryport)
#if IW5                                     
                                            ,GameEP = new IPEndPoint(
                                                 IPAddress.Parse(ipaddr.ToLower().Trim()), gameport)
#endif
                                         };
                        Servers.Add(server);
                        Serverss.Add(string.Format("{0}:{1}", ipaddr, queryport));
                        //Console.WriteLine("Query IP: {0}:{1}, Game IP: {0}:{2}", ipaddr, queryport, gameport);
                    }
                }
                if (strData[i] == "")
                    strData[i + 1] = strData[i] + "\\" + strData[i + 1];
            }
        }

        public class Server
        {
            public IPEndPoint QueryEP;
            public IPEndPoint GameEP;
            public Dictionary<string, string> StatusDvars;
            public Dictionary<string, string> InfoDvars;
            public List<Player> Players;
            public int Ping;
            public ServerStatus Status;
            public DateTime StartTime;
        }

        public class Player
        {
            public string Name;
            public string Score;
            public string Ping;
        }

        public enum ServerStatus
        {
            NotStarted,
            Status,
            Info,
            Display,
            Done,
            Filtered
        }

        private static Socket _connection;
        private static byte[] _obtainedData;
        private static EndPoint _obtainedIP;
        public static bool Query;

        public static void StartServerQuery()
        {
            Console.WriteLine("Starting query for servers...");
            _connection = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _connection.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 500);
            _connection.Bind(new IPEndPoint(IPAddress.Any, 0));
            _obtainedData = new byte[100 * 1024];
            _obtainedIP = new IPEndPoint(IPAddress.Loopback, 12345); // should be useless?
            _connection.BeginReceiveFrom(_obtainedData, 0, _obtainedData.Length, SocketFlags.None, ref _obtainedIP, QueryReceived, null);
            Query = true;
            QueryServers();
        }

        public static void QueryServers()
        {
            /*foreach (var server in Servers)
                StartQuery(server);*/
            var servers = Servers.ToList();
            foreach (var server in servers)
                StartQuery(server);
        }

        private static void StartQuery(Server server)
        {
            Console.WriteLine("Querying {0}", server.QueryEP);
            server.Status = ServerStatus.Info;
            server.StartTime = DateTime.UtcNow;
            var query = new byte[] { 0xFF, 0xFF, 0xFF, 0XFF, 0x67, 0x65, 0x74, 0x69, 0x6E, 0x66, 0x6F, 0x20, 0x78, 0x78, 0x78 };
            _connection.BeginSendTo(query, 0, query.Length, SocketFlags.None, server.QueryEP, QuerySent, null);
        }

        private static void StartStatusQuery(Server server)
        {
            server.Status = ServerStatus.Status;
            var query = new byte[] { 0xFF, 0xFF, 0xFF, 0XFF, 0x67, 0x65, 0x74, 0x73, 0x74, 0x61, 0x74, 0x75, 0x73 };
            _connection.BeginSendTo(query, 0, query.Length, SocketFlags.None, server.QueryEP, QuerySent, null);
        }

        private static void QuerySent(IAsyncResult ar)
        {
            try
            {
                _connection.EndSendTo(ar);
            }
            catch { }
        }

        private static void QueryReceived(IAsyncResult ar)
        {
            try
            {
                var bytes = _connection.EndReceiveFrom(ar, ref _obtainedIP);
                var obtainedEP = (IPEndPoint)_obtainedIP;
                var server = FindServer(obtainedEP);
                if (server == null) return;
                Servers.Remove(server);
                var strData = Encoding.ASCII.GetString(_obtainedData, 0, bytes);
                var lines = strData.Substring(4).Split('\n');
                if (lines[0].StartsWith("infoResponse") && server.Status == ServerStatus.Info)
                {
                    server.Ping = (int)(DateTime.UtcNow - server.StartTime).TotalMilliseconds;
                    var param = GetParams(lines[1].Split('\\'));
                    if (!param.ContainsKey("fs_game"))
                        param.Add("fs_game", "");
					if (strData.Contains("WZ"))
					{
						File.AppendAllText("wzinfodump.txt", string.Format("{0}{1}{2}\n", GetValue(param, "hostname").PadRight(35), server.QueryEP.ToString().PadRight(26), strData.Replace("\n", "")));
					}
                    server.InfoDvars = param;
                    ProcessServer(server);
                    //StartStatusQuery(server);
                }
                /*else if (lines[0].StartsWith("statusResponse") && server.Status == ServerStatus.Status)
                {
                    var param = GetParams(lines[1].Split('\\'));
                    if (!param.ContainsKey("fs_game"))
                        param.Add("fs_game", "");
                    server.StatusDvars = param;
                    server.Players = GetPlayers(lines);
                    server.Status = ServerStatus.Display;
                    ProcessServer(server);
                }*/
                Servers.Add(server);
            }
            catch (Exception)
            {
            }
            try
            {
                _connection.BeginReceiveFrom(_obtainedData, 0, _obtainedData.Length, SocketFlags.None, ref _obtainedIP, QueryReceived, null);
            }
            catch
            {
                try
                {
                    _connection.BeginReceiveFrom(_obtainedData, 0, _obtainedData.Length, SocketFlags.None, ref _obtainedIP, QueryReceived, null);
                }
                catch
                {
                }
            }
        }

        public static void ProcessServer(Server server)
        {
            Console.WriteLine("Processing {0}", server.QueryEP);
            server.Status = ServerStatus.Done;
			//File.AppendAllText("serverhostnames.txt", GetValue(server.InfoDvars, "hostname") + " " + ""/*server.GameEP.ToString()*/ + " " + server.QueryEP.ToString() + "\n");
            File.AppendAllText("serverinfo.txt", string.Format("{0}|!|!|{1}|!|!|{2}/{3}|!|!|{4}|!|!|{5}|!|!|{6}|!|!|{7}\n",
                 GetValue(server.InfoDvars, "hostname"), server.QueryEP/*GameEP*/, GetValue(server.InfoDvars, "clients"),
                 GetValue(server.InfoDvars, "sv_maxclients"), DescribeMapName(GetValue(server.InfoDvars, "mapname")),
                 DescribeGameType(GetValue(server.InfoDvars, "gametype")), CleanFsGame(GetValue(server.InfoDvars, "fs_game")),
                 Geo.GetCountryCode(server.QueryEP.Address)));
        }

        public static List<Player> GetPlayers(string[] lines)
        {
            var players = new List<Player>();
            var removechar = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };
            if (lines.Length >= 3)
            {
                for (int i = 2; i < lines.Length; i++)
                {
                    if (string.IsNullOrEmpty(lines[i]) || lines[i] == "\0") continue;
                    var player = new Player
                    {
                        Name = lines[i].TrimStart(removechar).TrimStart('"').TrimEnd('"'),
                        Score = lines[i].Split(' ')[0],
                        Ping = lines[i].Split(' ')[1]
                    };
                    players.Add(player);
                }
            }

            return players;
        }

        public static Server FindServer(IPEndPoint endPoint)
        {
            return Servers.FirstOrDefault(server => server.QueryEP.Equals(endPoint));
        }

        public static Dictionary<string, string> GetParams(string[] parts)
        {
            string key, val;
            var paras = new Dictionary<string, string>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Length == 0)
                {
                    continue;
                }

                key = parts[i++];
                val = parts[i];

                paras[key] = val;
            }

            return paras;
        }

        public static string DescribeMapName(string map)
        {
            switch (map)
            {
                case "mp_afghan":
                    return "Afghan";
                case "mp_complex":
                    return "Bailout";
                case "mp_abandon":
                    return "Carnival";
                case "mp_crash":
                    return "Crash";
                case "mp_derail":
                    return "Derail";
                case "mp_estate":
                    return "Estate";
                case "mp_favela":
                    return "Favela";
                case "mp_fuel2":
                    return "Fuel";
                case "mp_highrise":
                    return "Highrise";
                case "mp_invasion":
                    return "Invasion";
                case "mp_checkpoint":
                    return "Karachi";
                case "mp_overgrown":
                    return "Overgrown";
                case "mp_quarry":
                    return "Quarry";
                case "mp_rundown":
                    return "Rundown";
                case "mp_rust":
                    return "Rust";
                case "mp_compact":
                    return "Salvage";
                case "mp_boneyard":
                    return "Scrapyard";
                case "mp_nightshift":
                    return "Skidrow";
                case "mp_storm":
                    return "Storm";
                case "mp_strike":
                    return "Strike";
                case "mp_subbase":
                    return "Sub Base";
                case "mp_terminal":
                    return "Terminal";
                case "mp_trailerpark":
                    return "Trailer Park";
                case "mp_underpass":
                    return "Underpass";
                case "mp_vacant":
                    return "Vacant";
                case "mp_brecourt":
                    return "Wasteland";
                case "contingency":
                    return "Contingency";
                case "oilrig":
                    return "Oilrig";
                case "invasion":
                    return "Burger Town";
                case "gulag":
                    return "Gulag";
                case "so_ghillies":
                    return "Pripyat";
                case "roadkill":
                    return "Roadkill";
                case "iw4_credits":
                    return "IW4 Test Map";
                case "trainer":
                    return "Trainer";
                case "dc_whitehouse":
                    return "White House";
                case "favela":
                    return "SpecOps Favela";
                default:
                    return map;
            }
        }

        public static string DescribeGameType(string type)
        {
            switch (type)
            {
                case "war":
                    return "Team Deathmatch";
                case "dm":
                    return "Free-for-all";
                case "dom":
                    return "Domination";
                case "sab":
                    return "Sabotage";
                case "sd":
                    return "Search & Destroy";
                case "arena":
                    return "Arena";
                case "dd":
                    return "Demolition";
                case "ctf":
                    return "Capture the Flag";
                case "oneflag":
                    return "One-Flag CTF";
                case "gtnw":
                    return "Global Thermo-Nuclear War";
                case "gg":
                    return "Gun Game";
                case "ss":
                    return "Sharpshooter";
                case "oitc":
                    return "One in the Chamber";
                case "koth":
                    return "Headquarters";
                case "vip":
                    return "VIP";
                case "killcon":
                    return "Kill Confirmed";
                default:
                    return type;
            }
        }

        public static string GetValue(Dictionary<string, string> dict, string key)
        {
            try
            {
                return dict[key];
            }
            catch
            {
                return "";
            }
        }

        public static string CleanFsGame(string mod)
        {
            var parts = mod.Split(new[] { "mods/" }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join("", parts);
        }
    }
}
