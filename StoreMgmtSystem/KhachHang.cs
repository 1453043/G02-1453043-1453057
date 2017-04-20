using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class KhachHang
    {
        private string _id;
        private string _ten;
        private string _diaChi;
        private string _sdt;

        #region Contructor
        public KhachHang(string id, string ten, string diaChi, string sdt)
        {
            _id = id;
            _ten = ten;
            _diaChi = diaChi;
            _sdt = sdt;
        }
        #endregion

        #region Properties
        public string ID { set { this._id = value; } get { return this._id; } }
        public string Ten { set { this._ten = value; } get { return this._ten; } }
        public string DiaChi { set { this._diaChi = value; } get { return this._diaChi; } }
        public string Sdt { set { this._sdt = value; } get { return this._sdt; } }
        #endregion
    }
}
