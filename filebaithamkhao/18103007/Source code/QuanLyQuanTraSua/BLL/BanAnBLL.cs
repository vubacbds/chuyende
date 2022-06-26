using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BanAnBLL
    {
        QLQuanTraSuaDataContext QLTS = new QLQuanTraSuaDataContext();
        private static BanAnBLL instance;

        public static BanAnBLL Instance {
            get { if (instance == null) instance = new BanAnBLL(); return instance; }
            private set { instance = value; }
        }
        public BanAnBLL() { }
        public List<BanAn> LoadTableList()
        {
            return QLTS.BanAns.ToList();
        }
        public void InsertTableFood(string ten)
        {
            BanAn table = new BanAn();
            table.Ten = ten;
            table.TrangThai = "Trống";

            QLTS.BanAns.InsertOnSubmit(table);
            QLTS.SubmitChanges();
        }
        public void UpdateTableFood(int id, string ten)
        {
            BanAn table = QLTS.BanAns.Where(ban => ban.id == id).FirstOrDefault();
            table.Ten = ten;

            QLTS.SubmitChanges();
        }
        public void DeleteTableFood(int id)
        {
            BanAn table = QLTS.BanAns.Where(ban => ban.id == id).FirstOrDefault();

            QLTS.BanAns.DeleteOnSubmit(table);
            QLTS.SubmitChanges();
        }
    }
}
