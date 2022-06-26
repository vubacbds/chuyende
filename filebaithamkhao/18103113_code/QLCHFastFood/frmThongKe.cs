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
    public partial class frmThongKe : Form
    {
        MatHangBLL MHBLL = new MatHangBLL();
        HoaDonBLL HDBLL = new HoaDonBLL();
        ChiTietHoaDonBLL CTHDBLL = new ChiTietHoaDonBLL();
        ThongKeBLL TKBLL = new ThongKeBLL();
        DonViTinhBLL DVTBLL = new DonViTinhBLL();
        DateTime TuNgay, DenNgay;
        string tn, dn;
        public frmThongKe()
        {
            InitializeComponent();
        }

        public void LoadTK()
        {
            this.cbbTenMatHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbbTenMatHang.DataSource = MHBLL.LayTatCa(); //Lấy thông tin đưa vào Combobox
            cbbTenMatHang.DisplayMember = "TenMatHang";    //Hiện tên
            cbbTenMatHang.ValueMember = "ID";       //Lấy giá trị là ID
            cbbTenMatHang.SelectedIndex = -1;     //Không chọn giá trị mặc định của CBB
            dgvThongKe.Refresh();
        }

        private void frmThongKe_Load(object sender, EventArgs e) //Khi form load lấy giá trị thời gian mặc định của DatimePicker
        {
            LoadTK();
            tn = dtpTuNgay.Value.Date.ToString("dd/MM/yyyy");  
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            TuNgay = DateTime.ParseExact(tn, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            dn = dtpDenNgay.Value.Date.ToString("dd/MM/yyyy");
            DenNgay = DateTime.ParseExact(dn, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
      
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            tn = dtpTuNgay.Value.Date.ToString("dd/MM/yyyy");                
            TuNgay = DateTime.ParseExact(tn, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            dn = dtpDenNgay.Value.Date.ToString("dd/MM/yyyy");
            DenNgay = DateTime.ParseExact(dn, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private void btnXuatThongKe_Click(object sender, EventArgs e)
        {
            //Ràng buộc
            #region
            if (string.IsNullOrEmpty(cbbTenMatHang.Text))
            {
                MessageBox.Show("Vui lòng chọn tên mặt hàng");
                return;
            }
            string MaMatHang = cbbTenMatHang.SelectedValue.ToString();

            int compare = DateTime.Compare(TuNgay, DenNgay);
            if (compare > 0)
            {
                MessageBox.Show("Từ ngày muộn hơn Đến ngày là không hợp lệ");
                return;
            }
            if (compare == 0)
            {
                lblTieuDeTK.Text = "Thống kê: " + TKBLL.LayTenMatHang(MaMatHang) + " trong hôm nay";
            }
            else lblTieuDeTK.Text = "Thống kê: " + TKBLL.LayTenMatHang(MaMatHang) + " từ " + tn + " - " + dn;
            #endregion

            var ds = from h in TKBLL.LayChiTietHoaDonTrongKhoangThoiGian(TuNgay, DenNgay, MaMatHang)
            join d in HDBLL.LayTatCa() on h.MaHoaDon equals d.ID
            join k in MHBLL.LayTatCa() on h.MaMatHang equals k.ID
            join j in DVTBLL.LayTatCa() on k.DonViTinh equals j.ID
                     select new
                     {                      
                         k.TenMatHang,
                         h.SoLuong,
                         j.Ten,
                         h.ThanhTien,
                         d.NgayTao,
                         d.Giotao
                     };
            if (ds.ToList().Count()>0)
            {
                dgvThongKe.DataSource = ds.ToList();
                lblTongSoLuong.Text = "Tổng số lượng: " + TKBLL.TongSoLuong().ToString();
                lblTongTien.Text = "Tổng tiền: " + String.Format("{0:0,0 vnđ}", TKBLL.TongTien());

                //Định dạng Datagridview
                #region
                dgvThongKe.Columns["TenMatHang"].HeaderText = "Mặt hàng";
                dgvThongKe.Columns["SoLuong"].HeaderText = "SL";
                dgvThongKe.Columns["Ten"].HeaderText = "DVT";
                dgvThongKe.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvThongKe.Columns["NgayTao"].HeaderText = "Ngày bán";
                dgvThongKe.Columns["Giotao"].HeaderText = "Giờ bán";

                dgvThongKe.Columns["TenMatHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvThongKe.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvThongKe.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

                dgvThongKe.Columns["SoLuong"].Width = 40;
                dgvThongKe.Columns["Ten"].Width = 40;
                dgvThongKe.Columns["TenMatHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvThongKe.Columns["ThanhTien"].Width = 95;
                dgvThongKe.Columns["NgayTao"].Width = 90;
                dgvThongKe.Columns["Giotao"].Width = 80;
                #endregion
            }
            else
            {
                MessageBox.Show("Mặt hàng không có thông tin trong thời gian này");
                dgvThongKe.DataSource = "";
            }
            LoadTK();
        }     
    }
}
