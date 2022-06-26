using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Menu
    {
        private string tenMatHang;
        private int soLuong;
        private float gia;
        private float thanhTien;

        public Menu(string tenmathang, int soluong, float gia, float thanhtien = 0)
        {
            this.tenMatHang = tenmathang;
            this.soLuong = soluong;
            this.gia = gia;
            this.thanhTien = thanhtien;
        }
        public Menu(DataRow row)
        {
            this.tenMatHang = row["ten"].ToString();
            this.soLuong = (int)row["SoLuong"];
            this.gia = (float)Convert.ToDouble(row["Gia"].ToString());
            this.thanhTien = (float)Convert.ToDouble(row["ThanhTien"].ToString());
        }
        public string TenMatHang { get => tenMatHang; set => tenMatHang = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float Gia { get => gia; set => gia = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
