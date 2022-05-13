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
            return DB.DanhMucs.ToList();
        }
    }
}
