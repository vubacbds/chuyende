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
    public partial class fadmin : Form
    {
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        DanhMucBLL DMBLL = new DanhMucBLL();
        MonAnBLL MABLL = new MonAnBLL();
        HoaDonChiTietBLL HDCTBLL = new HoaDonChiTietBLL();
        HoaDonBLL HDBLL = new HoaDonBLL();
        BanAnBLL BABLL = new BanAnBLL();
        public fadmin()
        {
            InitializeComponent();
            LoadDanhMuc();
            LoadMonAn();
            LoadTaiKhoan();
            LoadBanAn();
            LoadHoaDon(false);
            AnHienMonAn = false;
            AnHienDanhMuc = false;
            AnHienBanAn = false;
        }
        private bool AnHienMonAn;
        private bool AnHienDanhMuc;
        private bool AnHienBanAn;

        #region Methods
        void LoadTaiKhoan()
        {
            //var kq = from h in TKBLL.LayTatCa() select new { h.tendangnhap, h.tenhienthi };
            dgvTaiKhoan.DataSource = TKBLL.LayTatCa().ToList();
            #region Định dạng Datagridview
            dgvTaiKhoan.Columns["tenhienthi"].HeaderText = "Tên hiển thị";
            dgvTaiKhoan.Columns["tendangnhap"].HeaderText = "Tên đăng nhập";
            dgvTaiKhoan.Columns["tendangnhap"].Width = 100;
            dgvTaiKhoan.Columns["tenhienthi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTaiKhoan.Columns[2].Visible = false;
            dgvTaiKhoan.Columns[3].Visible = false;
            #endregion
        }
        void LoadDanhMuc()
        {
            dgvDanhMuc.DataSource = DMBLL.LayTatCa();
            #region Định dạng Datagridview
            dgvDanhMuc.Columns["id"].HeaderText = "ID";
            dgvDanhMuc.Columns["ten"].HeaderText = "Tên danh mục";
            dgvDanhMuc.Columns["id"].Width = 40;
            dgvDanhMuc.Columns["ten"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDanhMuc.Columns[2].Visible = false;
            #endregion
        }
        void LoadMonAn()
        {
            dgvMonAn.DataSource = MABLL.LayTatCa();
            cbbDanhMuc.DataSource = DMBLL.LayTatCa(); 
            cbbDanhMuc.DisplayMember = "ten";    
            cbbDanhMuc.ValueMember = "id";
            cbbDanhMuc.SelectedIndex = -1;

            #region Định dạng Datagridview
            dgvMonAn.Columns["ten"].HeaderText = "Tên món";
            dgvMonAn.Columns["gia"].HeaderText = "Giá bán";
            dgvMonAn.Columns["gia"].Width = 80;
            dgvMonAn.Columns["ten"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMonAn.Columns["gia"].DefaultCellStyle.Format = "N0";
            dgvMonAn.Columns["gia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMonAn.Columns[0].Visible = false;
            dgvMonAn.Columns[2].Visible = false;
            dgvMonAn.Columns[4].Visible = false;
            dgvMonAn.Columns[5].Visible = false;
            #endregion
        }
        void LoadBanAn()
        {
            dgvBanAn.DataSource = BABLL.LayTatCa();
            #region Định dạng Datagridview
            dgvBanAn.Columns["ten"].HeaderText = "Tên bàn ăn";
            dgvBanAn.Columns["trangthai"].HeaderText = "Trạng thái";
            dgvBanAn.Columns["trangthai"].Width = 80;
            dgvBanAn.Columns["ten"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBanAn.Columns["trangthai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBanAn.Columns[0].Visible = false;
            #endregion
        }
        void LoadHoaDon(bool thongke)
        {
            List<HoaDon> listhd = HDBLL.LayTatCa();
            if (thongke)
            {
                listhd = HDBLL.LayHoaDonTheoThoiGian(dtpTuNgay.Value, dtpDenNgay.Value);
            }
            var kq = from h in listhd
                     join b in BABLL.LayTatCaHD() on h.idbanan equals b.id
                     orderby h.ngayvao descending
                     let doanhthusaugiamgia = h.tongtien - h.tongtien * h.giamgia / 100
                     select new
                     {
                         h.id,
                         h.tongtien,
                         h.ngayvao,
                         h.ngayra,
                         b.ten,
                         h.giamgia,
                         h.nguoitao,
                         h.trangthai,
                         idban = b.id,
                         doanhthusaugiamgia
                     };
            var tongdoanhthu = kq.Select(p => p.tongtien).Sum();
            var tongdoanhthusaugiamgia = kq.Select(p => p.doanhthusaugiamgia).Sum();
            dgvHoaDon.DataSource = kq.ToList();
            #region Định dạng Datagridview
            dgvHoaDon.Columns["id"].HeaderText = "Mã hóa đơn";
            dgvHoaDon.Columns["ngayvao"].HeaderText = "Ngày vào";
            dgvHoaDon.Columns["ngayra"].HeaderText = "Ngày ra";
            dgvHoaDon.Columns["ten"].HeaderText = "Tên bàn";
            dgvHoaDon.Columns["giamgia"].HeaderText = "Giảm giá(%)";
            dgvHoaDon.Columns["tongtien"].HeaderText = "Tổng tiền(vnđ)";
            dgvHoaDon.Columns["nguoitao"].HeaderText = "Người tạo";
            dgvHoaDon.Columns["trangthai"].HeaderText = "Trạng thái";
            dgvHoaDon.Columns["doanhthusaugiamgia"].HeaderText = "Tổng tiền sau giảm giá";
            dgvHoaDon.Columns["idban"].HeaderText = "ID bàn ăn";
            dgvHoaDon.Columns[8].Visible = false;
            dgvHoaDon.Columns[9].Visible = false;
            dgvHoaDon.Columns["tongtien"].DefaultCellStyle.Format = "N0";
            //dgvHoaDon.Columns["tongtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            #endregion

            if (thongke) //Nếu thống kê bằng true nghĩa là nhấn vào button thống kê mới hiển thị doanh thu
            {
                txtDoanhThuSauGiamGia.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", tongdoanhthusaugiamgia) + " vnđ";
                txtDoanhThu.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", tongdoanhthu) + " vnđ";
                var results = from k in kq    //Thống kê Doanh thu theo bàn ăn dùng groupby
                              group k by k.idban into theoban
                              orderby theoban.Key ascending
                              select new
                              {
                                  tenban = theoban.Select(g => g.ten).FirstOrDefault(),
                                  doanhthu = theoban.Sum(x => x.tongtien - x.tongtien * x.giamgia / 100)
                              };
                dgvDoanhThuTheoBan.DataSource = results.ToList();
                #region Định dạng Datagridview
                dgvDoanhThuTheoBan.Columns["tenban"].HeaderText = "Tên bàn";
                dgvDoanhThuTheoBan.Columns["doanhthu"].HeaderText = "Doanh thu";
                dgvDoanhThuTheoBan.Columns["doanhthu"].DefaultCellStyle.Format = "N0";
                dgvDoanhThuTheoBan.Columns["doanhthu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDoanhThuTheoBan.Columns["doanhthu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                #endregion

                var dsmonan = from h in listhd   //Thống kê doanh thu cho món ăn dùng groupby
                              join c in HDCTBLL.LayTatCa() on h.id equals c.idhoadon
                              join m in MABLL.LayTatCaHD() on c.idmonan equals m.id
                              let thanhtien = c.soluong * m.gia - c.soluong * m.gia * h.giamgia / 100
                              select new
                              {
                                  m.id,
                                  m.ten,
                                  c.soluong,
                                  thanhtien
                              };
                var groupbydsmonan = from k in dsmonan          
                                     group k by k.id into theomon
                              orderby theomon.Select(g => g.ten).FirstOrDefault() ascending
                              select new
                              {
                                  tenmon = theomon.Select(g => g.ten).FirstOrDefault(),
                                  doanhthu = theomon.Sum(x => x.thanhtien),
                                  soluong = theomon.Sum(x => x.soluong)
                              };
                dgvDoanhThuTheoMonAn.DataSource = groupbydsmonan.ToList();
                #region Định dạng Datagridview
                dgvDoanhThuTheoMonAn.Columns["tenmon"].HeaderText = "Tên món ăn";
                dgvDoanhThuTheoMonAn.Columns["doanhthu"].HeaderText = "Doanh thu";
                dgvDoanhThuTheoMonAn.Columns["doanhthu"].DefaultCellStyle.Format = "N0";
                dgvDoanhThuTheoMonAn.Columns["doanhthu"].Width = 60;
                dgvDoanhThuTheoMonAn.Columns["soluong"].HeaderText = "SL";
                dgvDoanhThuTheoMonAn.Columns["soluong"].Width = 30;
                dgvDoanhThuTheoMonAn.Columns["tenmon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDoanhThuTheoMonAn.Columns["doanhthu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                #endregion
            }
            else
            {
                txtDoanhThuSauGiamGia.Text = null;
            } 
        }
        void LoadChiTietHoaDon(string mahoadon)
        {
            var kq = from h in HDCTBLL.LayHoaDonChiTietTheoMaHoaDon(mahoadon)
                     join m in MABLL.LayTatCaHD() on h.idmonan equals m.id
                     select new
                     {
                         m.ten,
                         h.soluong,
                         m.gia
                     };
            dgvChiTietHoaDon.DataSource = kq.ToList();
            #region Định dạng Datagridview
            dgvChiTietHoaDon.Columns["ten"].HeaderText = "Tên món";
            dgvChiTietHoaDon.Columns["ten"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvChiTietHoaDon.Columns["soluong"].HeaderText = "SL";
            dgvChiTietHoaDon.Columns["soluong"].Width = 50;
            dgvChiTietHoaDon.Columns["gia"].HeaderText = "Đơn giá";
            dgvChiTietHoaDon.Columns["gia"].Width = 50;
            dgvChiTietHoaDon.Columns["gia"].DefaultCellStyle.Format = "N0";
            dgvChiTietHoaDon.Columns["gia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            #endregion
        }
        #endregion

        #region Events

        #region Events Tài khoản
        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            #region Ràng buộc nhập vào Form
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageBox.Show("Bạn thiếu tên đăng nhập");
                return;
            }
            if (string.IsNullOrEmpty(txtTenHienThi.Text))
            {
                MessageBox.Show("Bạn thiếu tên hiển thị");
                return;
            }
            if(TKBLL.KiemTraTenDangNhapBiTrung(txtTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
                return;
            }    
            #endregion

            TKBLL.ThemTaiKhoan(txtTenDangNhap.Text, txtTenHienThi.Text);
            LoadTaiKhoan();
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowi = e.RowIndex;
            if (rowi < 0 || rowi >= dgvTaiKhoan.Rows.Count)  //Để tránh lỗi khi nháy đúp vào tiêu đề
            {
                return;
            }
            else
            {
                #region Mở các nút thêm xóa sửa
                btnThemTaiKhoan.Enabled = true;
                btnSuaTaiKhoan.Enabled = true;
                btnXoaTaiKhoan.Enabled = true;
                btnResetMatKhau.Enabled = true;
                #endregion
                string tendangnhap = dgvTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString();
                TaiKhoan tk = TKBLL.LayTaiKhoanTheoTenDangNhap(tendangnhap);
                txtTenDangNhap.Text = tk.tendangnhap;
                txtTenHienThi.Text = tk.tenhienthi;
            }
        }
        private void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc Reset mật khẩu không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    TKBLL.Sua(txtTenDangNhap.Text, null, "6868");
                    MessageBox.Show("Reset mật khẩu thành công!");
                }
                catch
                {
                    MessageBox.Show("Reset mật khẩu thất bại!");
                }
            }
        }
        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                TKBLL.Sua(txtTenDangNhap.Text, txtTenHienThi.Text, null);
                LoadTaiKhoan();
            }
            catch
            {
                MessageBox.Show("Sửa tên hiển thị thất bại!");
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc Xóa tài khoản '" +txtTenDangNhap.Text+ "' không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    TKBLL.Xoa(txtTenDangNhap.Text);
                    txtTenDangNhap.Text = "";
                    txtTenHienThi.Text = "";
                    btnXoaTaiKhoan.Enabled = false;
                    btnThemTaiKhoan.Enabled = false;
                    btnSuaTaiKhoan.Enabled = false;
                    btnResetMatKhau.Enabled = false;
                    LoadTaiKhoan();
                }
                catch
                {
                    MessageBox.Show("Xóa tài khoản thất bại!");
                }
            }
        }

        private void txtTenDangNhap_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTenDangNhap.Text != "")
            {
                btnThemTaiKhoan.Enabled = true;
            }
            else
            {
                btnThemTaiKhoan.Enabled = false;
            }
        }
        private void btnTimTaiKhoan_Click(object sender, EventArgs e)
        {
            var query = TKBLL.LayTatCa().Where(t => t.tendangnhap.ToLower().Contains(txtTimTaiKhoan.Text.ToLower()));
            dgvTaiKhoan.DataSource = query.ToList();
            if (txtTimTaiKhoan.Text == "")
            {
                LoadTaiKhoan();
            }
        }
        #endregion

        #region Events Danh mục
        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            try
            {
                DMBLL.Them(txtTenDanhMuc.Text);
                LoadDanhMuc();
                LoadMonAn();  //Để cập nhật danh mục mới vào món ăn luôn
            }
            catch
            {
                MessageBox.Show("Thêm danh mục thất bại!");
            }
        }
        private void txtTenDanhMuc_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTenDanhMuc.Text != "")
            {
                btnThemDanhMuc.Enabled = true;
            }
            else
            {
                btnThemDanhMuc.Enabled = false;
            }

        }
        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowi = e.RowIndex;
            if (rowi < 0 || rowi >= dgvDanhMuc.Rows.Count)  //Để tránh lỗi khi nháy đúp vào tiêu đề
            {
                return;
            }
            else
            {
                #region Mở các nút thêm xóa sửa
                btnThemDanhMuc.Enabled = true;
                btnXoaDanhMuc.Enabled = true;
                btnSuaDanhMuc.Enabled = true;
                #endregion
                int id = int.Parse(dgvDanhMuc.Rows[e.RowIndex].Cells[0].Value.ToString());
                DanhMuc dm = DMBLL.LayDanhMucTheoID(id);
                txtIdDanhMuc.Text = dm.id.ToString();
                txtTenDanhMuc.Text = dm.ten;
            }
        }
        private void btnXoaDanhMuc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc Xóa danh mục '" + txtTenDanhMuc.Text + "' không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                int iddanhmuc = int.Parse(txtIdDanhMuc.Text);
                if (MABLL.KiemTraDanhMucCoMonChua(iddanhmuc) == null) //Trường hợp danh mục chưa có món ăn thì xóa được
                {
                    try
                    {
                        DMBLL.Xoa(iddanhmuc);
                        txtIdDanhMuc.Text = "";
                        txtTenDanhMuc.Text = "";
                        btnXoaDanhMuc.Enabled = false;
                        btnThemDanhMuc.Enabled = false;
                        btnSuaDanhMuc.Enabled = false;
                        LoadDanhMuc();
                        LoadMonAn();
                    }
                    catch
                    {
                        MessageBox.Show("Xóa danh mục thất bại!");
                    }
                }
                else    //Trường hợp danh mục có món ăn thì sửa trạng thái
                {
                    if (MessageBox.Show("Cảnh báo! Vì danh đã tồn tại món ăn, nên không thể xóa, bạn có muốn ẩn đi không ? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        DMBLL.Sua(iddanhmuc, null, 0);
                        LoadDanhMuc();
                        LoadMonAn();
                    }
                }
            }
        }
        private void btnSuaDanhMuc_Click(object sender, EventArgs e)
        {
            try
            {
                DMBLL.Sua(int.Parse(txtIdDanhMuc.Text), txtTenDanhMuc.Text, 1);
                LoadDanhMuc();
            }
            catch
            {
                MessageBox.Show("Sửa tên danh mục thất bại!");
            }
        }
        private void btnAnHienDanhMuc_Click(object sender, EventArgs e)  //Ẩn hiện danh mục 
        {
            AnHienDanhMuc = !AnHienDanhMuc;
            if (AnHienDanhMuc)
            {
                dgvDanhMuc.DataSource = DMBLL.LayDanhMucDaAnDi();
                btnAnHienDanhMuc.Text = "DS hiện";
            }
            else
            {
                LoadDanhMuc();
                btnAnHienDanhMuc.Text = "DS ẩn";
            }
        }

        private void dgvDanhMuc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  //Hiện lại danh mục
        {
            int rowi = e.RowIndex;
            if (rowi < 0 || rowi >= dgvDanhMuc.Rows.Count)  //Để tránh lỗi khi nháy đúp vào tiêu đề
            {
                return;
            }
            else
            {
                int id = int.Parse(dgvDanhMuc.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (DMBLL.LayDanhMucTheoID(id).trangthai == 0)
                {
                    DMBLL.Sua(id, null, 1);
                    MessageBox.Show("Đã hiện!");
                    dgvDanhMuc.DataSource = DMBLL.LayDanhMucDaAnDi();
                }
            }
        }
        #endregion

        #region Events Món án
        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowi = e.RowIndex;
            if (rowi < 0 || rowi >= dgvMonAn.Rows.Count)  //Để tránh lỗi khi nháy đúp vào tiêu đề
            {
                return;
            }
            else
            {
                #region Mở các nút thêm xóa sửa
                btnThemMonAn.Enabled = true;
                btnXoaMonAn.Enabled = true;
                btnSuaMonAn.Enabled = true;
                #endregion
                int id = int.Parse(dgvMonAn.Rows[e.RowIndex].Cells[0].Value.ToString());
                int iddanhmuc = int.Parse(dgvMonAn.Rows[e.RowIndex].Cells[2].Value.ToString());
                MonAn ma = MABLL.LayMonAnTheoID(id);
                txtIdMonAn.Text = ma.id.ToString();
                txtTenMonAn.Text = ma.ten;
                numGia.Value = (int)ma.gia;
                cbbDanhMuc.SelectedValue = iddanhmuc;    
            }
        }

        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenMonAn.Text))
            {
                MessageBox.Show("Bạn thiếu tên món");
                return;
            }
            if (cbbDanhMuc.SelectedValue == null)
            {
                MessageBox.Show("Bạn thiếu danh mục");
                return;
            }
            if (numGia.Value == 0)
            {
                MessageBox.Show("Chọn giá");
                return;
            }
            try
            {
                int iddanhmuc = int.Parse(cbbDanhMuc.SelectedValue.ToString());
                int gia = int.Parse(numGia.Value.ToString());
                MABLL.Them(txtTenMonAn.Text, iddanhmuc, gia);
                LoadMonAn();
            }
            catch
            {
                MessageBox.Show("Thêm món ăn thất bại!");
            }
        }

        private void txtTenMonAn_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTenMonAn.Text != "")
            {
                btnThemMonAn.Enabled = true;
            }
            else
            {
                btnThemMonAn.Enabled = false;
            }
        }

        private void btnXoaMonAn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc Xóa món '" + txtTenMonAn.Text + "' không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                int idmonan = int.Parse(txtIdMonAn.Text);
                if (HDCTBLL.KiemTraHDCTCoMonChua(idmonan) == null)
                {
                    try
                    {
                        MABLL.Xoa(idmonan);
                        txtIdMonAn.Text = "";
                        txtTenMonAn.Text = "";
                        numGia.Value = 0;
                        cbbDanhMuc.SelectedIndex = -1;

                        btnThemMonAn.Enabled = false;
                        btnXoaMonAn.Enabled = false;
                        btnSuaMonAn.Enabled = false;
                        LoadMonAn();
                    }
                    catch
                    {
                        MessageBox.Show("Xóa món ăn thất bại!");
                    }
                }
                else
                {
                    if (MessageBox.Show("Cảnh báo! Vì món ăn đã tồn tại hóa đơn, nên không thể xóa, bạn có muốn ẩn đi không ? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        MABLL.ThayDoiTrangThai(idmonan, 0);
                        LoadMonAn();
                    }
                }
            }   
        }
        private void btnSuaMonAn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenMonAn.Text))
            {
                MessageBox.Show("Bạn thiếu tên món");
                return;
            }
            if (cbbDanhMuc.SelectedValue == null)
            {
                MessageBox.Show("Bạn thiếu danh mục");
                return;
            }
            try
            {
                int iddanhmuc = int.Parse(cbbDanhMuc.SelectedValue.ToString());
                int gia = (int)numGia.Value;
                MABLL.Sua(int.Parse(txtIdMonAn.Text), txtTenMonAn.Text, iddanhmuc, gia);
                LoadMonAn();
            }
            catch
            {
                MessageBox.Show("Sửa món ăn thất bại!");
            }
        }
        private void btnTimMonAn_Click(object sender, EventArgs e)
        {
            var query = MABLL.LayTatCa().Where(c => RemoveDiacritics(c.ten.ToLower()).Contains(RemoveDiacritics(txtTimMonAn.Text.ToLower())));
            dgvMonAn.DataSource = query.ToList();
            if (txtTimMonAn.Text == "")
            {
                LoadMonAn();
            }
        }
        private string RemoveDiacritics(String s)  //Xóa dấu để tìm kiếm
        {
            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
        private void btnAnHienMonAn_Click(object sender, EventArgs e)  //Danh sách Ẩn hiện món ăn vì khi xóa món mà đã tồn tại trong hóa đơn chỉ ẩn đi
        {
            AnHienMonAn = !AnHienMonAn;
            if (AnHienMonAn)
            {
                dgvMonAn.DataSource = MABLL.LayMonDaAnDi();
                btnAnHienMonAn.Text = "DS hiện";
            }
            else
            {
                LoadMonAn();
                btnAnHienMonAn.Text = "DS ẩn";
            }
        }
        private void dgvMonAn_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //Nháy đúp vào món ăn thì thay đổi thành hiện
        {
            int rowi = e.RowIndex;
            if (rowi < 0 || rowi >= dgvDanhMuc.Rows.Count)  //Để tránh lỗi khi nháy đúp vào tiêu đề
            {
                return;
            }
            else
            {
                int id = int.Parse(dgvMonAn.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (MABLL.LayMonAnTheoID(id).trangthai == 0)
                {
                    MABLL.ThayDoiTrangThai(id, 1);
                    MessageBox.Show("Đã hiện!");
                    dgvMonAn.DataSource = MABLL.LayMonDaAnDi();
                }
            }
        }
        #endregion

        #region Events Bàn ăn
        private void btnThemBanAn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenBanAn.Text))
            {
                MessageBox.Show("Bạn thiếu tên bàn ăn");
                return;
            }
            BABLL.Them(txtTenBanAn.Text);
            LoadBanAn();
        }
        private void dgvBanAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowi = e.RowIndex;
            if (rowi < 0 || rowi >= dgvBanAn.Rows.Count)  //Để tránh lỗi khi nháy đúp vào tiêu đề
            {
                return;
            }
            else
            {
                #region Mở các nút thêm xóa sửa
                btnThemBanAn.Enabled = true;
                btnXoaBanAn.Enabled = true;
                btnSuaBanAn.Enabled = true;
                #endregion
                int id = int.Parse(dgvBanAn.Rows[e.RowIndex].Cells[0].Value.ToString());
                BanAn ba = BABLL.LayBanAnTheoID(id);
                txtIdBanAn.Text = ba.id.ToString();
                txtTenBanAn.Text = ba.ten;
                //cbbDanhMuc.SelectedValue = iddanhmuc;
            }
        }
        private void txtTenBanAn_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTenBanAn.Text != "")
            {
                btnThemBanAn.Enabled = true;
            }
            else
            {
                btnThemBanAn.Enabled = false;
            }
        }
        private void btnSuaBanAn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenBanAn.Text))
            {
                MessageBox.Show("Bạn thiếu tên bàn ăn");
                return;
            }
            int idbanan = int.Parse(txtIdBanAn.Text);
            BABLL.Sua(idbanan, null, txtTenBanAn.Text);
            LoadBanAn();
        }

        private void btnXoaBanAn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc Xóa '" + txtTenBanAn.Text + "' không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                int idbanan = int.Parse(txtIdBanAn.Text);
                if (HDBLL.KiemTraCoXoaDuocBanAnKhong(idbanan) == null)
                {
                    try
                    {
                        BABLL.Xoa(idbanan);
                        txtIdBanAn.Text = "";
                        txtTenBanAn.Text = "";

                        btnThemBanAn.Enabled = false;
                        btnXoaBanAn.Enabled = false;
                        btnSuaBanAn.Enabled = false;
                        LoadBanAn();
                    }
                    catch
                    {
                        MessageBox.Show("Xóa bàn ăn thất bại!");
                    }
                }
                else
                {
                    //MessageBox.Show("Đã tồn tại hóa đơn không thể xóa!");
                    if (MessageBox.Show("Cảnh báo! Vì bàn ăn đã tồn tại hóa đơn, nên không thể xóa, bạn có muốn ẩn đi không ? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        BABLL.Sua(idbanan, "Ẩn", null);
                        LoadBanAn();
                    }
                }
            }
        }
        private void btnAnHienBanAn_Click(object sender, EventArgs e) //Ẩn hiện bàn ăn
        {
            AnHienBanAn = !AnHienBanAn;
            if (AnHienBanAn)
            {
                dgvBanAn.DataSource = BABLL.LayBanAnDaAnDi();
                btnAnHienBanAn.Text = "DS hiện";
            }
            else
            {
                LoadBanAn();
                btnAnHienBanAn.Text = "DS ẩn";
            }
        }

        private void dgvBanAn_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //Hiện lại bàn ăn
        {
            int rowi = e.RowIndex;
            if (rowi < 0 || rowi >= dgvBanAn.Rows.Count)  //Để tránh lỗi khi nháy đúp vào tiêu đề
            {
                return;
            }
            else
            {
                int id = int.Parse(dgvBanAn.Rows[e.RowIndex].Cells[0].Value.ToString());
                string tt = "Trống";
                if (HDBLL.LayHoaDonTheoIDBanAn(id) != null)  //Nếu đã đặt thì set lại trạng thái đã đặt
                {
                    tt = "Đã đặt";
                }
                if (BABLL.LayBanAnTheoID(id).trangthai == "Ẩn")
                {
                    BABLL.Sua(id, tt, null);
                    MessageBox.Show("Đã hiện!");
                    dgvBanAn.DataSource = BABLL.LayBanAnDaAnDi();
                }
            }
        }
        #endregion

        #region Events Hóa đơn
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)  //Chọn vào 1 hàng hóa đơn hiển thị chi tiết
        {
            int rowi = e.RowIndex;
            if (rowi < 0 || rowi >= dgvHoaDon.Rows.Count)  //Để tránh lỗi khi nháy đúp vào tiêu đề
            {
                return;
            }
            else
            {
                string id = dgvHoaDon.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMaHoaDon.Text = id;
                LoadChiTietHoaDon(id);
            }
        }
        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            LoadHoaDon(true);
        }

        private void btnXuatExcel_Click_1(object sender, EventArgs e)
        {
            if (dgvHoaDon.RowCount > 0)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                    ToExcel(dgvHoaDon, saveFileDialog1.FileName);
                }
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu");
            }
        }
        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = "Quản lý quán ăn";

                // export header trong DataGridView
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        string giatri1o = "";
                        if (dataGridView1.Rows[i].Cells[j].Value != null) giatri1o = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        worksheet.Cells[i + 2, j + 1] = giatri1o;
                    }
                }
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }

        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc xóa hóa đơn '" + txtMaHoaDon.Text + "' không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(txtMaHoaDon.Text))
                {
                    MessageBox.Show("Bạn thiếu mã hóa đơn!");
                    return;
                }
                try
                {
                    if (HDBLL.LayHoaDonTheoID(txtMaHoaDon.Text).trangthai == 0) //Nếu hóa đơn chưa thanh toán thì khi xóa hóa đơn bàn ăn thay đổi trạng thái
                    {
                        int idbanan = HDBLL.LayHoaDonTheoID(txtMaHoaDon.Text).idbanan;
                        BABLL.Sua(idbanan, "Trống", null);
                    }
                    HDCTBLL.XoaTatCa(txtMaHoaDon.Text);
                    HDBLL.Xoa(txtMaHoaDon.Text);
                    LoadHoaDon(false);
                    dgvChiTietHoaDon.DataSource = null;
                    txtMaHoaDon.Text = "";
                }
                catch
                {
                    MessageBox.Show("Mã hóa đơn không tồn tại");
                }
            }
        }
        private void btnTimHoaDon_Click(object sender, EventArgs e)
        {
            var query = HDBLL.LayTatCa().Where(c => c.id.Contains(txtMaHoaDon.Text));
            dgvHoaDon.DataSource = query.ToList();
            if (txtMaHoaDon.Text == "")
            {
                LoadHoaDon(false);
            }
        }
        #endregion

        #endregion
    }
}
