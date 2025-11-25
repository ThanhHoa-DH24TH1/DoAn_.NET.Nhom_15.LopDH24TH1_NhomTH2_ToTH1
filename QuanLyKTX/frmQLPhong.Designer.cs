namespace QuanLyKTX
{
    partial class frmQLPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLPhong));
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            dgvPhong = new DataGridView();
            btnLamMoi = new Button();
            cbToa = new ComboBox();
            label3 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            cbTang = new ComboBox();
            label2 = new Label();
            cbTrangThai = new ComboBox();
            label4 = new Label();
            btnTimKiem = new Button();
            menuStrip1 = new MenuStrip();
            chứcNăngToolStripMenuItem = new ToolStripMenuItem();
            mnQuanLyThanhToan = new ToolStripMenuItem();
            mnQuanLyBaoCao = new ToolStripMenuItem();
            mnQuanLySinhVien = new ToolStripMenuItem();
            quảnLýHợpĐồngToolStripMenuItem = new ToolStripMenuItem();
            btnXExcel = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.BackColor = Color.FromArgb(224, 224, 224);
            btnSua.ForeColor = Color.FromArgb(33, 33, 33);
            btnSua.Location = new Point(728, 256);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(111, 35);
            btnSua.TabIndex = 19;
            btnSua.Text = "🖌️Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.BackColor = Color.FromArgb(229, 57, 53);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(728, 201);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(111, 36);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "🗑️Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.BackColor = Color.FromArgb(25, 118, 210);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(728, 156);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(111, 29);
            btnThem.TabIndex = 17;
            btnThem.Text = "➕Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dgvPhong
            // 
            dgvPhong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhong.BackgroundColor = Color.White;
            dgvPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhong.Location = new Point(12, 116);
            dgvPhong.Name = "dgvPhong";
            dgvPhong.RowHeadersWidth = 51;
            dgvPhong.Size = new Size(678, 341);
            dgvPhong.TabIndex = 16;
            dgvPhong.CellContentClick += dgvPhong_CellContentClick;
            dgvPhong.DataBindingComplete += dgv_DataBindingComplete;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(25, 118, 210);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(728, 106);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(111, 31);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "🔄️Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnRefresh_Click;
            // 
            // cbToa
            // 
            cbToa.FormattingEnabled = true;
            cbToa.Location = new Point(192, 62);
            cbToa.Name = "cbToa";
            cbToa.Size = new Size(87, 28);
            cbToa.TabIndex = 14;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(146, 65);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 13;
            label3.Text = "Tòa :";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.BackColor = Color.DodgerBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(868, 47);
            panel1.TabIndex = 11;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(21, 101, 192);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(868, 47);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ PHÒNG";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbTang
            // 
            cbTang.FormattingEnabled = true;
            cbTang.Location = new Point(344, 63);
            cbTang.Name = "cbTang";
            cbTang.Size = new Size(85, 28);
            cbTang.TabIndex = 21;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(288, 67);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 20;
            label2.Text = "Tầng :";
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Location = new Point(539, 63);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(151, 28);
            cbTrangThai.TabIndex = 23;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(448, 67);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 22;
            label4.Text = "Trạng Thái :";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(25, 118, 210);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(728, 61);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(111, 29);
            btnTimKiem.TabIndex = 24;
            btnTimKiem.Text = "🔎Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { chứcNăngToolStripMenuItem });
            menuStrip1.Location = new Point(0, 47);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(48, 31);
            menuStrip1.TabIndex = 25;
            menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            chứcNăngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnQuanLyThanhToan, mnQuanLyBaoCao, mnQuanLySinhVien, quảnLýHợpĐồngToolStripMenuItem });
            chứcNăngToolStripMenuItem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            chứcNăngToolStripMenuItem.Size = new Size(40, 27);
            chứcNăngToolStripMenuItem.Text = "☰";
            // 
            // mnQuanLyThanhToan
            // 
            mnQuanLyThanhToan.Name = "mnQuanLyThanhToan";
            mnQuanLyThanhToan.Size = new Size(255, 28);
            mnQuanLyThanhToan.Text = "Quản Lý Thanh Toán";
            mnQuanLyThanhToan.Click += mnQLThanhToan_Click;
            // 
            // mnQuanLyBaoCao
            // 
            mnQuanLyBaoCao.Name = "mnQuanLyBaoCao";
            mnQuanLyBaoCao.Size = new Size(255, 28);
            mnQuanLyBaoCao.Text = "Quản Lý Báo Cáo";
            mnQuanLyBaoCao.Click += mnQLBaoCao_Click;
            // 
            // mnQuanLySinhVien
            // 
            mnQuanLySinhVien.Name = "mnQuanLySinhVien";
            mnQuanLySinhVien.Size = new Size(255, 28);
            mnQuanLySinhVien.Text = "Quản Lý Sinh Viên";
            mnQuanLySinhVien.Click += mnQuanLySinhVien_Click;
            // 
            // quảnLýHợpĐồngToolStripMenuItem
            // 
            quảnLýHợpĐồngToolStripMenuItem.Name = "quảnLýHợpĐồngToolStripMenuItem";
            quảnLýHợpĐồngToolStripMenuItem.Size = new Size(255, 28);
            quảnLýHợpĐồngToolStripMenuItem.Text = "Quản Lý Hợp Đồng";
            quảnLýHợpĐồngToolStripMenuItem.Click += mnQuanLyHopDong_Click;
            // 
            // btnXExcel
            // 
            btnXExcel.Anchor = AnchorStyles.Right;
            btnXExcel.BackColor = Color.Green;
            btnXExcel.FlatStyle = FlatStyle.Flat;
            btnXExcel.ForeColor = Color.White;
            btnXExcel.Location = new Point(728, 308);
            btnXExcel.Name = "btnXExcel";
            btnXExcel.Size = new Size(111, 32);
            btnXExcel.TabIndex = 26;
            btnXExcel.Text = "📄Xuất Excel";
            btnXExcel.UseVisualStyleBackColor = false;
            btnXExcel.Click += btnXuatExcel_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(731, 361);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 116);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // frmQLPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 248);
            ClientSize = new Size(868, 489);
            Controls.Add(pictureBox1);
            Controls.Add(btnXExcel);
            Controls.Add(btnTimKiem);
            Controls.Add(cbTrangThai);
            Controls.Add(label4);
            Controls.Add(cbTang);
            Controls.Add(label2);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(dgvPhong);
            Controls.Add(btnLamMoi);
            Controls.Add(cbToa);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmQLPhong";
            Text = "frmQLPhong";
            Load += frmQLPhong_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            panel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private DataGridView dgvPhong;
        private Button btnLamMoi;
        private ComboBox cbToa;
        private Label label3;
        private Panel panel1;
        private Label label1;
        private ComboBox cbTang;
        private Label label2;
        private ComboBox cbTrangThai;
        private Label label4;
        private Button btnTimKiem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem chứcNăngToolStripMenuItem;
        private ToolStripMenuItem mnQuanLyThanhToan;
        private ToolStripMenuItem mnQuanLyBaoCao;
        private ToolStripMenuItem mnQuanLySinhVien;
        private ToolStripMenuItem quảnLýHợpĐồngToolStripMenuItem;
        private Button btnXExcel;
        private PictureBox pictureBox1;
    }
}