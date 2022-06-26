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
    public partial class frmDangKy : Form
    {
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        public frmDangKy()
        {
            InitializeComponent();
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            //Ràng buộc
            #region
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Bạn thiếu tên tài khoảrn");
                return;
            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Bạn thiếu mật khẩu");
                return;
            }
            if (TKBLL.KiemTraTenTaiKhoanBiTrung(txtUser.Text) == 1)
            {
                MessageBox.Show("Tên tài khoản đã tồn tại");
                return;
            }
            #endregion

            if (txtPass.Text == txtPassXN.Text)
            {
                TKBLL.DangKy(txtUser.Text, txtPass.Text);
                MessageBox.Show("Đăng ký thành công");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Mật khẩu không trùng");
                return;
            }                  
        }      
    }
}
