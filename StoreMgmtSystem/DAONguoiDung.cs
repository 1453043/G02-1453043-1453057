using System;
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
        // trả về ID người dùng
        // 0 nếu không tồn tại người dùng
        public string Authenticate(NguoiDung user)
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
                if (sqlDataTable.Tables[0].Rows.Count == 0)
                    return "";
                else
                    return sqlDataTable.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable Search()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select id,TenDangNhap,HoTen from NguoiDung";
            try
            {
                this.connect();
                DataTable sqlDataTable = this.ExecuteQuery_DataTable(cm);
                this.disconnect();
                return sqlDataTable;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
