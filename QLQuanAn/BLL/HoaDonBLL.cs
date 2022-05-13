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
        public void Them(int IDBanAn)
        {
            HoaDon hd = new HoaDon();
            hd.idbanan = IDBanAn;
            hd.ngayvao = DateTime.Now;

            DB.HoaDons.InsertOnSubmit(hd);
            DB.SubmitChanges();
        }
        public void Sua(int idbanan)
        {
            HoaDon hd = DB.HoaDons.FirstOrDefault(h => h.idbanan == idbanan && h.trangthai == 0);
            hd.trangthai = 1;
            DB.SubmitChanges();
        }
    }
}
