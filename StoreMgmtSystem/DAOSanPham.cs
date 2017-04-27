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
    class DAOSanPham : DataProvider
    {
        #region Constructor
        public DAOSanPham()
        {
        }
        #endregion

        #region Methods
        public bool Save(SanPham Sp)
        {
            this.connect();
            bool bCheck = true;
            string query = "insert into SanPham([id],[idNSX],[ThongTinBaoHanh],[TenSP],[MoTa],[Gia],[GiaGoc])"
                + "values(@ID,@IDNSX,@BH,@TEN,@MOTA,@GIA,@GIAGOC)";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.Add(new SqlParameter("@ID", Sp.ID.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@IDNSX", Sp.IDNSX.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@BH", Sp.BaoHanh.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@TEN", Sp.Ten.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@MOTA", Sp.MoTa.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@GIA", Sp.Gia));
            this.cm.Parameters.Add(new SqlParameter("@GIAGOC", Sp.GiaGoc));
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

        public bool Update(SanPham sp)
        {
            this.connect();
            bool bCheck = true;
            string query = "update SanPham set [TenSP]=@TEN, [idNSX]=@IDNSX, [Gia]=@GIA, [GiaGoc]=@GIAGOC," +
                "[ThongTinBaoHanh]=@TT, [MoTa]=@MOTA where [id] = @ID";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.Add(new SqlParameter("@TEN", sp.Ten.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@IDNSX", sp.IDNSX.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@GIA", sp.Gia));
            this.cm.Parameters.Add(new SqlParameter("@GIAGOC", sp.GiaGoc));
            this.cm.Parameters.Add(new SqlParameter("@TT", sp.BaoHanh.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@MOTA", sp.MoTa.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@ID", sp.ID.Trim()));
            try
            { this.cm.ExecuteNonQuery(); this.disconnect(); }
            catch (Exception ex) { this.disconnect(); bCheck = false; throw ex; }
            return bCheck;
        }

        public DataTable Search()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from SanPham";
            try
            {
                this.connect();
                DataTable sqlDataTable = this.ExecuteQuery_DataTable(cm);
                this.disconnect();
                return sqlDataTable;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable SearchForHoaDon()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select id,TenSP,GiaGoc from SanPham";
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

            if (category == "Tên sản phẩm")
            {
                query = "select * from SanPham where TenSP like '%' + @TenSp + '%'";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@TenSp", keyword);
            }
            else if (category == "ID")
            {
                query = "select * from SanPham where id like '%' + @ID + '%'";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", keyword);
            }
            else if (category == "Mã nhà sản xuất")
            {
                query = "select * from SanPham where idNSX = @idnsx";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@idnsx", keyword);
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

        public bool Delete(string idSP)
        {
            this.connect();
            bool bCheck = true;
            string query = "delete from SanPham where([id] = @ID)";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.Add(new SqlParameter("@ID", idSP));
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
