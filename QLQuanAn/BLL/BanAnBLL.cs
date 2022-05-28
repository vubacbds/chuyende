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
            return DB.BanAns.Where(b => b.trangthai == "Trống" || b.trangthai == "Đã đặt").ToList();
        }
        public void Sua(int idbandan, string trangthai, string tenbanan)
        {
            BanAn ba = DB.BanAns.FirstOrDefault(b => b.id == idbandan);
            if (trangthai != null)
            {
                ba.trangthai = trangthai;
            }
            if (tenbanan != null)
            {
                ba.ten = tenbanan;
            }
            DB.SubmitChanges();
        }
        public BanAn LayBanAnTheoID(int idbanan)
        {
            return DB.BanAns.Where(b => b.id == idbanan).FirstOrDefault();
        }
        public void Them(string tenban)
        {
            BanAn ba = new BanAn();
            ba.ten = tenban;
            ba.trangthai = "Trống";
            DB.BanAns.InsertOnSubmit(ba);
            DB.SubmitChanges();
        }
        public void Xoa(int id)
        {
            BanAn ba = DB.BanAns.Where(b => b.id == id).FirstOrDefault();
            DB.BanAns.DeleteOnSubmit(ba);
            DB.SubmitChanges();
        }
        public List<BanAn> LayBanAnDaAnDi()
        {
            return DB.BanAns.Where(b => b.trangthai == "Ẩn").ToList();
        }
        public List<BanAn> LayTatCaHD() //Lấy tất cả cho hóa đơn thống kê nên lấy cả cái ẩn luôn
        {
            return DB.BanAns.ToList();
        }
    }
}
