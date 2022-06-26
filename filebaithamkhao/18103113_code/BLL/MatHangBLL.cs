using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    
    public class MatHangBLL
    {
        QLCHFastFoodDataContext DB = new QLCHFastFoodDataContext();

        public List<MatHang> LayTatCa()
        {
            return DB.MatHangs.ToList();
        }

        public MatHang LayTheoMa(string ma)
        {
            return DB.MatHangs.FirstOrDefault(x => x.ID == ma);
        }

        public void Xoa(string ma)
        {
            MatHang mh = LayTheoMa(ma);
            DB.MatHangs.DeleteOnSubmit(mh);
            DB.SubmitChanges();
        }
        public void Them(string ID, string TenMatHang, int DonViTinh, int GiaBan)
        {          
            MatHang mh = new MatHang();
            mh.ID = ID;
            mh.TenMatHang = TenMatHang;
            mh.DonViTinh = DonViTinh;
            mh.GiaBan = GiaBan;
            mh.NgayTao = DateTime.Now;

            DB.MatHangs.InsertOnSubmit(mh);
            DB.SubmitChanges();
        }
        public void Sua(string TenMatHang, int DonViTinh, int GiaBan, string ma)
        {
            MatHang mh = LayTheoMa(ma);
            mh.TenMatHang = TenMatHang;
            mh.DonViTinh = DonViTinh;
            mh.GiaBan = GiaBan;
            DB.SubmitChanges();
        }
        public int DemSoLuong()
        {
             return DB.MatHangs.Count();
        }    
    }

    
}
