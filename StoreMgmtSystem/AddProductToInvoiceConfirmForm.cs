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
    public partial class AddProductToInvoiceConfirmForm : Form
    {
        public int SoLuong { get; set; }
        public int GiaGoc { get; set; }

        public AddProductToInvoiceConfirmForm(string giaGoc)
        {
            InitializeComponent();
            numGia.Value = int.Parse(giaGoc);
        }

        public AddProductToInvoiceConfirmForm(string soLuong, string giaGoc)
        {
            InitializeComponent();
            numSoLuong.Value = int.Parse(soLuong);
            numGia.Value = int.Parse(giaGoc);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SoLuong = (int)numSoLuong.Value;
            GiaGoc = (int)numGia.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
