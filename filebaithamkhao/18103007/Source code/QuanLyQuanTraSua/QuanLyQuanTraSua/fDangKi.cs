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

namespace QuanLyQuanCaPhe
{
    public partial class fDangKi : Form
    {
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        public fDangKi()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            string tenhienthi = txtTenHienThi.Text;
            string matkhau = txtMatKhau.Text;
            string tendangnhap = txtTenDN.Text;
            if(tendangnhap == "" || matkhau=="" ||tenhienthi =="")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TKBLL.InsertAccount(tendangnhap, tenhienthi, matkhau);
                MessageBox.Show("Đăng kí tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            
        }
    }
}
