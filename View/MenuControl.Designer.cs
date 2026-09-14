namespace Yugi_Poc_GameShop.View
{
    partial class MenuControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OpenBoosterPackButton = new System.Windows.Forms.Button();
            this.OpenCardTraderButton = new System.Windows.Forms.Button();
            this.OpenMagicBoosterButton = new System.Windows.Forms.Button();
            this.OpenOptionsButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.DuplicatesLabel = new System.Windows.Forms.Label();
            this.PointsLabel = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.TokensLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.OpenBoosterPackButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.OpenCardTraderButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.OpenMagicBoosterButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.OpenOptionsButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // OpenBoosterPackButton
            // 
            this.OpenBoosterPackButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenBoosterPackButton.Location = new System.Drawing.Point(3, 363);
            this.OpenBoosterPackButton.Name = "OpenBoosterPackButton";
            this.OpenBoosterPackButton.Size = new System.Drawing.Size(794, 54);
            this.OpenBoosterPackButton.TabIndex = 0;
            this.OpenBoosterPackButton.Text = "Open Booster Pack";
            this.OpenBoosterPackButton.UseVisualStyleBackColor = true;
            this.OpenBoosterPackButton.Click += new System.EventHandler(this.OpenBoosterPackButton_Click);
            // 
            // OpenCardTraderButton
            // 
            this.OpenCardTraderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenCardTraderButton.Location = new System.Drawing.Point(3, 423);
            this.OpenCardTraderButton.Name = "OpenCardTraderButton";
            this.OpenCardTraderButton.Size = new System.Drawing.Size(794, 54);
            this.OpenCardTraderButton.TabIndex = 1;
            this.OpenCardTraderButton.Text = "Trade one card for another one";
            this.OpenCardTraderButton.UseVisualStyleBackColor = true;
            this.OpenCardTraderButton.Click += new System.EventHandler(this.OpenCardTraderButton_Click);
            // 
            // OpenMagicBoosterButton
            // 
            this.OpenMagicBoosterButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenMagicBoosterButton.Location = new System.Drawing.Point(3, 483);
            this.OpenMagicBoosterButton.Name = "OpenMagicBoosterButton";
            this.OpenMagicBoosterButton.Size = new System.Drawing.Size(794, 54);
            this.OpenMagicBoosterButton.TabIndex = 2;
            this.OpenMagicBoosterButton.Text = "Tribute 3 cards to open a \"Heart of the Cards\" booster";
            this.OpenMagicBoosterButton.UseVisualStyleBackColor = true;
            this.OpenMagicBoosterButton.Click += new System.EventHandler(this.OpenMagicBoosterButton_Click);
            // 
            // OpenOptionsButton
            // 
            this.OpenOptionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenOptionsButton.Location = new System.Drawing.Point(3, 543);
            this.OpenOptionsButton.Name = "OpenOptionsButton";
            this.OpenOptionsButton.Size = new System.Drawing.Size(794, 54);
            this.OpenOptionsButton.TabIndex = 4;
            this.OpenOptionsButton.Text = "Options";
            this.OpenOptionsButton.UseVisualStyleBackColor = true;
            this.OpenOptionsButton.Click += new System.EventHandler(this.OpenOptionsButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(794, 294);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox4, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.DuplicatesLabel, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.PointsLabel, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox3, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.TokensLabel, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 303);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 54);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(116, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(107, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(568, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(107, 48);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // DuplicatesLabel
            // 
            this.DuplicatesLabel.AutoSize = true;
            this.DuplicatesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DuplicatesLabel.Location = new System.Drawing.Point(681, 0);
            this.DuplicatesLabel.Name = "DuplicatesLabel";
            this.DuplicatesLabel.Size = new System.Drawing.Size(110, 54);
            this.DuplicatesLabel.TabIndex = 5;
            this.DuplicatesLabel.Text = "0";
            this.DuplicatesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PointsLabel
            // 
            this.PointsLabel.AutoSize = true;
            this.PointsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PointsLabel.Location = new System.Drawing.Point(455, 0);
            this.PointsLabel.Name = "PointsLabel";
            this.PointsLabel.Size = new System.Drawing.Size(107, 54);
            this.PointsLabel.TabIndex = 4;
            this.PointsLabel.Text = "0";
            this.PointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(342, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(107, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // TokensLabel
            // 
            this.TokensLabel.AutoSize = true;
            this.TokensLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TokensLabel.Location = new System.Drawing.Point(229, 0);
            this.TokensLabel.Name = "TokensLabel";
            this.TokensLabel.Size = new System.Drawing.Size(107, 54);
            this.TokensLabel.TabIndex = 3;
            this.TokensLabel.Text = "0";
            this.TokensLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button OpenBoosterPackButton;
        private System.Windows.Forms.Button OpenCardTraderButton;
        private System.Windows.Forms.Button OpenMagicBoosterButton;
        private System.Windows.Forms.Button OpenOptionsButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label TokensLabel;
        private System.Windows.Forms.Label PointsLabel;
        private System.Windows.Forms.Label DuplicatesLabel;
    }
}
