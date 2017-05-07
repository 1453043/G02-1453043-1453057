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
            string query = "insert into NSX([id],[Ten],[DiaChi],[SDT]) values(@ID,@TEN,@DC,@SDT)";
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
        #endregion
    }
}
