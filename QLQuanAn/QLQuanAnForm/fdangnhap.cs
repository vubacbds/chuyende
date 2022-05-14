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
    public partial class fdangnhap : Form
    {
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        public fdangnhap()
        {
            InitializeComponent();
        }

        #region Events
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fdangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát không ?", "Thông bán", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnDanhNhap_Click(object sender, EventArgs e)
        {
            #region Ràng buộc nhập vào Form
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageBox.Show("Bạn thiếu tên đăng nhập");
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Bạn thiếu mật khẩu");
                return;
            }
            if (chkGhiNhoMatKhau.Checked)    //Ghi nhớ mật khẩu đăng nhập
            {
                Properties.Settings.Default.tendangnhap = txtTenDangNhap.Text;
                Properties.Settings.Default.matkhau = txtMatKhau.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.tendangnhap = "";
                Properties.Settings.Default.matkhau = "";
                Properties.Settings.Default.Save();
            }
            #endregion

            if (TKBLL.KiemTraDangNhap(txtTenDangNhap.Text, txtMatKhau.Text))
            {
                ftrangchu f = new ftrangchu();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }
        private void fdangnhap_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = Properties.Settings.Default.tendangnhap;
            txtMatKhau.Text = Properties.Settings.Default.matkhau;
        }
        #endregion


    }
}
