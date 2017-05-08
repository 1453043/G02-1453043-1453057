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
    public partial class ReceiptDetail : Form
    {
        CTLCT_HoaDonBanHang _hdData = new CTLCT_HoaDonBanHang();
        CTLHoaDonBanHang _hd = new CTLHoaDonBanHang();
        private bool mode;
        private string idHoaDon;

        public ReceiptDetail(List<string> hd, bool mode)
        {
            InitializeComponent();
            idHoaDon = hd[0];
            // cho data của đơn hàng được chọn vào
            txtAccount.Text = hd[1];
            txtCustomer.Text = hd[2];
            txtDate.Text = hd[3];
            txtPrice.Text = hd[4];

            // load thông tin hóa đơn
            DataTable table = _hdData.search(hd[0]);

            dataGridViewCT.DataSource = table;
            dataGridViewCT.Columns[dataGridViewCT.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridViewCT.DataBindingComplete += (o, _) =>
            //{
            //    var dataGridView = o as DataGridView;
            //    if (dataGridView != null)
            //    {
            //        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //        dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    }
            //};
            this.mode = mode;
            //mode: true: editable
            if (mode == false)
            {
                txtAccount.ReadOnly = true;
                txtDate.ReadOnly = true;
                dataGridViewCT.ReadOnly = true;
            }
        }


        private void dataGridViewCT_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int changedCol = e.ColumnIndex;
            int remainCol = 2;
            if (changedCol == 2) // so luong bi thay doi
                remainCol = 3;

            int a;
            int.TryParse(dataGridViewCT.Rows[e.RowIndex].Cells[changedCol].Value.ToString(), out a);
            int b;
            int.TryParse(dataGridViewCT.Rows[e.RowIndex].Cells[remainCol].Value.ToString(), out b);
            int result;
            int.TryParse(txtPrice.Text, out result);
            result += (a * b);
            txtPrice.Text = result.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mode == false)
            {
                Close();
            }

            if (_hd.update(idHoaDon, txtAccount.Text, txtCustomer.Text, Convert.ToDateTime(txtDate.Text), int.Parse(txtPrice.Text)))
            {
                // xóa đi CT đơn hàng cũ
                if (_hdData.delete(idHoaDon))
                {
                    // save bảng data đơn hàng
                    // tạo DataTable để lấy data trong grid view
                    DataTable table = new DataTable();
                    table.Columns.Add(new DataColumn("idNhapHang", typeof(string)));
                    table.Columns.Add(new DataColumn("idSanPham", typeof(string)));
                    table.Columns.Add(new DataColumn("SoLuong", typeof(int)));
                    table.Columns.Add(new DataColumn("GiaTien", typeof(int)));

                    object[] cellValues = new object[4];
                    cellValues[0] = idHoaDon;
                    foreach (DataGridViewRow row in dataGridViewCT.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            cellValues[1] = row.Cells[0].Value;
                            int val;
                            Int32.TryParse(row.Cells[1].Value.ToString(), out val); // so luong
                            cellValues[2] = val;
                            Int32.TryParse(row.Cells[2].Value.ToString(), out val); // gia tien
                            cellValues[3] = val;
                            table.Rows.Add(cellValues);
                        }
                    }
                    if (_hdData.save(table))
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }

                }
            }
        }
    }
}
