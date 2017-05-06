using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Main.DAO;
using System.Data.SqlClient;

namespace StoreMgmtSystem
{
    class DAOCT_HoaDonBanHang : DataProvider
    {
        #region Constructor
        public DAOCT_HoaDonBanHang()
        {
        }
        #endregion

        #region Methods
        public bool Save(DataTable ct)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strcnnString))
            {
                bulkCopy.BulkCopyTimeout = 600; // in seconds
                bulkCopy.DestinationTableName = "CT_HoaDonBanHang";
                try
                {
                    bulkCopy.WriteToServer(ct);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable Search(string id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select idSanPham,SoLuong,GiaTien from CT_HoaDonBanHang where idBanHang = @ID";
            cm.Parameters.AddWithValue("@ID", id);
            try
            {
                this.connect();
                DataTable sqlDataTable = this.ExecuteQuery_DataTable(cm);
                this.disconnect();
                return sqlDataTable;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Delete(string id)
        {
            this.connect();
            bool bCheck = true;
            string query = "delete from CT_HoaDonBanHang where([idBanHang] = @ID)";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.Add(new SqlParameter("@ID", id));
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
        #endregion
    }
}
