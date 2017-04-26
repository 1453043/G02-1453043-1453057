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

        public bool save(string idHD, string idNguoiLap, DateTime ngayLap)
        {
            HoaDonNhapHang hd = new HoaDonNhapHang(idHD, idNguoiLap, ngayLap);
            return dataHDNH.Save(hd);
        }

        public DataTable search()
        {
            return dataHDNH.Search();
        }
    }
}
