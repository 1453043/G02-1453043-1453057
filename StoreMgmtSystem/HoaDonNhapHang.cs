using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class HoaDonNhapHang
    {
        private string _id;
        private string _idNguoiLap;
        private DateTime _ngayLap;
        private int _tongTien;

        #region Contructor
        public HoaDonNhapHang(string id, string idNguoiLap, DateTime ngayLap, int tong)
        {
            _id = id;
            _idNguoiLap = idNguoiLap;
            _ngayLap = ngayLap;
            _tongTien = tong;
        }
        #endregion

        #region Properties
        public string ID { set { this._id = value; } get { return this._id; } }
        public string IDNguoiLap { set { this._idNguoiLap = value; } get { return this._idNguoiLap; } }
        public DateTime NgayLap { set { this._ngayLap = value; } get { return this._ngayLap; } }
        public int TongTien { set { this._tongTien = value; } get { return this._tongTien; } }
        #endregion
    }
}
