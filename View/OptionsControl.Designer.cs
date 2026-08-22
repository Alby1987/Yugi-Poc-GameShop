namespace Yugi_Poc_GameShop.View
{
    partial class OptionsControl
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MenuButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TokensLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TokensCountdownLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.InstalledGamesLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LanguagesComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.MenuButton, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.OkButton, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TokensLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TokensCountdownLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.InstalledGamesLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.LanguagesComboBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MenuButton
            // 
            this.MenuButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuButton.Location = new System.Drawing.Point(3, 543);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(394, 54);
            this.MenuButton.TabIndex = 2;
            this.MenuButton.Text = "Menu";
            this.MenuButton.UseVisualStyleBackColor = true;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OkButton.Location = new System.Drawing.Point(403, 543);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(394, 54);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(306, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tokens available:";
            // 
            // TokensLabel
            // 
            this.TokensLabel.AutoSize = true;
            this.TokensLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TokensLabel.Location = new System.Drawing.Point(403, 30);
            this.TokensLabel.Name = "TokensLabel";
            this.TokensLabel.Size = new System.Drawing.Size(13, 30);
            this.TokensLabel.TabIndex = 5;
            this.TokensLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(263, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Next token will be given in:";
            // 
            // TokensCountdownLabel
            // 
            this.TokensCountdownLabel.AutoSize = true;
            this.TokensCountdownLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TokensCountdownLabel.Location = new System.Drawing.Point(403, 60);
            this.TokensCountdownLabel.Name = "TokensCountdownLabel";
            this.TokensCountdownLabel.Size = new System.Drawing.Size(34, 30);
            this.TokensCountdownLabel.TabIndex = 7;
            this.TokensCountdownLabel.Text = "00:00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(299, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 90);
            this.label6.TabIndex = 8;
            this.label6.Text = "Games recognized:";
            // 
            // InstalledGamesLabel
            // 
            this.InstalledGamesLabel.AutoSize = true;
            this.InstalledGamesLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.InstalledGamesLabel.Location = new System.Drawing.Point(403, 90);
            this.InstalledGamesLabel.Name = "InstalledGamesLabel";
            this.InstalledGamesLabel.Size = new System.Drawing.Size(45, 90);
            this.InstalledGamesLabel.TabIndex = 9;
            this.InstalledGamesLabel.Text = "Loading";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(239, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "Card Language (requires restart)";
            // 
            // LanguagesComboBox
            // 
            this.LanguagesComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.LanguagesComboBox.FormattingEnabled = true;
            this.LanguagesComboBox.Location = new System.Drawing.Point(403, 183);
            this.LanguagesComboBox.Name = "LanguagesComboBox";
            this.LanguagesComboBox.Size = new System.Drawing.Size(394, 21);
            this.LanguagesComboBox.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.Location = new System.Drawing.Point(359, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 300);
            this.label8.TabIndex = 10;
            this.label8.Text = "About:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(403, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(271, 300);
            this.label9.TabIndex = 11;
            this.label9.Text = "Using part of code from GO-PoC-Toolset by Bitemydusto\r\n\r\nMade by Alby87\r\n\r\nLogo m" +
    "ade with AI\r\n\r\nThis is a fanwork and is not endorsed by Konami";
            // 
            // OptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OptionsControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.LanguageSelect_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox LanguagesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TokensLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TokensCountdownLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label InstalledGamesLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}
