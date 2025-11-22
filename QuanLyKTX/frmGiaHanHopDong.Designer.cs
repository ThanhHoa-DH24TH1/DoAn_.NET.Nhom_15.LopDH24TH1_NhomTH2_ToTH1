namespace QuanLyKTX
{
    partial class frmGiaHanHopDong
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
            dtpNewEndDate = new DateTimePicker();
            btnLuu = new Button();
            btnHuy = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 96);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 0;
            label1.Text = "Ngày kết thúc mới :";
            // 
            // dtpNewEndDate
            // 
            dtpNewEndDate.Location = new Point(219, 91);
            dtpNewEndDate.Name = "dtpNewEndDate";
            dtpNewEndDate.Size = new Size(250, 27);
            dtpNewEndDate.TabIndex = 1;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(158, 174);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 2;
            btnLuu.Text = "💾Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(292, 174);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(94, 29);
            btnHuy.TabIndex = 3;
            btnHuy.Text = "❌Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(174, 18);
            label2.Name = "label2";
            label2.Size = new Size(212, 28);
            label2.TabIndex = 4;
            label2.Text = "GIA HẠN HỢP ĐỒNG";
            // 
            // frmGiaHanHopDong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 253);
            Controls.Add(label2);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(dtpNewEndDate);
            Controls.Add(label1);
            Name = "frmGiaHanHopDong";
            Text = "frmGiaHanHopDong";
            Load += frmGiaHanHopDong_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpNewEndDate;
        private Button btnLuu;
        private Button btnHuy;
        private Label label2;
    }
}