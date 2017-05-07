using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace StoreMgmtSystem
{
    class CTLNguoiDung
    {
        DAONguoiDung dataNguoiDung = new DAONguoiDung();

        // trả về ID người dùng
        // 0 nếu không tồn tại người dùng
        public string authenticate(NguoiDung nd)
        {
            return dataNguoiDung.Authenticate(nd);
        }

        public int getTotalPage()
        {
            return dataNguoiDung.GetTotalPage();
        }

        public DataTable search()
        {
            return dataNguoiDung.Search();
        }

        public NguoiDung search(string id)
        {
            //DataTable result =  dataNguoiDung.Search(id, "ID");
            //return new NguoiDung(result.Rows[0]["id"].ToString(), result.Rows[0]["TenDangNhap"].ToString(),
            //    result.Rows[0]["MatKhau"].ToString(), result.Rows[0]["HoTen"].ToString(),
            //    int.Parse(result.Rows[0]["Loai"].ToString()));
            return dataNguoiDung.Search(id);
        }

        public DataTable search(string keyword, string category)
        {
            return dataNguoiDung.Search(keyword, category);
        }

        public int save(NguoiDung nd)
        {
            // kiem tra ten dang nhap
            DataTable queryresult =  dataNguoiDung.Search(nd.TenDangNhap, "Tên đăng nhập");
            if (queryresult.Rows.Count != 0)
                return 2;
            if(dataNguoiDung.Save(nd))
                return 1;
            return 0;
        }

        public int update(NguoiDung nd)
        {
            // kiem tra ten dang nhap
            //DataTable queryresult = dataNguoiDung.Search(nd.TenDangNhap, "Tên đăng nhập");
            //if (queryresult.Rows.Count != 0)
            //    return 2;
            try
            {
                if (dataNguoiDung.Update(nd) == 2)
                    return 2;
                return 1;
            }
            catch (Exception ex) { return 0; }
        }

        public bool delete(string id)
        {
            return dataNguoiDung.Delete(id);
        }
    }
}
