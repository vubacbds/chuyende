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

namespace QLQuanAnForm
{
    public partial class ftrangchu : Form
    {
        BanAnBLL BABLL = new BanAnBLL();
        HoaDonBLL HDBLL = new HoaDonBLL();
        HoaDonChiTietBLL HDCTBLL = new HoaDonChiTietBLL();
        MonAnBLL MABLL = new MonAnBLL();
        DanhMucBLL DMBLL = new DanhMucBLL();
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        int IDBanAn = 0;
        int giamgia = 0;
        public ftrangchu(string tendangnhap)
        {
            this.tendangnhap = tendangnhap;
            InitializeComponent();
            LoadBanAn();
            LoadDanhMuc();
            LoadTenHienThi();
        }
        private string tendangnhap;

        #region Methods
        void LoadBanAn()
        {
            flpBanAn.Controls.Clear();
            List<BanAn> DSBanAn = BABLL.LayTatCa();
            foreach (BanAn item in DSBanAn)
            {
                Button btn = new Button();
                btn.Width = 100;
                btn.Height = 100;
                btn.Text = item.ten + Environment.NewLine + item.trangthai;
                switch (item.trangthai)
                {
                    case "Trống":
                        btn.BackColor = Color.Coral;
                        break;
                    default:
                        btn.BackColor = Color.Ivory;
                        break;
                }
                btn.Click += Btn_Click;
                btn.Tag = item;
                flpBanAn.Controls.Add(btn); 
            }
        }
        void LoadDanhMuc()
        {
            cbbDanhMuc.DataSource = DMBLL.LayTatCa().ToList();
            cbbDanhMuc.DisplayMember = "ten";    //Hiện tên
            cbbDanhMuc.ValueMember = "id";
        }
        void LoadMonAnTheoDanhMuc(int id)
        {
            if (MABLL.KiemTraDanhMucCoMonChua(id)!=null)
            {
                cbbMonAn.DataSource = MABLL.LayTheoIDDanhMuc(id).ToList();
                cbbMonAn.DisplayMember = "ten";    //Hiện tên
                cbbMonAn.ValueMember = "id";
            }
            else
            {
                cbbMonAn.DataSource = null;
            }
        }
        void HienThiHoaDon(int IDBanAn)
        {
            List<HoaDonChiTiet> ds = HDCTBLL.LayHoaDonChiTietTheoIDBanAn(IDBanAn);
            if(ds != null)
            {
                var kq = from m in MABLL.LayTatCa()
                         join h in ds on m.id equals h.idmonan
                         orderby m.ten ascending
                         let thanhtien = m.gia * h.soluong
                         select new
                         {
                             m.id,
                             m.ten,
                             h.soluong,
                             m.gia,
                             thanhtien
                         };
                var tongtien = kq.Select(p => p.thanhtien).Sum();
                giamgia = (int)tongtien;
                string tt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", tongtien);

                dgvHoaDonChiTiet.DataSource = kq.ToList();
                lblTongTien.Text = tt + " vnđ";

                #region Định dạng Datagridview
                dgvHoaDonChiTiet.Columns["ten"].HeaderText = "Tên món";
                dgvHoaDonChiTiet.Columns["soluong"].HeaderText = "SL";
                dgvHoaDonChiTiet.Columns["gia"].HeaderText = "Đơn giá";
                dgvHoaDonChiTiet.Columns["thanhtien"].HeaderText = "Thành tiền";
                dgvHoaDonChiTiet.Columns["thanhtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHoaDonChiTiet.Columns["gia"].DefaultCellStyle.Format = "N0";
                dgvHoaDonChiTiet.Columns["thanhtien"].DefaultCellStyle.Format = "N0";
                dgvHoaDonChiTiet.Columns["ten"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvHoaDonChiTiet.Columns["soluong"].Width = 40;
                dgvHoaDonChiTiet.Columns[0].Visible = false; // ẩn đi trường ID
                #endregion
            }
            else
            {
                dgvHoaDonChiTiet.DataSource = null;
                lblTongTien.Text = "Tổng tiền: 0 vnđ";
            }
        }
        void LoadTenHienThi()
        {
            thôngTinCáNhânToolStripMenuItem.Text = TKBLL.LayTaiKhoanTheoTenDangNhap(tendangnhap).tenhienthi;

            if (TKBLL.LayTaiKhoanTheoTenDangNhap(tendangnhap).loai == 0)
            {
                adminToolStripMenuItem.Visible = false;
            }
        }
        #endregion

        #region Events
        private void Btn_Click(object sender, EventArgs e)
        {
            IDBanAn = ((sender as Button).Tag as BanAn).id;
            btnTenBan.Text = ((sender as Button).Tag as BanAn).ten;
            HienThiHoaDon(IDBanAn);

            lblThongBao.Text = "";
            numGiamGia.Value = 0;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fthongtincanhan f = new fthongtincanhan(tendangnhap);
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fadmin f = new fadmin();
            f.FormClosed += F_FormClosed2;
            f.ShowDialog();
        }

        private void F_FormClosed2(object sender, FormClosedEventArgs e)
        {
            LoadBanAn();
            LoadDanhMuc();
        }

        private void cbbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;
            DanhMuc selected = cb.SelectedItem as DanhMuc;
            int id = selected.id;
            LoadMonAnTheoDanhMuc(id);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbMonAn.SelectedValue == null)
            {
                MessageBox.Show("Bạn thiếu món ăn");
                return;
            }
            if (IDBanAn != 0)
            {
                int idmonan = int.Parse(cbbMonAn.SelectedValue.ToString());
                int soluong = int.Parse(numSoLuong.Value.ToString());
                string idhoadon = "HD" + (new Random().Next(10000000, 99999999)).ToString();

                if (HDBLL.LayHoaDonTheoIDBanAn(IDBanAn) == null)            //Khi bàn ăn không có hóa đơn nào
                {
                    HDBLL.Them(IDBanAn, idhoadon);
                    HDCTBLL.Them(idhoadon, idmonan, soluong);
                    BABLL.Sua(IDBanAn, "Đã đặt", null);
                    LoadBanAn();
                    HienThiHoaDon(IDBanAn);
                }
                else
                {
                    string idhoadonhientai = HDBLL.LayHoaDonTheoIDBanAn(IDBanAn).id;
                    if (HDCTBLL.LayMonAn(idmonan, idhoadonhientai) == null)    //Khi món ăn chưa tồn tại
                    {
                        HDCTBLL.Them(idhoadonhientai, idmonan, soluong);
                        HienThiHoaDon(IDBanAn);
                    }
                    else
                    {
                        HDCTBLL.Sua(idmonan, idhoadonhientai, soluong);
                        HienThiHoaDon(IDBanAn);
                    }
                }
            }
            else
            {
                lblThongBao.Text = "Chưa chọn bàn!";
            }
        }
        private void dgvHoaDonChiTiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowi = e.RowIndex;
            if (rowi < 0 || rowi >= dgvHoaDonChiTiet.Rows.Count)  //Để tránh lỗi khi nháy đúp vào tiêu đề
            {
                return;
            }
            else
            {
                int idmonan = int.Parse(dgvHoaDonChiTiet.Rows[e.RowIndex].Cells[0].Value.ToString());
                string idhoadon = HDBLL.LayHoaDonTheoIDBanAn(IDBanAn).id;
                HDCTBLL.XoaTungMon(idmonan, idhoadon);
                
                if(HDCTBLL.KiemTraHoaDonTonTaiMonAn(idhoadon) == null)  //Khi xóa 1 hàng mà hết món thì xóa luôn hóa đơn
                {
                    HDBLL.Xoa(idhoadon);
                    BABLL.Sua(IDBanAn, "Trống", null);
                    LoadBanAn();
                }
                HienThiHoaDon(IDBanAn);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (HDBLL.LayHoaDonTheoIDBanAn(IDBanAn) != null)
            {
                string tenbanan = BABLL.LayBanAnTheoID(IDBanAn).ten;
                if (MessageBox.Show("Bạn có chắc thanh toán tiền cho '" + tenbanan + "' không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    HDBLL.Sua(IDBanAn);
                    BABLL.Sua(IDBanAn, "Trống", null);
                    LoadBanAn();
                    HienThiHoaDon(IDBanAn);
                }
            }
        }

        private void btnTenBan_Click(object sender, EventArgs e)
        {
            if (HDBLL.LayHoaDonTheoIDBanAn(IDBanAn) != null)
            {
                string idhoadonhientai = HDBLL.LayHoaDonTheoIDBanAn(IDBanAn).id;
                string tenbanan = BABLL.LayBanAnTheoID(IDBanAn).ten;
                if (MessageBox.Show("Bạn có chắc xóa hết món '" + tenbanan + "' không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    HDCTBLL.XoaTatCa(idhoadonhientai);
                    HDBLL.Xoa(idhoadonhientai);
                    BABLL.Sua(IDBanAn, "Trống", null);
                    LoadBanAn();
                    HienThiHoaDon(IDBanAn);
                }
            }   
        }

        private void btnGiamGia_Click(object sender, EventArgs e)
        {
            int gg = giamgia - giamgia * int.Parse(numGiamGia.Text) / 100;
            lblTongTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}" + " vnđ", gg);
        }
        #endregion
    }
}
