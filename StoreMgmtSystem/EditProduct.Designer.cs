namespace StoreMgmtSystem
{
    partial class EditProduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbManu = new System.Windows.Forms.ComboBox();
            this.btnAddManu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGuarantee = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numGia = new System.Windows.Forms.NumericUpDown();
            this.numGiaGoc = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaGoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên sản phẩm";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 68);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 20);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhà sản xuất";
            // 
            // cmbManu
            // 
            this.cmbManu.FormattingEnabled = true;
            this.cmbManu.Location = new System.Drawing.Point(120, 101);
            this.cmbManu.Name = "cmbManu";
            this.cmbManu.Size = new System.Drawing.Size(236, 21);
            this.cmbManu.TabIndex = 3;
            // 
            // btnAddManu
            // 
            this.btnAddManu.Location = new System.Drawing.Point(362, 101);
            this.btnAddManu.Name = "btnAddManu";
            this.btnAddManu.Size = new System.Drawing.Size(75, 23);
            this.btnAddManu.TabIndex = 4;
            this.btnAddManu.Text = "Thêm NSX";
            this.btnAddManu.UseVisualStyleBackColor = true;
            this.btnAddManu.Click += new System.EventHandler(this.btnAddManu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mã sản phẩm";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(120, 35);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(236, 20);
            this.txtID.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giá";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mô tả";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(120, 201);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(236, 20);
            this.txtDesc.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Bảo hành";
            // 
            // txtGuarantee
            // 
            this.txtGuarantee.Location = new System.Drawing.Point(120, 234);
            this.txtGuarantee.Name = "txtGuarantee";
            this.txtGuarantee.Size = new System.Drawing.Size(236, 20);
            this.txtGuarantee.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point(340, 272);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 41);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Sửa sản phẩm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(239, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 41);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // numGia
            // 
            this.numGia.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numGia.Location = new System.Drawing.Point(120, 168);
            this.numGia.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numGia.Name = "numGia";
            this.numGia.Size = new System.Drawing.Size(236, 20);
            this.numGia.TabIndex = 5;
            // 
            // numGiaGoc
            // 
            this.numGiaGoc.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numGiaGoc.Location = new System.Drawing.Point(120, 135);
            this.numGiaGoc.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numGiaGoc.Name = "numGiaGoc";
            this.numGiaGoc.Size = new System.Drawing.Size(236, 20);
            this.numGiaGoc.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Giá gốc";
            // 
            // EditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 334);
            this.Controls.Add(this.numGiaGoc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numGia);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtGuarantee);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddManu);
            this.Controls.Add(this.cmbManu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "EditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa sản phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaGoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbManu;
        private System.Windows.Forms.Button btnAddManu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGuarantee;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.NumericUpDown numGiaGoc;
        private System.Windows.Forms.Label label7;
    }
}