namespace QuanLyKTX
{
    partial class frmQLHopDong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLHopDong));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTimHD = new TextBox();
            cmbTrangThai = new ComboBox();
            btnTim = new Button();
            btnLamMoi = new Button();
            btnTaoHD = new Button();
            btnThanhLy = new Button();
            btnGiaHan = new Button();
            dgvHopDong = new DataGridView();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            quảnLýSinhViênToolStripMenuItem = new ToolStripMenuItem();
            quảnLýPhòngToolStripMenuItem = new ToolStripMenuItem();
            quảnLýToolStripMenuItem = new ToolStripMenuItem();
            quảnLýThanhToánToolStripMenuItem = new ToolStripMenuItem();
            btnXExcel = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(21, 101, 192);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(837, 42);
            label1.TabIndex = 1;
            label1.Text = "QUẢN LÝ HỢP ĐỒNG";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(33, 33, 33);
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 2;
            label2.Text = "Tìm kiếm :";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(33, 33, 33);
            label3.Location = new Point(309, 81);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 3;
            label3.Text = "Trạng thái :";
            // 
            // txtTimHD
            // 
            txtTimHD.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimHD.Location = new Point(95, 78);
            txtTimHD.Name = "txtTimHD";
            txtTimHD.Size = new Size(187, 27);
            txtTimHD.TabIndex = 4;
            // 
            // cmbTrangThai
            // 
            cmbTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbTrangThai.FormattingEnabled = true;
            cmbTrangThai.Location = new Point(397, 77);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new Size(151, 28);
            cmbTrangThai.TabIndex = 5;
            // 
            // btnTim
            // 
            btnTim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTim.BackColor = Color.FromArgb(224, 224, 224);
            btnTim.ForeColor = Color.FromArgb(33, 33, 33);
            btnTim.Location = new Point(588, 76);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(94, 29);
            btnTim.TabIndex = 6;
            btnTim.Text = "🔎Tìm ";
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Click += btnTim_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(224, 224, 224);
            btnLamMoi.ForeColor = Color.FromArgb(33, 33, 33);
            btnLamMoi.Location = new Point(706, 76);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(119, 29);
            btnLamMoi.TabIndex = 7;
            btnLamMoi.Text = "🔄️Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnTaoHD
            // 
            btnTaoHD.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTaoHD.BackColor = Color.FromArgb(25, 118, 210);
            btnTaoHD.FlatStyle = FlatStyle.Flat;
            btnTaoHD.ForeColor = Color.White;
            btnTaoHD.Location = new Point(706, 151);
            btnTaoHD.Name = "btnTaoHD";
            btnTaoHD.Size = new Size(119, 33);
            btnTaoHD.TabIndex = 8;
            btnTaoHD.Text = "➕Tạo HD";
            btnTaoHD.UseVisualStyleBackColor = false;
            btnTaoHD.Click += btnTaoHD_Click;
            // 
            // btnThanhLy
            // 
            btnThanhLy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThanhLy.BackColor = Color.FromArgb(25, 118, 210);
            btnThanhLy.FlatStyle = FlatStyle.Flat;
            btnThanhLy.ForeColor = Color.White;
            btnThanhLy.Location = new Point(706, 209);
            btnThanhLy.Name = "btnThanhLy";
            btnThanhLy.Size = new Size(119, 34);
            btnThanhLy.TabIndex = 9;
            btnThanhLy.Text = "✅Thanh Lý";
            btnThanhLy.UseVisualStyleBackColor = false;
            btnThanhLy.Click += btnThanhLy_Click;
            // 
            // btnGiaHan
            // 
            btnGiaHan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGiaHan.BackColor = Color.FromArgb(25, 118, 210);
            btnGiaHan.FlatStyle = FlatStyle.Flat;
            btnGiaHan.ForeColor = Color.White;
            btnGiaHan.Location = new Point(706, 272);
            btnGiaHan.Name = "btnGiaHan";
            btnGiaHan.Size = new Size(119, 35);
            btnGiaHan.TabIndex = 10;
            btnGiaHan.Text = "✏️Gia Hạn";
            btnGiaHan.UseVisualStyleBackColor = false;
            btnGiaHan.Click += btnGiaHan_Click;
            // 
            // dgvHopDong
            // 
            dgvHopDong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHopDong.BackgroundColor = Color.White;
            dgvHopDong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHopDong.Location = new Point(12, 131);
            dgvHopDong.Name = "dgvHopDong";
            dgvHopDong.RowHeadersWidth = 51;
            dgvHopDong.Size = new Size(670, 368);
            dgvHopDong.TabIndex = 11;
            dgvHopDong.DataBindingComplete += dgv_DataBindingComplete;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 42);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(48, 31);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.BackColor = Color.Gainsboro;
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { quảnLýSinhViênToolStripMenuItem, quảnLýPhòngToolStripMenuItem, quảnLýToolStripMenuItem, quảnLýThanhToánToolStripMenuItem });
            toolStripMenuItem1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(40, 27);
            toolStripMenuItem1.Text = "☰";
            // 
            // quảnLýSinhViênToolStripMenuItem
            // 
            quảnLýSinhViênToolStripMenuItem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            quảnLýSinhViênToolStripMenuItem.Name = "quảnLýSinhViênToolStripMenuItem";
            quảnLýSinhViênToolStripMenuItem.Size = new Size(255, 28);
            quảnLýSinhViênToolStripMenuItem.Text = "Quản Lý Sinh Viên";
            quảnLýSinhViênToolStripMenuItem.Click += mnQuanLySinhVien_Click;
            // 
            // quảnLýPhòngToolStripMenuItem
            // 
            quảnLýPhòngToolStripMenuItem.Name = "quảnLýPhòngToolStripMenuItem";
            quảnLýPhòngToolStripMenuItem.Size = new Size(255, 28);
            quảnLýPhòngToolStripMenuItem.Text = "Quản Lý Phòng";
            quảnLýPhòngToolStripMenuItem.Click += mnQLPhong_Click;
            // 
            // quảnLýToolStripMenuItem
            // 
            quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            quảnLýToolStripMenuItem.Size = new Size(255, 28);
            quảnLýToolStripMenuItem.Text = "Quản Lý Báo Cáo";
            quảnLýToolStripMenuItem.Click += mnQLBaoCao_Click;
            // 
            // quảnLýThanhToánToolStripMenuItem
            // 
            quảnLýThanhToánToolStripMenuItem.Name = "quảnLýThanhToánToolStripMenuItem";
            quảnLýThanhToánToolStripMenuItem.Size = new Size(255, 28);
            quảnLýThanhToánToolStripMenuItem.Text = "Quản Lý Thanh Toán";
            quảnLýThanhToánToolStripMenuItem.Click += mnQLThanhToan_Click;
            // 
            // btnXExcel
            // 
            btnXExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnXExcel.BackColor = Color.Green;
            btnXExcel.FlatStyle = FlatStyle.Flat;
            btnXExcel.ForeColor = Color.White;
            btnXExcel.Location = new Point(706, 337);
            btnXExcel.Name = "btnXExcel";
            btnXExcel.Size = new Size(119, 37);
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
            pictureBox1.Location = new Point(706, 398);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 101);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // frmQLHopDong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 248);
            ClientSize = new Size(837, 511);
            Controls.Add(pictureBox1);
            Controls.Add(btnXExcel);
            Controls.Add(dgvHopDong);
            Controls.Add(btnGiaHan);
            Controls.Add(btnThanhLy);
            Controls.Add(btnTaoHD);
            Controls.Add(btnLamMoi);
            Controls.Add(btnTim);
            Controls.Add(cmbTrangThai);
            Controls.Add(txtTimHD);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            ForeColor = Color.FromArgb(33, 33, 33);
            MainMenuStrip = menuStrip1;
            Name = "frmQLHopDong";
            Text = "frmQLHopDong";
            Load += frmQLHopDong_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTimHD;
        private ComboBox cmbTrangThai;
        private Button btnTim;
        private Button btnLamMoi;
        private Button btnTaoHD;
        private Button btnThanhLy;
        private Button btnGiaHan;
        private DataGridView dgvHopDong;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem quảnLýSinhViênToolStripMenuItem;
        private ToolStripMenuItem quảnLýPhòngToolStripMenuItem;
        private ToolStripMenuItem quảnLýToolStripMenuItem;
        private ToolStripMenuItem quảnLýThanhToánToolStripMenuItem;
        private Button btnXExcel;
        private PictureBox pictureBox1;
    }
}