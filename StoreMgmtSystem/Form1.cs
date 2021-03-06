﻿using System;
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
        private CTLHoaDonNhapHang _hdData = new CTLHoaDonNhapHang();
        private CTLHoaDonBanHang _reData = new CTLHoaDonBanHang();
        private CTLNguoiDung _accData = new CTLNguoiDung();

        private int PgSize = 20;
        private int CurrentProductPageIndex = 1;
        private int TotalProductPage = 0;
        private int CurrentInvPageIndex = 1;
        private int TotalInvoicePage = 1;
        private int CurrentReceiptPageIndex = 1;
        private int TotalReceiptPage = 1;

        private string currentUser;
        private string currentUserID;
        enum Mode { admin, warehouse, cashier };
        private Mode mode = Mode.cashier;

        public Form1(string username, string iduser)
        {
            InitializeComponent();
            CultureInfo ci = new CultureInfo("vi-VN");
            loadLanguageResource(ci);

            currentUser = username;
            if (username == "admin")
                mode = Mode.admin;
            else mode = Mode.warehouse;
            
            currentUserID = iduser;
            lbUsername.Text = "Người dùng: " + username;
            if(mode == Mode.admin)
            {
                foreach (Control ctl in tabControlMain.Controls) ctl.Enabled = true;
                
                // load đơn bán hàng
                loadDataGridViewReceipt();
                // load đơn nhập hàng
                loadDataGridViewInvoice();
                // load dữ liệu Hàng hóa
                loadDataGridViewProduct();
                // load dữ liệu tài khoản
                loadDataGridViewAccount();
            }
            else if(mode == Mode.cashier)
            {
                tabControlMain.TabPages.Remove(tabPageImport);
                tabControlMain.TabPages.Remove(tabPageProduct);
                tabControlMain.TabPages.Remove(tabPageAccount);
            }
            else
            {
                tabControlMain.TabPages.Remove(tabPageSell);
                tabControlMain.TabPages.Remove(tabPageAccount);
                // load đơn nhập hàng
                loadDataGridViewInvoice();
                // load dữ liệu Hàng hóa
                loadDataGridViewProduct();
            }

            getTotalProductPage();
            txtPageProduct.Text = CurrentProductPageIndex.ToString();
            btnPrevPageProduct.Enabled = false;
            if (CurrentProductPageIndex == TotalProductPage)
                btnNextPageProduct.Enabled = false;

            txtPageBill.Text = CurrentReceiptPageIndex.ToString();
            btnPrevPageBill.Enabled = false;
            if (CurrentReceiptPageIndex == TotalReceiptPage)
                btnNextPageBill.Enabled = false;

            txtPageInvoice.Text = CurrentInvPageIndex.ToString();
            btnPrevPageInvoice.Enabled = false;
            if (CurrentInvPageIndex == TotalInvoicePage)
                btnNextPageInvoice.Enabled = false;

            // khởi tạo giá trị trong combobox toolStripComboBox1
            toolStripComboBox1.Items.Add("Tên người lập");
            toolStripComboBox1.Items.Add("Mã khách hàng");
            toolStripComboBox1.Items.Add("Mã hóa đơn");
            toolStripComboBox1.SelectedItem = "Tên người lập";

            // khởi tạo giá trị trong combobox cmbCategoryInvoice
            cmbCategoryInvoice.Items.Add("Tên người lập");
            cmbCategoryInvoice.Items.Add("Mã hóa đơn");
            cmbCategoryInvoice.SelectedItem = "Tên người lập";

            // khởi tạo giá trị trong combobox cmbCategoryProduct
            cmbCategoryProduct.Items.Add("Tên sản phẩm");
            cmbCategoryProduct.Items.Add("ID");
            cmbCategoryProduct.Items.Add("Mã nhà sản xuất");
            cmbCategoryProduct.SelectedItem = "Tên sản phẩm";

            // khởi tạo giá trị trong combobox cmbCategoryAccount
            cmbCategoryAccount.Items.Add("Tên đăng nhập");
            cmbCategoryAccount.Items.Add("Họ tên");
            cmbCategoryAccount.Items.Add("Loại");
            cmbCategoryAccount.Items.Add("ID");
            cmbCategoryAccount.SelectedItem = "Tên đăng nhập";
            
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
            //menuStat.Text = rm.GetString("stat", ci);
            menuLang.Text = rm.GetString("lang", ci);
            menuHelp.Text = rm.GetString("help", ci);
            mitemAboutUs.Text = rm.GetString("about_us", ci);
            tabPageProduct.Text = rm.GetString("tab_product", ci);
            tabPageImport.Text = rm.GetString("tab_import", ci);
            tabPageSell.Text = rm.GetString("tab_sell", ci);
            tabPageAccount.Text = rm.GetString("tab_account", ci);
        }
        private void loadDataGridViewReceipt()
        {
            DataTable reData = _reData.search();
            dataGridViewReceipt.DataSource = reData;

            dataGridViewReceipt.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        private void loadDataGridViewProduct()
        {
            DataTable spData = _spData.search(CurrentProductPageIndex, PgSize);
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

        private void loadDataGridViewInvoice()
        {
            DataTable hdnhData = _hdData.search();
            dataGridViewInv.DataSource = hdnhData;
            //dataGridViewProduct.Columns["id"].HeaderText = "Mã sản phẩm";
            //dataGridViewProduct.Columns["Ten"].HeaderText = "Tên sản phẩm";
            //dataGridViewProduct.Columns["idNSX"].HeaderText = "Nhà sản xuất";
            //dataGridViewProduct.Columns["Gia"].HeaderText = "Giá";
            //dataGridViewProduct.Columns["ThongTinBaoHanh"].HeaderText = "Bảo hành";
            //dataGridViewProduct.Columns["MoTa"].HeaderText = "Mô tả";

            dataGridViewInv.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        private void loadDataGridViewAccount()
        {
            DataTable accData = _accData.search();
            dataGridViewAccount.DataSource = accData;

            dataGridViewAccount.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        private void getTotalProductPage()
        {
            int count = _spData.getTotalCount();
            TotalProductPage = count / PgSize;
            if (count % PgSize > 0)
                TotalProductPage++;
        }

        private void mitemAccDetail_Click(object sender, EventArgs e)
        {
            AddAccountForm addAccountForm = new AddAccountForm(currentUserID, false);
            addAccountForm.ShowDialog();
        }

        private void mitemSignout_Click(object sender, EventArgs e)
        {   

        }

        private void mitemAboutUs_Click(object sender, EventArgs e)
        {
            AboutUs aboutUs = new AboutUs();
            aboutUs.Show();
        }

        private void mitemTut_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.Show();
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            AddInvoiceForm addInvoiceForm = new AddInvoiceForm(currentUser, currentUserID);
            if (addInvoiceForm.ShowDialog() == DialogResult.OK)
            {
                // load lại danh sách hóa đơn
                loadDataGridViewInvoice();
            }
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            AddReceiptForm addReceiptForm = new AddReceiptForm(currentUser, currentUserID);
            if (addReceiptForm.ShowDialog() == DialogResult.OK)
            {
                // load lại danh sách hóa đơn
                loadDataGridViewReceipt();
            }
        }

        private void btnEditBill_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewReceipt.CurrentCell.RowIndex;

            List<string> item = new List<string>();
            foreach (DataGridViewCell cell in dataGridViewReceipt.Rows[rowindex].Cells)
            {
                item.Add(cell.Value.ToString());
            }
            ReceiptDetail detailRecForm = new ReceiptDetail(item, true);
            if (detailRecForm.ShowDialog() == DialogResult.OK)
                loadDataGridViewReceipt();
        }

        private void btnDelBill_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewReceipt.CurrentCell.RowIndex;

            // delete đơn hàng theo id 
            _reData.delete(dataGridViewReceipt.Rows[rowindex].Cells[0].Value.ToString());

            // load lại danh sách hàng
            loadDataGridViewReceipt();
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewReceipt.CurrentCell.RowIndex;
            List<string> item = new List<string>();
            foreach (DataGridViewCell cell in dataGridViewReceipt.Rows[rowindex].Cells)
            {
                item.Add(cell.Value.ToString());
            }
            ReceiptDetail detailRecForm = new ReceiptDetail(item, false);
            detailRecForm.ShowDialog();
        }

        private void btnRefreshBillList_Click(object sender, EventArgs e)
        {
            // load lại danh sách hàng
            loadDataGridViewReceipt();
        }

        private void btnFindBill_Click(object sender, EventArgs e)
        {
            string keyword = txtKeywordBill.Text;
            string category = toolStripComboBox1.SelectedItem.ToString();
            DataTable queryResult = _reData.searchKeyword(keyword, category);

            dataGridViewReceipt.DataSource = queryResult;

            dataGridViewReceipt.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        private void btnPrevPageBill_Click(object sender, EventArgs e)
        {
            CurrentReceiptPageIndex--;
            txtPageBill.Text = CurrentReceiptPageIndex.ToString();
            if (CurrentReceiptPageIndex != TotalReceiptPage)
                btnNextPageBill.Enabled = true;
            if (CurrentReceiptPageIndex == 1)
                btnPrevPageBill.Enabled = false;
            loadDataGridViewReceipt();
        }

        private void btnNextPageBill_Click(object sender, EventArgs e)
        {
            CurrentReceiptPageIndex++;
            txtPageBill.Text = CurrentReceiptPageIndex.ToString();
            if (CurrentReceiptPageIndex != 1)
                btnPrevPageBill.Enabled = true;
            if (CurrentReceiptPageIndex == TotalInvoicePage)
                btnNextPageBill.Enabled = false;
            loadDataGridViewReceipt();
        }

        private void btnDelInvoice_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewInv.CurrentCell.RowIndex;
            
            // delete đơn hàng theo id 
            _hdData.delete(dataGridViewInv.Rows[rowindex].Cells[0].Value.ToString());

            // load lại danh sách hàng
            loadDataGridViewInvoice();
        }

        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewInv.CurrentCell.RowIndex;
            List<string> item = new List<string>();
            foreach (DataGridViewCell cell in dataGridViewInv.Rows[rowindex].Cells)
            {
                item.Add(cell.Value.ToString());
            }
            InvoiceDetail detailInvForm = new InvoiceDetail(item, true);
            if (detailInvForm.ShowDialog() == DialogResult.OK)
                loadDataGridViewInvoice();
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewInv.CurrentCell.RowIndex;
            List<string> item = new List<string>();
            foreach (DataGridViewCell cell in dataGridViewInv.Rows[rowindex].Cells)
            {
                item.Add(cell.Value.ToString());
            }
            InvoiceDetail detailInvForm = new InvoiceDetail(item, false);
            detailInvForm.ShowDialog();
        }

        private void btnRefreshInvoiceList_Click(object sender, EventArgs e)
        {
            loadDataGridViewInvoice();
        }

        private void btnFindInvoice_Click(object sender, EventArgs e)
        {
            string keyword = txtKeywordInvoice.Text;
            string category = cmbCategoryInvoice.SelectedItem.ToString();
            DataTable queryResult = _hdData.searchKeyword(keyword, category);

            dataGridViewInv.DataSource = queryResult;

            dataGridViewInv.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        private void btnPrevPageInvoice_Click(object sender, EventArgs e)
        {
            CurrentInvPageIndex--;
            txtPageInvoice.Text = CurrentInvPageIndex.ToString();
            if (CurrentInvPageIndex != TotalInvoicePage)
                btnNextPageInvoice.Enabled = true;
            if (CurrentInvPageIndex == 1)
                btnPrevPageInvoice.Enabled = false;
            loadDataGridViewInvoice();
        }

        private void btnNextPageInvoice_Click(object sender, EventArgs e)
        {
            CurrentInvPageIndex++;
            txtPageInvoice.Text = CurrentInvPageIndex.ToString();
            if (CurrentInvPageIndex != 1)
                btnPrevPageInvoice.Enabled = true;
            if (CurrentInvPageIndex == TotalInvoicePage)
                btnNextPageInvoice.Enabled = false;
            loadDataGridViewInvoice();
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
            EditProduct editProductForm = new EditProduct(product, true);
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
            // index row đang được chọn
            int rowindex = dataGridViewProduct.CurrentCell.RowIndex;
            List<string> product = new List<string>();
            foreach (DataGridViewCell cell in dataGridViewProduct.Rows[rowindex].Cells)
            {
                product.Add(cell.Value.ToString());
            }
            EditProduct editProductForm = new EditProduct(product, false);
            editProductForm.ShowDialog();
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

        // xử lý tìm kiếm lúc nhấn Enter trong khung keyword
        private void txtKeywordInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindInvoice_Click(this, new EventArgs());
            }
        }

        private void txtKeywordBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindBill_Click(this, new EventArgs());
            }
        }

        private void txtKeywordAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindAcc_Click(this, new EventArgs());
            }
        }

        private void btnAddAcc_Click(object sender, EventArgs e)
        {
            AddAccountForm addAccountForm = new AddAccountForm();
            if (addAccountForm.ShowDialog() == DialogResult.OK)
                loadDataGridViewAccount();
        }

        private void btnReloadAcc_Click(object sender, EventArgs e)
        {
            loadDataGridViewAccount();
        }

        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewAccount.CurrentCell.RowIndex;
            string id = dataGridViewAccount.Rows[rowindex].Cells[0].Value.ToString();

            AddAccountForm editAccountForm = new AddAccountForm(id);
            if (editAccountForm.ShowDialog() == DialogResult.OK)
                loadDataGridViewAccount();
        }

        private void btnDelAcc_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridViewAccount.CurrentCell.RowIndex;
            string id = dataGridViewAccount.Rows[rowindex].Cells[0].Value.ToString();
            _accData.delete(id);
            loadDataGridViewAccount();
        }

        private void btnViewAcc_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewAccount.CurrentCell.RowIndex;
            string id = dataGridViewAccount.Rows[rowindex].Cells[0].Value.ToString();

            AddAccountForm editAccountForm = new AddAccountForm(id);
            if (editAccountForm.ShowDialog() == DialogResult.OK)
                loadDataGridViewAccount();
        }

        private void btnFindAcc_Click(object sender, EventArgs e)
        {
            string keyword = txtKeywordAcc.Text;
            string category = cmbCategoryAccount.SelectedItem.ToString();
            DataTable queryResult = _accData.search(keyword, category);

            dataGridViewAccount.DataSource = queryResult;

            dataGridViewAccount.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        private void btnNextPageProduct_Click(object sender, EventArgs e)
        {
            CurrentProductPageIndex++;
            txtPageProduct.Text = CurrentProductPageIndex.ToString();
            if(CurrentProductPageIndex != 1)
                btnPrevPageProduct.Enabled = true;
            if (CurrentProductPageIndex == TotalProductPage)
                btnNextPageProduct.Enabled = false;
            loadDataGridViewProduct();
        }

        private void btnPrevPageProduct_Click(object sender, EventArgs e)
        {
            CurrentProductPageIndex--;
            txtPageProduct.Text = CurrentProductPageIndex.ToString();
            if (CurrentProductPageIndex != TotalProductPage)
                btnNextPageProduct.Enabled = true;
            if (CurrentProductPageIndex == 1)
                btnPrevPageProduct.Enabled = false;
            loadDataGridViewProduct();
        }

        private void mitemThongKeBan_Click(object sender, EventArgs e)
        {

        }

        private void mitemThongKeNhap_Click(object sender, EventArgs e)
        {
            using (DatePickerForm dateForm = new DatePickerForm())
            {

            }
        }

        private void dataGridViewReceipt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnViewBill_Click(sender, e);
        }

        private void dataGridViewInv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnViewInvoice_Click(sender, e);
        }

        private void dataGridViewProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnViewProduct_Click(sender, e);
        }

        private void dataGridViewAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnViewAcc_Click(sender, e);
        }
    }
}