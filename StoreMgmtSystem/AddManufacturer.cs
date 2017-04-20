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
        private DAONhaSanXuat _NSXData = new DAONhaSanXuat();

        public AddManufacturer()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // kiểm tra tính hợp lệ của 3 field
            if(txtID.Text.Length == 0) {
                MessageBox.Show("Lỗi", "Mã nhà sản xuất không được trống.");
                return;
            }
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Lỗi", "Tên nhà sản xuất không được trống.");
                return;
            }
            
            // tạo object NhaSanXuat
            NhaSanXuat nsxObj = new NhaSanXuat(txtID.Text, txtName.Text, txtAddress.Text);

            // gọi save xuống CSDL
            bool status = _NSXData.Save(nsxObj);
            if (status)
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo");
            }
        }
    }
}
