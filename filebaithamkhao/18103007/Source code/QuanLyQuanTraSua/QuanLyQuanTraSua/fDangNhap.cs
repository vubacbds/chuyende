using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace QuanLyQuanCaPhe
{
    public partial class fDangNhap : Form
    {
        QLQuanTraSuaDataContext DB = new QLQuanTraSuaDataContext();
        TaiKhoanBLL AccBLL = new TaiKhoanBLL();
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tendangnhap = txtTenDN.Text;
            string matkhau = txtMatKhau.Text;
            if (Login(tendangnhap, matkhau))
            {
                TaiKhoan Acc = AccBLL.GetAccountByUsername(tendangnhap);
                fQuanLy f = new fQuanLy();
                f.loginAccount = Acc;
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        bool Login(string tendangnhap,string matkhau)
        {
            if(AccBLL.login(tendangnhap, matkhau)!= null)
                return true;
            return false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát chương trình?","Thông báo", MessageBoxButtons.OKCancel)!= System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void ckbHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienThiMK.Checked == false)
                txtMatKhau.UseSystemPasswordChar = true;
            else
                txtMatKhau.UseSystemPasswordChar = false;
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {
            txtTenDN.Text = "admin";
            txtMatKhau.Text = "123456";
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            fDangKi f = new fDangKi();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
