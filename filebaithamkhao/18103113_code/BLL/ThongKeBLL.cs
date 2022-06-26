using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ThongKeBLL
    {
        QLCHFastFoodDataContext DB = new QLCHFastFoodDataContext();
        ChiTietHoaDonBLL CTHDBLL = new ChiTietHoaDonBLL();
        HoaDonBLL HDBLL = new HoaDonBLL();
        int TongDT;
        public List<HoaDon> LayHoaDonTrongKhoangThoiGian(DateTime TuNgay, DateTime DenNgay)
        {
                TongDT = 0;
                var hds = new List<HoaDon>();
                List<HoaDon> HoaDon = DB.HoaDons.ToList();

                foreach (HoaDon hd in HoaDon)
                {
                     if(SoSanh(hd.NgayTao, TuNgay, DenNgay) == 1)
                     {
                        hds.Add(hd);
                        TongDT += (int)hd.TongTien;
                     }
                }
                return hds.ToList(); 
        }

        public int TongDoanhThu()
        {
            return TongDT;
        }

        public int SoSanh(string ngaytao, DateTime tungay, DateTime denngay)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            DateTime NgayTao = DateTime.ParseExact(ngaytao, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            int compare = DateTime.Compare(NgayTao, tungay);
            int compare2 = DateTime.Compare(NgayTao, denngay);

            if (compare >= 0 && compare2 <= 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<int> LayMaHoaDonTrongKhoangThoiGian(DateTime TuNgay, DateTime DenNgay)
        {
            var DanhSachMaHoaDon = new List<int>();

            foreach (HoaDon hd in HDBLL.LayTatCa())
            {
                if (SoSanh(hd.NgayTao, TuNgay, DenNgay) == 1)
                {
                    DanhSachMaHoaDon.Add(hd.ID);
                }
            }
            return DanhSachMaHoaDon.ToList();
        }
        
        int TongSL, TongT;
        public List<ChiTietHoaDon> LayChiTietHoaDonTrongKhoangThoiGian(DateTime TuNgay, DateTime DenNgay, string mamathang)
        {
            TongSL = 0;
            TongT = 0;
            var DanhSachChiTietHoaDon = new List<ChiTietHoaDon>();

            foreach (int MaHoaDon in LayMaHoaDonTrongKhoangThoiGian(TuNgay, DenNgay))
            {
                foreach(ChiTietHoaDon cthd in CTHDBLL.LayTatCa())
                {
                    if(cthd.MaHoaDon == MaHoaDon && cthd.MaMatHang == mamathang)
                    {
                        DanhSachChiTietHoaDon.Add(cthd);
                        TongSL += (int)cthd.SoLuong;
                        TongT += (int)cthd.ThanhTien;
                    }                  
                }
                
            }
            return DanhSachChiTietHoaDon.ToList();
        }

        public int TongSoLuong()
        {
            return TongSL;
        }
        public int TongTien()
        {
            return TongT;
        }

        public string LayTenMatHang(string ma)
        {
            MatHang mh = DB.MatHangs.Where(x => x.ID == ma).FirstOrDefault();
            return mh.TenMatHang;
        }
    }  
}
