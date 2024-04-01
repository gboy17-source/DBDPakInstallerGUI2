namespace DBDPakInstallerGUI2
{
    partial class dbdPakInstaller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dbdPakInstaller));
            this.selectPaksFolder = new System.Windows.Forms.Button();
            this.selectPakBakFile = new System.Windows.Forms.Button();
            this.EpicGames = new System.Windows.Forms.RadioButton();
            this.Steam = new System.Windows.Forms.RadioButton();
            this.EXECUTE = new System.Windows.Forms.Button();
            this.PakBypass = new System.Windows.Forms.Button();
            this.Uninstall = new System.Windows.Forms.Button();
            this.modsList = new System.Windows.Forms.ListBox();
            this.modName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectPaksFolder
            // 
            this.selectPaksFolder.BackColor = System.Drawing.Color.Transparent;
            this.selectPaksFolder.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.selectPaksFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.selectPaksFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.selectPaksFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectPaksFolder.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPaksFolder.ForeColor = System.Drawing.Color.PowderBlue;
            this.selectPaksFolder.Location = new System.Drawing.Point(12, 32);
            this.selectPaksFolder.Name = "selectPaksFolder";
            this.selectPaksFolder.Size = new System.Drawing.Size(277, 89);
            this.selectPaksFolder.TabIndex = 0;
            this.selectPaksFolder.Text = "Select Paks folder";
            this.selectPaksFolder.UseVisualStyleBackColor = false;
            this.selectPaksFolder.Click += new System.EventHandler(this.selectPaksFolder_Click);
            // 
            // selectPakBakFile
            // 
            this.selectPakBakFile.BackColor = System.Drawing.Color.Transparent;
            this.selectPakBakFile.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.selectPakBakFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.selectPakBakFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.selectPakBakFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectPakBakFile.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPakBakFile.ForeColor = System.Drawing.Color.PowderBlue;
            this.selectPakBakFile.Location = new System.Drawing.Point(12, 145);
            this.selectPakBakFile.Name = "selectPakBakFile";
            this.selectPakBakFile.Size = new System.Drawing.Size(277, 90);
            this.selectPakBakFile.TabIndex = 1;
            this.selectPakBakFile.Text = "Select .pak/.bak file";
            this.selectPakBakFile.UseVisualStyleBackColor = false;
            this.selectPakBakFile.Click += new System.EventHandler(this.selectPakBakFile_Click);
            // 
            // EpicGames
            // 
            this.EpicGames.AutoSize = true;
            this.EpicGames.BackColor = System.Drawing.Color.Transparent;
            this.EpicGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EpicGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.EpicGames.ForeColor = System.Drawing.Color.PowderBlue;
            this.EpicGames.Location = new System.Drawing.Point(21, 256);
            this.EpicGames.Name = "EpicGames";
            this.EpicGames.Size = new System.Drawing.Size(145, 29);
            this.EpicGames.TabIndex = 2;
            this.EpicGames.TabStop = true;
            this.EpicGames.Text = "Epic Games";
            this.EpicGames.UseVisualStyleBackColor = false;
            this.EpicGames.CheckedChanged += new System.EventHandler(this.EpicGames_CheckedChanged);
            // 
            // Steam
            // 
            this.Steam.AutoSize = true;
            this.Steam.BackColor = System.Drawing.Color.Transparent;
            this.Steam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Steam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.Steam.ForeColor = System.Drawing.Color.PowderBlue;
            this.Steam.Location = new System.Drawing.Point(190, 256);
            this.Steam.Name = "Steam";
            this.Steam.Size = new System.Drawing.Size(90, 29);
            this.Steam.TabIndex = 3;
            this.Steam.TabStop = true;
            this.Steam.Text = "Steam";
            this.Steam.UseVisualStyleBackColor = false;
            this.Steam.CheckedChanged += new System.EventHandler(this.Steam_CheckedChanged);
            // 
            // EXECUTE
            // 
            this.EXECUTE.BackColor = System.Drawing.Color.Transparent;
            this.EXECUTE.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.EXECUTE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.EXECUTE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.EXECUTE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EXECUTE.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXECUTE.ForeColor = System.Drawing.Color.PowderBlue;
            this.EXECUTE.Location = new System.Drawing.Point(12, 291);
            this.EXECUTE.Name = "EXECUTE";
            this.EXECUTE.Size = new System.Drawing.Size(277, 90);
            this.EXECUTE.TabIndex = 4;
            this.EXECUTE.Text = "EXECUTE";
            this.EXECUTE.UseVisualStyleBackColor = false;
            this.EXECUTE.Click += new System.EventHandler(this.EXECUTE_Click);
            // 
            // PakBypass
            // 
            this.PakBypass.BackColor = System.Drawing.Color.Transparent;
            this.PakBypass.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.PakBypass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.PakBypass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.PakBypass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PakBypass.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PakBypass.ForeColor = System.Drawing.Color.PowderBlue;
            this.PakBypass.Location = new System.Drawing.Point(12, 606);
            this.PakBypass.Name = "PakBypass";
            this.PakBypass.Size = new System.Drawing.Size(371, 96);
            this.PakBypass.TabIndex = 5;
            this.PakBypass.Text = "Pak Bypass";
            this.PakBypass.UseVisualStyleBackColor = false;
            this.PakBypass.Click += new System.EventHandler(this.PakBypass_Click);
            // 
            // Uninstall
            // 
            this.Uninstall.BackColor = System.Drawing.Color.Transparent;
            this.Uninstall.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.Uninstall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.Uninstall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.Uninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Uninstall.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Uninstall.ForeColor = System.Drawing.Color.PowderBlue;
            this.Uninstall.Location = new System.Drawing.Point(811, 612);
            this.Uninstall.Name = "Uninstall";
            this.Uninstall.Size = new System.Drawing.Size(269, 90);
            this.Uninstall.TabIndex = 7;
            this.Uninstall.Text = "Uninstall";
            this.Uninstall.UseVisualStyleBackColor = false;
            this.Uninstall.Click += new System.EventHandler(this.Uninstall_Click);
            // 
            // modsList
            // 
            this.modsList.BackColor = System.Drawing.Color.DarkSlateGray;
            this.modsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modsList.ForeColor = System.Drawing.Color.PowderBlue;
            this.modsList.FormattingEnabled = true;
            this.modsList.ItemHeight = 25;
            this.modsList.Location = new System.Drawing.Point(599, 55);
            this.modsList.Name = "modsList";
            this.modsList.Size = new System.Drawing.Size(235, 504);
            this.modsList.TabIndex = 8;
            this.modsList.SelectedIndexChanged += new System.EventHandler(this.modsList_SelectedIndexChanged);
            // 
            // modName
            // 
            this.modName.BackColor = System.Drawing.Color.DarkSlateGray;
            this.modName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.modName.ForeColor = System.Drawing.Color.PowderBlue;
            this.modName.Location = new System.Drawing.Point(852, 55);
            this.modName.Multiline = true;
            this.modName.Name = "modName";
            this.modName.Size = new System.Drawing.Size(228, 504);
            this.modName.TabIndex = 9;
            this.modName.WordWrap = false;
            this.modName.TextChanged += new System.EventHandler(this.modName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label1.ForeColor = System.Drawing.Color.PowderBlue;
            this.label1.Location = new System.Drawing.Point(672, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 27);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mods list";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.75F);
            this.label2.ForeColor = System.Drawing.Color.PowderBlue;
            this.label2.Location = new System.Drawing.Point(868, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name your mod here";
            // 
            // dbdPakInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::DBDPakInstallerGUI2.Properties.Resources.wwww;
            this.ClientSize = new System.Drawing.Size(1104, 740);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modName);
            this.Controls.Add(this.modsList);
            this.Controls.Add(this.Uninstall);
            this.Controls.Add(this.PakBypass);
            this.Controls.Add(this.EXECUTE);
            this.Controls.Add(this.Steam);
            this.Controls.Add(this.EpicGames);
            this.Controls.Add(this.selectPakBakFile);
            this.Controls.Add(this.selectPaksFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "dbdPakInstaller";
            this.Text = "Gboy\'s DBD Pak Installer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectPaksFolder;
        private System.Windows.Forms.Button selectPakBakFile;
        private System.Windows.Forms.RadioButton EpicGames;
        private System.Windows.Forms.RadioButton Steam;
        private System.Windows.Forms.Button EXECUTE;
        private System.Windows.Forms.Button PakBypass;
        private System.Windows.Forms.Button Uninstall;
        private System.Windows.Forms.ListBox modsList;
        private System.Windows.Forms.TextBox modName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

