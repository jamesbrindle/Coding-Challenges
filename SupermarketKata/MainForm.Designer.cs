namespace SupermarketKata
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cbSKU = new System.Windows.Forms.ComboBox();
            this.lblSelectSKU = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.tbItemPrice = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbTotalPrice = new System.Windows.Forms.TextBox();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStartOver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSKU
            // 
            this.cbSKU.FormattingEnabled = true;
            this.cbSKU.Location = new System.Drawing.Point(98, 28);
            this.cbSKU.Name = "cbSKU";
            this.cbSKU.Size = new System.Drawing.Size(135, 21);
            this.cbSKU.TabIndex = 0;
            this.cbSKU.SelectedIndexChanged += new System.EventHandler(this.cbSKU_SelectedIndexChanged);
            // 
            // lblSelectSKU
            // 
            this.lblSelectSKU.AutoSize = true;
            this.lblSelectSKU.Location = new System.Drawing.Point(27, 31);
            this.lblSelectSKU.Name = "lblSelectSKU";
            this.lblSelectSKU.Size = new System.Drawing.Size(65, 13);
            this.lblSelectSKU.TabIndex = 1;
            this.lblSelectSKU.Text = "Select SKU:";
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Location = new System.Drawing.Point(27, 63);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(57, 13);
            this.lblItemPrice.TabIndex = 2;
            this.lblItemPrice.Text = "Item Price:";
            // 
            // tbItemPrice
            // 
            this.tbItemPrice.Location = new System.Drawing.Point(98, 60);
            this.tbItemPrice.Name = "tbItemPrice";
            this.tbItemPrice.Size = new System.Drawing.Size(220, 20);
            this.tbItemPrice.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(243, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbTotalPrice
            // 
            this.tbTotalPrice.Location = new System.Drawing.Point(98, 141);
            this.tbTotalPrice.Name = "tbTotalPrice";
            this.tbTotalPrice.Size = new System.Drawing.Size(135, 20);
            this.tbTotalPrice.TabIndex = 6;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(27, 144);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(61, 13);
            this.lblTotalPrice.TabIndex = 5;
            this.lblTotalPrice.Text = "Total Price:";
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(27, 174);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(35, 13);
            this.lblItems.TabIndex = 7;
            this.lblItems.Text = "Items:";
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SKU,
            this.Quantity,
            this.Total});
            this.dgvItems.Location = new System.Drawing.Point(30, 195);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(345, 150);
            this.dgvItems.TabIndex = 8;
            // 
            // SKU
            // 
            this.SKU.HeaderText = "SKU";
            this.SKU.Name = "SKU";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total Price";
            this.Total.Name = "Total";
            // 
            // btnStartOver
            // 
            this.btnStartOver.Location = new System.Drawing.Point(300, 367);
            this.btnStartOver.Name = "btnStartOver";
            this.btnStartOver.Size = new System.Drawing.Size(75, 23);
            this.btnStartOver.TabIndex = 9;
            this.btnStartOver.Text = "Start Over";
            this.btnStartOver.UseVisualStyleBackColor = true;
            this.btnStartOver.Click += new System.EventHandler(this.btnStartOver_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 402);
            this.Controls.Add(this.btnStartOver);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.tbTotalPrice);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbItemPrice);
            this.Controls.Add(this.lblItemPrice);
            this.Controls.Add(this.lblSelectSKU);
            this.Controls.Add(this.cbSKU);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Supermarket Kata";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSKU;
        private System.Windows.Forms.Label lblSelectSKU;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.TextBox tbItemPrice;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbTotalPrice;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button btnStartOver;
    }
}