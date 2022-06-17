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
using QLQuanAnForm.Properties;

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
        public ftrangchu(string tendangnhap)
        {
            InitializeComponent();
            this.tendangnhap = tendangnhap;
            this.IDBanAn = 0;
            this.tongtien = 0;
            LoadBanAn();
            LoadDanhMuc();
            LoadTenHienThi();
        }
        private string tendangnhap;
        private int IDBanAn;
        private int tongtien;

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
                var sumtien = kq.Select(p => p.thanhtien).Sum();
                tongtien = (int)sumtien;
                string tt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", sumtien);

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
        private void Btn_Click(object sender, EventArgs e)   //Chọn vào bàn ăn
        {
            IDBanAn = ((sender as Button).Tag as BanAn).id;
            btnTenBan.Text = ((sender as Button).Tag as BanAn).ten;
            HienThiHoaDon(IDBanAn);

            numGiamGia.Value = 0;
            panel4.Enabled = true;

            if (HDBLL.LayHoaDonTheoIDBanAn(IDBanAn) != null)
            {
                panel3.Enabled = true;
            }
            else
            {
                panel3.Enabled = false;
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)  //Đăng xuất
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem1_Click(object sender, EventArgs e)  //Vào trang cá nhân
        {
            fthongtincanhan f = new fthongtincanhan(tendangnhap);
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)  //Vào trang admin
        {
            fadmin f = new fadmin();
            f.FormClosed += F_FormClosed2;
            f.ShowDialog();
        }

        private void F_FormClosed2(object sender, FormClosedEventArgs e)  //Khi đóng trang admin thì load lại trang chủ
        {
            LoadBanAn();
            LoadDanhMuc();
        }

        private void cbbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)  //Chọn danh mục (load lại món ăn)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;
            DanhMuc selected = cb.SelectedItem as DanhMuc;
            int id = selected.id;
            LoadMonAnTheoDanhMuc(id);
        }
        private void btnThem_Click(object sender, EventArgs e)  //Chọn vào Thêm món vào hóa đơn
        {
            if (cbbMonAn.SelectedValue == null)
            {
                MessageBox.Show("Bạn thiếu món ăn");
                return;
            }
                int idmonan = int.Parse(cbbMonAn.SelectedValue.ToString());
                int soluong = int.Parse(numSoLuong.Value.ToString());
                string idhoadon = "HD" + (new Random().Next(10000000, 99999999)).ToString();

                if (HDBLL.LayHoaDonTheoIDBanAn(IDBanAn) == null)            //Khi bàn ăn không có hóa đơn nào
                {
                    HDBLL.Them(IDBanAn, idhoadon, tendangnhap);
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
        private void dgvHoaDonChiTiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  //Nháy đúp xóa từng món ăn
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

        private void btnTenBan_Click(object sender, EventArgs e) //Nhấn vào tên bàn để xóa hết tất cả món
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

        private void btnGiamGia_Click(object sender, EventArgs e)  //Chọn giảm giá
        {
            int gg = tongtien - tongtien * int.Parse(numGiamGia.Text) / 100;
            lblTongTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}" + " vnđ", gg);
        }

        #region Xử lý khi in
        private void btnPrint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                contextMenuStrip1.Show(btnPrint, e.X, e.Y);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) //Đưa dữ liệu vào Phiếu tính tiền để in
        {
            Image image = Resources.logoqa;
            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            e.Graphics.DrawString("Quán ăn B-A-C", new Font("Algerian", 30, FontStyle.Bold), Brushes.Black, new Point(350, 50));
            e.Graphics.DrawString("888 Lê Duẩn - BMT - 0868609878", new Font("Arial", 16), Brushes.Black, new Point(380, 90));
            e.Graphics.DrawString("PHIẾU TÍNH TIỀN", new Font("Arial", 25, FontStyle.Bold), Brushes.Black, new Point(300, 250));
            e.Graphics.DrawString("Mã PTT: " + HDBLL.LayHoaDonTheoIDBanAn(IDBanAn).id, new Font("Arial", 14), Brushes.Black, new Point(60, 288));
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm"), new Font("Arial", 14), Brushes.Black, new Point(550, 288));
            e.Graphics.DrawString("----------------------------------------------------", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(60, 300));
            e.Graphics.DrawString("Tên món", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(60, 330));
            e.Graphics.DrawString("SL", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(360, 330));
            e.Graphics.DrawString("Đơn giá", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(460, 330));
            e.Graphics.DrawString("Thành tiền", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(660, 330));
            e.Graphics.DrawString("----------------------------------------------------", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(60, 336));

            List<HoaDonChiTiet> ds = HDCTBLL.LayHoaDonChiTietTheoIDBanAn(IDBanAn);
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
            var sumtien = kq.Select(p => p.thanhtien).Sum();
            var sumsl = kq.Select(p => p.soluong).Sum();
            tongtien = (int)sumtien;
            int giamgia = tongtien * int.Parse(numGiamGia.Text) / 100;
            string tt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", sumtien);

            int ypos = 380;
            foreach (var i in kq.ToList())
            {
                e.Graphics.DrawString(i.ten, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, ypos));
                e.Graphics.DrawString(i.soluong.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(360, ypos));
                e.Graphics.DrawString("x", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(410, ypos));
                e.Graphics.DrawString(string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", i.gia), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(460, ypos));
                e.Graphics.DrawString("=", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(560, ypos));
                e.Graphics.DrawString(string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", i.thanhtien), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(660, ypos));
                ypos += 30;
            }
            e.Graphics.DrawString("----------------------------------------------------", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(60, ypos));
            e.Graphics.DrawString("Tổng SL & tiền: ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(60, ypos+40));
            e.Graphics.DrawString(sumsl.ToString(), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(360, ypos + 40));
            e.Graphics.DrawString(string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", sumtien), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(660, ypos + 40));
            e.Graphics.DrawString("Tiền giảm giá: ", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(500, ypos + 80));
            e.Graphics.DrawString(string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", giamgia), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(660, ypos + 80));
            e.Graphics.DrawString("Tiền khách trả: ", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(500, ypos + 120));
            e.Graphics.DrawString(string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", sumtien-giamgia), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(660, ypos + 120));

            e.Graphics.DrawString("Cảm ơn quý khách, hẹn gặp lại!", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(60, ypos + 160));
            e.Graphics.DrawString("(Nhân viên: " + TKBLL.LayTaiKhoanTheoTenDangNhap(tendangnhap).tenhienthi + ")", new Font("Arial", 12, FontStyle.Italic), Brushes.Black, new Point(60, ypos + 180));
        }
        private void inPhiếuTínhTiềnToolStripMenuItem_Click(object sender, EventArgs e)  //Nhấn vào in Phiếu tính tiền
        {
            string tenbanan = BABLL.LayBanAnTheoID(IDBanAn).ten;
            if (MessageBox.Show("Bạn có chắc thanh toán tiền cho '" + tenbanan + "' không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                PrintDialog pDlg = new PrintDialog();
                printDocument1.DocumentName = "In phiếu tính tiền";
                pDlg.Document = printDocument1;
                pDlg.AllowSelection = true;
                pDlg.AllowSomePages = true;
                //DialogResult userResp = pDlg.ShowDialog();
                //SaveFileDialog saveFileDialog = new SaveFileDialog();
                //userResp = saveFileDialog.ShowDialog();
                //Nullable<bool> result = pDlg.ShowDialog();

                if (pDlg.ShowDialog() == DialogResult.OK)
                {
                   printDocument1.Print();
                   HDBLL.Sua(IDBanAn, int.Parse(numGiamGia.Value.ToString()), tongtien);
                   BABLL.Sua(IDBanAn, "Trống", null);
                   LoadBanAn();
                   HienThiHoaDon(IDBanAn); 
                }
                else
                {
                    MessageBox.Show("Đã hủy in");
                }
                //printDocument1.Print();
            }
        }
        private void induanhabepToolStripMenuItem_Click(object sender, EventArgs e)  //Nhấn vào in Phiếu đưa nhà bếp
        {
            PrintDialog pDlg = new PrintDialog();
            printDocument2.DocumentName = "In phiếu nhà bếp";
            pDlg.Document = printDocument2;
            pDlg.AllowSelection = true;
            pDlg.AllowSomePages = true;
            if (pDlg.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }
            else
            {
                MessageBox.Show("Đã hủy in");
            }
            //printDocument2.Print();
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) //Đưa dữ liệu vào Phiếu đưa nhà bếp
        {
            Image image = Resources.logoqa;
            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            e.Graphics.DrawString("Quán ăn B-A-C", new Font("Algerian", 30, FontStyle.Bold), Brushes.Black, new Point(350, 50));
            e.Graphics.DrawString("888 Lê Duẩn - BMT - 0868609878", new Font("Arial", 16), Brushes.Black, new Point(380, 90));
            e.Graphics.DrawString("PHIẾU ĐƯA NHÀ BẾP", new Font("Arial", 25, FontStyle.Bold), Brushes.Black, new Point(270, 250));
            e.Graphics.DrawString("Mã PTT: " + HDBLL.LayHoaDonTheoIDBanAn(IDBanAn).id, new Font("Arial", 14), Brushes.Black, new Point(60, 288));
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm"), new Font("Arial", 14), Brushes.Black, new Point(550, 288));
            e.Graphics.DrawString("----------------------------------------------------", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(60, 300));
            e.Graphics.DrawString("Tên món ăn", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(60, 330));
            e.Graphics.DrawString("SL", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(360, 330));
            e.Graphics.DrawString("----------------------------------------------------", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(60, 336));

            List<HoaDonChiTiet> ds = HDCTBLL.LayHoaDonChiTietTheoIDBanAn(IDBanAn);
            var dsthucan = from m in MABLL.LayTheoIDDanhMuc(1)
                     join h in ds on m.id equals h.idmonan
                     orderby m.ten ascending
                     select new
                     {
                         m.id,
                         m.ten,
                         h.soluong
                     };
            var dsnuocuong = from m in MABLL.LayTheoIDDanhMuc(2)
                           join h in ds on m.id equals h.idmonan
                           orderby m.ten ascending
                           select new
                           {
                               m.id,
                               m.ten,
                               h.soluong
                           };
            int ypos = 380;
            foreach (var i in dsthucan.ToList())
            {
                e.Graphics.DrawString(i.ten, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, ypos));
                e.Graphics.DrawString(i.soluong.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(360, ypos));
                ypos += 30;
            }

            e.Graphics.DrawString("----------------------------------------------------", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(60, ypos));
            e.Graphics.DrawString("Tên nước uống", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(60, ypos+30));
            e.Graphics.DrawString("SL", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(360, ypos+30));
            e.Graphics.DrawString("----------------------------------------------------", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(60, ypos+36));

            ypos += 76;
            foreach (var i in dsnuocuong.ToList())
            {
                e.Graphics.DrawString(i.ten, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, ypos));
                e.Graphics.DrawString(i.soluong.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(360, ypos));
                ypos += 30;
            }
        }
        private void dgvHoaDonChiTiet_DataSourceChanged(object sender, EventArgs e) //Khi hóa đơn không còn món thì button in ẩn đi
        {
            if (HDBLL.LayHoaDonTheoIDBanAn(IDBanAn) != null)
            {
                panel3.Enabled = true;
            }
            else
            {
                panel3.Enabled = false;
            }
        }

        private void printDocument2_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e) //Khi kết thúc in Phiếu đưa nhà bếp
        {
            MessageBox.Show("In phiếu đưa nhà bếp thành công");
        }
        private void printDocument1_EndPrint_1(object sender, System.Drawing.Printing.PrintEventArgs e) //Khi kết thúc in Phiếu tính tiền
        {
            MessageBox.Show("In phiếu tính tiền thành công");
        }
        #endregion

        #endregion

    }
}
