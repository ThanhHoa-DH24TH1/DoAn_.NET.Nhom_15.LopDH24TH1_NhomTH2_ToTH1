namespace QuanLyKTX
{
    partial class frmQLSinhVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLSinhVien));
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            txtTimSV = new TextBox();
            label3 = new Label();
            cbKhoa = new ComboBox();
            btnLamMoi = new Button();
            dgvSinhVien = new DataGridView();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnTimKiem = new Button();
            menuStrip1 = new MenuStrip();
            chứcNăngToolStripMenuItem = new ToolStripMenuItem();
            mnQuanLyPhong = new ToolStripMenuItem();
            mnQuanLyBaoCao = new ToolStripMenuItem();
            mnQuanLyThanhToan = new ToolStripMenuItem();
            mnQLHopDong = new ToolStripMenuItem();
            btnXExcel = new Button();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(25, 118, 210);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(866, 42);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ SINH VIÊN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            panel1.Size = new Size(866, 42);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(146, 67);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 2;
            label2.Text = "Tìm kiếm : ";
            // 
            // txtTimSV
            // 
            txtTimSV.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimSV.BackColor = Color.White;
            txtTimSV.BorderStyle = BorderStyle.FixedSingle;
            txtTimSV.Location = new Point(230, 64);
            txtTimSV.Multiline = true;
            txtTimSV.Name = "txtTimSV";
            txtTimSV.Size = new Size(210, 27);
            txtTimSV.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(483, 67);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 4;
            label3.Text = "Khoa :";
            // 
            // cbKhoa
            // 
            cbKhoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbKhoa.BackColor = Color.White;
            cbKhoa.FormattingEnabled = true;
            cbKhoa.Location = new Point(539, 63);
            cbKhoa.Name = "cbKhoa";
            cbKhoa.Size = new Size(154, 28);
            cbKhoa.TabIndex = 5;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(33, 150, 243);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(729, 122);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(113, 31);
            btnLamMoi.TabIndex = 6;
            btnLamMoi.Text = "🔄️Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSinhVien.BackgroundColor = Color.White;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(12, 122);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.Size = new Size(678, 414);
            dgvSinhVien.TabIndex = 7;
            dgvSinhVien.DataBindingComplete += dgv_DataBindingComplete;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.BackColor = Color.FromArgb(33, 150, 243);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(729, 172);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(113, 29);
            btnThem.TabIndex = 8;
            btnThem.Text = "➕Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.BackColor = Color.FromArgb(229, 57, 53);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(729, 228);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(113, 35);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "🗑️Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.BackColor = Color.FromArgb(158, 158, 158);
            btnSua.ForeColor = Color.FromArgb(33, 33, 33);
            btnSua.Location = new Point(729, 290);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(113, 39);
            btnSua.TabIndex = 10;
            btnSua.Text = "🖌️Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.FromArgb(33, 150, 243);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(729, 62);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(113, 29);
            btnTimKiem.TabIndex = 11;
            btnTimKiem.Text = "🔎Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTim_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { chứcNăngToolStripMenuItem });
            menuStrip1.Location = new Point(0, 42);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(48, 31);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            chứcNăngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnQuanLyPhong, mnQuanLyBaoCao, mnQuanLyThanhToan, mnQLHopDong });
            chứcNăngToolStripMenuItem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            chứcNăngToolStripMenuItem.Size = new Size(40, 27);
            chứcNăngToolStripMenuItem.Text = "☰";
            // 
            // mnQuanLyPhong
            // 
            mnQuanLyPhong.Name = "mnQuanLyPhong";
            mnQuanLyPhong.Size = new Size(255, 28);
            mnQuanLyPhong.Text = "Quản Lý Phòng";
            mnQuanLyPhong.Click += mnQuanLyPhong_Click;
            // 
            // mnQuanLyBaoCao
            // 
            mnQuanLyBaoCao.Name = "mnQuanLyBaoCao";
            mnQuanLyBaoCao.Size = new Size(255, 28);
            mnQuanLyBaoCao.Text = "Quản Lý Báo Cáo";
            mnQuanLyBaoCao.Click += mnQLBaoCao_Click;
            // 
            // mnQuanLyThanhToan
            // 
            mnQuanLyThanhToan.Name = "mnQuanLyThanhToan";
            mnQuanLyThanhToan.Size = new Size(255, 28);
            mnQuanLyThanhToan.Text = "Quản Lý Thanh Toán";
            mnQuanLyThanhToan.Click += mnQLThanhToan_Click;
            // 
            // mnQLHopDong
            // 
            mnQLHopDong.Name = "mnQLHopDong";
            mnQLHopDong.Size = new Size(255, 28);
            mnQLHopDong.Text = "Quản Lý Hợp Đồng";
            mnQLHopDong.Click += mnQLHopDong_Click;
            // 
            // btnXExcel
            // 
            btnXExcel.BackColor = Color.Green;
            btnXExcel.FlatStyle = FlatStyle.Flat;
            btnXExcel.ForeColor = Color.White;
            btnXExcel.Location = new Point(729, 366);
            btnXExcel.Name = "btnXExcel";
            btnXExcel.Size = new Size(113, 32);
            btnXExcel.TabIndex = 25;
            btnXExcel.Text = "📄Xuất Excel";
            btnXExcel.UseVisualStyleBackColor = false;
            btnXExcel.Click += btnXuatExcel_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(729, 423);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 113);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // frmQLSinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 248);
            ClientSize = new Size(866, 548);
            Controls.Add(pictureBox1);
            Controls.Add(btnXExcel);
            Controls.Add(btnTimKiem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(dgvSinhVien);
            Controls.Add(btnLamMoi);
            Controls.Add(cbKhoa);
            Controls.Add(label3);
            Controls.Add(txtTimSV);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Name = "frmQLSinhVien";
            Text = "frmQLSinhVien";
            FormClosed += frmQLSinhVien_FormClosed;
            Load += frmQLSinhVien_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private TextBox txtTimSV;
        private Label label3;
        private ComboBox cbKhoa;
        private Button btnLamMoi;
        private DataGridView dgvSinhVien;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnTimKiem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem chứcNăngToolStripMenuItem;
        private ToolStripMenuItem mnQuanLyPhong;
        private ToolStripMenuItem mnQuanLyBaoCao;
        private ToolStripMenuItem mnQuanLyThanhToan;
        private ToolStripMenuItem mnQLHopDong;
        private Button btnXExcel;
        private PictureBox pictureBox1;
    }
}