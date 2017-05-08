namespace StoreMgmtSystem
{
    partial class FindCustomerForm
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
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtSearh = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dataGridViewKhachHang = new System.Windows.Forms.DataGridView();
            this.btnChon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(17, 16);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(220, 24);
            this.cmbCategory.TabIndex = 0;
            // 
            // txtSearh
            // 
            this.txtSearh.Location = new System.Drawing.Point(247, 16);
            this.txtSearh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearh.Name = "txtSearh";
            this.txtSearh.Size = new System.Drawing.Size(196, 22);
            this.txtSearh.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(452, 14);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 28);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dataGridViewKhachHang
            // 
            this.dataGridViewKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKhachHang.Location = new System.Drawing.Point(17, 50);
            this.dataGridViewKhachHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewKhachHang.Name = "dataGridViewKhachHang";
            this.dataGridViewKhachHang.Size = new System.Drawing.Size(535, 373);
            this.dataGridViewKhachHang.TabIndex = 3;
            // 
            // btnChon
            // 
            this.btnChon.Location = new System.Drawing.Point(452, 431);
            this.btnChon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(100, 37);
            this.btnChon.TabIndex = 4;
            this.btnChon.Text = "Chọn";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // FindCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 474);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.dataGridViewKhachHang);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtSearh);
            this.Controls.Add(this.cmbCategory);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FindCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm khách hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtSearh;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dataGridViewKhachHang;
        private System.Windows.Forms.Button btnChon;
    }
}