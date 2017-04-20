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
        private DAONhaSanXuat _NSXData = new DAONhaSanXuat();
        private DAOSanPham _spData = new DAOSanPham();

        public EditProduct(List<string> product)
        {
            InitializeComponent();
            // load data NSX cho combo box
            DataTable nsxData = _NSXData.Search();
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
                DataTable nsxData = _NSXData.Search();

                cmbManu.DisplayMember = "TenNSX";
                cmbManu.ValueMember = "TenNSX";
                cmbManu.DataSource = nsxData.DefaultView;
                cmbManu.BindingContext = this.BindingContext;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // kiểm tra các fields
            if (txtID.Text.Length == 0)
            {
                MessageBox.Show("Mã sản phẩm không được trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Mã sản phẩm không được trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Mã sản phẩm không được trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // tạo object SanPham
            SanPham spObj = new SanPham(txtID.Text, cmbManu.SelectedValue.ToString(), txtName.Text, 
                txtGuarantee.Text, txtDesc.Text, (int)numGia.Value);

            // gọi save xuống CSDL
            bool status = _spData.Update(spObj);
            if (status)
            {
                MessageBox.Show("Sửa thành công", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
