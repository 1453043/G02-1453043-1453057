using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StoreMgmtSystem
{
    class CTLCT_HoaDonBanHang
    {
        DAOCT_HoaDonBanHang dataHDBH = new DAOCT_HoaDonBanHang();

        public bool save(DataTable table)
        {
            return dataHDBH.Save(table);
        }

        public DataTable search(string id)
        {
            return dataHDBH.Search(id);
        }

        public bool delete(string ID)
        {
            return dataHDBH.Delete(ID);
        }
    }
}
