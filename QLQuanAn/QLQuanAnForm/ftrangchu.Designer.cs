﻿
namespace QLQuanAnForm
{
    partial class ftrangchu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvHoaDonChiTiet = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numGiamGia = new System.Windows.Forms.NumericUpDown();
            this.btnGiamGia = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnTenBan = new System.Windows.Forms.Button();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThem = new System.Windows.Forms.Button();
            this.cbbMonAn = new System.Windows.Forms.ComboBox();
            this.cbbDanhMuc = new System.Windows.Forms.ComboBox();
            this.flpBanAn = new System.Windows.Forms.FlowLayoutPanel();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonChiTiet)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(858, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem1,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinCáNhânToolStripMenuItem.Image = global::QLQuanAnForm.Properties.Resources.user;
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Trang cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thôngTinCáNhânToolStripMenuItem1
            // 
            this.thôngTinCáNhânToolStripMenuItem1.Name = "thôngTinCáNhânToolStripMenuItem1";
            this.thôngTinCáNhânToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.thôngTinCáNhânToolStripMenuItem1.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem1.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem1_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.adminToolStripMenuItem.Text = "Trang quản lý";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvHoaDonChiTiet);
            this.panel2.Location = new System.Drawing.Point(450, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 209);
            this.panel2.TabIndex = 3;
            // 
            // dgvHoaDonChiTiet
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDonChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDonChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonChiTiet.Location = new System.Drawing.Point(4, 4);
            this.dgvHoaDonChiTiet.Name = "dgvHoaDonChiTiet";
            this.dgvHoaDonChiTiet.Size = new System.Drawing.Size(389, 202);
            this.dgvHoaDonChiTiet.TabIndex = 0;
            this.dgvHoaDonChiTiet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDonChiTiet_CellDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTongTien);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.numGiamGia);
            this.panel3.Controls.Add(this.btnGiamGia);
            this.panel3.Controls.Add(this.btnThanhToan);
            this.panel3.Location = new System.Drawing.Point(450, 287);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(393, 51);
            this.panel3.TabIndex = 4;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(197, 22);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.lblTongTien.Size = new System.Drawing.Size(108, 23);
            this.lblTongTien.TabIndex = 10;
            this.lblTongTien.Text = "Tổng tiền: 0 vnđ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(18, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "%";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numGiamGia
            // 
            this.numGiamGia.Location = new System.Drawing.Point(22, 6);
            this.numGiamGia.Name = "numGiamGia";
            this.numGiamGia.Size = new System.Drawing.Size(65, 20);
            this.numGiamGia.TabIndex = 4;
            this.numGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGiamGia
            // 
            this.btnGiamGia.Location = new System.Drawing.Point(5, 24);
            this.btnGiamGia.Name = "btnGiamGia";
            this.btnGiamGia.Size = new System.Drawing.Size(82, 21);
            this.btnGiamGia.TabIndex = 4;
            this.btnGiamGia.Text = "Giảm giá";
            this.btnGiamGia.UseVisualStyleBackColor = true;
            this.btnGiamGia.Click += new System.EventHandler(this.btnGiamGia_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(308, 3);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(82, 44);
            this.btnThanhToan.TabIndex = 3;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnTenBan);
            this.panel4.Controls.Add(this.numSoLuong);
            this.panel4.Controls.Add(this.btnThem);
            this.panel4.Controls.Add(this.cbbMonAn);
            this.panel4.Controls.Add(this.cbbDanhMuc);
            this.panel4.Location = new System.Drawing.Point(450, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(393, 51);
            this.panel4.TabIndex = 5;
            // 
            // btnTenBan
            // 
            this.btnTenBan.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnTenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTenBan.Location = new System.Drawing.Point(4, 3);
            this.btnTenBan.Name = "btnTenBan";
            this.btnTenBan.Size = new System.Drawing.Size(57, 45);
            this.btnTenBan.TabIndex = 4;
            this.btnTenBan.Text = "Tên bàn";
            this.btnTenBan.UseVisualStyleBackColor = false;
            this.btnTenBan.Click += new System.EventHandler(this.btnTenBan_Click);
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(244, 14);
            this.numSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(58, 20);
            this.numSoLuong.TabIndex = 3;
            this.numSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(308, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(82, 44);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cbbMonAn
            // 
            this.cbbMonAn.FormattingEnabled = true;
            this.cbbMonAn.Location = new System.Drawing.Point(67, 25);
            this.cbbMonAn.Name = "cbbMonAn";
            this.cbbMonAn.Size = new System.Drawing.Size(171, 21);
            this.cbbMonAn.TabIndex = 1;
            // 
            // cbbDanhMuc
            // 
            this.cbbDanhMuc.FormattingEnabled = true;
            this.cbbDanhMuc.Location = new System.Drawing.Point(67, 3);
            this.cbbDanhMuc.Name = "cbbDanhMuc";
            this.cbbDanhMuc.Size = new System.Drawing.Size(171, 21);
            this.cbbDanhMuc.TabIndex = 0;
            this.cbbDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cbbDanhMuc_SelectedIndexChanged);
            // 
            // flpBanAn
            // 
            this.flpBanAn.AutoScroll = true;
            this.flpBanAn.Location = new System.Drawing.Point(12, 27);
            this.flpBanAn.Name = "flpBanAn";
            this.flpBanAn.Size = new System.Drawing.Size(436, 311);
            this.flpBanAn.TabIndex = 6;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(755, 11);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(0, 13);
            this.lblThongBao.TabIndex = 7;
            // 
            // ftrangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 358);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.flpBanAn);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ftrangchu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý quán ăn";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonChiTiet)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cbbMonAn;
        private System.Windows.Forms.ComboBox cbbDanhMuc;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.FlowLayoutPanel flpBanAn;
        private System.Windows.Forms.NumericUpDown numGiamGia;
        private System.Windows.Forms.Button btnGiamGia;
        private System.Windows.Forms.DataGridView dgvHoaDonChiTiet;
        private System.Windows.Forms.Button btnTenBan;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblTongTien;
    }
}