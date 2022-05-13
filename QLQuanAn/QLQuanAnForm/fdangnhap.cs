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
        #endregion
    }
}
