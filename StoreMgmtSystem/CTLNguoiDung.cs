using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class CTLNguoiDung
    {
        DAONguoiDung dataNguoiDung = new DAONguoiDung();

        public bool authenticate(NguoiDung nd)
        {
            //return true;
            //DataTable user = dataNguoiDung.Authenticate(nd);
            return dataNguoiDung.Authenticate(nd);
        }
    }
}
