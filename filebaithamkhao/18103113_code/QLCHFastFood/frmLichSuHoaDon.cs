using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using System.Globalization;
using System.Threading;

namespace QLCHFastFood
{
    public partial class frmLichSuHoaDon : Form
    {
        MatHangBLL MHBLL = new MatHangBLL();
        HoaDonBLL HDBLL = new HoaDonBLL();
        ChiTietHoaDonBLL CTHDBLL = new ChiTietHoaDonBLL();
        ThongKeBLL TKBLL = new ThongKeBLL();
        DateTime TuNgay, DenNgay, HomNay;
        string tn, dn;
        public frmLichSuHoaDon()
        {
            InitializeComponent();
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e) //Lấy thời gian khi chọn trên DatetimePicker
        {
            tn = dtpTuNgay.Value.Date.ToString("dd/MM/yyyy");
            TuNgay = DateTime.ParseExact(tn, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            dn = dtpDenNgay.Value.Date.ToString("dd/MM/yyyy");
            DenNgay = DateTime.ParseExact(dn, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            int compare = DateTime.Compare(TuNgay, DenNgay);        
            if (compare > 0)                                       //Ràng buộc Từ ngày không được muộn hơn Đến ngày
            {
                MessageBox.Show("Từ ngày muộn hơn Đến ngày là không hợp lệ");
                return;
            }

            dgvLichSuHoaDon.DataSource = TKBLL.LayHoaDonTrongKhoangThoiGian(TuNgay, DenNgay);
            lblTongSoLuong.Text = "Tổng số hóa đơn: " + TKBLL.LayHoaDonTrongKhoangThoiGian(TuNgay, DenNgay).Count().ToString();
            lblTongDoanhThu.Text = "Tổng doanh thu: " + String.Format("{0:0,0 vnđ}", TKBLL.TongDoanhThu());

            if(compare == 0) {
                lblHoaDonHN.Text = "Những hóa đơn ngày hôm nay";
            }
            else lblHoaDonHN.Text = "Những hóa đơn từ " + tn + " - " + dn;


            //Định dạng Datagridview
            #region
            dgvLichSuHoaDon.Columns["ID"].HeaderText = "Mã";
            dgvLichSuHoaDon.Columns["TenNguoiMua"].HeaderText = "Khách hàng";
            dgvLichSuHoaDon.Columns["SoDienThoai"].HeaderText = "SĐT";
            dgvLichSuHoaDon.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgvLichSuHoaDon.Columns["Giotao"].HeaderText = "Giờ tạo";
            dgvLichSuHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";

            dgvLichSuHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvLichSuHoaDon.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLichSuHoaDon.Columns["ID"].Width = 70;
            dgvLichSuHoaDon.Columns["SoDienThoai"].Width = 90;
            dgvLichSuHoaDon.Columns["NgayTao"].Width = 90;
            dgvLichSuHoaDon.Columns["Giotao"].Width = 90;
            #endregion
        }

        private void dgvLichSuHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //Đúp chuột vào DataGridview hàng nào thì xuất lên hóa đơn hàng đó
        {
            int rowi = e.RowIndex;
            if (rowi < 0 || rowi >= dgvLichSuHoaDon.Rows.Count) //Kiểm tra đúp chuột vào tiêu đề DataGridview thì ko được
            {
                return;
            }
            else
            {
                int MaHoaDon = int.Parse(dgvLichSuHoaDon.Rows[e.RowIndex].Cells[0].Value.ToString());
                new frmXuatHoaDon(MaHoaDon, HDBLL.LayTongTien(MaHoaDon)).ShowDialog();
            }     
        }

        private void frmLichSuHoaDon_Load(object sender, EventArgs e)  //Khi form load hiển thị hóa đơn ngày hôm nay
        {
            CultureInfo viVn = new CultureInfo("vi-VN");
            DateTime n = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string ngayhn = n.ToString("d", viVn);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            HomNay = DateTime.ParseExact(ngayhn, "dd/MM/yyyy", CultureInfo.InvariantCulture);  //Lấy ngày hôm nay
          
            dgvLichSuHoaDon.DataSource = TKBLL.LayHoaDonTrongKhoangThoiGian(HomNay, HomNay);  
            lblTongSoLuong.Text = "Tổng số hóa đơn: " + TKBLL.LayHoaDonTrongKhoangThoiGian(HomNay, HomNay).Count().ToString();
            lblTongDoanhThu.Text = "Tổng doanh thu: " + String.Format("{0:0,0 vnđ}", TKBLL.TongDoanhThu());
            lblHoaDonHN.Text = "Những hóa đơn ngày hôm nay";
            
            //Định dạng Datagridview
            #region
            dgvLichSuHoaDon.Columns["ID"].HeaderText = "Mã";
            dgvLichSuHoaDon.Columns["TenNguoiMua"].HeaderText = "Khách hàng";
            dgvLichSuHoaDon.Columns["SoDienThoai"].HeaderText = "SĐT";
            dgvLichSuHoaDon.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgvLichSuHoaDon.Columns["Giotao"].HeaderText = "Giờ tạo";
            dgvLichSuHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";

            dgvLichSuHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvLichSuHoaDon.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLichSuHoaDon.Columns["ID"].Width = 70;
            dgvLichSuHoaDon.Columns["SoDienThoai"].Width = 90;
            dgvLichSuHoaDon.Columns["NgayTao"].Width = 90;
            dgvLichSuHoaDon.Columns["Giotao"].Width = 90;
            dgvLichSuHoaDon.Columns["TenNguoiMua"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            #endregion

            tn = dtpTuNgay.Value.Date.ToString("dd/MM/yyyy");  //Form load lấy giá trị DataeTime mặc định
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            TuNgay = DateTime.ParseExact(tn, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            dn = dtpDenNgay.Value.Date.ToString("dd/MM/yyyy");
            DenNgay = DateTime.ParseExact(dn, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }      
    }
}
