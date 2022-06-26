using DAL;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe
{
    public partial class fQuanTriVien : Form
    {
        public TaiKhoan loginAccout;

        DanhMucMatHangBLL CatBLL = new DanhMucMatHangBLL();
        MatHangBLL MHBLL = new MatHangBLL();
        BanAnBLL BABLL = new BanAnBLL();
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        ChucVuBLL CVBLL = new ChucVuBLL();
        HoaDonBLL HDBLL = new HoaDonBLL();

        BindingSource foodListBDS = new BindingSource();
        BindingSource categoryBDS = new BindingSource();
        BindingSource tableFoodBDS = new BindingSource();
        BindingSource accountBDS = new BindingSource();
        public fQuanTriVien()
        {
            InitializeComponent();
        }
        private void fQuanTriVien_Load(object sender, EventArgs e)
        {
            dgvMatHang.DataSource = foodListBDS;
            dgvDanhMuc.DataSource = categoryBDS;
            dgvBan.DataSource = tableFoodBDS;
            dgvTaiKhoan.DataSource = accountBDS;

            LoadDateTimePickerBill();
            LoadlistBillByDateAndPage(dtpTuNgay.Value, dtpDenNgay.Value, 1);

            LoadListFood();
            AddFoodBinding();
            LoadCategoryIntoComboBox(cbDM);

            LoadListCategory();
            AddCategoryBinding();

            LoadListTableFood();
            AddTableFoodBinding();
            LoadStatusTable();

            LoadListAccount();
            AddAccountBinding();
            LoadTypeAccount();
        }
        #region methods
        //Mặt hàng
        List<MatHang> SearchFoodByName(string ten)
        {
            List<MatHang> listFood = MHBLL.SearchFoodByName(ten);
            return listFood;
        }
        void LoadListFood()
        {
            foodListBDS.DataSource = MHBLL.GetListFood();

            dgvMatHang.Columns[0].HeaderText = "ID";
            dgvMatHang.Columns[1].HeaderText = "Tên sản phẩm";
            dgvMatHang.Columns[2].HeaderText = "ID Danh mục";
            dgvMatHang.Columns[3].HeaderText = "Giá";
            dgvMatHang.Columns[4].Visible = false;

            dgvMatHang.AllowUserToAddRows = false;
        }
        
        void AddFoodBinding()
        {
            txtIdMH.DataBindings.Add(new Binding("Text", dgvMatHang.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtTenMH.DataBindings.Add(new Binding("Text", dgvMatHang.DataSource, "Ten", true, DataSourceUpdateMode.Never));
            nmGiaMH.DataBindings.Add(new Binding("Value", dgvMatHang.DataSource, "Gia", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = DanhMucMatHangBLL.Instance.GetListCategory();
            cb.DisplayMember = "Ten";
        }

        // Danh mục
        void LoadListCategory()
        {
            categoryBDS.DataSource = CatBLL.GetListCategory();

            dgvDanhMuc.Columns[0].HeaderText = "ID";
            dgvDanhMuc.Columns[1].HeaderText = "Tên danh mục";

            dgvDanhMuc.AllowUserToAddRows = false;
        }
        void AddCategoryBinding()
        {
            txtIdDM.DataBindings.Add(new Binding("Text", dgvDanhMuc.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtTenDM.DataBindings.Add(new Binding("Text", dgvDanhMuc.DataSource, "Ten", true, DataSourceUpdateMode.Never));
        }
        // Bàn ăn
        void LoadListTableFood()
        {
            tableFoodBDS.DataSource = BABLL.LoadTableList();

            dgvBan.Columns[0].HeaderText = "ID";
            dgvBan.Columns[1].HeaderText = "Tên bàn";
            dgvBan.Columns[2].HeaderText = "Trạng thái";

            dgvBan.AllowUserToAddRows = false;
        }
        void LoadStatusTable()
        {
            cbTrangThaiBan.DataSource = BABLL.LoadTableList();
            cbTrangThaiBan.DisplayMember = "TrangThai";
        }
        void AddTableFoodBinding()
        {
            txtIdBan.DataBindings.Add(new Binding("Text", dgvBan.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtTenBan.DataBindings.Add(new Binding("Text", dgvBan.DataSource, "Ten", true, DataSourceUpdateMode.Never));
        }

        // Tài khoản
        void LoadListAccount()
        {
            accountBDS.DataSource = TKBLL.GetListAccount();

            dgvTaiKhoan.Columns[0].HeaderText = "Tên đăng nhập";
            dgvTaiKhoan.Columns[1].HeaderText = "Mật khẩu";
            dgvTaiKhoan.Columns[1].Visible = false;
            dgvTaiKhoan.Columns[2].HeaderText = "Tên hiển thị";
            dgvTaiKhoan.Columns[3].HeaderText = "Chức vụ";
            dgvTaiKhoan.Columns[4].Visible = false;

            dgvTaiKhoan.AllowUserToAddRows = false;
        }
        void AddAccountBinding()
        {
            txtTenDN.DataBindings.Add(new Binding("Text", dgvTaiKhoan.DataSource, "TenDangNhap", true, DataSourceUpdateMode.Never));
            txtTenHienThi.DataBindings.Add(new Binding("Text", dgvTaiKhoan.DataSource, "TenTaiKhoan", true, DataSourceUpdateMode.Never));
        }
        void LoadTypeAccount()
        {
            cbLoaiTK.DataSource = CVBLL.GetListType();
            cbLoaiTK.DisplayMember = "Ten";
        }

        //Doanh thu
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1);
            dtpDenNgay.Value = dtpTuNgay.Value.AddMonths(1).AddDays(-1);
        }
        void LoadlistBillByDateAndPage(DateTime tungay, DateTime denngay, int page)
        {            
            dgvDoanhThu.DataSource = HDBLL.GetBillListByDateAndPage(tungay, denngay, page);
        }
        int LastPage(DateTime tungay, DateTime denngay)
        {
            int numBill = HDBLL.GetNumBillListByDate(dtpTuNgay.Value, dtpDenNgay.Value);
            int lastPage = numBill / 10;

            if (numBill % 10 != 0)
            {
                lastPage++;
            }
            return lastPage;
        }
        #endregion

        #region events
        // Mặt hàng
        private void txtIdMH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMatHang.SelectedCells.Count > 0)
                {
                    int id = -1;
                    //if (dgvMatHang.SelectedCells[0].OwningRow.Cells["id_DM"].Value != null)
                        id = (int)dgvMatHang.SelectedCells[0].OwningRow.Cells["id_DM"].Value;

                    int index = -1, i = 0;
                    foreach (DanhMucMatHang item in cbDM.Items)
                    {
                        if (item.id == id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbDM.SelectedIndex = index;
                }
            }
            catch{}
        }
        private void btnXoaMH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc xóa sản phẩm: " + txtTenMH.Text + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                int id = Convert.ToInt32(txtIdMH.Text);
                MHBLL.DeleteFood(id);
                LoadListFood();

                if (deleteFood != null)
                {
                    deleteFood(this, new EventArgs());
                }
            }
        }
        private void btnThemMH_Click(object sender, EventArgs e)
        {
            string ten = txtTenMH.Text;
            int id_cat = (cbDM.SelectedItem as DanhMucMatHang).id;
            float gia = (float)nmGiaMH.Value;

            MHBLL.InsertFood(ten, id_cat, gia);
            LoadListFood();

            if (inserFood != null)
            {
                inserFood(this, new EventArgs());
            }
        }
        private void btnSuaMH_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdMH.Text);
            string ten = txtTenMH.Text;
            int id_cat = (cbDM.SelectedItem as DanhMucMatHang).id;
            float gia = (float)nmGiaMH.Value;

            MHBLL.UpdateFood(id, ten, id_cat, gia);
            LoadListFood();

            if (updateFood != null)
            {
                updateFood(this, new EventArgs());
            }
        }
        private void btnXemMH_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        private void btnTimMH_Click(object sender, EventArgs e)
        {
            foodListBDS.DataSource = SearchFoodByName(txtTimTenMH.Text);
        }

        //Doanh thu
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadlistBillByDateAndPage(dtpTuNgay.Value, dtpDenNgay.Value, 1);
        }
        private void txtTrang_TextChanged(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtTrang.Text);
            LoadlistBillByDateAndPage(dtpTuNgay.Value, dtpDenNgay.Value, page);
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            txtTrang.Text = "1";
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtTrang.Text);
            if (page > 1)
                page--;
            txtTrang.Text = page.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int lastPage = LastPage(dtpTuNgay.Value, dtpDenNgay.Value);
            int page = Convert.ToInt32(txtTrang.Text);
            if (page < lastPage)
                page++;

            txtTrang.Text = page.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int lastPage = LastPage(dtpTuNgay.Value, dtpDenNgay.Value);
            txtTrang.Text = lastPage.ToString();
        }

        // Danh mục        
        private void btnThemDM_Click(object sender, EventArgs e)
        {
            string ten = txtTenDM.Text;
            CatBLL.InsertCategory(ten);
            LoadListCategory();
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc xóa danh mục: " + txtTenDM.Text,"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.OK)
            {
                int id = Convert.ToInt32(txtIdDM.Text);
                CatBLL.DeleteCategory(id);
                LoadListCategory();
            }
        }

        private void btnSuaDM_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdDM.Text);
            string ten = txtTenDM.Text;
            CatBLL.UpdateCategory(id, ten);
            LoadListCategory();
        }
        
        private void btnXemDM_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }

        // Bàn ăn
        private void txtIdBan_TextChanged(object sender, EventArgs e)
        {
            if (dgvBan.SelectedCells.Count > 0)
            {
                int id = (int)dgvBan.SelectedCells[0].OwningRow.Cells["id"].Value;

                int index = -1, i = 0;
                foreach (BanAn item in cbTrangThaiBan.Items)
                {
                    if (item.id == id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbTrangThaiBan.SelectedIndex = index;
            }
        }
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            string ten = txtTenBan.Text;
            BABLL.InsertTableFood(ten);
            LoadListTableFood();
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc xóa: " + txtTenBan.Text, "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                int id = Convert.ToInt32(txtIdBan.Text);
                BABLL.DeleteTableFood(id);
                LoadListTableFood();
            }
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdBan.Text);
            string ten = txtTenBan.Text;
            BABLL.UpdateTableFood(id, ten);
            LoadListTableFood();
        }

        private void btnXemBan_Click(object sender, EventArgs e)
        {
            LoadListTableFood();
        }

        // Tài khoản
        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvTaiKhoan.SelectedCells.Count > 0)
                {
                    int id = (int)dgvTaiKhoan.SelectedCells[0].OwningRow.Cells["id_CV"].Value;

                    int index = -1, i = 0;
                    foreach (ChucVu item in cbLoaiTK.Items)
                    {
                        if (item.id == id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbLoaiTK.SelectedIndex = index;
                }
            }
            catch { }
        }
        private void btnThemTK_Click(object sender, EventArgs e)
        {
            string tendangnhap = txtTenDN.Text;
            string tenhienthi = txtTenHienThi.Text;
            int id_cv = (cbLoaiTK.SelectedItem as ChucVu).id;
            TKBLL.InsertAccount(tendangnhap, tenhienthi, id_cv);

            LoadListAccount();
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            string tendangnhap = txtTenDN.Text;
            if (loginAccout.TenDangNhap.Equals(tendangnhap))
                MessageBox.Show("Vui lòng không xóa tài khoản đang dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (MessageBox.Show("Bạn có chắc xóa tài khoản: " + txtTenHienThi.Text, "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                TKBLL.DeleteAccount(tendangnhap);
                LoadListAccount();
            }
        }

        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            try
            {
                string tendangnhap = txtTenDN.Text;
                string tenhienthi = txtTenHienThi.Text;
                int id_cv = (cbLoaiTK.SelectedItem as ChucVu).id;
                TKBLL.UpdateAccount(tendangnhap, tenhienthi, id_cv);
                LoadListAccount();
            }
            catch {
                MessageBox.Show("Không được đổi tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXemTK_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }
        private void btnResetMK_Click(object sender, EventArgs e)
        {
            string tendangnhap = txtTenDN.Text;
            string tenhienthi = txtTenHienThi.Text;
            TKBLL.ResetPass(tendangnhap);
            MessageBox.Show("Reset mật khẩu thành công cho tài khoản: " + tenhienthi + "\nMật khẩu: 1");
        }

        // EventHander Food
        private event EventHandler inserFood;
        public event EventHandler InserFood
        {
            add { inserFood += value; }
            remove { inserFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        #endregion
        
    }
}
