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

namespace QLCHFastFood
{
    public partial class frmXuatHoaDon : Form
    {
        MatHangBLL MHBLL = new MatHangBLL();
        HoaDonBLL HDBLL = new HoaDonBLL();
        ChiTietHoaDonBLL CTHDBLL = new ChiTietHoaDonBLL();
        DonViTinhBLL DVTBLL = new DonViTinhBLL();
        public frmXuatHoaDon(int MaHoaDon, int TongTien)
        {
            this.MaHoaDon = MaHoaDon;
            this.TongTien = TongTien;
            InitializeComponent();
        }
        private int MaHoaDon;
        private int TongTien;

        private void frmXuatHoaDon_Load(object sender, EventArgs e)
        {
            var ds = from h in MHBLL.LayTatCa()
                     join d in CTHDBLL.LayTatCa() on h.ID equals d.MaMatHang
                     join k in DVTBLL.LayTatCa() on h.DonViTinh equals k.ID
                     where d.MaHoaDon == MaHoaDon
                     select new
                     {
                         h.TenMatHang,
                         d.SoLuong,
                         k.Ten,
                         d.ThanhTien
                     };
            dgvXuatHoaDon.DataSource = ds.ToList();

            //Định dạng DataGridView
            #region
            dgvXuatHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvXuatHoaDon.Columns["TenMatHang"].HeaderText = "Mặt hàng";
            dgvXuatHoaDon.Columns["SoLuong"].HeaderText = "SL";
            dgvXuatHoaDon.Columns["Ten"].HeaderText = "ĐVT";
            dgvXuatHoaDon.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvXuatHoaDon.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvXuatHoaDon.Columns["SoLuong"].Width = 40;
            dgvXuatHoaDon.Columns["Ten"].Width = 40;
            dgvXuatHoaDon.Columns["TenMatHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            #endregion

            lblTongTien.Text = "Tổng tiền: " + String.Format("{0:0,0 vnđ}", TongTien);
            lblBangChu.Text = CTHDBLL.So_chu(TongTien);
            lblNgayTao.Text = HDBLL.LayNgay(MaHoaDon);
            lblGioTao.Text = HDBLL.LayGio(MaHoaDon);
            lblKhachHang.Text = "KH: " + HDBLL.LayKhachHang(MaHoaDon);
            lblSDT.Text = "SDT: " + HDBLL.LaySDT(MaHoaDon);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã in !");
            this.Dispose();
        }     
    }
}
