namespace TLSharpSample
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
            this.GHash = new System.Windows.Forms.TextBox();
            this.joinB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.TextBox();
            this.CodeOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UpdatesList = new System.Windows.Forms.ListBox();
            this.phone = new System.Windows.Forms.ComboBox();
            this.StopTimer = new System.Windows.Forms.Button();
            this.ErrorsBox = new System.Windows.Forms.ListBox();
            this.ReplisBox = new System.Windows.Forms.ListBox();
            this.donate = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // GHash
            // 
            this.GHash.Location = new System.Drawing.Point(9, 95);
            this.GHash.Name = "GHash";
            this.GHash.Size = new System.Drawing.Size(218, 21);
            this.GHash.TabIndex = 0;
            // 
            // joinB
            // 
            this.joinB.Location = new System.Drawing.Point(9, 122);
            this.joinB.Name = "joinB";
            this.joinB.Size = new System.Drawing.Size(218, 23);
            this.joinB.TabIndex = 1;
            this.joinB.Text = "عضویت در گروه";
            this.joinB.UseVisualStyleBackColor = true;
            this.joinB.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "همراه:";
            // 
            // ConnectB
            // 
            this.ConnectB.Location = new System.Drawing.Point(80, 66);
            this.ConnectB.Name = "ConnectB";
            this.ConnectB.Size = new System.Drawing.Size(147, 23);
            this.ConnectB.TabIndex = 4;
            this.ConnectB.Text = "اتصال";
            this.ConnectB.UseVisualStyleBackColor = true;
            this.ConnectB.Click += new System.EventHandler(this.ConnectB_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "کد:";
            // 
            // code
            // 
            this.code.Enabled = false;
            this.code.Location = new System.Drawing.Point(12, 39);
            this.code.Name = "code";
            this.code.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.code.Size = new System.Drawing.Size(215, 21);
            this.code.TabIndex = 5;
            // 
            // CodeOK
            // 
            this.CodeOK.Enabled = false;
            this.CodeOK.Location = new System.Drawing.Point(12, 66);
            this.CodeOK.Name = "CodeOK";
            this.CodeOK.Size = new System.Drawing.Size(62, 23);
            this.CodeOK.TabIndex = 7;
            this.CodeOK.Text = "تایید کد";
            this.CodeOK.UseVisualStyleBackColor = true;
            this.CodeOK.Click += new System.EventHandler(this.CodeOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "هش گروه:";
            // 
            // UpdatesList
            // 
            this.UpdatesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdatesList.FormattingEnabled = true;
            this.UpdatesList.Location = new System.Drawing.Point(12, 151);
            this.UpdatesList.Name = "UpdatesList";
            this.UpdatesList.Size = new System.Drawing.Size(281, 108);
            this.UpdatesList.TabIndex = 9;
            // 
            // phone
            // 
            this.phone.FormattingEnabled = true;
            this.phone.Location = new System.Drawing.Point(12, 12);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(215, 21);
            this.phone.TabIndex = 10;
            // 
            // StopTimer
            // 
            this.StopTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StopTimer.Location = new System.Drawing.Point(80, 506);
            this.StopTimer.Name = "StopTimer";
            this.StopTimer.Size = new System.Drawing.Size(213, 23);
            this.StopTimer.TabIndex = 11;
            this.StopTimer.Text = "دریافت";
            this.StopTimer.UseVisualStyleBackColor = true;
            this.StopTimer.Click += new System.EventHandler(this.StopTimer_Click);
            // 
            // ErrorsBox
            // 
            this.ErrorsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorsBox.FormattingEnabled = true;
            this.ErrorsBox.Location = new System.Drawing.Point(12, 431);
            this.ErrorsBox.Name = "ErrorsBox";
            this.ErrorsBox.Size = new System.Drawing.Size(281, 69);
            this.ErrorsBox.TabIndex = 12;
            // 
            // ReplisBox
            // 
            this.ReplisBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplisBox.FormattingEnabled = true;
            this.ReplisBox.Items.AddRange(new object[] {
            "hi#Salam 🙃",
            "/start#I,m @WeCanCo :)",
            "/wecan#I LOVE HE 💝"});
            this.ReplisBox.Location = new System.Drawing.Point(12, 265);
            this.ReplisBox.Name = "ReplisBox";
            this.ReplisBox.Size = new System.Drawing.Size(281, 160);
            this.ReplisBox.TabIndex = 13;
            // 
            // donate
            // 
            this.donate.AutoSize = true;
            this.donate.Location = new System.Drawing.Point(12, 511);
            this.donate.Name = "donate";
            this.donate.Size = new System.Drawing.Size(63, 13);
            this.donate.TabIndex = 14;
            this.donate.TabStop = true;
            this.donate.Text = "حمایت مالی";
            this.donate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.donate_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 534);
            this.Controls.Add(this.donate);
            this.Controls.Add(this.ReplisBox);
            this.Controls.Add(this.ErrorsBox);
            this.Controls.Add(this.StopTimer);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.UpdatesList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CodeOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.code);
            this.Controls.Add(this.ConnectB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.joinB);
            this.Controls.Add(this.GHash);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = " وی کن شارپ | WeCan TLSharp Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GHash;
        private System.Windows.Forms.Button joinB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConnectB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Button CodeOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox UpdatesList;
        private System.Windows.Forms.ComboBox phone;
        private System.Windows.Forms.Button StopTimer;
        private System.Windows.Forms.ListBox ErrorsBox;
        private System.Windows.Forms.ListBox ReplisBox;
        private System.Windows.Forms.LinkLabel donate;
    }
}

