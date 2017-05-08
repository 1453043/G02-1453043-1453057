using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class CTLHoaDonNhapHang
    {
        DAOHoaDonNhapHang dataHDNH = new DAOHoaDonNhapHang();
        DAOCT_HoaDonNhapHang dataCT = new DAOCT_HoaDonNhapHang();

        public bool save(string idHD, string idNguoiLap, DateTime ngayLap, int tong)
        {
            HoaDonNhapHang hd = new HoaDonNhapHang(idHD, idNguoiLap, ngayLap, tong);
            return dataHDNH.Save(hd);
        }

        public bool update(string idHD, string idNguoiLap, DateTime ngayLap, int tong)
        {
            HoaDonNhapHang hd = new HoaDonNhapHang(idHD, idNguoiLap, ngayLap, tong);
            return dataHDNH.Update(hd);
        }

        public DataTable search()
        {
            return dataHDNH.Search();
        }

        public DataTable searchKeyword(string keyword, string category)
        {
            return dataHDNH.SearchWithKeyword(keyword, category);
        }

        public bool delete(string ID)
        {
            // delete CT_HoaDonNhapHang trước
            if (dataCT.Delete(ID))
            {
                return dataHDNH.Delete(ID);
            }
            return false;
        }
    }
}
