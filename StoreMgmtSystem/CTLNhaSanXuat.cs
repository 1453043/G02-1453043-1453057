using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class CTLNhaSanXuat
    {
        private DAONhaSanXuat dataNSX = new DAONhaSanXuat();

        public bool save(NhaSanXuat Nsx)
        {
            return dataNSX.Save(Nsx);
        }

        public int save(string id, string name, string address)
        {
            // kiểm tra tính hợp lệ của field
            if (id.Length == 0)
            {
                return 2;
            }
            if (name.Length == 0)
            {
                return 3;
            }
            NhaSanXuat nsxObj = new NhaSanXuat(id, name, address);
            if (dataNSX.Save(nsxObj))
                return 1;
            return 0;
        }

        public DataTable search()
        {
            return dataNSX.Search();
        }
    }
}
