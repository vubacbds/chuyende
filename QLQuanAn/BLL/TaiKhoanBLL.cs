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
        QLQuanAnDataContext DB = new QLQuanAnDataContext();
        
        public List<TaiKhoan> LayTatCa()
        {
            return DB.TaiKhoans.ToList();
        } 

        public bool KiemTraDangNhap(string tendangnhap, string matkhau)
        {
            byte[] x = ASCIIEncoding.ASCII.GetBytes(matkhau);   //Mã hóa mật khẩu
            byte[] hasdata = new MD5CryptoServiceProvider().ComputeHash(x);
            string hasmatkhau = "";
            foreach (byte item in hasdata)
            {
                hasmatkhau += item;
            }
            TaiKhoan tk = DB.TaiKhoans.Where(t => t.tendangnhap == tendangnhap && t.matkhau == hasmatkhau).FirstOrDefault();
            if (tk != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ThemTaiKhoan(string tendangnhap, string tenhienthi)
        {
            byte[] x = ASCIIEncoding.ASCII.GetBytes("6868");  //Mã hóa mật khẩu
            byte[] hasdata = new MD5CryptoServiceProvider().ComputeHash(x);

            string hasmatkhau = "";
            foreach (byte item in hasdata)
            {
                hasmatkhau += item;
            }
            TaiKhoan tk = new TaiKhoan();
            tk.tendangnhap = tendangnhap;
            tk.tenhienthi = tenhienthi;
            tk.matkhau = hasmatkhau;

            DB.TaiKhoans.InsertOnSubmit(tk);
            DB.SubmitChanges();
        }
        public TaiKhoan LayTaiKhoanTheoTenDangNhap(string tendangnhap)
        {
            return DB.TaiKhoans.Where(t => t.tendangnhap == tendangnhap).FirstOrDefault();
        }
        public void Sua(string tendangnhap, string tenhienthi, string matkhau)
        {
            TaiKhoan tk = DB.TaiKhoans.FirstOrDefault(t => t.tendangnhap == tendangnhap);
            tk.tenhienthi = tenhienthi;
            if (matkhau != null)
            {
                byte[] x = ASCIIEncoding.ASCII.GetBytes(matkhau);  //Mã hóa mật khẩu
                byte[] hasdata = new MD5CryptoServiceProvider().ComputeHash(x);

                string hasmatkhau = "";
                foreach (byte item in hasdata)
                {
                    hasmatkhau += item;
                }
                tk.matkhau = hasmatkhau;
            }
            DB.SubmitChanges();
        }

    }
}
