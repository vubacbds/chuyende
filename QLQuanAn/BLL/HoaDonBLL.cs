using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class HoaDonBLL
    {
        QLQuanAnDataContext DB = new QLQuanAnDataContext();
        public List<HoaDon> LayTatCa()
        {
            return DB.HoaDons.ToList();
        }
        public HoaDon LayHoaDonTheoIDBanAn(int idbanan)
        {
            return DB.HoaDons.Where(hd => hd.idbanan==idbanan && hd.trangthai==0).FirstOrDefault();
        }
        public HoaDon KiemTraCoXoaDuocBanAnKhong(int idbanan)
        {
            return DB.HoaDons.Where(hd => hd.idbanan == idbanan).FirstOrDefault();
        }
        public void Them(int IDBanAn, string idhoadon, string nguoitao)
        {
            HoaDon hd = new HoaDon();
            hd.id = idhoadon;
            hd.idbanan = IDBanAn;
            hd.ngayvao = DateTime.Now;
            hd.nguoitao = nguoitao;

            DB.HoaDons.InsertOnSubmit(hd);
            DB.SubmitChanges();
        }
        public void Sua(int idbanan, int giamgia, int tongtien)
        {
            HoaDon hd = DB.HoaDons.FirstOrDefault(h => h.idbanan == idbanan && h.trangthai == 0);
            hd.trangthai = 1;
            hd.ngayra = DateTime.Now;
            hd.giamgia = giamgia;
            hd.tongtien = tongtien;
            DB.SubmitChanges();
        }
        public void Xoa(string idhoadon)
        {
            HoaDon hd = DB.HoaDons.FirstOrDefault(h => h.id == idhoadon);
            DB.HoaDons.DeleteOnSubmit(hd);
            DB.SubmitChanges();
        }
        public List<HoaDon> LayHoaDonTheoThoiGian(DateTime tungay, DateTime denngay)
        {
            return DB.HoaDons.Where(hd => hd.ngayra >= tungay && hd.ngayra <= denngay && hd.trangthai == 1).ToList();
        }
    }
}
