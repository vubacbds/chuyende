using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ChiTietHoaDonBLL
    {
        QLQuanTraSuaDataContext QLTS = new QLQuanTraSuaDataContext();
        private static ChiTietHoaDonBLL instance;

        public static ChiTietHoaDonBLL Instance {
            get { if (instance == null) instance = new ChiTietHoaDonBLL(); return instance; }
            private set => instance = value; }
        public ChiTietHoaDonBLL() { }
        public List<ChiTietHoaDon> GetListInfo(int id_HD)
        {
            return QLTS.ChiTietHoaDons.Where(ct => ct.id_HD==id_HD).ToList();
        }
        public void InsertBillInfo(int idHD,int idMH,int soluong)
        {
            QLTS.USP_InsertBillInfo(idHD, idMH, soluong);
            QLTS.SubmitChanges();
        }
    }
}
