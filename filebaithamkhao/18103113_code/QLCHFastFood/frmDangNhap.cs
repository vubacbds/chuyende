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

namespace QLCHFastFood
{
    public partial class frmDangNhap : Form
    {
        TaiKhoanBLL TaiKhoanBLL = new TaiKhoanBLL();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //Ràng buộc
            #region
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
                Properties.Settings.Default.user = txtTenDangNhap.Text;
                Properties.Settings.Default.pass = txtMatKhau.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.user = "";
                Properties.Settings.Default.pass = "";
                Properties.Settings.Default.Save();
            }
            #endregion

            TaiKhoan nv = TaiKhoanBLL.LayTheoTenDangNhapVaMatKhau(txtTenDangNhap.Text, txtMatKhau.Text);
            if (nv != null)
            {
                frmQLMuaHang frmDH = new frmQLMuaHang();
                this.Hide();         
                frmDH.FormClosed += FrmDH_FormClosed;
                frmDH.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tên đăng nhặp hoặc mật khẩu không đúng !");
            }
        }

        private void FrmDH_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmDangKy().ShowDialog();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = Properties.Settings.Default.user;
            txtMatKhau.Text = Properties.Settings.Default.pass;
        }
    }
}
