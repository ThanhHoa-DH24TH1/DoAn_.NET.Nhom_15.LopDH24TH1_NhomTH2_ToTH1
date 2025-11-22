namespace QuanLyKTX
{
    partial class frmDashboard
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            btnRefesh = new Button();
            label2 = new Label();
            btnQLBaoCao = new Button();
            btnQLHopDong = new Button();
            btnQLThanhToan = new Button();
            btnQLPhong = new Button();
            btnQLSinhVien = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblTime = new ToolStripStatusLabel();
            timerClock = new System.Windows.Forms.Timer(components);
            panel3 = new Panel();
            lblSinhVien = new Label();
            label3 = new Label();
            panel4 = new Panel();
            lblPhongTrong = new Label();
            label4 = new Label();
            panel5 = new Panel();
            lblDoanhThuThang = new Label();
            label6 = new Label();
            panel6 = new Panel();
            lblChuaThanhToan = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 101, 192);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1198, 95);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(477, 18);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(231, 46);
            label1.TabIndex = 0;
            label1.Text = "DASHBOARD";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(13, 71, 161);
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(btnRefesh);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnQLBaoCao);
            panel2.Controls.Add(btnQLHopDong);
            panel2.Controls.Add(btnQLThanhToan);
            panel2.Controls.Add(btnQLPhong);
            panel2.Controls.Add(btnQLSinhVien);
            panel2.Cursor = Cursors.Hand;
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 95);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(241, 598);
            panel2.TabIndex = 1;
            // 
            // btnRefesh
            // 
            btnRefesh.Anchor = AnchorStyles.Bottom;
            btnRefesh.BackColor = Color.Transparent;
            btnRefesh.FlatStyle = FlatStyle.Flat;
            btnRefesh.ForeColor = Color.FromArgb(236, 239, 241);
            btnRefesh.Location = new Point(73, 498);
            btnRefesh.Name = "btnRefesh";
            btnRefesh.Size = new Size(94, 55);
            btnRefesh.TabIndex = 6;
            btnRefesh.Text = "🔄️";
            btnRefesh.UseVisualStyleBackColor = false;
            btnRefesh.Click += btnRefesh_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(75, 4);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 28);
            label2.TabIndex = 5;
            label2.Text = "MENU";
            // 
            // btnQLBaoCao
            // 
            btnQLBaoCao.Anchor = AnchorStyles.Left;
            btnQLBaoCao.BackColor = Color.Transparent;
            btnQLBaoCao.FlatStyle = FlatStyle.Flat;
            btnQLBaoCao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnQLBaoCao.ForeColor = Color.White;
            btnQLBaoCao.Location = new Point(0, 386);
            btnQLBaoCao.Margin = new Padding(4);
            btnQLBaoCao.Name = "btnQLBaoCao";
            btnQLBaoCao.Size = new Size(241, 41);
            btnQLBaoCao.TabIndex = 4;
            btnQLBaoCao.Text = "Quản Lý Báo Cáo";
            btnQLBaoCao.UseVisualStyleBackColor = false;
            btnQLBaoCao.Click += btnQLBaoCao_Click;
            // 
            // btnQLHopDong
            // 
            btnQLHopDong.Anchor = AnchorStyles.Left;
            btnQLHopDong.BackColor = Color.Transparent;
            btnQLHopDong.FlatStyle = FlatStyle.Flat;
            btnQLHopDong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnQLHopDong.ForeColor = Color.White;
            btnQLHopDong.Location = new Point(0, 310);
            btnQLHopDong.Margin = new Padding(4);
            btnQLHopDong.Name = "btnQLHopDong";
            btnQLHopDong.Size = new Size(241, 41);
            btnQLHopDong.TabIndex = 3;
            btnQLHopDong.Text = "Quản Lý Hợp Đồng";
            btnQLHopDong.UseVisualStyleBackColor = false;
            btnQLHopDong.Click += btnQLHopDong_Click;
            // 
            // btnQLThanhToan
            // 
            btnQLThanhToan.Anchor = AnchorStyles.Left;
            btnQLThanhToan.BackColor = Color.Transparent;
            btnQLThanhToan.FlatStyle = FlatStyle.Flat;
            btnQLThanhToan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnQLThanhToan.ForeColor = Color.White;
            btnQLThanhToan.Location = new Point(0, 232);
            btnQLThanhToan.Margin = new Padding(4);
            btnQLThanhToan.Name = "btnQLThanhToan";
            btnQLThanhToan.Size = new Size(241, 41);
            btnQLThanhToan.TabIndex = 2;
            btnQLThanhToan.Text = "Quản Lý Thanh Toán";
            btnQLThanhToan.UseVisualStyleBackColor = false;
            btnQLThanhToan.Click += btnQLThanhToan_Click;
            // 
            // btnQLPhong
            // 
            btnQLPhong.Anchor = AnchorStyles.Left;
            btnQLPhong.BackColor = Color.Transparent;
            btnQLPhong.FlatStyle = FlatStyle.Flat;
            btnQLPhong.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQLPhong.ForeColor = Color.White;
            btnQLPhong.Location = new Point(0, 163);
            btnQLPhong.Margin = new Padding(4);
            btnQLPhong.Name = "btnQLPhong";
            btnQLPhong.Size = new Size(241, 41);
            btnQLPhong.TabIndex = 1;
            btnQLPhong.Text = "Quản Lý Phòng";
            btnQLPhong.UseVisualStyleBackColor = false;
            btnQLPhong.Click += btnQLPhong_Click;
            // 
            // btnQLSinhVien
            // 
            btnQLSinhVien.Anchor = AnchorStyles.Left;
            btnQLSinhVien.BackColor = Color.Transparent;
            btnQLSinhVien.FlatStyle = FlatStyle.Flat;
            btnQLSinhVien.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQLSinhVien.ForeColor = Color.White;
            btnQLSinhVien.Location = new Point(0, 95);
            btnQLSinhVien.Margin = new Padding(4);
            btnQLSinhVien.Name = "btnQLSinhVien";
            btnQLSinhVien.Size = new Size(241, 41);
            btnQLSinhVien.TabIndex = 0;
            btnQLSinhVien.Text = "Quản Lý Sinh Viên";
            btnQLSinhVien.UseVisualStyleBackColor = false;
            btnQLSinhVien.Click += btnQLSinhVien_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, lblTime });
            statusStrip1.Location = new Point(241, 667);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 19, 0);
            statusStrip1.Size = new Size(957, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(786, 20);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.Text = "⌚";
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTime
            // 
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(151, 20);
            lblTime.Text = "toolStripStatusLabel1";
            // 
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Interval = 1000;
            timerClock.Tick += timerClock_Tick;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(30, 136, 229);
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(lblSinhVien);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(364, 169);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(246, 139);
            panel3.TabIndex = 3;
            // 
            // lblSinhVien
            // 
            lblSinhVien.Dock = DockStyle.Fill;
            lblSinhVien.FlatStyle = FlatStyle.Flat;
            lblSinhVien.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblSinhVien.Location = new Point(0, 28);
            lblSinhVien.Margin = new Padding(4, 0, 4, 0);
            lblSinhVien.Name = "lblSinhVien";
            lblSinhVien.Size = new Size(242, 107);
            lblSinhVien.TabIndex = 1;
            lblSinhVien.Text = "aaaaaaaaaaaaaaaaaaaaaa";
            lblSinhVien.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(242, 28);
            label3.TabIndex = 0;
            label3.Text = "Sinh Viên";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(67, 160, 71);
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(lblPhongTrong);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(762, 169);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(246, 139);
            panel4.TabIndex = 4;
            // 
            // lblPhongTrong
            // 
            lblPhongTrong.Dock = DockStyle.Fill;
            lblPhongTrong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPhongTrong.Location = new Point(0, 28);
            lblPhongTrong.Margin = new Padding(4, 0, 4, 0);
            lblPhongTrong.Name = "lblPhongTrong";
            lblPhongTrong.Size = new Size(242, 107);
            lblPhongTrong.TabIndex = 8;
            lblPhongTrong.Text = "aaaaaaaaaaaaaaaaaaaaaaa";
            lblPhongTrong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(242, 28);
            label4.TabIndex = 7;
            label4.Text = "Phòng Trống";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(251, 192, 45);
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.Controls.Add(lblDoanhThuThang);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(762, 371);
            panel5.Margin = new Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new Size(246, 139);
            panel5.TabIndex = 6;
            // 
            // lblDoanhThuThang
            // 
            lblDoanhThuThang.Dock = DockStyle.Fill;
            lblDoanhThuThang.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblDoanhThuThang.Location = new Point(0, 28);
            lblDoanhThuThang.Margin = new Padding(4, 0, 4, 0);
            lblDoanhThuThang.Name = "lblDoanhThuThang";
            lblDoanhThuThang.Size = new Size(242, 107);
            lblDoanhThuThang.TabIndex = 8;
            lblDoanhThuThang.Text = "aaaaaaaaaaaaaaaaaaaaaaa";
            lblDoanhThuThang.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, 0);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(242, 28);
            label6.TabIndex = 7;
            label6.Text = "Doanh Thu Tháng";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(229, 57, 53);
            panel6.BorderStyle = BorderStyle.Fixed3D;
            panel6.Controls.Add(lblChuaThanhToan);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(364, 371);
            panel6.Margin = new Padding(4);
            panel6.Name = "panel6";
            panel6.Size = new Size(246, 139);
            panel6.TabIndex = 5;
            // 
            // lblChuaThanhToan
            // 
            lblChuaThanhToan.Dock = DockStyle.Fill;
            lblChuaThanhToan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblChuaThanhToan.Location = new Point(0, 28);
            lblChuaThanhToan.Margin = new Padding(4, 0, 4, 0);
            lblChuaThanhToan.Name = "lblChuaThanhToan";
            lblChuaThanhToan.Size = new Size(242, 107);
            lblChuaThanhToan.TabIndex = 8;
            lblChuaThanhToan.Text = "aaaaaaaaaaaaaaaaaaaaaa";
            lblChuaThanhToan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(242, 28);
            label5.TabIndex = 7;
            label5.Text = "Chưa Thanh Toán";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1013, 526);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 137);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 242, 253);
            ClientSize = new Size(1198, 693);
            Controls.Add(pictureBox1);
            Controls.Add(panel5);
            Controls.Add(panel6);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(statusStrip1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Margin = new Padding(4);
            Name = "frmDashboard";
            Text = "frmDashboard";
            FormClosed += frmDashboard_FormClosed_1;
            Load += frmDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer timerClock;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button btnQLBaoCao;
        private Button btnQLHopDong;
        private Button btnQLThanhToan;
        private Button btnQLPhong;
        private Button btnQLSinhVien;
        private Label label2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label5;
        private PictureBox pictureBox1;
        private Label lblSinhVien;
        private Label lblPhongTrong;
        private Label lblDoanhThuThang;
        private Label lblChuaThanhToan;
        private Button btnRefesh;
    }
}