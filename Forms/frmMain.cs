using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using ComponentOwl.BetterListView;
using aIWServerParser4.Classes;

namespace aIWServerParser4.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            lsServers.ItemComparer = new ItemComparer();
        }

        #region Form Events
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            ReadUI();
            new Thread(Utils.CheckForUpdates).Start(this);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUI();
            //backgroundQuery.CancelAsync();
            //backgroundRefresh.CancelAsync();
        }

        private void lsServers_KeyDown(object sender, KeyEventArgs e)
        {
            if (lsServers.IsAnythingSelected)
                if (e.KeyCode == Keys.C && e.Control)
                    Clipboard.SetText(lsServers.SelectedItems[0].SubItems[1].Text);
        }
        #endregion

        #region Menu Strip Events
        private void refreshToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            QueryServer.Query = false;
            backgroundQuery.CancelAsync();
            Utils.ClearVariables();
            lsServers.Items.Clear();
            toolStripStatusLabel1.Text = Variables.Favourites
                                             ? "Reading favourites from file"
                                             : "Querying master server for servers";
            backgroundRefresh.RunWorkerAsync();
        }

        private void masterServerToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            Variables.Favourites = false;
            masterServerToolStripMenuItem1.Checked = true;
            favouritesToolStripMenuItem1.Checked = false;
        }

        private void favouritesToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            Variables.Favourites = true;
            masterServerToolStripMenuItem1.Checked = false;
            favouritesToolStripMenuItem1.Checked = true;
        }

        private void filtersToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var frm = new frmFilters(this);
            frm.Show();
        }

        private void rCONToolToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var frm = new frmRcon();
            frm.Show();
        }

        private void playerSearchToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var frm = new frmPlayerSearch();
            frm.Show();
        }

        private void listRightClickMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!lsServers.IsAnythingSelected)
            {
                copyIPToolStripMenuItem.Enabled = false;
                viewInfoToolStripMenuItem.Enabled = false;
                saveToFavouritesToolStripMenuItem.Enabled = false;
            }
            else
            {
                copyIPToolStripMenuItem.Enabled = true;
                viewInfoToolStripMenuItem.Enabled = true;
                saveToFavouritesToolStripMenuItem.Enabled = true;
            }
        }

        private void copyIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lsServers.SelectedItems[0].SubItems[1].Text);
        }

        private void viewInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmInfo(this);
            frm.Show();
        }

        private void saveToFavouritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var server = lsServers.SelectedItems[0].SubItems[1].Text;
            File.AppendAllText("favourites.txt", server + "\n");
        }

        private void lsServers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!lsServers.IsAnythingSelected) return;
            var frm = new frmInfo(this);
            frm.Show();
        }
        #endregion

        #region Background Worker
        private void backgroundRefresh_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            QueryMaster.Start();
        }

        private void backgroundRefresh_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Querying " + Variables.Servers.Count + " servers";
            backgroundQuery.RunWorkerAsync();
        }

        private void backgroundQuery_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            QueryServer.Start(this);
            var start = DateTime.UtcNow;
            QueryServer.QueryServers();
            while ((DateTime.UtcNow - start).TotalSeconds < 10 && QueryServer.Query)
            {
                lock (Variables.Servers)
                {
                    var servers = Variables.Servers.Where(server => server.Status == ServerStatus.Display).ToList();
                    foreach (var server in servers)
                    {
                        Variables.Servers.Remove(server);
                        QueryServer.ProcessServer(server);
                        Variables.Servers.Add(server);
                    }
                    if (Variables.Servers.Count == Variables.ServersDone)
                        break;
                }
                Thread.Sleep(150);
            }
        }

        private void backgroundQuery_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            var element = (BetterListViewItem)e.UserState;
            lsServers.Items.Add(element);
            toolStripStatusLabel1.Text = string.Format("Queried {0} out of {1} servers",
                                                       Variables.ServersFiltered + Variables.ServersDone,
                                                       Variables.Servers.Count);
            toolStripProgressBar1.Maximum = Variables.Servers.Count;
            toolStripProgressBar1.PerformStep();
        }

        private void backgroundQuery_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format("Showing {0} ({1} players) out of {2} servers", Variables.ServersDone,
                                                       Variables.PlayerCount, Variables.Servers.Count);
            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
        }
        #endregion

        private void SaveUI()
        {
            using (var writer = new StringWriter())
            {
                writer.WriteLine(Size.Height);
                writer.WriteLine(Size.Width);
                writer.WriteLine(ServerName.Width);
                writer.WriteLine(IP.Width);
                writer.WriteLine(Players.Width);
                writer.WriteLine(Map.Width);
                writer.WriteLine(GameMode.Width);
                writer.WriteLine(HC.Width);
                writer.WriteLine(Mod.Width);
                writer.WriteLine(Ping.Width);
                File.WriteAllText("parser_settings.dat", writer.ToString());
            }
        }

        private void ReadUI()
        {
            if (!File.Exists("parser_settings.dat")) return;
            var lines = File.ReadAllLines("parser_settings.dat");
            if (lines.Length != 10) return;
            Size = new Size(int.Parse(lines[1]), int.Parse(lines[0]));
            ServerName.Width = int.Parse(lines[2]);
            IP.Width = int.Parse(lines[3]);
            Players.Width = int.Parse(lines[4]);
            Map.Width = int.Parse(lines[5]);
            GameMode.Width = int.Parse(lines[6]);
            HC.Width = int.Parse(lines[7]);
            Mod.Width = int.Parse(lines[8]);
            Ping.Width = int.Parse(lines[9]);
            /*lsServers.Columns.Clear();
            lsServers.Columns.AddRange(new object[]
                                           {
                                               ServerName,
                                               IP,
                                               Players,
                                               Map,
                                               GameMode,
                                               HC,
                                               Mod,
                                               Ping
                                           });*/
        }
    }
}
