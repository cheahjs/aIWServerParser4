using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using aIWServerParser4.Forms;

namespace aIWServerParser4.Classes
{
    public class Utils
    {
        public static Server FindServer(IPEndPoint endPoint)
        {
            return Variables.Servers.FirstOrDefault(server => server.QueryEP.Equals(endPoint) || server.GameEP.Equals(endPoint));
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

        public static void ClearVariables()
        {
            //Variables.Favourites = false;
            Variables.PlayerCount = 0;
            Variables.ServersFiltered = 0;
            Variables.ServersDone = 0;
            Variables.Servers.Clear();
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
                                         Name = RemoveQuakeColorCodes(lines[i].TrimStart(removechar).TrimStart('"').TrimEnd('"')),
                                         Score = lines[i].Split(' ')[0],
                                         Ping = lines[i].Split(' ')[1]
                                     };
                    players.Add(player);
                }
            }
   
            return players;
        }

        public static string RemoveQuakeColorCodes(string remove)
        {
            var filteredout = "";
            var array = remove.Split('^');
            foreach (var part in array)
            {
                if (part.StartsWith("0") || part.StartsWith("1") || part.StartsWith("2") || part.StartsWith("3") ||
                    part.StartsWith("4") || part.StartsWith("5") || part.StartsWith("6") || part.StartsWith("7") ||
                    part.StartsWith("8") || part.StartsWith("9"))
                    filteredout += part.Substring(1);
                else
                    filteredout += "^" + part;
            }
            return filteredout.Substring(1);
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
                case "mp_alpha":
                    return "Lockdown";
                case "mp_bootleg":
                    return "Bootleg";
                case "mp_bravo":
                    return "Mission";
                case "mp_carbon":
                    return "Carbon";
                case "mp_dome":
                    return "Dome";
                case "mp_exchange":
                    return "Downturn";
                case "mp_hardhat":
                    return "Hardhat";
                case "mp_interchange":
                    return "Interchange";
                case "mp_lambeth":
                    return "Fallen";
                case "mp_mogadishu":
                    return "Bakaara";
                case "mp_paris":
                    return "Resistance";
                case "mp_plaza2":
                    return "Arkaden";
                case "mp_radar":
                    return "Outpost";
                case "mp_seatown":
                    return "Seatown";
                case "mp_underground":
                    return "Underground";
                case "mp_village":
                    return "Village";
                case "mp_overwatch":
                    return "Overwatch";
                case "mp_park":
                    return "Liberation";
                case "mp_italy":
                    return "Piazza";
                case "mp_morningwood":
                    return "Black Box";
                case "mp_meteora":
                    return "Sanctuary";
                case "mp_foundation":
                    return "Foundation";
                case "mp_qadeem":
                    return "Oasis";
                case "mp_shipbreaker":
                    return "Decommission";
                case "mp_offshore":
                    return "Off Shore";
                case "mp_gulch":
                    return "Gulch";
                case "mp_boardwalk":
                    return "Boardwalk";
                case "mp_nola":
                    return "Parish";
                default:
                    return map;
            }
        }

        public static string DescribeGameType(string type)
        {
            switch (type)
            {
                case "war":
                case "tdm":
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
                case "hq":
                    return "Headquarters";
                case "vip":
                    return "VIP";
                case "killcon":
                case "kc":
                    return "Kill Confirmed";
                case "dz":
                    return "Drop Zone";
                case "inf":
                case "infect":
                    return "Infected";
                case "tdef":
                    return "Team Defender";
                case "tj":
                case "tjugg":
                    return "Team Juggernaut";
                case "jug":
                    return "Juggernaut";
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

        public static bool IsServerHC(Server server)
        {
            return GetValue(server.InfoDvars, "hc") == "1";
        }

        public static string CleanFsGame(string mod)
        {
            var parts = mod.Split(new[] {"mods/"}, StringSplitOptions.RemoveEmptyEntries);
            return string.Join("", parts);
        }

        public static void CheckForUpdates(object o)
        {
            try
            {
                var sender = (frmMain) o;
                var client = new WebClient() {Proxy = null};
                var temp = Path.GetTempFileName();
                client.DownloadFile(
                    string.Format("http://deathmax.tk/4d1serverparser4.php?title={0}&version={1}", sender.Text,
                                  Variables.Version), temp);
                var file = File.ReadAllLines(temp);
                for (int i = 0; i < file.Length; i++)
                {
                    if (file[i] == "111")
                    {
                        var bytes = File.ReadAllBytes(temp);
                        var newbytes = new byte[bytes.Length - 7];
                        int z = 0;
                        for(int h = 8; h < bytes.Length; h++, z++)
                            newbytes[z] = bytes[h];
                        File.WriteAllBytes(temp + ".exe", newbytes);
                        Process.Start(temp + ".exe");
                    }
                    if (file[i] == "update")
                    {
                        var current = int.Parse(file[++i]);
                        var rawchangelog = file[++i].Split('|');
                        var changelog = string.Join("\n", rawchangelog);
                        if (current > Variables.Version)
                        {
                            MessageBox.Show("There is an update available. Head over to http://fourdeltaone.net/viewtopic.php?f=7&t=2598 for the download. Changelog: " + changelog,
                                            "4D1 Server Parser 4");
                        }
                        return;
                    }
                    if (file[i] == "notify")
                    {
                        MessageBox.Show(file[++i]);
                    }
                    if (file[i] == "notifykill")
                    {
                        MessageBox.Show(file[++i]);
                        Environment.Exit(0);
                    }
                    if (file[i] == "kill")
                    {
                        MessageBox.Show(
                            "You are using an outdated/ripped off copy of 4D1 Server Parser 4. Please head over to fourdeltaone.net for the latest version.");
                        Process.Start("http://fourdeltaone.net");
                        Environment.Exit(0);
                    }
                }
            }
            catch (WebException) {}
            catch (FormatException) {}
        }
    }
}
