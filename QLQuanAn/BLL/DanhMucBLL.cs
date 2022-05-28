using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DanhMucBLL
    {
        QLQuanAnDataContext DB = new QLQuanAnDataContext();
        public List<DanhMuc> LayTatCa()
        {
            return DB.DanhMucs.Where(d => d.trangthai == 1).ToList();
        }
        public void Them(string tendanhmuc)
        {
            DanhMuc dm = new DanhMuc();
            dm.ten = tendanhmuc;
            dm.trangthai = 1;
            DB.DanhMucs.InsertOnSubmit(dm);
            DB.SubmitChanges();
        }
        public DanhMuc LayDanhMucTheoID(int id)
        {
            return DB.DanhMucs.Where(d => d.id == id).FirstOrDefault();
        }
        public void Xoa(int id)
        {
            DanhMuc dm = DB.DanhMucs.Where(d => d.id == id).FirstOrDefault();
            DB.DanhMucs.DeleteOnSubmit(dm);
            DB.SubmitChanges();
        }
        public void Sua(int id, string tendanhmuc, byte trangthai)
        {
            DanhMuc dm = DB.DanhMucs.Where(d => d.id == id).FirstOrDefault();
            if(tendanhmuc != null)
            {
                dm.ten = tendanhmuc;
            }
            if (trangthai != null)
            {
                dm.trangthai = trangthai;
            }

            DB.SubmitChanges();
        }
        public List<DanhMuc> LayDanhMucDaAnDi()
        {
            return DB.DanhMucs.Where(d => d.trangthai == 0).ToList();
        }
    }
}
