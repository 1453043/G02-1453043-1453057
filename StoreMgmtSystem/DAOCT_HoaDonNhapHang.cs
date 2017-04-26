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
        #endregion
    }
}
