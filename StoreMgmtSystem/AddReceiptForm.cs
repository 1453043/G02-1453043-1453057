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
    public partial class AddReceiptForm : Form
    {
        private CTLSanPham _spData = new CTLSanPham();
        private CTLHoaDonBanHang _hdData = new CTLHoaDonBanHang();
        private CTLCT_HoaDonBanHang _ct = new CTLCT_HoaDonBanHang();
        private string currentUserID;
        private int currentPrice;
        private string currentGuestID;

        public AddReceiptForm(string username, string userid)
        {
            InitializeComponent();

            // load dữ liệu Hàng hóa
            loadDataGridViewProduct();

            // khởi tạo giá trị trong combobox cmbCategoryProduct
            cmbCategoryProduct.Items.Add("Tên sản phẩm");
            cmbCategoryProduct.Items.Add("ID");
            cmbCategoryProduct.Items.Add("Mã nhà sản xuất");
            cmbCategoryProduct.SelectedItem = "Tên sản phẩm";

            currentUserID = userid;
            txtAccount.Text = username;
            currentPrice = 0;
            // khởi tạo giá trị ngày lập vào txtDate
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void loadDataGridViewProduct()
        {
            DataTable spData = _spData.searchForHoaDon();
            dataGridViewProduct.DataSource = spData;
            //dataGridViewProduct.Columns["id"].HeaderText = "Mã sản phẩm";
            //dataGridViewProduct.Columns["Ten"].HeaderText = "Tên sản phẩm";
            //dataGridViewProduct.Columns["idNSX"].HeaderText = "Nhà sản xuất";
            //dataGridViewProduct.Columns["Gia"].HeaderText = "Giá";
            //dataGridViewProduct.Columns["ThongTinBaoHanh"].HeaderText = "Bảo hành";
            //dataGridViewProduct.Columns["MoTa"].HeaderText = "Mô tả";

            dataGridViewProduct.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[0].Width = 40;

                    //dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string keyword = txtKeywordProduct.Text;
            string category = cmbCategoryProduct.SelectedItem.ToString();
            DataTable queryResult = _spData.searchKeyword(keyword, category);

            dataGridViewProduct.DataSource = queryResult;

            dataGridViewProduct.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    // dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    //dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //index row đang được chọn
            int rowindex = dataGridViewProduct.CurrentCell.RowIndex;
            // lấy id
            string id = dataGridViewProduct.Rows[rowindex].Cells[0].Value.ToString();
            string name = dataGridViewProduct.Rows[rowindex].Cells[1].Value.ToString();
            int gia = int.Parse(dataGridViewProduct.Rows[rowindex].Cells[2].Value.ToString());

            // kiểm tra xem item này đã có bên gridview bên phải chưa
            // có rồi thì +1 số lượng
            int rowFound = -1;
            foreach (DataGridViewRow gridrow in dataGridViewForm.Rows)
            {
                if (gridrow.Cells[0].Value != null && gridrow.Cells[0].Value.ToString().Equals(id))
                {
                    rowFound = gridrow.Index;
                    dataGridViewForm.Rows[dataGridViewForm.SelectedRows[0].Index].Selected = false;
                    dataGridViewForm.Rows[rowFound].Selected = true;
                    int val;
                    int.TryParse(dataGridViewForm.Rows[rowFound].Cells[2].Value.ToString(), out val);
                    if (val > 0)
                    {
                        val++;
                        dataGridViewForm.Rows[rowFound].Cells[2].Value = val.ToString();
                    }
                    break;
                }
            }
            if (rowFound == -1)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewForm.RowTemplate.Clone();
                row.CreateCells(dataGridViewForm, id, name, "1", gia);

                dataGridViewForm.Rows.Add(row);
            }

            // cộng vào tổng tiền hiện tại
            currentPrice += gia;
            txtPrice.Text = currentPrice.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewForm.CurrentCell.RowIndex;

            dataGridViewForm.Rows.RemoveAt(rowindex);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime datenow = DateTime.Now;
            string idHD = datenow.ToString("ddMMyyhhmmss");

            // save đơn hàng
            _hdData.save(idHD, currentUserID, currentGuestID, datenow, currentPrice);

            // save bảng data đơn hàng
            // tạo DataTable để lấy data trong grid view
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("idNhapHang", typeof(string)));
            table.Columns.Add(new DataColumn("idSanPham", typeof(string)));
            table.Columns.Add(new DataColumn("SoLuong", typeof(int)));
            table.Columns.Add(new DataColumn("GiaTien", typeof(int)));

            object[] cellValues = new object[4];
            foreach (DataGridViewRow row in dataGridViewForm.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    cellValues[0] = idHD;
                    cellValues[1] = row.Cells[0].Value;
                    int val;
                    Int32.TryParse(row.Cells[2].Value.ToString(), out val); // so luong
                    cellValues[2] = val;
                    Int32.TryParse(row.Cells[3].Value.ToString(), out val); // gia tien
                    cellValues[3] = val;
                    table.Rows.Add(cellValues);
                }
            }
            if (_ct.save(table))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        // xử lý tìm kiếm lúc nhấn Enter trong khung keyword
        private void txtKeywordProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(this, new EventArgs());
            }
        }

    }
}
