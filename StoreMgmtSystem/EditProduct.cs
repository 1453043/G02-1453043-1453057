using System;
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

        public EditProduct(List<string> product)
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
            numGia.Value = Int32.Parse(product[3]);
            txtDesc.Text = product[4];
            txtGuarantee.Text = product[5];
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
            // gọi save
            int status = _spData.update(txtID.Text, cmbManu.SelectedValue.ToString(), txtName.Text,
                txtGuarantee.Text, txtDesc.Text, (int)numGia.Value);

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
