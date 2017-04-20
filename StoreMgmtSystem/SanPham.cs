using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class SanPham
    {
        private string _id;
        private string _idNSX;
        private string _thongTinBaoHanh;
        private string _ten;
        private string _moTa;
        private int _gia;

        #region Contructor
        public SanPham(string id, string idNSX, string ten, string baoHanh, string moTa, int gia)
        {
            _id = id;
            _idNSX = idNSX;
            _thongTinBaoHanh = baoHanh;
            _ten = ten;
            _moTa = moTa;
            _gia = gia;
        }
        #endregion

        #region Properties
        public string ID { set { this._id = value; } get { return this._id; } }
        public string IDNSX { set { this._idNSX = value; } get { return this._idNSX; } }
        public string BaoHanh { set { this._thongTinBaoHanh = value; } get { return this._thongTinBaoHanh; } }
        public string Ten { set { this._ten = value; } get { return this._ten; } }
        public string MoTa { set { this._moTa = value; } get { return this._moTa; } }
        public int Gia { set { this._gia = value; } get { return this._gia; } }
        #endregion
    }
}
