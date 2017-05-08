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
    class DAOHoaDonBanHang : DataProvider
    {
        #region Constructor
        public DAOHoaDonBanHang()
        {
        }
        #endregion

        #region Methods
        public bool Save(HoaDonBanHang hd)
        {
            this.connect();
            bool bCheck = true;
            string query = "insert into HoaDonBanHang([id],[idNguoiBan],[idNguoiMua],[NgayLap],[TongGiaTien])"
                + "values(@ID,@IDuser,@IDguest,@date,@tong)";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.AddWithValue("ID", hd.ID.Trim());
            this.cm.Parameters.AddWithValue("IDuser", hd.IDNguoiBan.Trim());
            this.cm.Parameters.AddWithValue("IDguest", hd.IDNguoiMua.Trim());
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

        public bool Update(HoaDonBanHang hd)
        {
            this.connect();
            bool bCheck = true;
            string query = "update HoaDonBanHang set [idNguoiMua]=@IDguest, [NgayLap]=@date, [TongGiaTien]=@tong" +
                " where [id] = @ID";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.AddWithValue("ID", hd.ID.Trim());
            this.cm.Parameters.AddWithValue("IDguest", hd.IDNguoiMua.Trim());
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
            //cm.CommandText = "select * from HoaDonBanHang";
            cm.CommandText = "select HoaDonBanHang.id,HoTen as NguoiLapHoaDon,idNguoiMua,NgayLap,TongGiaTien "
                + "from HoaDonBanHang join NguoiDung on idNguoiBan = NguoiDung.id";
            try
            {
                this.connect();
                DataTable sqlDataTable = this.ExecuteQuery_DataTable(cm);
                this.disconnect();
                return sqlDataTable;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable SearchWithKeyword(string keyword, string category)
        {
            SqlCommand cmd = new SqlCommand();
            string query = "";

            if (category == "Tên người lập")
            {
                query = "select HoaDonBanHang.id,HoTen as NguoiLapHoaDon,idNguoiMua,NgayLap,TongGiaTien "
                + "from HoaDonBanHang join NguoiDung on idNguoiBan = NguoiDung.id where HoTen like '%' + @Ten + '%'";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Ten", keyword);
            }
            else if (category == "Mã hóa đơn")
            {
                query = "select HoaDonBanHang.id,HoTen as NguoiLapHoaDon,idNguoiMua,NgayLap,TongGiaTien "
                + "from HoaDonBanHang join NguoiDung on idNguoiBan = NguoiDung.id where HoaDonBanHang.id like '%' + @ID + '%'";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", keyword);
            }
            else if (category == "Mã khách hàng")
            {
                query = "select HoaDonBanHang.id,HoTen as NguoiLapHoaDon,idNguoiMua,NgayLap,TongGiaTien "
                + "from HoaDonBanHang join NguoiDung on idNguoiBan = NguoiDung.id where idNguoiMua like '%' + @IDMua + '%'";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@IDMua", keyword);
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

        public bool Delete(string id)
        {
            this.connect();
            bool bCheck = true;
            string query = "delete from HoaDonBanHang where([id] = @ID)";
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
