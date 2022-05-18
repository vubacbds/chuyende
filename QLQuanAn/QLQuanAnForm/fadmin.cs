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
        public fadmin()
        {
            InitializeComponent();
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
            dgvTaiKhoan.Columns["tendangnhap"].Width = 90;
            dgvTaiKhoan.Columns["tenhienthi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

           
            #endregion
        }
        #endregion

        #region Events
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
        }
        #endregion
    }
}
