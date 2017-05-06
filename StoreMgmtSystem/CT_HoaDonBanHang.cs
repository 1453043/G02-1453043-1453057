using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class CT_HoaDonBanHang
    {
        private string _idDonBanHang;
        private string _idSanPham;
        private int _soLuong;
        private int _giaTien;

        #region Contructor
        public CT_HoaDonBanHang(string idDon, string idSP, int soLuong, int giaTien)
        {
            _idDonBanHang = idDon;
            _idSanPham = idSP;
            _soLuong = soLuong;
            _giaTien = giaTien;
        }
        #endregion

        #region Properties
        public string IDDonHang { set { this._idDonBanHang = value; } get { return this._idDonBanHang; } }
        public string IDSanPham { set { this._idSanPham = value; } get { return this._idSanPham; } }
        public int SoLuong { set { this._soLuong = value; } get { return this._soLuong; } }
        public int GiaTien { set { this._giaTien = value; } get { return this._giaTien; } }
        #endregion
    }
}
