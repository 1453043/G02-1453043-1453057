using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class HoaDonBanHang
    {
        private string _id;
        private string _idNguoiBan;
        private string _idNguoiMua;
        private DateTime _ngayLap;

        #region Contructor
        public HoaDonBanHang(string id, string idNguoiBan, string idNguoiMua, DateTime ngayLap)
        {
            _id = id;
            _idNguoiBan = idNguoiBan;
            _idNguoiMua = idNguoiMua;
            _ngayLap = ngayLap;
        }
        #endregion

        #region Properties
        public string ID { set { this._id = value; } get { return this._id; } }
        public string IDNguoiBan { set { this._idNguoiBan = value; } get { return this._idNguoiBan; } }
        public string IDNguoiMua { set { this._idNguoiMua = value; } get { return this._idNguoiMua; } }
        public DateTime NgayLap { set { this._ngayLap = value; } get { return this._ngayLap; } }
        #endregion
    }
}
