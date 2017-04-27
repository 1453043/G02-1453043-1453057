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
    class DAOCT_HoaDonNhapHang : DataProvider
    {
        #region Constructor
        public DAOCT_HoaDonNhapHang()
        {
        }
        #endregion

        #region Methods
        public bool Save(DataTable ct)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strcnnString))
            {
                bulkCopy.BulkCopyTimeout = 600; // in seconds
                bulkCopy.DestinationTableName = "CT_HoaDonNhapHang";
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
            cm.CommandText = "select idSanPham,SoLuong,GiaTien from CT_HoaDonNhapHang where idNhapHang = @ID";
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
            string query = "delete from CT_HoaDonNhapHang where([idNhapHang] = @ID)";
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
