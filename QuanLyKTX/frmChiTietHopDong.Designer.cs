namespace QuanLyKTX
{
    partial class frmChiTietHopDong
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
            cmbStudent = new ComboBox();
            cmbRoom = new ComboBox();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtDeposit = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // cmbStudent
            // 
            cmbStudent.FormattingEnabled = true;
            cmbStudent.Location = new Point(126, 109);
            cmbStudent.Name = "cmbStudent";
            cmbStudent.Size = new Size(151, 28);
            cmbStudent.TabIndex = 0;
            // 
            // cmbRoom
            // 
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(126, 173);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(151, 28);
            cmbRoom.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(503, 109);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(250, 27);
            dtpStartDate.TabIndex = 2;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(503, 171);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(250, 27);
            dtpEndDate.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 109);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 4;
            label1.Text = "Sinh viên :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 176);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 5;
            label2.Text = "Phòng :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(379, 173);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 7;
            label3.Text = "Ngày kết thúc :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(380, 109);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 6;
            label4.Text = "Ngày bắt đầu :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 239);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 8;
            label5.Text = "Tiền cọc :";
            // 
            // txtDeposit
            // 
            txtDeposit.Location = new Point(126, 239);
            txtDeposit.Name = "txtDeposit";
            txtDeposit.Size = new Size(151, 27);
            txtDeposit.TabIndex = 9;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(21, 101, 192);
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(233, 332);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(107, 40);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "💾Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(229, 57, 53);
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(422, 332);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(106, 40);
            btnHuy.TabIndex = 12;
            btnHuy.Text = "❌Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(25, 118, 210);
            label6.Location = new Point(263, 23);
            label6.Name = "label6";
            label6.Size = new Size(251, 41);
            label6.TabIndex = 13;
            label6.Text = "Thêm Hợp Đồng";
            // 
            // frmChiTietHopDong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 248);
            ClientSize = new Size(800, 411);
            Controls.Add(label6);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(txtDeposit);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(cmbRoom);
            Controls.Add(cmbStudent);
            Name = "frmChiTietHopDong";
            Text = "frmChiTietHopDong";
            Load += frmChiTietHopDong_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbStudent;
        private ComboBox cmbRoom;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtDeposit;
        private Button btnLuu;
        private Button btnHuy;
        private Label label6;
    }
}