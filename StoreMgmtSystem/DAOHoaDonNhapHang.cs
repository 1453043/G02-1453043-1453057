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
    class DAOHoaDonNhapHang : DataProvider
    {
        #region Constructor
        public DAOHoaDonNhapHang()
        {
        }
        #endregion

        #region Methods
        public bool Save(HoaDonNhapHang hd)
        {
            this.connect();
            bool bCheck = true;
            string query = "insert into HoaDonNhapHang([id],[idNguoiLap],[NgayLap],[TongGiaTien])"
                + "values(@ID,@IDuser,@date,@tong)";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.AddWithValue("ID", hd.ID.Trim());
            this.cm.Parameters.AddWithValue("IDuser", hd.IDNguoiLap.Trim());
            this.cm.Parameters.AddWithValue("date", hd.NgayLap.ToString("yyyy-MM-dd"));
            this.cm.Parameters.AddWithValue("tong", hd.TongTien);
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

        public bool Update(HoaDonNhapHang hd)
        {
            this.connect();
            bool bCheck = true;
            string query = "update HoaDonNhapHang set [idNguoiLap]=@IDuser, [NgayLap]=@date, [TongGiaTien]=@tong" +
                " where [id] = @ID";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.AddWithValue("ID", hd.ID.Trim());
            this.cm.Parameters.AddWithValue("IDuser", hd.IDNguoiLap.Trim());
            this.cm.Parameters.AddWithValue("date", hd.NgayLap.ToString("yyyy-MM-dd"));
            this.cm.Parameters.AddWithValue("tong", hd.TongTien);
            try
            { this.cm.ExecuteNonQuery(); this.disconnect(); }
            catch (Exception ex) { this.disconnect(); bCheck = false; throw ex; }
            return bCheck;
        }

        public DataTable Search()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from HoaDonNhapHang";
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
            string query = "delete from HoaDonNhapHang where([id] = @ID)";
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
