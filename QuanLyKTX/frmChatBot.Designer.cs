namespace QuanLyKTX
{
    partial class frmChatBot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChatBot));
            rtbChatHistory = new RichTextBox();
            pnlInput = new Panel();
            btnSend = new Button();
            txtInput = new TextBox();
            pnlInput.SuspendLayout();
            SuspendLayout();
            // 
            // rtbChatHistory
            // 
            rtbChatHistory.Location = new Point(49, 37);
            rtbChatHistory.Name = "rtbChatHistory";
            rtbChatHistory.Size = new Size(543, 201);
            rtbChatHistory.TabIndex = 0;
            rtbChatHistory.Text = "";
            // 
            // pnlInput
            // 
            pnlInput.BackColor = Color.White;
            pnlInput.Controls.Add(btnSend);
            pnlInput.Controls.Add(txtInput);
            pnlInput.Location = new Point(49, 258);
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new Size(543, 66);
            pnlInput.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(456, 22);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(65, 29);
            btnSend.TabIndex = 1;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(16, 22);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(434, 27);
            txtInput.TabIndex = 0;
            // 
            // frmChatBot
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 177, 76);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(636, 411);
            Controls.Add(pnlInput);
            Controls.Add(rtbChatHistory);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmChatBot";
            Text = "frmChatBot";
            TransparencyKey = Color.FromArgb(34, 177, 76);
            Load += frmChatBot_Load;
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbChatHistory;
        private Panel pnlInput;
        private Button btnSend;
        private TextBox txtInput;
    }
}