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
            return DB.MonAns.ToList();
        }
        public List<MonAn> LayTheoIDDanhMuc(int iddanhmuc)
        {
            return DB.MonAns.Where(m => m.iddanhmuc == iddanhmuc).ToList();
        }

    }
}
