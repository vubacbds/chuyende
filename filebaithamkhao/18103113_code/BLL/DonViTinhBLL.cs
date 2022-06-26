using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DonViTinhBLL
    {
        QLCHFastFoodDataContext DB = new QLCHFastFoodDataContext();
        public List<DonViTinh> LayTatCa()
        {
            return DB.DonViTinhs.ToList();
        }
    }
}
