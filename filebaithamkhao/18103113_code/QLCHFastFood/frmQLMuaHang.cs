using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace QLCHFastFood
{
    public partial class frmQLMuaHang : Form
    {
        MatHangBLL MHBLL = new MatHangBLL();
        HoaDonBLL HDBLL = new HoaDonBLL();
        ChiTietHoaDonBLL CTHDBLL = new ChiTietHoaDonBLL();
        DonViTinhBLL DVTBLL = new DonViTinhBLL();
        int MaHoaDon, TongTien;
        public frmQLMuaHang()
        {
            InitializeComponent();
        }
        public void LoadHD()
        {
            this.cbbTenMatHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbbTenMatHang.DataSource = MHBLL.LayTatCa(); //Lấy thông tin đưa vào Combobox
            cbbTenMatHang.DisplayMember = "TenMatHang";    //Hiện tên
            cbbTenMatHang.ValueMember = "ID";       //Lấy giá trị là ID
            cbbTenMatHang.SelectedIndex = -1;     //Không chọn giá trị mặc định của CBB
            txtTenKhachHang.Text = "Khách lẻ"; //Để mặc định tên khách hàng (có thể ko biết tên)
            txtSoDienThoai.Text = "09xx"; //Để mặc định sđt
            txtSoLuong.Text = "";

            TongTien = CTHDBLL.TongTien();
            lblTongTien.Text = "Tổng tiền: "+ String.Format("{0:0,0 vnđ}", TongTien);

            var ds = from h in MHBLL.LayTatCa()
                     join d in CTHDBLL.LayTatCa() on h.ID equals d.MaMatHang
                     join k in DVTBLL.LayTatCa() on h.DonViTinh equals k.ID
                     where d.TrangThai == null
                     select new
                     {
                         d.ID,
                         h.TenMatHang,
                         d.SoLuong,
                         k.Ten,
                         d.ThanhTien
                     };
            dgvHoaDon.DataSource = ds.ToList();

            //Định dạng Datagridview
            #region
            dgvHoaDon.Columns["TenMatHang"].HeaderText = "Mặt hàng";
            dgvHoaDon.Columns["SoLuong"].HeaderText = "SL";
            dgvHoaDon.Columns["Ten"].HeaderText = "ĐVT";
            dgvHoaDon.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvHoaDon.Columns["TenMatHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHoaDon.Columns["SoLuong"].Width = 40;
            dgvHoaDon.Columns["Ten"].Width = 40;
            #endregion
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadHD();                 
            dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvHoaDon.Columns[0].Visible = false;
            Random rand = new Random();
            MaHoaDon = rand.Next(100000, 999999);         
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            //Ràng buộc
            #region
            if (string.IsNullOrEmpty(cbbTenMatHang.Text))
            {
                MessageBox.Show("Vui lòng chọn tên mặt hàng");
                return;
            }
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập só lượng");
                return;
            }          
            #endregion

            string MaMatHang = cbbTenMatHang.SelectedValue.ToString();
            int SoLuong = int.Parse(txtSoLuong.Text);

            MatHang mh = MHBLL.LayTheoMa(MaMatHang);
            int ThanhTien = (int)mh.GiaBan * SoLuong;

            try
            {
                if(CTHDBLL.KiemTraTrungTenHangTrongGioHang(MaMatHang) == 1) //Nếu nhập trùng mặt hàng thì chỉ cho tăng thêm số lượng
                {
                    CTHDBLL.SuaSoLuong(MaMatHang, SoLuong);
                    MessageBox.Show("Chỉnh số lượng thành công! ");
                    LoadHD();
                }
                else
                {
                    CTHDBLL.ThemVaoGio(MaHoaDon, MaMatHang, SoLuong, ThanhTien);
                    MessageBox.Show("Thêm vào giỏ thành công! ");
                    LoadHD();
                }           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại! " + ex.Message);
            }
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowi = e.RowIndex;
            if (rowi < 0 || rowi >= dgvHoaDon.Rows.Count)
            {
                return;
            }
            else
            {
                int idhd = int.Parse(dgvHoaDon.Rows[e.RowIndex].Cells[0].Value.ToString());
                CTHDBLL.Xoa(idhd);
                LoadHD();
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            string TenKhacHang = txtTenKhachHang.Text;
            string SoDienThoai = txtSoDienThoai.Text;

            //Ràng buộc
            #region
            if(SoDienThoai.Length != 10 && SoDienThoai != "09xx")
            {
                MessageBox.Show("Vui lòng nhập SDT có 10 số");
                return;
            }         
            #endregion
          
            try
            {
                if (CTHDBLL.DemSoLuong() > 0)
                {
                    HDBLL.Them(MaHoaDon, TenKhacHang, SoDienThoai);
                    MessageBox.Show("Thêm vào hóa đơn thàng công!");

                    CTHDBLL.Sua();
                    new frmXuatHoaDon(MaHoaDon, TongTien).ShowDialog();

                    Random rand = new Random();
                    MaHoaDon = rand.Next(100000, 999999);
                    LoadHD();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhâp bánh vào giỏ");
                    return;
                }                                     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm vào hóa đơn thất bại! " + ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadHD();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            new frmThongKe().ShowDialog();
            LoadHD();
        }

        private void btnQLMatHang_Click(object sender, EventArgs e)
        {
            new frmMatHang().ShowDialog();
            LoadHD();
        }

        private void btnXemLichSuHoaDon_Click(object sender, EventArgs e)
        {
            new frmLichSuHoaDon().ShowDialog();
            LoadHD();
        }

        private void frmHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            CTHDBLL.XoaNull();
        }       
    }
    
}

