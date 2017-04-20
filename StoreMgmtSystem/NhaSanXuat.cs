using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class NhaSanXuat
    {
        private string _id;
        private string _ten;
        private string _diaChi;

        #region Contructor
        public NhaSanXuat(string id, string ten, string diaChi)
        {
            _id = id;
            _ten = ten;
            _diaChi = diaChi;
        }
        #endregion

        #region Properties
        public string ID { set { this._id = value; } get { return this._id; } }
        public string Ten { set { this._ten = value; } get { return this._ten; } }
        public string DiaChi { set { this._diaChi = value; } get { return this._diaChi; } }
        #endregion
    }
}
