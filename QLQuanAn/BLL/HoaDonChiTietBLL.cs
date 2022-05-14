using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class HoaDonChiTietBLL
    {
        QLQuanAnDataContext DB = new QLQuanAnDataContext();
        public List<HoaDonChiTiet> LayHoaDonChiTietTheoIDBanAn(int idbanan)
        {
            HoaDon hd = DB.HoaDons.Where(h => h.idbanan == idbanan && h.trangthai == 0).FirstOrDefault();
            if (hd != null)
            {
                string IDHoaDon = hd.id;
                return DB.HoaDonChiTiets.Where(hds => hds.idhoadon == IDHoaDon).ToList();
            }
            else
            {
                return null;
            }
        }

        public void Them(string idhoadon, int idmonan, int soluong)
        {
            HoaDonChiTiet hdct = new HoaDonChiTiet();
            hdct.idhoadon = idhoadon;
            hdct.idmonan = idmonan;
            hdct.soluong = soluong;

            DB.HoaDonChiTiets.InsertOnSubmit(hdct);
            DB.SubmitChanges();
        }

        public HoaDonChiTiet LayMonAn(int idmonan, string idhoadon)
        {
            return DB.HoaDonChiTiets.Where(hdct => hdct.idmonan == idmonan && hdct.idhoadon == idhoadon).FirstOrDefault();
        }

        public HoaDonChiTiet KiemTraHoaDonTonTaiMonAn(string idhoadon)
        {
            return DB.HoaDonChiTiets.Where(hdct => hdct.idhoadon == idhoadon).FirstOrDefault();
        }

        public void Sua(int idmonan, string idhoadon, int soluong)
        {
            HoaDonChiTiet hdct = DB.HoaDonChiTiets.FirstOrDefault(h => h.idmonan == idmonan && h.idhoadon == idhoadon);
            hdct.soluong = hdct.soluong + soluong;
            DB.SubmitChanges();
        }
        public void XoaTungMon(int idmonan, string idhoadon)
        {
            HoaDonChiTiet hdct = DB.HoaDonChiTiets.FirstOrDefault(h => h.idmonan == idmonan && h.idhoadon == idhoadon);
            DB.HoaDonChiTiets.DeleteOnSubmit(hdct);
            DB.SubmitChanges();
        }
        public void XoaTatCa(string idhoadon)
        {
            List<HoaDonChiTiet> hdct = DB.HoaDonChiTiets.Where(h => h.idhoadon == idhoadon).ToList();
            foreach (HoaDonChiTiet h in hdct)
            {
                DB.HoaDonChiTiets.DeleteOnSubmit(h);
            }
            DB.SubmitChanges();
        }

    }
}
