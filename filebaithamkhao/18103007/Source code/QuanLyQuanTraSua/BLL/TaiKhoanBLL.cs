using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TaiKhoanBLL
    {
        QLQuanTraSuaDataContext QLTS = new QLQuanTraSuaDataContext();
        private static TaiKhoanBLL instance;

        public static TaiKhoanBLL Instance {
            get { if (instance == null) instance = new TaiKhoanBLL(); return instance; }
            private set { instance = value; }
        }
        public TaiKhoanBLL() { }
        public TaiKhoan GetAccountByUsername(string tendangnhap)
        {
            return QLTS.TaiKhoans.Where(tk => tk.TenDangNhap == tendangnhap).FirstOrDefault();
        }
        public bool UpdateAccount(string tendangnhap, string tentaikhoan, string matkhau, string matkhaumoi)
        {
            string hashPassNew = "";
            string hashPassOld = HashPassword(matkhau);
            if (matkhaumoi != "")
            {
                hashPassNew = HashPassword(matkhaumoi);
            }          

            int result = QLTS.USP_UpdateAccout(tendangnhap, tentaikhoan, hashPassOld, hashPassNew);
            QLTS.SubmitChanges();
            return result > 0;
        }
        public TaiKhoan login(string tendangnhap, string matkhau)
        {
            string hashPass = HashPassword(matkhau);
            return QLTS.TaiKhoans.Where(tk => tk.TenDangNhap == tendangnhap && tk.MatKhau == hashPass).FirstOrDefault();
  
        }
        public List<TaiKhoan> GetListAccount()
        {
            return QLTS.TaiKhoans.ToList();
        }
        public void InsertAccount(string tendangnhap, string tenhienthi, string matkhau)
        {
            TaiKhoan acc = new TaiKhoan();
            acc.TenDangNhap = tendangnhap;
            acc.TenTaiKhoan = tenhienthi;
            acc.id_CV = 2;
            acc.MatKhau = HashPassword(matkhau);

            QLTS.TaiKhoans.InsertOnSubmit(acc);
            QLTS.SubmitChanges();
        }
        public void InsertAccount(string tendangnhap, string tenhienthi,int id_cv)
        {
            TaiKhoan acc = new TaiKhoan();
            acc.TenDangNhap = tendangnhap;
            acc.TenTaiKhoan = tenhienthi;
            acc.id_CV = id_cv;
            acc.MatKhau = "c4ca4238a0b923820dcc509a6f75849b";

            QLTS.TaiKhoans.InsertOnSubmit(acc);
            QLTS.SubmitChanges();
        }
        public void UpdateAccount(string tendangnhap, string tenhienthi, int id_cv)
        {
            TaiKhoan acc = QLTS.TaiKhoans.Where(a => a.TenDangNhap == tendangnhap).FirstOrDefault();
            acc.TenTaiKhoan = tenhienthi;
            acc.id_CV = id_cv;

            QLTS.SubmitChanges();
        }
        public void DeleteAccount(string tendangnhap)
        {
            TaiKhoan acc = QLTS.TaiKhoans.Where(a => a.TenDangNhap == tendangnhap).FirstOrDefault();

            QLTS.TaiKhoans.DeleteOnSubmit(acc);
            QLTS.SubmitChanges();
        }
        public void ResetPass(string tendangnhap)
        {
            TaiKhoan acc = QLTS.TaiKhoans.Where(a => a.TenDangNhap == tendangnhap).FirstOrDefault();
            acc.MatKhau = "c4ca4238a0b923820dcc509a6f75849b";

            QLTS.SubmitChanges();
        }
        public string HashPassword(string matkhau)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(matkhau);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
