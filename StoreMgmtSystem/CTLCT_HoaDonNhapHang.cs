using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class CTLCT_HoaDonNhapHang
    {
        DAOCT_HoaDonNhapHang dataHDNH = new DAOCT_HoaDonNhapHang();

        public bool save(DataTable table)
        {
            return dataHDNH.Save(table);
        }
    }
}
