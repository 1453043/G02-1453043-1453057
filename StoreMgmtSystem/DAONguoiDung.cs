using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Main.DAO;

namespace StoreMgmtSystem
{
    class DAONguoiDung : DataProvider
    {
        #region Constructor
        public DAONguoiDung()
        {
        }
        #endregion

        #region Methods
        public DataTable Search(NguoiDung user)
        {
            string s = "select * from NguoiDung where TenDangNhap = @user and MatKhau = @pass";
            SqlCommand cmd = new SqlCommand(s);
            cmd.Parameters.AddWithValue("@user", user.TenDangNhap);
            cmd.Parameters.AddWithValue("@pass", user.MatKhau);
            try
            {
                this.connect();
                DataSet sqlDataTable = this.ExecuteQuery(cmd);
                this.disconnect();
                if (sqlDataTable.Tables == null)
                    return null;
                else
                    return sqlDataTable.Tables[0];
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
