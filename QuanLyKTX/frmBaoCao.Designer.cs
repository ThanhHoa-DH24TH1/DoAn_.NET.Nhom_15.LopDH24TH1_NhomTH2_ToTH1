namespace QuanLyKTX
{
    partial class frmBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao));
            dgvBaoCao = new DataGridView();
            btnLamMoi = new Button();
            cbDenThang = new ComboBox();
            label3 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            cbTuThang = new ComboBox();
            label2 = new Label();
            panelChartPlaceholder = new Panel();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            quảnLýSinhViênToolStripMenuItem = new ToolStripMenuItem();
            quảnLýThanhToánToolStripMenuItem = new ToolStripMenuItem();
            quảnLýPhòngToolStripMenuItem = new ToolStripMenuItem();
            quảnLýHơpĐồngToolStripMenuItem = new ToolStripMenuItem();
            btnXExcel = new Button();
            cmbLoaiBieuDo = new ComboBox();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBaoCao.BackgroundColor = Color.White;
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Location = new Point(13, 332);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.RowHeadersWidth = 51;
            dgvBaoCao.Size = new Size(966, 127);
            dgvBaoCao.TabIndex = 16;
            dgvBaoCao.DataBindingComplete += dgv_DataBindingComplete;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(25, 118, 210);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(1001, 58);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(114, 33);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "🔄️Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // cbDenThang
            // 
            cbDenThang.Anchor = AnchorStyles.Top;
            cbDenThang.FormattingEnabled = true;
            cbDenThang.Location = new Point(464, 55);
            cbDenThang.Name = "cbDenThang";
            cbDenThang.Size = new Size(151, 28);
            cbDenThang.TabIndex = 14;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(33, 33, 33);
            label3.Location = new Point(373, 58);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 13;
            label3.Text = "Đến tháng :";
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
            panel1.Size = new Size(1127, 42);
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
            label1.Size = new Size(1127, 42);
            label1.TabIndex = 0;
            label1.Text = "BÁO CÁO";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbTuThang
            // 
            cbTuThang.Anchor = AnchorStyles.Top;
            cbTuThang.FormattingEnabled = true;
            cbTuThang.Location = new Point(184, 52);
            cbTuThang.Name = "cbTuThang";
            cbTuThang.Size = new Size(151, 28);
            cbTuThang.TabIndex = 21;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(33, 33, 33);
            label2.Location = new Point(103, 55);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 20;
            label2.Text = "Từ tháng :";
            // 
            // panelChartPlaceholder
            // 
            panelChartPlaceholder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelChartPlaceholder.BackColor = Color.White;
            panelChartPlaceholder.Location = new Point(12, 118);
            panelChartPlaceholder.Name = "panelChartPlaceholder";
            panelChartPlaceholder.Size = new Size(967, 208);
            panelChartPlaceholder.TabIndex = 22;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 42);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(48, 31);
            menuStrip1.TabIndex = 23;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { quảnLýSinhViênToolStripMenuItem, quảnLýThanhToánToolStripMenuItem, quảnLýPhòngToolStripMenuItem, quảnLýHơpĐồngToolStripMenuItem });
            toolStripMenuItem1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(40, 27);
            toolStripMenuItem1.Text = "☰";
            // 
            // quảnLýSinhViênToolStripMenuItem
            // 
            quảnLýSinhViênToolStripMenuItem.Name = "quảnLýSinhViênToolStripMenuItem";
            quảnLýSinhViênToolStripMenuItem.Size = new Size(260, 28);
            quảnLýSinhViênToolStripMenuItem.Text = "Quản Lý Sinh Viên";
            quảnLýSinhViênToolStripMenuItem.Click += mnQuanLySinhVien_Click;
            // 
            // quảnLýThanhToánToolStripMenuItem
            // 
            quảnLýThanhToánToolStripMenuItem.Name = "quảnLýThanhToánToolStripMenuItem";
            quảnLýThanhToánToolStripMenuItem.Size = new Size(260, 28);
            quảnLýThanhToánToolStripMenuItem.Text = "Quản Lý Thanh Toán ";
            quảnLýThanhToánToolStripMenuItem.Click += mnQLThanhToan_Click;
            // 
            // quảnLýPhòngToolStripMenuItem
            // 
            quảnLýPhòngToolStripMenuItem.Name = "quảnLýPhòngToolStripMenuItem";
            quảnLýPhòngToolStripMenuItem.Size = new Size(260, 28);
            quảnLýPhòngToolStripMenuItem.Text = "Quản Lý Phòng";
            quảnLýPhòngToolStripMenuItem.Click += mnQLPhong_Click;
            // 
            // quảnLýHơpĐồngToolStripMenuItem
            // 
            quảnLýHơpĐồngToolStripMenuItem.Name = "quảnLýHơpĐồngToolStripMenuItem";
            quảnLýHơpĐồngToolStripMenuItem.Size = new Size(260, 28);
            quảnLýHơpĐồngToolStripMenuItem.Text = "Quản Lý Hơp Đồng";
            quảnLýHơpĐồngToolStripMenuItem.Click += mnQLHopDong_Click;
            // 
            // btnXExcel
            // 
            btnXExcel.Anchor = AnchorStyles.Right;
            btnXExcel.BackColor = Color.Green;
            btnXExcel.FlatStyle = FlatStyle.Flat;
            btnXExcel.ForeColor = Color.White;
            btnXExcel.Location = new Point(1002, 128);
            btnXExcel.Name = "btnXExcel";
            btnXExcel.Size = new Size(113, 32);
            btnXExcel.TabIndex = 24;
            btnXExcel.Text = "📄Xuất Excel";
            btnXExcel.UseVisualStyleBackColor = false;
            btnXExcel.Click += btnXuatExcel_Click;
            // 
            // cmbLoaiBieuDo
            // 
            cmbLoaiBieuDo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLoaiBieuDo.FormattingEnabled = true;
            cmbLoaiBieuDo.Items.AddRange(new object[] { "Cột (Column)", "Đường (Line)", "Tròn (Pie)", "Miền (Area)" });
            cmbLoaiBieuDo.Location = new Point(797, 55);
            cmbLoaiBieuDo.Name = "cmbLoaiBieuDo";
            cmbLoaiBieuDo.Size = new Size(124, 28);
            cmbLoaiBieuDo.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(692, 58);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 26;
            label4.Text = "Loại biểu đồ :";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1001, 349);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 127);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // frmBaoCao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(244, 246, 248);
            ClientSize = new Size(1127, 488);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(cmbLoaiBieuDo);
            Controls.Add(btnXExcel);
            Controls.Add(panelChartPlaceholder);
            Controls.Add(cbTuThang);
            Controls.Add(label2);
            Controls.Add(dgvBaoCao);
            Controls.Add(btnLamMoi);
            Controls.Add(cbDenThang);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmBaoCao";
            Text = "frmBaoCao";
            Load += frmBaoCao_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            panel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvBaoCao;
        private Button btnLamMoi;
        private ComboBox cbDenThang;
        private Label label3;
        private Panel panel1;
        private Label label1;
        private ComboBox cbTuThang;
        private Label label2;
        private Panel panelChartPlaceholder;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem quảnLýSinhViênToolStripMenuItem;
        private ToolStripMenuItem quảnLýThanhToánToolStripMenuItem;
        private ToolStripMenuItem quảnLýPhòngToolStripMenuItem;
        private ToolStripMenuItem quảnLýHơpĐồngToolStripMenuItem;
        private Button btnXExcel;
        private ComboBox cmbLoaiBieuDo;
        private Label label4;
        private PictureBox pictureBox1;
    }
}