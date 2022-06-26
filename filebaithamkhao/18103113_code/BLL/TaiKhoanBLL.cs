using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TaiKhoanBLL
    {
        QLCHFastFoodDataContext DB = new QLCHFastFoodDataContext();

        public List<TaiKhoan> LayTatCa()
        {
            return DB.TaiKhoans.ToList();
        }

        public TaiKhoan LayTheoTenDangNhapVaMatKhau(string tendangnhap, string matkhau)
        {
            byte[] x = ASCIIEncoding.ASCII.GetBytes(matkhau);   //Mã hóa mật khẩu
            byte[] hasdata = new MD5CryptoServiceProvider().ComputeHash(x);
            string hasmatkhau = "";
            foreach (byte item in hasdata)
            {   
                hasmatkhau += item;
            }
            return DB.TaiKhoans.Where(tk => tk.TenDangNhap == tendangnhap && tk.MatKhau == hasmatkhau).FirstOrDefault();
        }

        public void DangKy(string tendangnhap, string matkhau)
        {
            byte[] x = ASCIIEncoding.ASCII.GetBytes(matkhau);  //Mã hóa mật khẩu
            byte[] hasdata = new MD5CryptoServiceProvider().ComputeHash(x);

            string hasmatkhau = "";
            foreach (byte item in hasdata)
            {
                hasmatkhau += item;
            }
            TaiKhoan tk = new TaiKhoan();
            tk.TenDangNhap = tendangnhap;
            tk.MatKhau = hasmatkhau;

            DB.TaiKhoans.InsertOnSubmit(tk);
            DB.SubmitChanges();
        }

        public int KiemTraTenTaiKhoanBiTrung(string tentaikhoan)
        {
            int Trung = 0;
            TaiKhoan a = DB.TaiKhoans.Where(tk => tk.TenDangNhap == tentaikhoan).FirstOrDefault();
            if(a != null)
            {
                Trung = 1;
            }
            return Trung;
        }
    }
}
