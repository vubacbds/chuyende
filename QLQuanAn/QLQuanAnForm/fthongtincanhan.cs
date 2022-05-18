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
    public partial class fthongtincanhan : Form
    {
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        public fthongtincanhan(string tendangnhap)
        {
            this.tendangnhap = tendangnhap;
            InitializeComponent();
        }
        private string tendangnhap;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fthongtincanhan_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = tendangnhap;
            txtTenHienThi.Text = TKBLL.LayTaiKhoanTheoTenDangNhap(tendangnhap).tenhienthi;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            #region Ràng buộc nhập vào Form
            if (string.IsNullOrEmpty(txtTenHienThi.Text))
            {
                MessageBox.Show("Bạn thiếu tên hiển thị");
                return;
            }
            
            if(txtMatKhau.Text != "")
            {
                if (string.IsNullOrEmpty(txtMatKhauMoi.Text))
                {
                    MessageBox.Show("Bạn thiếu mật khẩu mới");
                    return;
                }

                if (txtMatKhauMoi.Text == txtNhapLai.Text)
                {
                    if(TKBLL.KiemTraDangNhap(tendangnhap, txtMatKhau.Text) == true)
                    {
                        try
                        {
                            TKBLL.Sua(tendangnhap, txtTenHienThi.Text, txtMatKhauMoi.Text);
                            MessageBox.Show("Đổi mật khẩu thành công!");
                        }
                        catch
                        {
                            MessageBox.Show("Đổi mật khẩu thất bại!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Mật khẩu không trùng");
                    return;
                }
            }
            else
            {
                try
                {
                    TKBLL.Sua(tendangnhap, txtTenHienThi.Text, null);
                    MessageBox.Show("Đổi đổi tên hiểu thị thành công!");
                }
                catch
                {
                    MessageBox.Show("Đổi đổi tên hiểu thị thất bại!");
                }
            }
            
            #endregion
        }
    }
}
