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
    public partial class AddInvoiceForm : Form
    {
        private CTLSanPham _spData = new CTLSanPham();

        public AddInvoiceForm()
        {
            InitializeComponent();

            // load dữ liệu Hàng hóa
            loadDataGridViewProduct();

            // khởi tạo giá trị trong combobox cmbCategoryProduct
            cmbCategoryProduct.Items.Add("Tên sản phẩm");
            cmbCategoryProduct.Items.Add("ID");
            cmbCategoryProduct.Items.Add("Mã nhà sản xuất");
            cmbCategoryProduct.SelectedItem = "Tên sản phẩm";

            // khởi tạo giá trị ngày lập vào txtDate
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void loadDataGridViewProduct()
        {
            DataTable spData = _spData.search();
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
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        // xử lý tìm kiếm lúc nhấn Enter trong khung keyword
        private void txtKeywordProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(this, new EventArgs());
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct addProductForm = new AddProduct();
            if (addProductForm.ShowDialog() == DialogResult.OK)
                loadDataGridViewProduct();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewProduct.CurrentCell.RowIndex;
            // lấy id
            string id = dataGridViewProduct.Rows[rowindex].Cells[0].Value.ToString();
            string name = dataGridViewProduct.Rows[rowindex].Cells[1].Value.ToString();
            DataGridViewRow row = (DataGridViewRow)dataGridViewForm.RowTemplate.Clone();
            row.CreateCells(dataGridViewForm, id, name, "1");

            dataGridViewForm.Rows.Add(row);
        }
    }
}
