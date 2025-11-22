namespace QuanLyKTX
{
    partial class frmDangNhap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            btnDN = new Button();
            txtTenDN = new TextBox();
            txtMK = new TextBox();
            label3 = new Label();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(25, 118, 210);
            label1.Location = new Point(308, 42);
            label1.Name = "label1";
            label1.Size = new Size(184, 38);
            label1.TabIndex = 0;
            label1.Text = "Đăng Nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(33, 33, 33);
            label2.Location = new Point(168, 139);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên đăng nhập :";
            // 
            // btnDN
            // 
            btnDN.BackColor = Color.FromArgb(33, 150, 243);
            btnDN.ForeColor = Color.White;
            btnDN.Location = new Point(224, 319);
            btnDN.Name = "btnDN";
            btnDN.Size = new Size(114, 51);
            btnDN.TabIndex = 2;
            btnDN.Text = "Đăng nhập";
            btnDN.UseVisualStyleBackColor = false;
            btnDN.Click += btnDangNhap_Click;
            // 
            // txtTenDN
            // 
            txtTenDN.Location = new Point(330, 132);
            txtTenDN.Name = "txtTenDN";
            txtTenDN.Size = new Size(211, 27);
            txtTenDN.TabIndex = 3;
            // 
            // txtMK
            // 
            txtMK.Location = new Point(330, 214);
            txtMK.Name = "txtMK";
            txtMK.PasswordChar = '*';
            txtMK.Size = new Size(211, 27);
            txtMK.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(33, 33, 33);
            label3.Location = new Point(168, 217);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 4;
            label3.Text = "Mật khẩu :";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(158, 158, 158);
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(443, 319);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(116, 51);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 242, 253);
            ClientSize = new Size(800, 412);
            Controls.Add(btnThoat);
            Controls.Add(txtMK);
            Controls.Add(label3);
            Controls.Add(txtTenDN);
            Controls.Add(btnDN);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmDangNhap";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnDN;
        private TextBox txtTenDN;
        private TextBox txtMK;
        private Label label3;
        private Button btnThoat;
    }
}
