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
    public partial class AddProduct : Form
    {
        private DAONhaSanXuat _NSXData = new DAONhaSanXuat();
        public AddProduct()
        {
            InitializeComponent();
            // load data NSX cho combo box
            DataTable nsxData = _NSXData.Search();
            cmbManu.DisplayMember = "TenNSX";
            cmbManu.ValueMember = "TenNSX";
            cmbManu.DataSource = nsxData.DefaultView;
            cmbManu.BindingContext = this.BindingContext;
        }

        private void btnAddManu_Click(object sender, EventArgs e)
        {
            AddManufacturer addManuForm = new AddManufacturer();
            if(addManuForm.ShowDialog() == DialogResult.OK)
            {
                // thêm NSX mới thành công
                // cho vào combobox NSX
                DataTable nsxData = _NSXData.Search();

                cmbManu.DisplayMember = "TenNSX";
                cmbManu.ValueMember = "TenNSX";
                cmbManu.DataSource = nsxData.DefaultView;
                cmbManu.BindingContext = this.BindingContext;
            }
        }
    }
}
