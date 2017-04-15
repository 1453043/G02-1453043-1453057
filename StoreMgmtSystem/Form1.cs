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
        public Form1()
        {
            InitializeComponent();
            CultureInfo ci = new CultureInfo("vi-VN");
            loadLanguageResource(ci);
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
            menuAccount.Text = rm.GetString("account", ci);
            mitemLogin.Text = rm.GetString("log_in", ci);
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
    }
}
