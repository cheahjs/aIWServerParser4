using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aIWServerParser4.Classes;

namespace aIWServerParser4.Forms
{
    public partial class frmPlayerSearch : Form
    {
        #region Variables
        List<Server> _search = new List<Server>();
        #endregion

        #region Form Methods
        public frmPlayerSearch()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            findPlayer(txtSearch.Text);
        }
        private void findPlayer(string name)
        {
            var foundplayers = new Dictionary<string, Server>();
            var servers = _search;
            var randomizer = new Random(Environment.TickCount);
            foreach (var server in servers)
            {
                foreach (var player in server.Players)
                {
                    if (!string.IsNullOrEmpty(player.Name) && player.Name != "\0")
                    {
                        if (player.Name.ToUpper().IndexOf(name.ToUpper()) != -1 || player.Name.ToUpper().IndexOf(name.ToUpper()) != -1)
                        {
                            var playername = player.Name + randomizer.Next(1000000, 9999999);
                            foundplayers.Add(playername, server);
                        }
                    }
                }
            }
            displayPlayers(foundplayers);
        }
        private void displayPlayers(Dictionary<string, Server> players)
        {
            listViewFound.Items.Clear();
            var length = 0;
            foreach (var item in players)
            {
                try
                {
                    var listitem = listViewFound.Items.Add(Utils.RemoveQuakeColorCodes(item.Key));
                    listitem.SubItems.Add(Utils.RemoveQuakeColorCodes(Utils.GetValue(item.Value.StatusDvars, "sv_hostname")));
                    listitem.SubItems.Add(item.Value.QueryEP.ToString());
                    length = (Utils.RemoveQuakeColorCodes(item.Key).Length - 7);
                    listitem.Text = item.Key.Substring(0, length);
                }
                catch { }
            }
            listViewFound.Sort();
        }
        private void frmSearchPlayer_Load(object sender, EventArgs e)
        {
            _search.AddRange(Variables.Servers.Where(server => server.Status == ServerStatus.Done));
        }

        private void listViewFound_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Control)
            {
                var selectedItem = listViewFound.SelectedItems[0];
                if (selectedItem != null)
                {
                    Clipboard.SetDataObject(selectedItem.Text + " - " + selectedItem.SubItems[1].Text + " - " + selectedItem.SubItems[2].Text);
                    e.Handled = true;
                }
            }
        }
        private void listViewFound_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewFound.SelectedItems.Count > 0)
            {
            }
        }
        #endregion
    }
}
