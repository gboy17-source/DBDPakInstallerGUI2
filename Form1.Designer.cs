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
            // dbdPakInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DBDPakInstallerGUI2.Properties.Resources.wwww;
            this.ClientSize = new System.Drawing.Size(1104, 740);
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
    }
}

