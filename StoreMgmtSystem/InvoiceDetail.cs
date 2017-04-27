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
    public partial class InvoiceDetail : Form
    {
        CTLCT_HoaDonNhapHang _hdData = new CTLCT_HoaDonNhapHang();
        public InvoiceDetail(List<string> hd)
        {
            InitializeComponent();

            // cho data của đơn hàng được chọn vào
            txtAccount.Text = hd[1];
            txtDate.Text = hd[2];
            txtPrice.Text = hd[3];

            // load thông tin hóa đơn
            DataTable table = _hdData.search(hd[0]);

            dataGridViewCT.DataSource = table;

            dataGridViewCT.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }
    }
}
