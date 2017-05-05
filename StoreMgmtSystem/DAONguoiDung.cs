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
            cm.CommandText = "select id,TenDangNhap,HoTen,Loai from NguoiDung";
            try
            {
                this.connect();
                DataTable sqlDataTable = this.ExecuteQuery_DataTable(cm);
                this.disconnect();
                return sqlDataTable;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable Search(string keyword, string category)
        {
            SqlCommand cmd = new SqlCommand();
            string query = "";
            if (category == "ID")
            {
                query = "select id,TenDangNhap,HoTen,Loai from NguoiDung where id = @Id";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Id", keyword);
            }
            else if (category == "Tên đăng nhập")
            {
                query = "select id,TenDangNhap,HoTen,Loai from NguoiDung where TenDangNhap like '%' + @TenDN + '%'";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@TenDN", keyword);
            }
            else if (category == "Họ tên")
            {
                query = "select id,TenDangNhap,HoTen,Loai from NguoiDung where HoTen like '%' + @HoTen + '%'";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@HoTen", keyword);
            }
            else if (category == "Loại")
            {
                query = "select id,TenDangNhap,HoTen,Loai from NguoiDung where Loai like '%' + @loai + '%'";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@loai", keyword);
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

        public bool Save(NguoiDung nd)
        {
            this.connect();
            bool bCheck = true;
            string query = "insert into NguoiDung([id],[TenDangNhap],[MatKhau],[HoTen],[Loai])"
                + "values(@ID,@username,@password,@name,@type)";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.Add(new SqlParameter("@ID", nd.ID.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@username", nd.TenDangNhap.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@password", nd.MatKhau.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@name", nd.HoTen.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@type", nd.Loai));
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

        public bool Update(NguoiDung nd)
        {
            this.connect();
            bool bCheck = true;
            string query = "update NguoiDung set [TenDangNhap]=@username, [MatKhau]=@password, [HoTen]=@name, [Loai]=@type" +
                " where [id] = @ID";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.Add(new SqlParameter("@ID", nd.ID.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@username", nd.TenDangNhap.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@password", nd.MatKhau.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@name", nd.HoTen.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@type", nd.Loai));
            try
            { this.cm.ExecuteNonQuery(); this.disconnect(); }
            catch (Exception ex) { this.disconnect(); bCheck = false; throw ex; }
            return bCheck;
        }

        public bool Delete(string id)
        {
            this.connect();
            bool bCheck = true;
            string query = "delete from NguoiDung where([id] = @ID)";
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

