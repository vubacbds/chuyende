using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class HoaDonBLL
    {
        QLCHFastFoodDataContext DB = new QLCHFastFoodDataContext();
        ChiTietHoaDonBLL CTHDBLL = new ChiTietHoaDonBLL();
        public List<HoaDon> LayTatCa()
        {
            return DB.HoaDons.ToList();
        }
        public void Them(int ID, string TenNguoiMua, string SoDienThoai)
        {
            HoaDon hd = new HoaDon();
            hd.ID = ID;
            hd.TenNguoiMua = TenNguoiMua;
            hd.SoDienThoai = SoDienThoai;

            //Lấy thời gian hiện tại
            #region  
           
            CultureInfo viVn = new CultureInfo("vi-VN");
            int day = DateTime.Now.Day;                    //Lấy ngày hiện tại
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            DateTime n = new DateTime(year, month, day);   //Chuyển thành datetime
            string ngaytao = n.ToString("d", viVn);          //Thanh đổi định dạng thành giờ VN

            CultureInfo enUs = new CultureInfo("en-US");    //Lấy giờ hiện tại
            DateTime g = DateTime.Now;
            string giotao = g.ToString("t", enUs);         
            #endregion

            hd.NgayTao = ngaytao;
            hd.Giotao = giotao;
            hd.TongTien = CTHDBLL.TongTien();

            DB.HoaDons.InsertOnSubmit(hd);
            DB.SubmitChanges();
        }

        public string LayNgay(int ma)
        {
            return DB.HoaDons.FirstOrDefault(x => x.ID == ma).NgayTao.ToString();
        }

        public string LayGio(int ma)
        {
            return DB.HoaDons.FirstOrDefault(x => x.ID == ma).Giotao.ToString();
        }

        public string LayKhachHang(int ma)
        {
            return DB.HoaDons.FirstOrDefault(x => x.ID == ma).TenNguoiMua;
        }

        public string LaySDT(int ma)
        {
            return DB.HoaDons.FirstOrDefault(x => x.ID == ma).SoDienThoai;
        }

        public int LayTongTien(int ma)
        {
            return (int)DB.HoaDons.FirstOrDefault(x => x.ID == ma).TongTien;
        }
    }
}


