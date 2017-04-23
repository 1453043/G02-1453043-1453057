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
    public partial class AddManufacturer : Form
    {
        private CTLNhaSanXuat _NSXData = new CTLNhaSanXuat();

        public AddManufacturer()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int status = _NSXData.save(txtID.Text, txtName.Text, txtAddress.Text);
            if (status == 1)
            {
                MessageBox.Show("Thêm thành công", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (status == 2)
            {
                MessageBox.Show("Mã nhà sản xuất không được trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (status == 3)
            {
                MessageBox.Show("Tên nhà sản xuất không được trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
