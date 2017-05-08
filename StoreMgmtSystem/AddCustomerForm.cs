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
    public partial class AddCustomerForm : Form
    {
        private CTLKhachHang _KhData = new CTLKhachHang();
        string id = DateTime.Now.ToString("hhmmssddMMyy");
        public AddCustomerForm()
        {
            InitializeComponent();
            txtID.Text = id;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // gọi save
            int status = _KhData.save(id, txtTen.Text, txtDiaChi.Text, txtSDT.Text);
            if (status == 1)
            {
                MessageBox.Show("Thêm thành công", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (status == 2)
            {
                MessageBox.Show("Tên khách hàng không được trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (status == 3)
            {
                MessageBox.Show("Số điện thoại không được trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (status == 0)
            {
                MessageBox.Show("Thêm thất bại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
