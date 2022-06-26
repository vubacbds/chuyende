using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MenuBLL
    {
        QLQuanTraSuaDataContext QLTS = new QLQuanTraSuaDataContext();
        private static MenuBLL instance;

        public static MenuBLL Instance {
            get { if (instance == null) instance = new MenuBLL(); return instance; }
            private set => instance = value; }
        private MenuBLL() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            /*List<Menu> listMenu = new List<Menu>();
            string query = "select C.Ten, B.SoLuong, C.Gia, B.SoLuong*C.Gia as ThanhTien from HoaDon A inner join ChiTietHoaDon B on A.id = B.id_HD inner join MatHang C on B.id_MH = C.id where A.id_Ban = " + id + " and A.TrangThai=0";

            DataTable data = DataService.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }*/
            List<Menu> listMenu = new List<Menu>();
            var result = (from a in QLTS.HoaDons
                          join b in QLTS.ChiTietHoaDons on a.id equals b.id_HD
                          join c in QLTS.MatHangs on b.id_MH equals c.id
                          select new { Ten = c.Ten, SoLuong = b.SoLuong, Gia = c.Gia, ThanhTien = b.SoLuong * c.Gia, id_ban = a.id_Ban, trangthai = a.TrangThai }
                         ).Where(p => p.id_ban == id && p.trangthai == 0);
            foreach (var item in result)
            {
                float gia = (float)Convert.ToDouble(item.Gia.ToString());
                float thanhtien = (float)Convert.ToDouble(item.ThanhTien.ToString());
                Menu menu = new Menu(item.Ten,item.SoLuong,gia,thanhtien);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
