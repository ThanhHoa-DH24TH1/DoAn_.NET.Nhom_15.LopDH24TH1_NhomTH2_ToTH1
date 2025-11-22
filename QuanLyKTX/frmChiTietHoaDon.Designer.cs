namespace QuanLyKTX
{
    partial class frmChiTietHoaDon
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtPhiDichVu = new TextBox();
            txtDGNuoc = new TextBox();
            txtTienMang = new TextBox();
            txtDGDien = new TextBox();
            cbThangNam = new ComboBox();
            btnHuy = new Button();
            btnTao = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 122);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 0;
            label1.Text = "Tháng/năm (*) :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 235);
            label2.Name = "label2";
            label2.Size = new Size(156, 20);
            label2.TabIndex = 1;
            label2.Text = "Đơn giá nước (đ/m3) :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(416, 122);
            label3.Name = "label3";
            label3.Size = new Size(153, 20);
            label3.TabIndex = 3;
            label3.Text = "Tiền mạng (đ/tháng) :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 176);
            label4.Name = "label4";
            label4.Size = new Size(160, 20);
            label4.TabIndex = 2;
            label4.Text = "Đơn giá điện (đ/kWh) :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(415, 176);
            label5.Name = "label5";
            label5.Size = new Size(154, 20);
            label5.TabIndex = 5;
            label5.Text = "Phí dịch vụ (đ/tháng) :";
            // 
            // txtPhiDichVu
            // 
            txtPhiDichVu.Location = new Point(610, 176);
            txtPhiDichVu.Name = "txtPhiDichVu";
            txtPhiDichVu.Size = new Size(151, 27);
            txtPhiDichVu.TabIndex = 6;
            // 
            // txtDGNuoc
            // 
            txtDGNuoc.Location = new Point(205, 232);
            txtDGNuoc.Name = "txtDGNuoc";
            txtDGNuoc.Size = new Size(151, 27);
            txtDGNuoc.TabIndex = 7;
            // 
            // txtTienMang
            // 
            txtTienMang.Location = new Point(610, 118);
            txtTienMang.Name = "txtTienMang";
            txtTienMang.Size = new Size(151, 27);
            txtTienMang.TabIndex = 9;
            // 
            // txtDGDien
            // 
            txtDGDien.Location = new Point(205, 173);
            txtDGDien.Name = "txtDGDien";
            txtDGDien.Size = new Size(151, 27);
            txtDGDien.TabIndex = 8;
            // 
            // cbThangNam
            // 
            cbThangNam.FormattingEnabled = true;
            cbThangNam.Location = new Point(205, 118);
            cbThangNam.Name = "cbThangNam";
            cbThangNam.Size = new Size(151, 28);
            cbThangNam.TabIndex = 10;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(229, 57, 53);
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(436, 318);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(94, 29);
            btnHuy.TabIndex = 12;
            btnHuy.Text = "❌Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnTao
            // 
            btnTao.BackColor = Color.FromArgb(25, 118, 210);
            btnTao.FlatStyle = FlatStyle.Flat;
            btnTao.ForeColor = Color.White;
            btnTao.Location = new Point(258, 318);
            btnTao.Name = "btnTao";
            btnTao.Size = new Size(94, 29);
            btnTao.TabIndex = 11;
            btnTao.Text = "➕Tạo";
            btnTao.UseVisualStyleBackColor = false;
            btnTao.Click += btnTao_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(25, 118, 210);
            label6.Location = new Point(305, 19);
            label6.Name = "label6";
            label6.Size = new Size(202, 41);
            label6.TabIndex = 13;
            label6.Text = "Tạo Hóa Đơn";
            // 
            // frmChiTietHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 248);
            ClientSize = new Size(800, 379);
            Controls.Add(label6);
            Controls.Add(btnHuy);
            Controls.Add(btnTao);
            Controls.Add(cbThangNam);
            Controls.Add(txtTienMang);
            Controls.Add(txtDGDien);
            Controls.Add(txtDGNuoc);
            Controls.Add(txtPhiDichVu);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmChiTietHoaDon";
            Text = "frmChiTietHoaDon";
            Load += frmChiTietHoaDon_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtPhiDichVu;
        private TextBox txtDGNuoc;
        private TextBox txtTienMang;
        private TextBox txtDGDien;
        private ComboBox cbThangNam;
        private Button btnHuy;
        private Button btnTao;
        private Label label6;
    }
}