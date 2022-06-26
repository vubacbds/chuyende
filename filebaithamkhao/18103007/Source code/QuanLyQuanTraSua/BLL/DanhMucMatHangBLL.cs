using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DanhMucMatHangBLL
    {
        QLQuanTraSuaDataContext QLTS = new QLQuanTraSuaDataContext();
        private static DanhMucMatHangBLL instance;

        public static DanhMucMatHangBLL Instance {
            get { if (instance == null) instance = new DanhMucMatHangBLL(); return instance; }
            private set => instance = value; }
        public DanhMucMatHangBLL() { }
        public List<DanhMucMatHang> GetListCategory()
        {
            return QLTS.DanhMucMatHangs.ToList();
        }
        public DanhMucMatHang GetCatByID(int id)
        {
            DanhMucMatHang cat = QLTS.DanhMucMatHangs.Where(dm => dm.id == id).FirstOrDefault();

            return cat;
        }
        public void InsertCategory(string ten)
        {
            DanhMucMatHang cat = new DanhMucMatHang();
            cat.Ten = ten;

            QLTS.DanhMucMatHangs.InsertOnSubmit(cat);
            QLTS.SubmitChanges();
        }
        public void UpdateCategory(int id, string ten)
        {
            DanhMucMatHang cat = QLTS.DanhMucMatHangs.Where(dm => dm.id == id).FirstOrDefault();
            cat.Ten = ten;

            QLTS.SubmitChanges();
        }
        public void DeleteCategory(int id)
        {
            DanhMucMatHang cat = QLTS.DanhMucMatHangs.Where(dm => dm.id == id).FirstOrDefault();

            QLTS.DanhMucMatHangs.DeleteOnSubmit(cat);
            QLTS.SubmitChanges();
        }
    }
}
