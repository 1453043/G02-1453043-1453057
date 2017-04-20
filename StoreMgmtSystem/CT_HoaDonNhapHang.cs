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

        #region Contructor
        public CT_HoaDonNhapHang(string idDon, string idSP, int soLuong)
        {
            _idDonNhapHang = idDon;
            _idSanPham = idSP;
            _soLuong = soLuong;
        }
        #endregion

        #region Properties
        public string IDDonHang { set { this._idDonNhapHang = value; } get { return this._idDonNhapHang; } }
        public string IDSanPham { set { this._idSanPham = value; } get { return this._idSanPham; } }
        public int SoLuong { set { this._soLuong = value; } get { return this._soLuong; } }
        #endregion
    }
}
