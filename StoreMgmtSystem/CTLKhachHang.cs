using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StoreMgmtSystem
{
    class CTLKhachHang
    {
        private DAOKhachHang dataKH = new DAOKhachHang();

        public bool save(KhachHang KH)
        {
            return dataKH.Save(KH);
        }

        public int save(string id, string name, string address, string sdt)
        {
            // kiểm tra tính hợp lệ của field
            if (name.Length == 0)
            {
                return 2;
            }
            if (sdt.Length == 0)
            {
                return 3;
            }
            KhachHang KHObj = new KhachHang(id, name, address, sdt);
            if (dataKH.Save(KHObj))
                return 1;
            return 0;
        }

        public DataTable search()
        {
            return dataKH.Search();
        }

        public DataTable searchKeyword(string keyword, string category)
        {
            return dataKH.SearchWithKeyword(keyword, category);
        }
    }
}
