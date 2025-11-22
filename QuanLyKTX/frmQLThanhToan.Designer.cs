namespace QuanLyKTX
{
    partial class frmQLThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLThanhToan));
            btnSua = new Button();
            btnThem = new Button();
            dgvThanhToan = new DataGridView();
            btnLamMoi = new Button();
            cbThang = new ComboBox();
            label3 = new Label();
            txtTim = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            chứcNăngToolStripMenuItem = new ToolStripMenuItem();
            mnQuanLySinhVien = new ToolStripMenuItem();
            mnQuanLyPhong = new ToolStripMenuItem();
            mnQuanLyBaoCao = new ToolStripMenuItem();
            quảnLýHợpĐồngToolStripMenuItem = new ToolStripMenuItem();
            cbTrangThai = new ComboBox();
            label4 = new Label();
            btnTimKiem = new Button();
            btnXExcel = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvThanhToan).BeginInit();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.BackColor = Color.FromArgb(25, 118, 210);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(879, 275);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(121, 39);
            btnSua.TabIndex = 20;
            btnSua.Text = "✅Thanh Toán";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnThanhToan_Click;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.BackColor = Color.FromArgb(224, 224, 224);
            btnThem.ForeColor = Color.FromArgb(33, 33, 33);
            btnThem.Location = new Point(879, 225);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(121, 29);
            btnThem.TabIndex = 18;
            btnThem.Text = "➕Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dgvThanhToan
            // 
            dgvThanhToan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvThanhToan.BackgroundColor = Color.White;
            dgvThanhToan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThanhToan.Location = new Point(22, 159);
            dgvThanhToan.Name = "dgvThanhToan";
            dgvThanhToan.RowHeadersWidth = 51;
            dgvThanhToan.Size = new Size(821, 372);
            dgvThanhToan.TabIndex = 17;
            dgvThanhToan.DataBindingComplete += dgv_DataBindingComplete;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(224, 224, 224);
            btnLamMoi.ForeColor = Color.FromArgb(33, 33, 33);
            btnLamMoi.Location = new Point(879, 171);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(121, 31);
            btnLamMoi.TabIndex = 16;
            btnLamMoi.Text = "🔄️Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // cbThang
            // 
            cbThang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbThang.FormattingEnabled = true;
            cbThang.Location = new Point(328, 111);
            cbThang.Name = "cbThang";
            cbThang.Size = new Size(151, 28);
            cbThang.TabIndex = 15;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(33, 33, 33);
            label3.Location = new Point(256, 115);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 14;
            label3.Text = "Tháng :";
            // 
            // txtTim
            // 
            txtTim.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTim.Location = new Point(132, 112);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(102, 27);
            txtTim.TabIndex = 13;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(33, 33, 33);
            label2.Location = new Point(45, 117);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 12;
            label2.Text = "Tìm kiếm : ";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1028, 73);
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
            label1.Size = new Size(1028, 42);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ THANH TOÁN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { chứcNăngToolStripMenuItem });
            menuStrip1.Location = new Point(0, 42);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(48, 31);
            menuStrip1.TabIndex = 24;
            menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            chứcNăngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnQuanLySinhVien, mnQuanLyPhong, mnQuanLyBaoCao, quảnLýHợpĐồngToolStripMenuItem });
            chứcNăngToolStripMenuItem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            chứcNăngToolStripMenuItem.Size = new Size(40, 27);
            chứcNăngToolStripMenuItem.Text = "☰";
            // 
            // mnQuanLySinhVien
            // 
            mnQuanLySinhVien.Name = "mnQuanLySinhVien";
            mnQuanLySinhVien.Size = new Size(248, 28);
            mnQuanLySinhVien.Text = "Quản Lý Sinh Viên";
            mnQuanLySinhVien.Click += mnQuanLySinhVien_Click;
            // 
            // mnQuanLyPhong
            // 
            mnQuanLyPhong.Name = "mnQuanLyPhong";
            mnQuanLyPhong.Size = new Size(248, 28);
            mnQuanLyPhong.Text = "Quản Lý Phòng";
            mnQuanLyPhong.Click += mnQLPhong_Click;
            // 
            // mnQuanLyBaoCao
            // 
            mnQuanLyBaoCao.Name = "mnQuanLyBaoCao";
            mnQuanLyBaoCao.Size = new Size(248, 28);
            mnQuanLyBaoCao.Text = "Quản Lý Báo Cáo";
            mnQuanLyBaoCao.Click += mnQLBaoCao_Click;
            // 
            // quảnLýHợpĐồngToolStripMenuItem
            // 
            quảnLýHợpĐồngToolStripMenuItem.Name = "quảnLýHợpĐồngToolStripMenuItem";
            quảnLýHợpĐồngToolStripMenuItem.Size = new Size(248, 28);
            quảnLýHợpĐồngToolStripMenuItem.Text = "Quản Lý Hợp Đồng";
            quảnLýHợpĐồngToolStripMenuItem.Click += mnQLHopDong_Click;
            // 
            // cbTrangThai
            // 
            cbTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Location = new Point(587, 113);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(151, 28);
            cbTrangThai.TabIndex = 22;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(33, 33, 33);
            label4.Location = new Point(496, 116);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 21;
            label4.Text = "Trạng Thái :";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.FromArgb(224, 224, 224);
            btnTimKiem.ForeColor = Color.FromArgb(33, 33, 33);
            btnTimKiem.Location = new Point(879, 117);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(121, 29);
            btnTimKiem.TabIndex = 23;
            btnTimKiem.Text = "🔎Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTim_Click;
            // 
            // btnXExcel
            // 
            btnXExcel.BackColor = Color.Green;
            btnXExcel.FlatStyle = FlatStyle.Flat;
            btnXExcel.ForeColor = Color.White;
            btnXExcel.Location = new Point(879, 338);
            btnXExcel.Name = "btnXExcel";
            btnXExcel.Size = new Size(121, 36);
            btnXExcel.TabIndex = 25;
            btnXExcel.Text = "📄Xuất Excel";
            btnXExcel.UseVisualStyleBackColor = false;
            btnXExcel.Click += btnXuatExcel_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(879, 444);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 117);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // frmQLThanhToan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 248);
            ClientSize = new Size(1028, 573);
            Controls.Add(pictureBox1);
            Controls.Add(btnXExcel);
            Controls.Add(btnTimKiem);
            Controls.Add(cbTrangThai);
            Controls.Add(label4);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgvThanhToan);
            Controls.Add(btnLamMoi);
            Controls.Add(cbThang);
            Controls.Add(label3);
            Controls.Add(txtTim);
            Controls.Add(label2);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Name = "frmQLThanhToan";
            Load += frmQLThanhToan_Load;
            ((System.ComponentModel.ISupportInitialize)dgvThanhToan).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSua;
        private Button btnThem;
        private DataGridView dgvThanhToan;
        private Button btnLamMoi;
        private ComboBox cbThang;
        private Label label3;
        private TextBox txtTim;
        private Label label2;
        private Panel panel1;
        private Label label1;
        private ComboBox cbTrangThai;
        private Label label4;
        private Button btnTimKiem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem chứcNăngToolStripMenuItem;
        private ToolStripMenuItem mnQuanLySinhVien;
        private ToolStripMenuItem mnQuanLyPhong;
        private ToolStripMenuItem mnQuanLyBaoCao;
        private ToolStripMenuItem quảnLýHợpĐồngToolStripMenuItem;
        private Button btnXExcel;
        private PictureBox pictureBox1;
    }
}