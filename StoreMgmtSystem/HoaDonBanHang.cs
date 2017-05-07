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
        private int _tongTien;

        #region Contructor
        public HoaDonBanHang(string id, string idNguoiBan, string idNguoiMua, DateTime ngayLap, int tong)
        {
            _id = id;
            _idNguoiBan = idNguoiBan;
            _idNguoiMua = idNguoiMua;
            _ngayLap = ngayLap;
            _tongTien = tong;
        }
        #endregion

        #region Properties
        public string ID { set { this._id = value; } get { return this._id; } }
        public string IDNguoiBan { set { this._idNguoiBan = value; } get { return this._idNguoiBan; } }
        public string IDNguoiMua { set { this._idNguoiMua = value; } get { return this._idNguoiMua; } }
        public DateTime NgayLap { set { this._ngayLap = value; } get { return this._ngayLap; } }
        public int TongTien { set { this._tongTien = value; } get { return this._tongTien; } }
        #endregion
    }
}
