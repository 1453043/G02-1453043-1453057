using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Globalization;

namespace StoreMgmtSystem
{
    public partial class Form1 : Form
    {
        private CTLSanPham _spData = new CTLSanPham();

        public Form1()
        {
            InitializeComponent();
            CultureInfo ci = new CultureInfo("vi-VN");
            loadLanguageResource(ci);

            // load dữ liệu Hàng hóa
            loadDataGridViewProduct();

            // khởi tạo giá trị trong combobox cmbCategoryProduct
            cmbCategoryProduct.Items.Add("Tên sản phẩm");
            cmbCategoryProduct.Items.Add("ID");
            cmbCategoryProduct.Items.Add("Mã nhà sản xuất");
            cmbCategoryProduct.SelectedItem = "Tên sản phẩm";
        }

        private void mitemVi_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("vi-VN");
            loadLanguageResource(ci);
        }

        private void mitemEn_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-US");
            loadLanguageResource(ci);
        }

        private void loadLanguageResource(CultureInfo ci)
        {
            Assembly a = Assembly.Load("StoreMgmtSystem");
            ResourceManager rm = new ResourceManager("StoreMgmtSystem.Lang.langres", a);
            this.Text = rm.GetString("title", ci);
            menuAccount.Text = rm.GetString("account", ci);
            mitemAccDetail.Text = rm.GetString("account_detail", ci);
            mitemSignout.Text = rm.GetString("sign_out", ci);
            menuStat.Text = rm.GetString("stat", ci);
            menuLang.Text = rm.GetString("lang", ci);
            menuHelp.Text = rm.GetString("help", ci);
            mitemAboutUs.Text = rm.GetString("about_us", ci);
            tabPageProduct.Text = rm.GetString("tab_product", ci);
            tabPageImport.Text = rm.GetString("tab_import", ci);
            tabPageSell.Text = rm.GetString("tab_sell", ci);
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
        private void mitemAccDetail_Click(object sender, EventArgs e)
        {

        }

        private void mitemSignout_Click(object sender, EventArgs e)
        {

        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            AddInvoiceForm addInvoiceForm = new AddInvoiceForm();
            if (addInvoiceForm.ShowDialog() == DialogResult.OK) ;
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {

        }

        private void btnEditBill_Click(object sender, EventArgs e)
        {

        }

        private void btnDelBill_Click(object sender, EventArgs e)
        {

        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshBillList_Click(object sender, EventArgs e)
        {

        }

        private void btnFindBill_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevPageBill_Click(object sender, EventArgs e)
        {

        }

        private void btnNextPageBill_Click(object sender, EventArgs e)
        {

        }

        private void btnDelInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btnEditInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshInvoiceList_Click(object sender, EventArgs e)
        {

        }

        private void btnFindInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevPageInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btnNextPageInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct addProductForm = new AddProduct();
            if (addProductForm.ShowDialog() == DialogResult.OK)
                loadDataGridViewProduct();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewProduct.CurrentCell.RowIndex;
            List<string> product = new List<string>();
            //int columnindex = dataGridViewProduct.CurrentCell.ColumnIndex;
            //MessageBox.Show(dataGridViewProduct.Rows[rowindex].Cells[columnindex].Value.ToString());
            foreach (DataGridViewCell cell in dataGridViewProduct.Rows[rowindex].Cells)
            {
                product.Add(cell.Value.ToString());
            }
            EditProduct editProductForm = new EditProduct(product);
            if(editProductForm.ShowDialog() == DialogResult.OK)
            {
                loadDataGridViewProduct();
            }

        }

        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewProduct.CurrentCell.RowIndex;
            // delete theo id 
            _spData.delete(dataGridViewProduct.Rows[rowindex].Cells[0].Value.ToString());

            // load lại danh sách hàng
            loadDataGridViewProduct();
        }

        private void btnRefreshProductList_Click(object sender, EventArgs e)
        {
            // load lại danh sách hàng
            loadDataGridViewProduct();
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnFindProduct_Click(object sender, EventArgs e)
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
                btnFindProduct_Click(this, new EventArgs());
            }
        }
    }
}
