using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.DAO;
using System.Data.SqlClient;
using System.Data;

namespace StoreMgmtSystem
{
    class DAOKhachHang : DataProvider
    {
        #region Constructor
        public DAOKhachHang()
        {
        }
        #endregion

        #region Methods
        public bool Save(KhachHang kh)
        {
            this.connect();
            bool bCheck = true;
            string query = "insert into KhachHang([id],[Ten],[DiaChi],[SDT]) values(@ID,@TEN,@DC,@SDT)";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.Add(new SqlParameter("@ID", kh.ID.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@TEN", kh.Ten.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@DC", kh.DiaChi));
            this.cm.Parameters.Add(new SqlParameter("@SDT", kh.Sdt.Trim()));
            try
            {
                this.cm.ExecuteNonQuery();
                this.disconnect();
            }
            catch (Exception ex)
            {
                this.disconnect();
                bCheck = false;
                throw ex;
            }
            return bCheck;
        }

        public DataTable Search()
        {
            try
            {
                this.connect();
                DataTable sqlDataTable = this.ExecuteQuery_DataTable(new SqlCommand("select * from KhachHang"));
                this.disconnect();
                return sqlDataTable;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable SearchWithKeyword(string keyword, string category)
        {
            SqlCommand cmd = new SqlCommand();
            string query = "";

            if (category == "Tên khách hàng")
            {
                query = "select id,Ten,SDT from KhachHang where Ten like '%' + @Ten + '%'";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Ten", keyword);
            }
            else if (category == "ID")
            {
                query = "select id,Ten,SDT from KhachHang where id like '%' + @ID + '%'";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", keyword);
            }
            else if (category == "Số điện thoại")
            {
                query = "select id,Ten,SDT from KhachHang where SDT = @SDT";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@SDT", keyword);
            }
            try
            {
                this.connect();
                DataTable sqlDataTable = this.ExecuteQuery_DataTable(cmd);
                this.disconnect();
                return sqlDataTable;
            }
            catch (Exception ex) { throw ex; }
        }


        #endregion
    }
}
