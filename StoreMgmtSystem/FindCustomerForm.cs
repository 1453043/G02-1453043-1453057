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
    public partial class FindCustomerForm : Form
    {
        CTLKhachHang _khData = new CTLKhachHang();
        public string currentID;
        public FindCustomerForm()
        {
            InitializeComponent();
            loadDataGridViewKhachHang();
            // khởi tạo giá trị trong combobox cmbCategoryProduct
            cmbCategory.Items.Add("Tên khách hàng");
            cmbCategory.Items.Add("ID");
            cmbCategory.Items.Add("Số điện thoại");
            cmbCategory.SelectedItem = "Tên khách hàng";
        }

        private void loadDataGridViewKhachHang()
        {
            DataTable spData = _khData.search();
            dataGridViewKhachHang.DataSource = spData;
            //dataGridViewKhachHang.Columns["id"].HeaderText = "Mã sản phẩm";
            //dataGridViewKhachHang.Columns["Ten"].HeaderText = "Tên sản phẩm";
            //dataGridViewKhachHang.Columns["idNSX"].HeaderText = "Nhà sản xuất";
            //dataGridViewKhachHang.Columns["Gia"].HeaderText = "Giá";
            //dataGridViewKhachHang.Columns["ThongTinBaoHanh"].HeaderText = "Bảo hành";
            //dataGridViewKhachHang.Columns["MoTa"].HeaderText = "Mô tả";

            dataGridViewKhachHang.DataBindingComplete += (o, _) =>
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtSearh.Text;
            string category = cmbCategory.SelectedItem.ToString();
            DataTable queryResult = _khData.searchKeyword(keyword, category);

            dataGridViewKhachHang.DataSource = queryResult;

            dataGridViewKhachHang.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    // dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    //dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewKhachHang.CurrentCell.RowIndex;
            // delete theo id 
            currentID = dataGridViewKhachHang.Rows[rowindex].Cells[0].Value.ToString();
            Close();
        }
    }
}
