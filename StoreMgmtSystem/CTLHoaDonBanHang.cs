﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StoreMgmtSystem
{
    class CTLHoaDonBanHang
    {
        DAOHoaDonBanHang dataHDBH = new DAOHoaDonBanHang();
        DAOCT_HoaDonBanHang dataCT = new DAOCT_HoaDonBanHang();

        public bool save(string idHD, string idNguoiBan, string idNguoiMua, DateTime ngayLap, int tong)
        {
            HoaDonBanHang hd = new HoaDonBanHang(idHD, idNguoiBan, idNguoiMua, ngayLap, tong);
            return dataHDBH.Save(hd);
        }

        public bool update(string idHD, string idNguoiBan, string idNguoiMua, DateTime ngayLap, int tong)
        {
            HoaDonBanHang hd = new HoaDonBanHang(idHD, idNguoiBan, idNguoiMua, ngayLap, tong);
            return dataHDBH.Update(hd);
        }

        public DataTable search()
        {
            return dataHDBH.Search();
        }

        public DataTable searchKeyword(string keyword, string category)
        {
            return dataHDBH.SearchWithKeyword(keyword, category);
        }

        public bool delete(string ID)
        {
            // delete CT_HoaDonBanHang trước
            if (dataCT.Delete(ID))
            {
                return dataHDBH.Delete(ID);
            }
            return false;
        }
    }
}
