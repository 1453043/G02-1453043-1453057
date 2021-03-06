﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class NguoiDung
    {
        private string _id;
        private string _tenDangNhap;
        private string _matKhau;
        private string _hoTen;
        private int _loai;

        #region Contructor
        public NguoiDung(string id, string tenDangNhap, string matKhau, string hoTen, int loai)
        {
            _id = id;
            _tenDangNhap = tenDangNhap;
            _matKhau = matKhau;
            _hoTen = hoTen;
            _loai = loai;
        }
        public NguoiDung(string tenDangNhap, string matKhau)
        {
            _id = "";
            _tenDangNhap = tenDangNhap;
            _matKhau = matKhau;
            _hoTen = "";
        }
        #endregion

        #region Properties
        public string ID { set { this._id = value; } get { return this._id; } }
        public string TenDangNhap { set { this._tenDangNhap = value; } get { return this._tenDangNhap; } }
        public string MatKhau { set { this._matKhau = value; } get { return this._matKhau; } }
        public string HoTen { set { this._hoTen = value; } get { return this._hoTen; } }
        public int Loai { set { this._loai = value; } get { return this._loai; } }
        #endregion
    }
}
