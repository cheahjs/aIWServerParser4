using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ComponentOwl.BetterListView;
using aIWServerParser4.Forms;

namespace aIWServerParser4.Classes
{
    class QueryServer
    {
        private static Socket _connection;
        private static byte[] _obtainedData;
        private static EndPoint _obtainedIP;
        private static frmMain _sender;
        public static bool Query;

        public static void Start(object sender)
        {
            _sender = (frmMain)sender;
            _connection = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _connection.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 500);
            _connection.Bind(new IPEndPoint(IPAddress.Any, 0));
            _obtainedData = new byte[100 * 1024];
            _obtainedIP = new IPEndPoint(IPAddress.Loopback, 12345); // should be useless?
            _connection.BeginReceiveFrom(_obtainedData, 0, _obtainedData.Length, SocketFlags.None, ref _obtainedIP, QueryReceived, null);
            Query = true;
        }

        public static void QueryServers()
        {
            foreach (var server in Variables.Servers)
                StartQuery(server);
        }

        private static void StartQuery(Server server)
        {
            server.Status = ServerStatus.Info;
            server.StartTime = DateTime.UtcNow;
            var query = new byte[] { 0xFF, 0xFF, 0xFF, 0XFF, 0x67, 0x65, 0x74, 0x69, 0x6E, 0x66, 0x6F, 0x20, 0x78, 0x78, 0x78 };
            _connection.BeginSendTo(query, 0, query.Length, SocketFlags.None, server.QueryEP, QuerySent, null);
        }

        private static void StartStatusQuery(Server server)
        {
            server.Status = ServerStatus.Status;
            var query = new byte[] { 0xFF, 0xFF, 0xFF, 0XFF, 0x67, 0x65, 0x74, 0x73, 0x74, 0x61, 0x74, 0x75, 0x73, 0x20, 0x78, 0x78, 0x78 };
            _connection.BeginSendTo(query, 0, query.Length, SocketFlags.None, server.QueryEP, QuerySent, null);
        }

        private static void QuerySent(IAsyncResult ar)
        {
            try
            {
                _connection.EndSendTo(ar);
            }
            catch {}
        }

        private static void QueryReceived(IAsyncResult ar)
        {
            try
            {
                var bytes = _connection.EndReceiveFrom(ar, ref _obtainedIP);
                var obtainedEP = (IPEndPoint)_obtainedIP;
                var server = Utils.FindServer(obtainedEP);
                if (server == null) return;
                Variables.Servers.Remove(server);
                var strData = Encoding.ASCII.GetString(_obtainedData, 0, bytes);
                var lines = strData.Substring(4).Split('\n');
                if (lines[0].StartsWith("infoResponse") && server.Status == ServerStatus.Info)
                {
                    server.Ping = (int)(DateTime.UtcNow - server.StartTime).TotalMilliseconds;
                    var param = Utils.GetParams(lines[1].Split('\\'));
                    if (!param.ContainsKey("fs_game"))
                        param.Add("fs_game", "");
                    server.InfoDvars = param;
                    StartStatusQuery(server);
                    server.StatusDvars = param;
                    server.Players = new List<Player>();
                    server.Status = ServerStatus.Display;
                    //File.AppendAllText("hostnames.txt", param["hostname"].TrimEnd(new[] {'\0'}) + " ||| " + obtainedEP.ToString() + "\n");
                }
                else if (lines[0].StartsWith("statusResponse") && server.Status == ServerStatus.Status)
                {
                    var param = Utils.GetParams(lines[1].Split('\\'));
                    if (!param.ContainsKey("fs_game"))
                        param.Add("fs_game", "");
                    server.StatusDvars = param;
                    server.Players = Utils.GetPlayers(lines);
                    server.Status = ServerStatus.Display;
                }
                Variables.Servers.Add(server);
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

        public static void ProcessServer(Server server, bool background = true)
        {
            var element = new BetterListViewItem();
            var subitems = new List<BetterListViewSubItem>();
            element.Text = Utils.RemoveQuakeColorCodes(Utils.GetValue(server.InfoDvars, "hostname")).TrimEnd('\0');
            subitems.Add(new BetterListViewSubItem(server.GameEP.ToString()));
            subitems.Add(new BetterListViewSubItem(string.Format("{0}/{1}", Utils.GetValue(server.InfoDvars, "clients"), Utils.GetValue(server.InfoDvars, "sv_maxclients"))));
            subitems.Add(new BetterListViewSubItem(Utils.DescribeMapName(Utils.GetValue(server.InfoDvars, "mapname"))));
            subitems.Add(new BetterListViewSubItem(Utils.DescribeGameType(Utils.GetValue(server.InfoDvars, "gametype"))));
            subitems.Add(new BetterListViewSubItem(Utils.IsServerHC(server) ? "Yes" : "No"));
            subitems.Add(new BetterListViewSubItem(Utils.CleanFsGame(Utils.RemoveQuakeColorCodes(Utils.GetValue(server.InfoDvars, "fs_game")))));
            subitems.Add(new BetterListViewSubItem(server.Ping.ToString(CultureInfo.InvariantCulture)));
            element.SubItems.AddRange(subitems);
            if (Variables.Filter.MatchFilter(server))
            {
                Variables.ServersDone++;
                server.Status = ServerStatus.Done;
                var numplayers = 0;
                int.TryParse(Utils.GetValue(server.InfoDvars, "clients"), out numplayers);
                Variables.PlayerCount += numplayers;
                if (background)
                    _sender.backgroundQuery.ReportProgress(11, element);
                else
                    Variables.ItemsToAdd.Add(element);
            }
            else
            {
                Variables.ServersFiltered++;
                server.Status = ServerStatus.Filtered;
            }
        }
    }
}
