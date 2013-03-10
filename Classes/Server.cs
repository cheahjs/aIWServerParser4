using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace aIWServerParser4.Classes
{
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

        public bool IsPlayerHere(string name)
        {
            if (name == "" && Players.Count == 0)
                return true;
            return Players.Any(player => player.Name.Contains(name));
        }
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

    public class Filter
    {
        public string ServerName;
        public string PlayerName;
        public CheckState Hardcore;
        public string Map;
        public string Mode;
        public string Mod;
        public bool Full;
        public bool Empty;

        public Filter()
        {
            ServerName = "";
            PlayerName = "";
            Hardcore = CheckState.Indeterminate;
            Map = "Any";
            Mode = "Any";
            Mod = "*";
            Full = true;
            Empty = true;
        }

        public bool MatchFilter(Server server)
        {
            if (Utils.GetValue(server.InfoDvars, "hostname").Contains(ServerName) || Utils.RemoveQuakeColorCodes(Utils.GetValue(server.InfoDvars, "hostname")).Contains(ServerName))
                if (server.IsPlayerHere(PlayerName))
                    if (Hardcore == CheckState.Indeterminate || (Hardcore == CheckState.Checked && Utils.IsServerHC(server)) || (Hardcore == CheckState.Unchecked && !Utils.IsServerHC(server)))
                        if (Map == "Any" || Utils.DescribeMapName(Utils.GetValue(server.InfoDvars, "mapname")) == Map || Utils.GetValue(server.InfoDvars, "mapname") == Map)
                            if (Mode == "Any" || Utils.DescribeGameType(Utils.GetValue(server.InfoDvars, "gametype")) == Mode || Utils.GetValue(server.InfoDvars, "gametype") == Mode)
                                if (Mod == "*" || (Mod == "None" && Utils.GetValue(server.StatusDvars, "fs_game") == "") || Utils.CleanFsGame(Utils.GetValue(server.StatusDvars, "fs_game")).Contains(Mod))
                                    if (Full || server.Players.Count < int.Parse(Utils.GetValue(server.StatusDvars, "sv_maxclients")))
                                        if (Empty || server.Players.Count > 0)
                                            return true;
            return false;
        }
    }
}
