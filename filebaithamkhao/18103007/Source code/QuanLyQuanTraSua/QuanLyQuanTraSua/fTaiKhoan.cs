using DAL;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe
{
    public partial class fTaiKhoan : Form
    {
        private TaiKhoan loginAccount;

        public TaiKhoan LoginAccount { get => loginAccount; set => loginAccount = value; }
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();

        public fTaiKhoan(TaiKhoan Acc)
        {
            InitializeComponent();
            this.loginAccount = Acc;
            LoadAccount();
        }
        void LoadAccount()
        {
            txtTenDN.Text = LoginAccount.TenDangNhap;
            txtTenHienThi.Text = LoginAccount.TenTaiKhoan;
        }
        void UpdateAccountInfo()
        {
            string tenhienthi = txtTenHienThi.Text;
            string matkhau = txtMatKhau.Text;
            string matkhaumoi = txtMatKhauMoi.Text;
            string nhaplai = txtNhapLai.Text;
            string tendangnhap = txtTenDN.Text;

            if (!matkhaumoi.Equals(nhaplai))
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (TKBLL.UpdateAccount(tendangnhap, tenhienthi, matkhau, matkhaumoi))
                {
                    MessageBox.Show("Cập nhật thông tin cá nhân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(TKBLL.GetAccountByUsername(tendangnhap)));
                }
                else
                    MessageBox.Show("Vui lòng điền đúng mật khẩu!", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
    }
    public class AccountEvent : EventArgs
    {
        private TaiKhoan acc;

        public TaiKhoan Acc { get => acc; set => acc = value; }
        public AccountEvent(TaiKhoan Acc)
        {
            this.acc = Acc;
        }
    };
}
