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

namespace QLQuanAnForm
{
    public partial class fadmin : Form
    {
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        DanhMucBLL DMBLL = new DanhMucBLL();
        MonAnBLL MABLL = new MonAnBLL();
        HoaDonChiTietBLL HDCTBLL = new HoaDonChiTietBLL();
        public fadmin()
        {
            InitializeComponent();
            LoadDanhMuc();
            LoadMonAn();
            LoadTaiKhoan();
        }
        #region Methods
        void LoadTaiKhoan()
        {
            var kq = from h in TKBLL.LayTatCa() select new { h.tendangnhap, h.tenhienthi };
            dgvTaiKhoan.DataSource = kq.ToList();
            #region Định dạng Datagridview
            dgvTaiKhoan.Columns["tenhienthi"].HeaderText = "Tên hiển thị";
            dgvTaiKhoan.Columns["tendangnhap"].HeaderText = "Tên đăng nhập";
            dgvTaiKhoan.Columns["tendangnhap"].Width = 100;
            dgvTaiKhoan.Columns["tenhienthi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

           
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
                    DMBLL.Sua(iddanhmuc, null, 0);
                    LoadDanhMuc();
                    LoadMonAn();
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
            if (txtTenMonAn.Text != null)
            {
                btnThemMonAn.Enabled = true;
            }
            else
            {
                btnThemDanhMuc.Enabled = false;
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
                    MABLL.ThayDoiTrangThai(idmonan);
                    LoadMonAn();
                }
            }   
        }
        private void btnSuaMonAn_Click(object sender, EventArgs e)
        {
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
        #endregion

        #endregion

    }
}
