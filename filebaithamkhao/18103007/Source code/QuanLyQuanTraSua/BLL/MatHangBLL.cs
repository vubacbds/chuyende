using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class MatHangBLL
    {
        QLQuanTraSuaDataContext QLTS = new QLQuanTraSuaDataContext();
        private static MatHangBLL instance;

        public static MatHangBLL Instance {
            get { if (instance == null) instance = new MatHangBLL(); return instance; }
            private set => instance = value; }
        public MatHangBLL() { }
        public List<MatHang> getListFoodByCatID(int cat_id)
        {
            return QLTS.MatHangs.Where(mh => mh.id_DM == cat_id).ToList();
        }
        public List<MatHang> GetListFood()
        {
            return QLTS.MatHangs.ToList();
        }
        public void InsertFood( string ten, int id_cat, float gia)
        {
            MatHang food = new MatHang();
            food.Ten = ten;
            food.id_DM = id_cat;
            food.Gia = gia;

            QLTS.MatHangs.InsertOnSubmit(food);
            QLTS.SubmitChanges();
        }
        public void UpdateFood(int id, string ten, int id_cat, float gia)
        {
            MatHang food = QLTS.MatHangs.Where(mh => mh.id == id).FirstOrDefault();
            food.Ten = ten;
            food.id_DM = id_cat;
            food.Gia = gia;
            
            QLTS.SubmitChanges();
        }
        public void DeleteFood(int id)
        {
            MatHang food = QLTS.MatHangs.Where(mh => mh.id == id).FirstOrDefault();

            QLTS.MatHangs.DeleteOnSubmit(food);
            QLTS.SubmitChanges(); 
        }
        public List<MatHang> SearchFoodByName(string ten)
        {
            var result = from f in QLTS.MatHangs
                         where f.Ten.Contains(ten)
                         select f;
            List<MatHang> data = new List<MatHang>();
            foreach(var item in result)
            {
                data.Add(item);
            }
            return data;
        }
    }
}
