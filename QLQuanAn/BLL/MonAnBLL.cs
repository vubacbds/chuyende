using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class MonAnBLL
    {
        QLQuanAnDataContext DB = new QLQuanAnDataContext();
        public List<MonAn> LayTatCa()
        {
            return DB.MonAns.Where(m => m.trangthai == 1).ToList();
        }
        public List<MonAn> LayTheoIDDanhMuc(int iddanhmuc)
        {
            return DB.MonAns.Where(m => m.iddanhmuc == iddanhmuc).ToList();
        }
        public MonAn LayMonAnTheoID(int id)
        {
            return DB.MonAns.Where(m => m.id == id).FirstOrDefault();
        }
        public MonAn KiemTraDanhMucCoMonChua(int iddanhmuc)
        {
            return DB.MonAns.Where(m => m.iddanhmuc == iddanhmuc).FirstOrDefault();
        }
        public void Them(string tenmon, int iddanhmuc, int gia)
        {
            MonAn ma = new MonAn();
            ma.ten = tenmon;
            ma.iddanhmuc = iddanhmuc;
            ma.gia = gia;
            ma.trangthai = 1;
            DB.MonAns.InsertOnSubmit(ma);
            DB.SubmitChanges();
        }
        public void Xoa(int id)
        {
            MonAn ma = DB.MonAns.Where(m => m.id == id).FirstOrDefault();
            DB.MonAns.DeleteOnSubmit(ma);
            DB.SubmitChanges();
        }
        public void Sua(int id, string tenmonan, int iddanhmuc, int gia)
        {
            MonAn ma = DB.MonAns.Where(m => m.id == id).FirstOrDefault();
            ma.ten = tenmonan;
            ma.iddanhmuc = iddanhmuc;
            ma.gia = gia;
            DB.SubmitChanges();
        }
        public void ThayDoiTrangThai(int id, byte trangthai)
        {
            MonAn ma = DB.MonAns.Where(m => m.id == id).FirstOrDefault();
            ma.trangthai = trangthai;
            DB.SubmitChanges();
        }
        public List<MonAn> LayMonDaAnDi()
        {
            return DB.MonAns.Where(m => m.trangthai == 0).ToList();
        }
        public List<MonAn> LayTatCaHD() //Lấy tất cả cho hóa đơn thống kê nên lấy cả cái ẩn luôn, ko cần điều kiện
        {
            return DB.MonAns.ToList();
        }
    }
}
