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
    public partial class Login : Form
    {
        private CTLNguoiDung _ndData = new CTLNguoiDung();
        public string Username { get; set; }
        public string IDuser { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NguoiDung user = new NguoiDung(txtUsername.Text, txtPassword.Text);
            string id = _ndData.authenticate(user);
            if (id != "")
            {
                DialogResult = DialogResult.OK;
                Username = txtUsername.Text;
                IDuser = id;

                Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
            //DialogResult = DialogResult.OK;
            //Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
