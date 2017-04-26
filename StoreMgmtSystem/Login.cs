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
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NguoiDung user = new NguoiDung(txtUsername.Text, txtPassword.Text);
            if (_ndData.authenticate(user))
            {
                DialogResult = DialogResult.OK;
                //Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
            //DialogResult = DialogResult.OK;
            //Close();
        }
    }
}
