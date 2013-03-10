using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using aIWServerParser4.Classes;

namespace aIWServerParser4.Forms
{
    public partial class frmInfo : Form
    {
        private frmMain _sender;
        public frmInfo(frmMain sender)
        {
            InitializeComponent();
            _sender = sender;
            Populate();
        }

        private void Populate()
        {
            var server =
                Utils.FindServer(
                    new IPEndPoint(IPAddress.Parse(_sender.lsServers.SelectedItems[0].SubItems[1].Text.Split(':')[0]),
                                   int.Parse(_sender.lsServers.SelectedItems[0].SubItems[1].Text.Split(':')[1])));
            var dvaritems = server.StatusDvars.Select(pair => new ListViewItem(new[] {pair.Key, pair.Value})).ToList();
            var playeritems = server.Players.Select(player => new ListViewItem(new[] {player.Name, player.Score, player.Ping})).ToList();
            lsDvars.Items.AddRange(dvaritems.ToArray());
            lsPlayers.Items.AddRange(playeritems.ToArray());
            txtName.Text = Utils.RemoveQuakeColorCodes(Utils.GetValue(server.InfoDvars, "hostname"));
            txtMap.Text = Utils.DescribeMapName(Utils.GetValue(server.InfoDvars, "mapname"));
            txtGameType.Text = Utils.DescribeGameType(Utils.GetValue(server.InfoDvars, "gametype"));
            txtIP.Text = server.QueryEP.ToString();
        }

        private void lsPlayers_KeyDown(object sender, KeyEventArgs e)
        {
            if (lsPlayers.SelectedItems.Count > 0)
            {
                if (e.KeyCode == Keys.C && e.Control)
                {
                    var item = lsPlayers.SelectedItems[0];
                    Clipboard.SetText(string.Format("{0} - {1} - {2}", item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text));
                }
            }
        }
    }
}
