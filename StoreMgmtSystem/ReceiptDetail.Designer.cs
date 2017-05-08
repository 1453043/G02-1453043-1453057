namespace StoreMgmtSystem
{
    partial class ReceiptDetail
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
            this.txtPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.dataGridViewCT = new System.Windows.Forms.DataGridView();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCT)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.AutoSize = true;
            this.txtPrice.Location = new System.Drawing.Point(579, 52);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(16, 17);
            this.txtPrice.TabIndex = 13;
            this.txtPrice.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(483, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tổng tiền:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(653, 518);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "Xác nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dataGridViewCT
            // 
            this.dataGridViewCT.AllowUserToAddRows = false;
            this.dataGridViewCT.AllowUserToDeleteRows = false;
            this.dataGridViewCT.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCT.Location = new System.Drawing.Point(24, 92);
            this.dataGridViewCT.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewCT.MultiSelect = false;
            this.dataGridViewCT.Name = "dataGridViewCT";
            this.dataGridViewCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCT.Size = new System.Drawing.Size(729, 404);
            this.dataGridViewCT.TabIndex = 10;
            this.dataGridViewCT.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCT_CellDoubleClick);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(100, 48);
            this.txtDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(219, 22);
            this.txtDate.TabIndex = 8;
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(100, 16);
            this.txtAccount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.ReadOnly = true;
            this.txtAccount.Size = new System.Drawing.Size(219, 22);
            this.txtAccount.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngày lập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Người lập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Khách hàng";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(577, 16);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(175, 22);
            this.txtCustomer.TabIndex = 15;
            // 
            // ReceiptDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 561);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dataGridViewCT);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReceiptDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hoá đơn bán hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dataGridViewCT;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomer;
    }
}