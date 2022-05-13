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
        
        void LoadTaiKhoan()
        {
            var kq = from h in TKBLL.LayTatCa() select new { h.tendangnhap, h.tenhienthi };
            dgvTaiKhoan.DataSource = kq.ToList();
            //Định dạng Datagridview
            #region
            dgvTaiKhoan.Columns["tenhienthi"].HeaderText = "Tên hiển thị";
            dgvTaiKhoan.Columns["tendangnhap"].HeaderText = "Tên đăng nhập";
            #endregion
        }

        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            TKBLL.ThemTaiKhoan(txtTenDangNhap.Text, txtTenHienThi.Text);
            LoadTaiKhoan();
        }
    }
}
