namespace Yugi_Poc_GameShop.View
{
    partial class OpenNewBoosterControl
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
            this.LeftPictureBox = new System.Windows.Forms.PictureBox();
            this.CenterPictureBox = new System.Windows.Forms.PictureBox();
            this.RightPictureBox = new System.Windows.Forms.PictureBox();
            this.LeftRichTextBox = new System.Windows.Forms.RichTextBox();
            this.CenterRichTextBox = new System.Windows.Forms.RichTextBox();
            this.RightRichTextBox = new System.Windows.Forms.RichTextBox();
            this.MenuButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CenterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.LeftPictureBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CenterPictureBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RightPictureBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.LeftRichTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CenterRichTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.RightRichTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.MenuButton, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LeftPictureBox
            // 
            this.LeftPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPictureBox.Location = new System.Drawing.Point(3, 3);
            this.LeftPictureBox.Name = "LeftPictureBox";
            this.LeftPictureBox.Size = new System.Drawing.Size(260, 414);
            this.LeftPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.LeftPictureBox.TabIndex = 0;
            this.LeftPictureBox.TabStop = false;
            this.LeftPictureBox.Click += new System.EventHandler(this.LeftPictureBox_Click);
            // 
            // CenterPictureBox
            // 
            this.CenterPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPictureBox.Location = new System.Drawing.Point(269, 3);
            this.CenterPictureBox.Name = "CenterPictureBox";
            this.CenterPictureBox.Size = new System.Drawing.Size(260, 414);
            this.CenterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CenterPictureBox.TabIndex = 1;
            this.CenterPictureBox.TabStop = false;
            this.CenterPictureBox.Click += new System.EventHandler(this.CenterPictureBox_Click);
            // 
            // RightPictureBox
            // 
            this.RightPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPictureBox.Location = new System.Drawing.Point(535, 3);
            this.RightPictureBox.Name = "RightPictureBox";
            this.RightPictureBox.Size = new System.Drawing.Size(262, 414);
            this.RightPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.RightPictureBox.TabIndex = 2;
            this.RightPictureBox.TabStop = false;
            this.RightPictureBox.Click += new System.EventHandler(this.RightPictureBox_Click);
            // 
            // LeftRichTextBox
            // 
            this.LeftRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftRichTextBox.Location = new System.Drawing.Point(3, 423);
            this.LeftRichTextBox.Name = "LeftRichTextBox";
            this.LeftRichTextBox.ReadOnly = true;
            this.LeftRichTextBox.Size = new System.Drawing.Size(260, 114);
            this.LeftRichTextBox.TabIndex = 3;
            this.LeftRichTextBox.Text = "";
            // 
            // CenterRichTextBox
            // 
            this.CenterRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterRichTextBox.Location = new System.Drawing.Point(269, 423);
            this.CenterRichTextBox.Name = "CenterRichTextBox";
            this.CenterRichTextBox.ReadOnly = true;
            this.CenterRichTextBox.Size = new System.Drawing.Size(260, 114);
            this.CenterRichTextBox.TabIndex = 4;
            this.CenterRichTextBox.Text = "";
            // 
            // RightRichTextBox
            // 
            this.RightRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightRichTextBox.Location = new System.Drawing.Point(535, 423);
            this.RightRichTextBox.Name = "RightRichTextBox";
            this.RightRichTextBox.ReadOnly = true;
            this.RightRichTextBox.Size = new System.Drawing.Size(262, 114);
            this.RightRichTextBox.TabIndex = 5;
            this.RightRichTextBox.Text = "";
            // 
            // MenuButton
            // 
            this.MenuButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuButton.Location = new System.Drawing.Point(535, 543);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(262, 54);
            this.MenuButton.TabIndex = 6;
            this.MenuButton.Text = "Menu";
            this.MenuButton.UseVisualStyleBackColor = true;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // OpenNewBoosterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OpenNewBoosterControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CenterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox LeftPictureBox;
        private System.Windows.Forms.PictureBox CenterPictureBox;
        private System.Windows.Forms.PictureBox RightPictureBox;
        private System.Windows.Forms.RichTextBox LeftRichTextBox;
        private System.Windows.Forms.RichTextBox CenterRichTextBox;
        private System.Windows.Forms.RichTextBox RightRichTextBox;
        private System.Windows.Forms.Button MenuButton;
    }
}
