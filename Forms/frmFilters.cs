using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentOwl.BetterListView;
using aIWServerParser4.Classes;

namespace aIWServerParser4.Forms
{
    public partial class frmFilters : Form
    {
        private readonly frmMain _frmMain;

        public frmFilters(frmMain sender)
        {
            InitializeComponent();
            _frmMain = sender;
            filterName.Text = Variables.Filter.ServerName;
            filterPlayer.Text = Variables.Filter.PlayerName;
            filterHC.CheckState = Variables.Filter.Hardcore;
            filterMap.Text = Variables.Filter.Map;
            filterType.Text = Variables.Filter.Mode;
            filterMod.Text = Variables.Filter.Mod;
            filterFull.Checked = Variables.Filter.Full;
            filterEmpty.Checked = Variables.Filter.Empty;
            Variables.ItemsToAdd = new List<BetterListViewItem>();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (_frmMain.backgroundQuery.IsBusy)
            {
                MessageBox.Show("Query is still running, try again after the query has finished.", "4D1 Server Parser 4");
                return;
            }
            Variables.Filter.ServerName = filterName.Text;
            Variables.Filter.PlayerName = filterPlayer.Text;
            Variables.Filter.Hardcore = filterHC.CheckState;
            Variables.Filter.Map = filterMap.Text;
            Variables.Filter.Mode = filterType.Text;
            Variables.Filter.Mod = filterMod.Text;
            Variables.Filter.Full = filterFull.Checked;
            Variables.Filter.Empty = filterEmpty.Checked;
            _frmMain.lsServers.Items.Clear();
            Variables.ItemsToAdd.Clear();
            Variables.ServersDone = 0;
            Variables.ServersFiltered = 0;
            Variables.PlayerCount = 0;
            lock (Variables.Servers)
            {
                var servers = Variables.Servers.Where(server => server.Status == ServerStatus.Filtered || server.Status == ServerStatus.Done).ToList();
                foreach (var server in servers)
                {
                    QueryServer.ProcessServer(server, false);
                }
            }
            _frmMain.lsServers.BeginUpdate();
            foreach (var element in Variables.ItemsToAdd)
            {
                _frmMain.lsServers.Items.Add(element);
            }
            _frmMain.lsServers.EndUpdate();
            _frmMain.toolStripStatusLabel1.Text = string.Format("Showing {0} ({1} players) out of {2} servers", Variables.ServersDone,
                                           Variables.PlayerCount, Variables.Servers.Count);
            _frmMain.toolStripProgressBar1.Value = _frmMain.toolStripProgressBar1.Maximum;
        }
    }
}
