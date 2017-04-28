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
    public partial class AddAccountForm : Form
    {
        CTLNguoiDung _ngData = new CTLNguoiDung();
        private bool mode = false; // true : edit account
        private string currentID;

        public AddAccountForm()
        {
            InitializeComponent();
        }
        public AddAccountForm(string id)
        {
            InitializeComponent();
            mode = true;
            currentID = id;

            NguoiDung userInfo = _ngData.search(id);

            txtUsername.Text = userInfo.TenDangNhap;
            txtPassword.Text = userInfo.MatKhau;
            txtName.Text = userInfo.HoTen;
            if (userInfo.Loai == 1)
                radAdmin.Checked = true;
            else if (userInfo.Loai == 2)
                radNVKho.Checked = true;
            else
                radNVBanHang.Checked = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int type = 3;
            RadioButton radChecked = null;
            foreach (var control in groupBox1.Controls)
            {
                RadioButton radio = control as RadioButton;

                if (radio != null && radio.Checked)
                {
                    radChecked = radio;
                }
            }
            if (radChecked.Text == "Admin")
                type = 1;
            else if (radChecked.Text == "Nhân viên kho")
                type = 2;
            if (mode == false)
            {
                string id = DateTime.Now.ToString("hhmmssddMMyy");
                NguoiDung newuser = new NguoiDung(id, txtUsername.Text, txtPassword.Text, txtName.Text, type);
                int res = _ngData.save(newuser);
                if (res == 1)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if (res == 2)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại.");
                }
                else MessageBox.Show("Thêm người dùng thất bại");
            }
            else
            {
                NguoiDung editUser = new NguoiDung(currentID, txtUsername.Text, txtPassword.Text, txtName.Text, type);
                int res = _ngData.update(editUser);
                if (res == 1)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if (res == 2)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại.");
                }
                else MessageBox.Show("Sửa người dùng thất bại");
            }
        }
    }
}
