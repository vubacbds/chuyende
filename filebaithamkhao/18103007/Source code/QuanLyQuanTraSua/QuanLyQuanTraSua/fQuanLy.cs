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
using Menu = DAL.Menu;

namespace QuanLyQuanCaPhe
{
    public partial class fQuanLy : Form
    {
        public TaiKhoan loginAccount;
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        TaiKhoan newUser;

        public fQuanLy()
        {
            InitializeComponent();
            
        }
        private void fQuanLy_Load(object sender, EventArgs e)
        {
            
            LoadTable();
            LoadCategory();
            CheckTypeAccount(loginAccount.id_CV);
            newUser = TKBLL.GetAccountByUsername(loginAccount.TenDangNhap);
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + newUser.TenTaiKhoan + ")";
        }

        #region Method
        void CheckTypeAccount(int chucvu)
        {
            if (chucvu == 1)
                quảnLýToolStripMenuItem.Enabled = true;
            else
                quảnLýToolStripMenuItem.Enabled = false;
        }
        void LoadCategory()
        {
            List<DanhMucMatHang> listCat = DanhMucMatHangBLL.Instance.GetListCategory();
            cbDanhMuc.DataSource = listCat;
            cbDanhMuc.DisplayMember = "Ten";
        }
        void LoadFoodListByCategoryID(int cat_id)
        {
            List<MatHang> food = MatHangBLL.Instance.getListFoodByCatID(cat_id);
            cbMatHang.DataSource = food;
            cbMatHang.DisplayMember = "Ten";
        }
        void LoadTable()
        {
            flpBan.Controls.Clear();
            BanAnBLL BABLL = new BanAnBLL();
            List<BanAn> dsBan = BABLL.LoadTableList();
            
            foreach (BanAn item in dsBan)
            {
                Button btn = new Button() { Width = 90, Height = 90 };
                btn.Text = item.Ten + Environment.NewLine + item.TrangThai;
                btn.Click += btn_Click;
                btn.Tag = item;

                if (item.TrangThai == "Trống")
                {
                    btn.BackColor = Color.LightGreen;
                }
                else
                {
                    btn.BackColor = Color.LightPink;
                }

                flpBan.Controls.Add(btn);
            }
        }
        void ShowBill(int id)
        {
            float Tong = 0;
            List<Menu> listBillInfo = MenuBLL.Instance.GetListMenuByTable(id);
            lsvBill.Items.Clear();
            foreach (Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenMatHang.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.Gia.ToString());
                lsvItem.SubItems.Add(item.ThanhTien.ToString());
                Tong += item.ThanhTien;

                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTongTien.Text = Tong.ToString("c",culture);
        }

        #endregion

        #region Events
        private void btn_Click(object sender, EventArgs e)
        {
            BanAn table = (sender as Button).Tag as BanAn;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(table.id);
            btnThemMon.Enabled = true;
            lbBan.Text = table.Ten;
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTaiKhoan f = new fTaiKhoan(newUser);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }

        void f_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.TenTaiKhoan + ")";
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanTriVien f = new fQuanTriVien();
            f.loginAccout = loginAccount;
            f.InserFood += f_InserFood;
            f.DeleteFood += f_DeleteFood;
            f.UpdateFood += f_UpdateFood;
            f.ShowDialog();
        }

        private void f_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbDanhMuc.SelectedItem as DanhMucMatHang).id);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as BanAn).id);
        }

        private void f_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbDanhMuc.SelectedItem as DanhMucMatHang).id);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as BanAn).id);
            LoadTable();
        }

        private void f_InserFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbDanhMuc.SelectedItem as DanhMucMatHang).id);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as BanAn).id);
        }

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cat_id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            DanhMucMatHang selected = cb.SelectedItem as DanhMucMatHang;
            cat_id = selected.id;
            LoadFoodListByCategoryID(cat_id);
        }
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            BanAn table = lsvBill.Tag as BanAn;

            int idBill = HoaDonBLL.Instance.getUncheckBillIDByTableID(table.id);
            int idFood = (cbMatHang.SelectedItem as MatHang).id;
            int sl = (int)nmSoLuongMon.Value;

            // Bill đã thanh toán hoặc bàn chưa có bill
            if (idBill == -1)
            {
                HoaDonBLL.Instance.InsertBill(table.id);
                idBill = HoaDonBLL.Instance.GetMaxIdBill();
                ChiTietHoaDonBLL.Instance.InsertBillInfo(idBill, idFood, sl);
            }
            // Bill đã có bàn và chưa thanh toán
            else
            {
                ChiTietHoaDonBLL.Instance.InsertBillInfo(idBill, idFood, sl);
            }
            ShowBill(table.id);
            LoadTable();
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            BanAn table = lsvBill.Tag as BanAn;
            int idBill = HoaDonBLL.Instance.getUncheckBillIDByTableID(table.id);
            float TongTien = (float)Convert.ToDouble(txtTongTien.Text.Split(',')[0].Replace(".", ""));
            if (idBill != -1)
            {
                if(MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho " + table.Ten,"Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    HoaDonBLL.Instance.CheckOut(idBill,TongTien);
                    ShowBill(table.id);
                    LoadTable();
                }
            }
        }

        #endregion
                
    }
}
