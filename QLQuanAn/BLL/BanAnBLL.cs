using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BanAnBLL
    {
        QLQuanAnDataContext DB = new QLQuanAnDataContext();

        public List<BanAn> LayTatCa()
        {
            return DB.BanAns.ToList();
        }
        public void Sua(int idbandan, string trangthai)
        {
            BanAn ba = DB.BanAns.FirstOrDefault(b => b.id == idbandan);
            ba.trangthai = trangthai;
            DB.SubmitChanges();
        }
        public string LayTenBanAn(int idbanan)
        {
            return DB.BanAns.Where(b => b.id == idbanan).FirstOrDefault().ten;
        }
    }
}
