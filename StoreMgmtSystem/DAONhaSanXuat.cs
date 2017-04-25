using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Main.DAO;

namespace StoreMgmtSystem
{
    class DAONhaSanXuat : DataProvider
    {
        #region Constructor
        public DAONhaSanXuat()
        {
        }
        #endregion

        #region Methods
        public bool Save(NhaSanXuat Nsx)
        {
            this.connect();
            bool bCheck = true;
            string query = "insert into NSX([id],[TenNSX],[DiaChi]) values(@ID,@TEN,@DC)";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.Add(new SqlParameter("@ID", Nsx.ID.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@TEN", Nsx.Ten.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@DC", Nsx.DiaChi));
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
                DataTable sqlDataTable = this.ExecuteQuery_DataTable("select * from NSX");
                this.disconnect();
                return sqlDataTable;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
