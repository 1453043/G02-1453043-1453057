using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class CT_HoaDonNhapHang
    {
        private string _idDonNhapHang;
        private string _idSanPham;
        private int _soLuong;
        private int _giaTien;

        #region Contructor
        public CT_HoaDonNhapHang(string idDon, string idSP, int soLuong, int giaTien)
        {
            _idDonNhapHang = idDon;
            _idSanPham = idSP;
            _soLuong = soLuong;
            _giaTien = giaTien;
        }
        #endregion

        #region Properties
        public string IDDonHang { set { this._idDonNhapHang = value; } get { return this._idDonNhapHang; } }
        public string IDSanPham { set { this._idSanPham = value; } get { return this._idSanPham; } }
        public int SoLuong { set { this._soLuong = value; } get { return this._soLuong; } }
        public int GiaTien { set { this._giaTien = value; } get { return this._giaTien; } }
        #endregion
    }
}
