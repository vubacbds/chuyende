using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBLL
    {
        QLQuanTraSuaDataContext QLTS = new QLQuanTraSuaDataContext();
        private static HoaDonBLL instance;
        public static HoaDonBLL Instance {
            get { if (instance == null) instance = new HoaDonBLL(); return instance; }
            private set => instance = value; }
        public HoaDonBLL() { }

        // bill chưa thanh toán: Bill_ID
        // bill đã thanh toán hoặc bàn chưa có bill: -1
        public int getUncheckBillIDByTableID(int id)
        {
            HoaDon isbill = QLTS.HoaDons.Where(hd => hd.id_Ban == id && hd.TrangThai == 0).FirstOrDefault();
            if (isbill!=null)
            {
                return isbill.id;
            }
            return -1;
        }
        public void InsertBill(int idBan)
        {
            //DataService.Instance.ExcutenonQuery("exec USP_InsertBill @idBan", new object[] { idBan });
            QLTS.USP_InsertBill(idBan);
            QLTS.SubmitChanges();
        }
        public int GetMaxIdBill()
        {
            try
            {
                //return (int)DataService.Instance.ExcuteScalar("Select Max(id) from HoaDon");
                //return int.Parse(QLTS.USP_GetMaxIdBill().FirstOrDefault().ToString());
                return QLTS.HoaDons.OrderByDescending(b => b.id).FirstOrDefault().id;
            }
            catch
            {
                return 1;
            }
        }
        public void CheckOut(int id, float tongtien)
        {
            HoaDon Bill = QLTS.HoaDons.Where(hd => hd.id == id).FirstOrDefault();
            Bill.TrangThai = 1;
            Bill.NgayRa = DateTime.Now.Date;
            Bill.TongThanhTien = tongtien;
            
            QLTS.SubmitChanges();
        }
        public DataTable GetBillListByDate(DateTime tungay, DateTime denngay)
        {
            ISingleResult<USP_GetListBillByDateResult> result = QLTS.USP_GetListBillByDate(tungay,denngay);
            DataTable data = new DataTable();
            data.Columns.Add("TenBan",typeof(string));
            data.Columns.Add("NgayVao",typeof(DateTime));
            data.Columns.Add("NgayRa",typeof(DateTime));
            data.Columns.Add("TongTien",typeof(float));

            foreach(USP_GetListBillByDateResult item in result)
            {
                data.Rows.Add(item.Ten, item.NgayVao, item.NgayRa, item.TongThanhTien);
            }
            return data;
        }
        public DataTable GetBillListByDateAndPage(DateTime tungay, DateTime denngay, int trang)
        {
            ISingleResult<USP_GetListBillByDateAndPageResult> result = QLTS.USP_GetListBillByDateAndPage(tungay, denngay, trang);
            DataTable data = new DataTable();
            data.Columns.Add("TenBan", typeof(string));
            data.Columns.Add("NgayVao", typeof(DateTime));
            data.Columns.Add("NgayRa", typeof(DateTime));
            data.Columns.Add("TongTien", typeof(float));

            foreach (USP_GetListBillByDateAndPageResult item in result)
            {
                data.Rows.Add(item.Ten, item.NgayVao, item.NgayRa, item.TongThanhTien);
            }
            return data;
        }
        public int GetNumBillListByDate(DateTime tungay, DateTime denngay)
        {
            ISingleResult<USP_GetListBillByDateResult> result = QLTS.USP_GetListBillByDate(tungay, denngay);
            return result.Count();
        }
    }
}
