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
    public partial class DatePickerForm : Form
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public DatePickerForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            startDate = startDatePicker.Value;
            endDate = endDatePicker.Value;
        }
    }
}
