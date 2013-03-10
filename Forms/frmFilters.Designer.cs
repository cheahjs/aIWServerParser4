namespace aIWServerParser4.Forms
{
    partial class frmFilters
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
            this.label1 = new System.Windows.Forms.Label();
            this.filterName = new System.Windows.Forms.TextBox();
            this.filterPlayer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filterHC = new System.Windows.Forms.CheckBox();
            this.filterMap = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.filterType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.filterMod = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.filterFull = new System.Windows.Forms.CheckBox();
            this.filterEmpty = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name: ";
            // 
            // filterName
            // 
            this.filterName.Location = new System.Drawing.Point(93, 6);
            this.filterName.Name = "filterName";
            this.filterName.Size = new System.Drawing.Size(179, 20);
            this.filterName.TabIndex = 1;
            // 
            // filterPlayer
            // 
            this.filterPlayer.Location = new System.Drawing.Point(93, 32);
            this.filterPlayer.Name = "filterPlayer";
            this.filterPlayer.Size = new System.Drawing.Size(179, 20);
            this.filterPlayer.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Player Name: ";
            // 
            // filterHC
            // 
            this.filterHC.AutoSize = true;
            this.filterHC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.filterHC.Checked = true;
            this.filterHC.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.filterHC.Location = new System.Drawing.Point(11, 60);
            this.filterHC.Name = "filterHC";
            this.filterHC.Size = new System.Drawing.Size(70, 17);
            this.filterHC.TabIndex = 4;
            this.filterHC.Text = "Hardcore";
            this.filterHC.ThreeState = true;
            this.filterHC.UseVisualStyleBackColor = true;
            // 
            // filterMap
            // 
            this.filterMap.FormattingEnabled = true;
            this.filterMap.Items.AddRange(new object[] {
            "Any",
            "Lockdown",
            "Bootleg",
            "Mission",
            "Carbon",
            "Dome",
            "Downturn",
            "Hardhat",
            "Interchange",
            "Fallen",
            "Bakaara",
            "Resistance",
            "Arkaden",
            "Output",
            "Seatown",
            "Underground",
            "Village",
            "Overwatch",
            "Liberation",
            "Piazza",
            "Black Box",
            "Sanctuary",
            "Foundation",
            "Oasis",
            "Decommission",
            "Off Shore",
            "Gulch",
            "Boardwalk",
            "Parish"});
            this.filterMap.Location = new System.Drawing.Point(93, 129);
            this.filterMap.Name = "filterMap";
            this.filterMap.Size = new System.Drawing.Size(179, 21);
            this.filterMap.TabIndex = 6;
            this.filterMap.Text = "Any";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Map:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Game Type";
            // 
            // filterType
            // 
            this.filterType.FormattingEnabled = true;
            this.filterType.Items.AddRange(new object[] {
            "Any",
            "Team Deathmatch",
            "Free-for-all",
            "Domination",
            "Sabotage",
            "Search & Destroy",
            "Arena",
            "Demolition",
            "Capture the Flag",
            "One-Flag CTF",
            "Global Thermo-Nuclear War",
            "Headquarters",
            "Gun Game",
            "Sharpshooter",
            "One in the Chamber",
            "VIP",
            "Kill Confirmed",
            "Infected",
            "Juggernaut",
            "Team Juggernaut",
            "Drop Zone"});
            this.filterType.Location = new System.Drawing.Point(93, 156);
            this.filterType.Name = "filterType";
            this.filterType.Size = new System.Drawing.Size(179, 21);
            this.filterType.TabIndex = 8;
            this.filterType.Text = "Any";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mod:";
            // 
            // filterMod
            // 
            this.filterMod.FormattingEnabled = true;
            this.filterMod.Items.AddRange(new object[] {
            "*",
            "None"});
            this.filterMod.Location = new System.Drawing.Point(93, 183);
            this.filterMod.Name = "filterMod";
            this.filterMod.Size = new System.Drawing.Size(179, 21);
            this.filterMod.TabIndex = 12;
            this.filterMod.Text = "*";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(176, 212);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(96, 23);
            this.btnFilter.TabIndex = 13;
            this.btnFilter.Text = "Apply Filters";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // filterFull
            // 
            this.filterFull.AutoSize = true;
            this.filterFull.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.filterFull.Checked = true;
            this.filterFull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filterFull.Location = new System.Drawing.Point(11, 83);
            this.filterFull.Name = "filterFull";
            this.filterFull.Size = new System.Drawing.Size(81, 17);
            this.filterFull.TabIndex = 14;
            this.filterFull.Text = "Full Servers";
            this.filterFull.UseVisualStyleBackColor = true;
            // 
            // filterEmpty
            // 
            this.filterEmpty.AutoSize = true;
            this.filterEmpty.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.filterEmpty.Checked = true;
            this.filterEmpty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filterEmpty.Location = new System.Drawing.Point(11, 106);
            this.filterEmpty.Name = "filterEmpty";
            this.filterEmpty.Size = new System.Drawing.Size(94, 17);
            this.filterEmpty.TabIndex = 15;
            this.filterEmpty.Text = "Empty Servers";
            this.filterEmpty.UseVisualStyleBackColor = true;
            // 
            // frmFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 250);
            this.Controls.Add(this.filterEmpty);
            this.Controls.Add(this.filterFull);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.filterMod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.filterType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.filterMap);
            this.Controls.Add(this.filterHC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.filterPlayer);
            this.Controls.Add(this.filterName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFilters";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Filters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filterName;
        private System.Windows.Forms.TextBox filterPlayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox filterHC;
        private System.Windows.Forms.ComboBox filterMap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox filterType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox filterMod;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.CheckBox filterFull;
        private System.Windows.Forms.CheckBox filterEmpty;
    }
}