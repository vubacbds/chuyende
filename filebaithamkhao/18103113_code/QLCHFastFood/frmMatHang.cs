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
    public partial class frmMatHang : Form
    {
        MatHangBLL MHBLL = new MatHangBLL();
        DonViTinhBLL DVTBLL = new DonViTinhBLL();
        public frmMatHang()
        {
            InitializeComponent();
        }

        public void LoadDSMH()  //Hàm load nối các table và hiển thị các cột cần thiết
        {
            var ds = from h in MHBLL.LayTatCa()
                      join d in DVTBLL.LayTatCa() on h.DonViTinh equals d.ID
                      where h.TenMatHang.ToLower().Contains(txtTuKhoa.Text.ToLower())
                      select new
                      {
                          h.ID,
                          h.TenMatHang,
                          d.Ten,
                          h.GiaBan
                      };
            dgvData.DataSource = ds.ToList();
        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            LoadDSMH();
            //Định dạng Datagridview
            #region
            dgvData.Columns["ID"].HeaderText = "Mã";
            dgvData.Columns["TenMatHang"].HeaderText = "Mặt hàng";
            dgvData.Columns["Ten"].HeaderText = "Đơn vị";
            dgvData.Columns["GiaBan"].HeaderText = "Giá bán";

            dgvData.Columns["Ten"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvData.Columns["GiaBan"].DefaultCellStyle.Format = "N0";

            dgvData.Columns["ID"].Width = 50;
            dgvData.Columns["TenMatHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvData.Columns["Ten"].Width = 50;
            dgvData.Columns["GiaBan"].Width = 80;
            #endregion
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDSMH();
        }
      
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowi = e.RowIndex;
            if (rowi < 0 || rowi >= dgvData.Rows.Count)
            {
                return;
            }
            else
            {
                //MessageBox.Show("Bạn vừa nhấn vào hàng có Index " + dgvData.Rows[e.RowIndex].Index);
                new frmQLMatHang(dgvData.Rows[e.RowIndex].Cells[0].Value.ToString(), this).ShowDialog();
                LoadDSMH();
            }          
        }

        private void btnThemMatHang_Click(object sender, EventArgs e)
        {
            new frmQLMatHang(null, this).ShowDialog();
            LoadDSMH();
        }

        public void LoadSua()
        {
            this.Hide();
            new frmMatHang().ShowDialog();
            this.Dispose();
        }

    }
}
