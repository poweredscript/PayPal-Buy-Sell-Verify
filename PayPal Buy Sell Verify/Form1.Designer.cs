namespace PayPal_Buy_Sell_Verify
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.labelReport = new System.Windows.Forms.Label();
            this.buttonFacebookMessageCheck = new System.Windows.Forms.Button();
            this.labelVerifyListUpdate = new System.Windows.Forms.Label();
            this.verifyListOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(421, 20);
            this.textBox1.TabIndex = 0;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(458, 42);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(100, 23);
            this.buttonCheck.TabIndex = 1;
            this.buttonCheck.Text = "ตรวจสอบ";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(3, 19);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(128, 13);
            this.labelID.TabIndex = 2;
            this.labelID.Text = "ID/Facebook Profile URL";
            // 
            // labelReport
            // 
            this.labelReport.AutoSize = true;
            this.labelReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReport.Location = new System.Drawing.Point(2, 68);
            this.labelReport.Name = "labelReport";
            this.labelReport.Size = new System.Drawing.Size(241, 24);
            this.labelReport.TabIndex = 3;
            this.labelReport.Text = "ใส่ข้อมูล จากนั้นคลิกปุ่มตรวจสอบ";
            // 
            // buttonFacebookMessageCheck
            // 
            this.buttonFacebookMessageCheck.Location = new System.Drawing.Point(403, 102);
            this.buttonFacebookMessageCheck.Name = "buttonFacebookMessageCheck";
            this.buttonFacebookMessageCheck.Size = new System.Drawing.Size(155, 23);
            this.buttonFacebookMessageCheck.TabIndex = 4;
            this.buttonFacebookMessageCheck.Text = "เปิดหน้า facebook messages";
            this.buttonFacebookMessageCheck.UseVisualStyleBackColor = true;
            this.buttonFacebookMessageCheck.Click += new System.EventHandler(this.buttonFacebookMessageCheck_Click);
            // 
            // labelVerifyListUpdate
            // 
            this.labelVerifyListUpdate.AutoSize = true;
            this.labelVerifyListUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelVerifyListUpdate.ForeColor = System.Drawing.Color.Red;
            this.labelVerifyListUpdate.Location = new System.Drawing.Point(134, 47);
            this.labelVerifyListUpdate.Name = "labelVerifyListUpdate";
            this.labelVerifyListUpdate.Size = new System.Drawing.Size(176, 13);
            this.labelVerifyListUpdate.TabIndex = 6;
            this.labelVerifyListUpdate.Text = "กำลังโหลดรายชื่อ โปรดรอสักครู่";
            // 
            // verifyListOpen
            // 
            this.verifyListOpen.Location = new System.Drawing.Point(6, 102);
            this.verifyListOpen.Name = "verifyListOpen";
            this.verifyListOpen.Size = new System.Drawing.Size(151, 23);
            this.verifyListOpen.TabIndex = 7;
            this.verifyListOpen.Text = "ดูรายชื่อผู้ผ่านการ verify แล้ว";
            this.verifyListOpen.UseVisualStyleBackColor = true;
            this.verifyListOpen.Click += new System.EventHandler(this.verifyListOpen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 132);
            this.Controls.Add(this.verifyListOpen);
            this.Controls.Add(this.labelVerifyListUpdate);
            this.Controls.Add(this.buttonFacebookMessageCheck);
            this.Controls.Add(this.labelReport);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "PayPal Buy Sell Verify";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelReport;
        private System.Windows.Forms.Button buttonFacebookMessageCheck;
        private System.Windows.Forms.Label labelVerifyListUpdate;
        private System.Windows.Forms.Button verifyListOpen;
    }
}

