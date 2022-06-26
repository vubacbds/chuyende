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
    
    public partial class frmQLMatHang : Form
    {
        MatHangBLL MHBLL = new MatHangBLL();
        DonViTinhBLL DVTBLL = new DonViTinhBLL();

        MatHang mh = null;
        public frmQLMatHang(string mahang, frmMatHang fmh)
        {
            this.mahang = mahang;
            this.fmh = fmh;
            InitializeComponent();
        }
        private string mahang;
        private frmMatHang fmh;

        private void frmMH_Load(object sender, EventArgs e)
        {
            this.cbbDVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbbDVT.DataSource = DVTBLL.LayTatCa(); //Lấy thông tin đưa vào Combobox
            cbbDVT.DisplayMember = "Ten";    //Hiện tên
            cbbDVT.ValueMember = "ID";       //Lấy giá trị là ID
            cbbDVT.SelectedIndex = -1;     //Không chọn giá trị mặc định của CBB

            if (!string.IsNullOrEmpty(mahang))  //Nếu tồn tại mã hàng lấy lại thông tin
            {
                lblTieuDe.Text = "Cập nhật thông tin mặt hàng";
                mh = MHBLL.LayTheoMa(mahang);
                txtTenMatHang.Text = mh.TenMatHang;
                cbbDVT.SelectedValue = mh.DonViTinh;
                txtGiaBan.Text = mh.GiaBan.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
       
        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Ràng buộc
            #region
            if (string.IsNullOrEmpty(txtTenMatHang.Text))  
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng");
                return;
            }
            if (cbbDVT.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính");
                return;
            }
            if (string.IsNullOrEmpty(txtGiaBan.Text))
            {
                MessageBox.Show("Vui lòng nhập giá bán");
                return;
            }
            try
            {
                var dg = int.Parse(txtGiaBan.Text);
                if (dg <= 0)
                {
                    MessageBox.Show("Đơn giá không hợp lệ");
                    return;
                }
            }

            catch
            {
                MessageBox.Show("Đơn giá không hợp lệ");
                return;
            }
            #endregion
            
            if (mh != null)   //Cập nhật mặt hàng
            {
                try
                {
                    MHBLL.Sua(txtTenMatHang.Text, int.Parse(cbbDVT.SelectedValue.ToString()), int.Parse(txtGiaBan.Text), mahang);
                    MessageBox.Show("Cập nhật bánh thành công! ");
                    this.Dispose();
                    fmh.LoadSua();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật bánh thất bại! " + ex.Message);
                }
            }
            else  //Thêm mới mặt hàng
            {
                Random rand = new Random();        
                int Ma = rand.Next(100, 999);     //Tạo mã mặt hàng bằng Random
                var mahang = txtTenMatHang.Text.Substring(0, 1).ToUpper() + Ma; //Lấy chữ cái đầu tên mặt hàng + ma random

                try
                {
                    MHBLL.Them(mahang, txtTenMatHang.Text, int.Parse(cbbDVT.SelectedValue.ToString()), int.Parse(txtGiaBan.Text));
                    MessageBox.Show("Thêm mới mặt hàng thành công ");
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm mới mặt hàng thất bại: " + ex.Message);
                }

            }
        }
     
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MHBLL.Xoa(mahang);
            this.Dispose();
        }        
    }
}
