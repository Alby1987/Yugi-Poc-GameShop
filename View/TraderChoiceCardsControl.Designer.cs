namespace Yugi_Poc_GameShop.View
{
    partial class TraderChoiceCardsControl
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
            this.LeftListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CardPictureBox = new System.Windows.Forms.PictureBox();
            this.DescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.MenuButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.UpperGroupBox = new System.Windows.Forms.GroupBox();
            this.UpperListView = new System.Windows.Forms.ListView();
            this.LowerGroupBox = new System.Windows.Forms.GroupBox();
            this.LowerListView = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CardPictureBox)).BeginInit();
            this.UpperGroupBox.SuspendLayout();
            this.LowerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.LeftListView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CardPictureBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionRichTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ResetButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ConfirmButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.MenuButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.SearchTextBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.UpperGroupBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.LowerGroupBox, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LeftListView
            // 
            this.LeftListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.LeftListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftListView.FullRowSelect = true;
            this.LeftListView.HideSelection = false;
            this.LeftListView.Location = new System.Drawing.Point(3, 3);
            this.LeftListView.MultiSelect = false;
            this.LeftListView.Name = "LeftListView";
            this.tableLayoutPanel1.SetRowSpan(this.LeftListView, 3);
            this.LeftListView.Size = new System.Drawing.Size(260, 534);
            this.LeftListView.TabIndex = 2;
            this.LeftListView.UseCompatibleStateImageBehavior = false;
            this.LeftListView.View = System.Windows.Forms.View.Details;
            this.LeftListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LeftListView_ColumnClick);
            this.LeftListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.LeftListView_ItemDrag);
            this.LeftListView.SelectedIndexChanged += new System.EventHandler(this.LeftListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Amount";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Y";
            this.columnHeader3.Width = 20;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "K";
            this.columnHeader4.Width = 20;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "J";
            this.columnHeader5.Width = 20;
            // 
            // CardPictureBox
            // 
            this.CardPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardPictureBox.Location = new System.Drawing.Point(269, 3);
            this.CardPictureBox.Name = "CardPictureBox";
            this.tableLayoutPanel1.SetRowSpan(this.CardPictureBox, 2);
            this.CardPictureBox.Size = new System.Drawing.Size(260, 414);
            this.CardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CardPictureBox.TabIndex = 3;
            this.CardPictureBox.TabStop = false;
            // 
            // DescriptionRichTextBox
            // 
            this.DescriptionRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionRichTextBox.Location = new System.Drawing.Point(269, 423);
            this.DescriptionRichTextBox.Name = "DescriptionRichTextBox";
            this.DescriptionRichTextBox.ReadOnly = true;
            this.DescriptionRichTextBox.Size = new System.Drawing.Size(260, 114);
            this.DescriptionRichTextBox.TabIndex = 4;
            this.DescriptionRichTextBox.Text = "";
            // 
            // ResetButton
            // 
            this.ResetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResetButton.Location = new System.Drawing.Point(535, 423);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(262, 114);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmButton.Location = new System.Drawing.Point(535, 543);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(262, 54);
            this.ConfirmButton.TabIndex = 1;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // MenuButton
            // 
            this.MenuButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuButton.Location = new System.Drawing.Point(269, 543);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(260, 54);
            this.MenuButton.TabIndex = 0;
            this.MenuButton.Text = "Menu";
            this.MenuButton.UseVisualStyleBackColor = true;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchTextBox.Location = new System.Drawing.Point(3, 543);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(260, 20);
            this.SearchTextBox.TabIndex = 8;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // UpperGroupBox
            // 
            this.UpperGroupBox.Controls.Add(this.UpperListView);
            this.UpperGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpperGroupBox.Location = new System.Drawing.Point(535, 3);
            this.UpperGroupBox.Name = "UpperGroupBox";
            this.UpperGroupBox.Size = new System.Drawing.Size(262, 204);
            this.UpperGroupBox.TabIndex = 9;
            this.UpperGroupBox.TabStop = false;
            this.UpperGroupBox.Text = "Drop one card to trade";
            // 
            // UpperListView
            // 
            this.UpperListView.AllowDrop = true;
            this.UpperListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpperListView.HideSelection = false;
            this.UpperListView.Location = new System.Drawing.Point(3, 16);
            this.UpperListView.Name = "UpperListView";
            this.UpperListView.Size = new System.Drawing.Size(256, 185);
            this.UpperListView.TabIndex = 5;
            this.UpperListView.UseCompatibleStateImageBehavior = false;
            this.UpperListView.View = System.Windows.Forms.View.List;
            this.UpperListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.UpperListView_DragDrop);
            this.UpperListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.UpperListView_DragEnter);
            // 
            // LowerGroupBox
            // 
            this.LowerGroupBox.Controls.Add(this.LowerListView);
            this.LowerGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LowerGroupBox.Location = new System.Drawing.Point(535, 213);
            this.LowerGroupBox.Name = "LowerGroupBox";
            this.LowerGroupBox.Size = new System.Drawing.Size(262, 204);
            this.LowerGroupBox.TabIndex = 10;
            this.LowerGroupBox.TabStop = false;
            this.LowerGroupBox.Text = "Drop one card to get";
            // 
            // LowerListView
            // 
            this.LowerListView.AllowDrop = true;
            this.LowerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LowerListView.HideSelection = false;
            this.LowerListView.Location = new System.Drawing.Point(3, 16);
            this.LowerListView.Name = "LowerListView";
            this.LowerListView.Size = new System.Drawing.Size(256, 185);
            this.LowerListView.TabIndex = 7;
            this.LowerListView.UseCompatibleStateImageBehavior = false;
            this.LowerListView.View = System.Windows.Forms.View.List;
            this.LowerListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.LowerListView_DragDrop);
            this.LowerListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.LowerListView_DragEnter);
            // 
            // TraderChoiceCardsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TraderChoiceCardsControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.CardTraderNewCards_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CardPictureBox)).EndInit();
            this.UpperGroupBox.ResumeLayout(false);
            this.LowerGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.ListView LeftListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.PictureBox CardPictureBox;
        private System.Windows.Forms.RichTextBox DescriptionRichTextBox;
        private System.Windows.Forms.ListView UpperListView;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.ListView LowerListView;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.GroupBox UpperGroupBox;
        private System.Windows.Forms.GroupBox LowerGroupBox;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
