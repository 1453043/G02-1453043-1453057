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

        // trả về ID người dùng
        // 0 nếu không tồn tại người dùng
        public string authenticate(NguoiDung nd)
        {
            return dataNguoiDung.Authenticate(nd);
        }

        public DataTable search()
        {
            return dataNguoiDung.Search();
        }

    }
}
