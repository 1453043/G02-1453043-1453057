using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class CTLSanPham
    {
        DAOSanPham dataSanPham = new DAOSanPham();

        public bool save(SanPham sp)
        {
            return dataSanPham.Save(sp);
        }

        public int save(string id, string NSX, string name, string bh, string desc, int gia)
        {
            // kiểm tra các fields
            if (id.Length == 0)
                return 2;
            if (name.Length == 0)
                return 3;
            SanPham spObj = new SanPham(id, NSX, name, bh, desc, gia);
            if (dataSanPham.Save(spObj))
                return 1;
            return 0;
        }

        public bool update(SanPham sp)
        {
            return dataSanPham.Update(sp);
        }

        public bool delete(string ID)
        {
            return dataSanPham.Delete(ID);
        }

        public int update(string id, string NSX, string name, string bh, string desc, int gia)
        {
            if (id.Length == 0)
                return 2;
            if (name.Length == 0)
                return 3;
            SanPham spObj = new SanPham(id, NSX, name, bh, desc, gia);
            if (dataSanPham.Update(spObj))
                return 1;
            return 0;
        }

        public DataTable search()
        {
            return dataSanPham.Search();
        }

        public DataTable searchForHoaDon()
        {
            return dataSanPham.SearchForHoaDon();
        }

        public DataTable searchKeyword(string keyword, string category)
        {
            return dataSanPham.SearchWithKeyword(keyword, category);
        }

    }
}
