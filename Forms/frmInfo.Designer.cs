namespace aIWServerParser4.Forms
{
    partial class frmInfo
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
            this.lsDvars = new System.Windows.Forms.ListView();
            this.Dvar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsPlayers = new System.Windows.Forms.ListView();
            this.ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Score = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ping = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGameType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsDvars
            // 
            this.lsDvars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Dvar,
            this.Value});
            this.lsDvars.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsDvars.FullRowSelect = true;
            this.lsDvars.GridLines = true;
            this.lsDvars.Location = new System.Drawing.Point(0, 220);
            this.lsDvars.MultiSelect = false;
            this.lsDvars.Name = "lsDvars";
            this.lsDvars.Size = new System.Drawing.Size(284, 124);
            this.lsDvars.TabIndex = 0;
            this.lsDvars.UseCompatibleStateImageBehavior = false;
            this.lsDvars.View = System.Windows.Forms.View.Details;
            // 
            // Dvar
            // 
            this.Dvar.Text = "Dvar";
            this.Dvar.Width = 136;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 125;
            // 
            // lsPlayers
            // 
            this.lsPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnName,
            this.Score,
            this.Ping});
            this.lsPlayers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsPlayers.FullRowSelect = true;
            this.lsPlayers.GridLines = true;
            this.lsPlayers.Location = new System.Drawing.Point(0, 123);
            this.lsPlayers.MultiSelect = false;
            this.lsPlayers.Name = "lsPlayers";
            this.lsPlayers.Size = new System.Drawing.Size(284, 97);
            this.lsPlayers.TabIndex = 7;
            this.lsPlayers.UseCompatibleStateImageBehavior = false;
            this.lsPlayers.View = System.Windows.Forms.View.Details;
            this.lsPlayers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsPlayers_KeyDown);
            // 
            // ColumnName
            // 
            this.ColumnName.Text = "Name";
            this.ColumnName.Width = 156;
            // 
            // Score
            // 
            this.Score.Text = "Score";
            // 
            // Ping
            // 
            this.Ping.Text = "Ping";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(84, 19);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(188, 20);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Map:";
            // 
            // txtMap
            // 
            this.txtMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMap.Location = new System.Drawing.Point(84, 71);
            this.txtMap.Name = "txtMap";
            this.txtMap.ReadOnly = true;
            this.txtMap.Size = new System.Drawing.Size(188, 20);
            this.txtMap.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Game Type:";
            // 
            // txtGameType
            // 
            this.txtGameType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGameType.Location = new System.Drawing.Point(84, 97);
            this.txtGameType.Name = "txtGameType";
            this.txtGameType.ReadOnly = true;
            this.txtGameType.Size = new System.Drawing.Size(188, 20);
            this.txtGameType.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "IP:";
            // 
            // txtIP
            // 
            this.txtIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIP.Location = new System.Drawing.Point(84, 45);
            this.txtIP.Name = "txtIP";
            this.txtIP.ReadOnly = true;
            this.txtIP.Size = new System.Drawing.Size(188, 20);
            this.txtIP.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtGameType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMap);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 123);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 344);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsPlayers);
            this.Controls.Add(this.lsDvars);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Server Info";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsDvars;
        private System.Windows.Forms.ColumnHeader Dvar;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.ListView lsPlayers;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader Score;
        private System.Windows.Forms.ColumnHeader Ping;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGameType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}