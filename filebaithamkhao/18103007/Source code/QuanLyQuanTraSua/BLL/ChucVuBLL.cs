using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ChucVuBLL
    {
        QLQuanTraSuaDataContext QLTS = new QLQuanTraSuaDataContext();
        public List<ChucVu> GetListType()
        {
            return QLTS.ChucVus.ToList();
        }
    }
}
