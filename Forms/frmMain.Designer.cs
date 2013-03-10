using System.Windows.Forms;

namespace aIWServerParser4.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsServers = new ComponentOwl.BetterListView.BetterListView();
            this.ServerName = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.IP = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.Players = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.Map = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.GameMode = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.HC = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.Mod = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.Ping = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.listRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFavouritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterServerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.favouritesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rCONToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundRefresh = new System.ComponentModel.BackgroundWorker();
            this.backgroundQuery = new System.ComponentModel.BackgroundWorker();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lsServers)).BeginInit();
            this.listRightClickMenu.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip.Location = new System.Drawing.Point(0, 240);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(584, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 17);
            this.toolStripStatusLabel1.Text = "Welcome!";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Step = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsServers);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 216);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Servers";
            // 
            // lsServers
            // 
            this.lsServers.AutoSizeItemsInDetailsView = true;
            this.lsServers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsServers.Columns.AddRange(new object[] {
            this.ServerName,
            this.IP,
            this.Players,
            this.Map,
            this.GameMode,
            this.HC,
            this.Mod,
            this.Ping});
            this.lsServers.ContextMenuStrip = this.listRightClickMenu;
            this.lsServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsServers.GridLines = ComponentOwl.BetterListView.BetterListViewGridLines.Grid;
            this.lsServers.Location = new System.Drawing.Point(3, 16);
            this.lsServers.MultiSelect = false;
            this.lsServers.Name = "lsServers";
            this.lsServers.Size = new System.Drawing.Size(578, 197);
            this.lsServers.TabIndex = 1;
            this.lsServers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsServers_KeyDown);
            this.lsServers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsServers_MouseDoubleClick);
            // 
            // ServerName
            // 
            this.ServerName.Name = "ServerName";
            this.ServerName.Style = ComponentOwl.BetterListView.BetterListViewColumnHeaderStyle.Sortable;
            this.ServerName.Text = "Name";
            this.ServerName.Width = 120;
            // 
            // IP
            // 
            this.IP.Name = "IP";
            this.IP.Style = ComponentOwl.BetterListView.BetterListViewColumnHeaderStyle.Sortable;
            this.IP.Text = "IP";
            this.IP.Width = 104;
            // 
            // Players
            // 
            this.Players.Name = "Players";
            this.Players.Style = ComponentOwl.BetterListView.BetterListViewColumnHeaderStyle.Sortable;
            this.Players.Text = "Players";
            this.Players.Width = 60;
            // 
            // Map
            // 
            this.Map.Name = "Map";
            this.Map.Style = ComponentOwl.BetterListView.BetterListViewColumnHeaderStyle.Sortable;
            this.Map.Text = "Map";
            this.Map.Width = 82;
            // 
            // GameMode
            // 
            this.GameMode.Name = "GameMode";
            this.GameMode.Style = ComponentOwl.BetterListView.BetterListViewColumnHeaderStyle.Sortable;
            this.GameMode.Text = "Game Mode";
            this.GameMode.Width = 81;
            // 
            // HC
            // 
            this.HC.Name = "HC";
            this.HC.Style = ComponentOwl.BetterListView.BetterListViewColumnHeaderStyle.Sortable;
            this.HC.Text = "HC";
            this.HC.Width = 38;
            // 
            // Mod
            // 
            this.Mod.Name = "Mod";
            this.Mod.Style = ComponentOwl.BetterListView.BetterListViewColumnHeaderStyle.Sortable;
            this.Mod.Text = "Mod";
            this.Mod.Width = 50;
            // 
            // Ping
            // 
            this.Ping.Name = "Ping";
            this.Ping.Style = ComponentOwl.BetterListView.BetterListViewColumnHeaderStyle.Sortable;
            this.Ping.Text = "Ping";
            this.Ping.Width = 42;
            // 
            // listRightClickMenu
            // 
            this.listRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyIPToolStripMenuItem,
            this.viewInfoToolStripMenuItem,
            this.saveToFavouritesToolStripMenuItem});
            this.listRightClickMenu.Name = "listRightClickMenu";
            this.listRightClickMenu.Size = new System.Drawing.Size(170, 70);
            this.listRightClickMenu.Opening += new System.ComponentModel.CancelEventHandler(this.listRightClickMenu_Opening);
            // 
            // copyIPToolStripMenuItem
            // 
            this.copyIPToolStripMenuItem.Name = "copyIPToolStripMenuItem";
            this.copyIPToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.copyIPToolStripMenuItem.Text = "Copy IP";
            this.copyIPToolStripMenuItem.Click += new System.EventHandler(this.copyIPToolStripMenuItem_Click);
            // 
            // viewInfoToolStripMenuItem
            // 
            this.viewInfoToolStripMenuItem.Name = "viewInfoToolStripMenuItem";
            this.viewInfoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.viewInfoToolStripMenuItem.Text = "View Info";
            this.viewInfoToolStripMenuItem.Click += new System.EventHandler(this.viewInfoToolStripMenuItem_Click);
            // 
            // saveToFavouritesToolStripMenuItem
            // 
            this.saveToFavouritesToolStripMenuItem.Name = "saveToFavouritesToolStripMenuItem";
            this.saveToFavouritesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveToFavouritesToolStripMenuItem.Text = "Save to Favourites";
            this.saveToFavouritesToolStripMenuItem.Click += new System.EventHandler(this.saveToFavouritesToolStripMenuItem_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(584, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            this.filtersToolStripMenuItem.Click += new System.EventHandler(this.filtersToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterServerToolStripMenuItem,
            this.rCONToolToolStripMenuItem,
            this.playerSearchToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // masterServerToolStripMenuItem
            // 
            this.masterServerToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.masterServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterServerToolStripMenuItem1,
            this.favouritesToolStripMenuItem1});
            this.masterServerToolStripMenuItem.Name = "masterServerToolStripMenuItem";
            this.masterServerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.masterServerToolStripMenuItem.Text = "Server List";
            // 
            // masterServerToolStripMenuItem1
            // 
            this.masterServerToolStripMenuItem1.Checked = true;
            this.masterServerToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.masterServerToolStripMenuItem1.Name = "masterServerToolStripMenuItem1";
            this.masterServerToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.masterServerToolStripMenuItem1.Text = "Master Server";
            this.masterServerToolStripMenuItem1.Click += new System.EventHandler(this.masterServerToolStripMenuItem1_Click);
            // 
            // favouritesToolStripMenuItem1
            // 
            this.favouritesToolStripMenuItem1.Name = "favouritesToolStripMenuItem1";
            this.favouritesToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.favouritesToolStripMenuItem1.Text = "Favourites";
            this.favouritesToolStripMenuItem1.Click += new System.EventHandler(this.favouritesToolStripMenuItem1_Click);
            // 
            // rCONToolToolStripMenuItem
            // 
            this.rCONToolToolStripMenuItem.Name = "rCONToolToolStripMenuItem";
            this.rCONToolToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rCONToolToolStripMenuItem.Text = "RCON Tool";
            this.rCONToolToolStripMenuItem.Click += new System.EventHandler(this.rCONToolToolStripMenuItem_Click);
            // 
            // playerSearchToolStripMenuItem
            // 
            this.playerSearchToolStripMenuItem.Name = "playerSearchToolStripMenuItem";
            this.playerSearchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.playerSearchToolStripMenuItem.Text = "Player Search";
            this.playerSearchToolStripMenuItem.Click += new System.EventHandler(this.playerSearchToolStripMenuItem_Click);
            // 
            // backgroundRefresh
            // 
            this.backgroundRefresh.WorkerReportsProgress = true;
            this.backgroundRefresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundRefresh_DoWork);
            this.backgroundRefresh.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundRefresh_RunWorkerCompleted);
            // 
            // backgroundQuery
            // 
            this.backgroundQuery.WorkerReportsProgress = true;
            this.backgroundQuery.WorkerSupportsCancellation = true;
            this.backgroundQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundQuery_DoWork);
            this.backgroundQuery.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundQuery_ProgressChanged);
            this.backgroundQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundQuery_RunWorkerCompleted);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "frmMain";
            this.Text = "4D1 Server Parser 4 (IW5M Edition)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lsServers)).EndInit();
            this.listRightClickMenu.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterServerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem favouritesToolStripMenuItem1;
        internal ComponentOwl.BetterListView.BetterListView lsServers;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader IP;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader Map;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader GameMode;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader HC;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader Mod;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader Ping;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader ServerName;
        private System.Windows.Forms.ToolStripMenuItem rCONToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerSearchToolStripMenuItem;
        internal System.ComponentModel.BackgroundWorker backgroundRefresh;
        internal System.ComponentModel.BackgroundWorker backgroundQuery;
        private System.Windows.Forms.ContextMenuStrip listRightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem copyIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFavouritesToolStripMenuItem;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader Players;
    }
}

