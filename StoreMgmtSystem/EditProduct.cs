﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreMgmtSystem
{
    public partial class EditProduct : Form
    {
        private CTLNhaSanXuat _NSXData = new CTLNhaSanXuat();
        private CTLSanPham _spData = new CTLSanPham();
        bool mode = false;

        public EditProduct(List<string> product, bool mode)
        {
            InitializeComponent();
            // load data NSX cho combo box
            DataTable nsxData = _NSXData.search();
            cmbManu.DisplayMember = "TenNSX";
            cmbManu.ValueMember = "id";
            cmbManu.DataSource = nsxData.DefaultView;
            cmbManu.BindingContext = this.BindingContext;

            // cho data của sản phẩm được chọn vào
            txtID.Text = product[0];
            txtName.Text = product[1];
            cmbManu.Text = product[2];
            numGiaGoc.Value = Int32.Parse(product[3]);
            numGia.Value = Int32.Parse(product[4]);
            txtDesc.Text = product[5];
            txtGuarantee.Text = product[6];

            this.mode = mode;
            if (this.mode == false)
            {
                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                {
                    tb.ReadOnly = true;
                }
                numGiaGoc.ReadOnly = true;
                numGia.ReadOnly = true;
            }
        }

        private void btnAddManu_Click(object sender, EventArgs e)
        {
            AddManufacturer addManuForm = new AddManufacturer();
            if(addManuForm.ShowDialog() == DialogResult.OK)
            {
                // thêm NSX mới thành công
                // cho vào combobox NSX
                DataTable nsxData = _NSXData.search();

                cmbManu.DisplayMember = "TenNSX";
                cmbManu.ValueMember = "TenNSX";
                cmbManu.DataSource = nsxData.DefaultView;
                cmbManu.BindingContext = this.BindingContext;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (mode == false)
                return;
            // gọi save
            int status = _spData.update(txtID.Text, cmbManu.SelectedValue.ToString(), txtName.Text,
                txtGuarantee.Text, txtDesc.Text, (int)numGia.Value,(int)numGiaGoc.Value);

            if (status == 1)
            {
                MessageBox.Show("Sửa thành công", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (status == 2)
            {
                MessageBox.Show("Mã sản phẩm không được trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (status == 3)
            {
                MessageBox.Show("Tên sản phẩm không được trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (status == 0)
            {
                MessageBox.Show("Sửa thất bại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
