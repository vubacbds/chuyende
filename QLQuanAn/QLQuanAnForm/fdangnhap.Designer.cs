
namespace QLQuanAnForm
{
    partial class fdangnhap
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDanhNhap = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkGhiNhoMatKhau = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkGhiNhoMatKhau);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnDanhNhap);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 180);
            this.panel1.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(297, 151);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDanhNhap
            // 
            this.btnDanhNhap.Location = new System.Drawing.Point(216, 151);
            this.btnDanhNhap.Name = "btnDanhNhap";
            this.btnDanhNhap.Size = new System.Drawing.Size(75, 23);
            this.btnDanhNhap.TabIndex = 3;
            this.btnDanhNhap.Text = "Đăng nhập";
            this.btnDanhNhap.UseVisualStyleBackColor = true;
            this.btnDanhNhap.Click += new System.EventHandler(this.btnDanhNhap_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtMatKhau);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(436, 49);
            this.panel3.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(162, 10);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(141, 20);
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTenDangNhap);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(436, 49);
            this.panel2.TabIndex = 0;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(162, 10);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(141, 20);
            this.txtTenDangNhap.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập: ";
            // 
            // chkGhiNhoMatKhau
            // 
            this.chkGhiNhoMatKhau.AutoSize = true;
            this.chkGhiNhoMatKhau.Location = new System.Drawing.Point(165, 113);
            this.chkGhiNhoMatKhau.Name = "chkGhiNhoMatKhau";
            this.chkGhiNhoMatKhau.Size = new System.Drawing.Size(110, 17);
            this.chkGhiNhoMatKhau.TabIndex = 4;
            this.chkGhiNhoMatKhau.Text = "Ghi nhớ mật khẩu";
            this.chkGhiNhoMatKhau.UseVisualStyleBackColor = true;
            // 
            // fdangnhap
            // 
            this.AcceptButton = this.btnDanhNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(464, 198);
            this.Controls.Add(this.panel1);
            this.Name = "fdangnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fdangnhap_FormClosing);
            this.Load += new System.EventHandler(this.fdangnhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDanhNhap;
        private System.Windows.Forms.CheckBox chkGhiNhoMatKhau;
    }
}

