namespace MSMQT
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSMTP = new System.Windows.Forms.TextBox();
            this.txtFJRDZ = new System.Windows.Forms.TextBox();
            this.txtFJRMM = new System.Windows.Forms.TextBox();
            this.txtSJRDZ = new System.Windows.Forms.TextBox();
            this.txtYJZT = new System.Windows.Forms.TextBox();
            this.txtYJZW = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnAllSend = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFJ = new System.Windows.Forms.TextBox();
            this.btnFJ = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "SMTP主机:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "发件人地址:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "发件人密码:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "收件人地址:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "邮件主题:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "邮件正文:";
            // 
            // txtSMTP
            // 
            this.txtSMTP.Location = new System.Drawing.Point(90, 15);
            this.txtSMTP.Name = "txtSMTP";
            this.txtSMTP.Size = new System.Drawing.Size(194, 21);
            this.txtSMTP.TabIndex = 6;
            this.txtSMTP.Text = "smtp.qq.com";
            // 
            // txtFJRDZ
            // 
            this.txtFJRDZ.Location = new System.Drawing.Point(90, 44);
            this.txtFJRDZ.Name = "txtFJRDZ";
            this.txtFJRDZ.Size = new System.Drawing.Size(194, 21);
            this.txtFJRDZ.TabIndex = 7;
            this.txtFJRDZ.Text = "775116851@qq.com";
            // 
            // txtFJRMM
            // 
            this.txtFJRMM.Location = new System.Drawing.Point(90, 73);
            this.txtFJRMM.Name = "txtFJRMM";
            this.txtFJRMM.PasswordChar = '*';
            this.txtFJRMM.Size = new System.Drawing.Size(194, 21);
            this.txtFJRMM.TabIndex = 8;
            this.txtFJRMM.Text = "l";
            // 
            // txtSJRDZ
            // 
            this.txtSJRDZ.Location = new System.Drawing.Point(90, 102);
            this.txtSJRDZ.Name = "txtSJRDZ";
            this.txtSJRDZ.Size = new System.Drawing.Size(194, 21);
            this.txtSJRDZ.TabIndex = 9;
            this.txtSJRDZ.Text = "540936548@qq.com";
            // 
            // txtYJZT
            // 
            this.txtYJZT.Location = new System.Drawing.Point(90, 131);
            this.txtYJZT.Name = "txtYJZT";
            this.txtYJZT.Size = new System.Drawing.Size(194, 21);
            this.txtYJZT.TabIndex = 10;
            this.txtYJZT.Text = "测试的";
            // 
            // txtYJZW
            // 
            this.txtYJZW.Location = new System.Drawing.Point(90, 160);
            this.txtYJZW.Multiline = true;
            this.txtYJZW.Name = "txtYJZW";
            this.txtYJZW.Size = new System.Drawing.Size(194, 80);
            this.txtYJZW.TabIndex = 11;
            this.txtYJZW.Text = "这是测试正文";
            this.txtYJZW.DoubleClick += new System.EventHandler(this.txtYJZW_DoubleClick);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(14, 189);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(69, 51);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnAllSend
            // 
            this.btnAllSend.Location = new System.Drawing.Point(14, 250);
            this.btnAllSend.Name = "btnAllSend";
            this.btnAllSend.Size = new System.Drawing.Size(270, 23);
            this.btnAllSend.TabIndex = 13;
            this.btnAllSend.Text = "从消息队列中发送邮件";
            this.btnAllSend.UseVisualStyleBackColor = true;
            this.btnAllSend.Click += new System.EventHandler(this.btnAllSend_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFJ
            // 
            this.txtFJ.Enabled = false;
            this.txtFJ.Location = new System.Drawing.Point(14, 327);
            this.txtFJ.Name = "txtFJ";
            this.txtFJ.ReadOnly = true;
            this.txtFJ.Size = new System.Drawing.Size(189, 21);
            this.txtFJ.TabIndex = 15;
            // 
            // btnFJ
            // 
            this.btnFJ.Location = new System.Drawing.Point(209, 325);
            this.btnFJ.Name = "btnFJ";
            this.btnFJ.Size = new System.Drawing.Size(75, 23);
            this.btnFJ.TabIndex = 16;
            this.btnFJ.Text = "附件";
            this.btnFJ.UseVisualStyleBackColor = true;
            this.btnFJ.Click += new System.EventHandler(this.btnFJ_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 400);
            this.Controls.Add(this.btnFJ);
            this.Controls.Add(this.txtFJ);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAllSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtYJZW);
            this.Controls.Add(this.txtYJZT);
            this.Controls.Add(this.txtSJRDZ);
            this.Controls.Add(this.txtFJRMM);
            this.Controls.Add(this.txtFJRDZ);
            this.Controls.Add(this.txtSMTP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "消息队列发送邮件";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSMTP;
        private System.Windows.Forms.TextBox txtFJRDZ;
        private System.Windows.Forms.TextBox txtFJRMM;
        private System.Windows.Forms.TextBox txtSJRDZ;
        private System.Windows.Forms.TextBox txtYJZT;
        private System.Windows.Forms.TextBox txtYJZW;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnAllSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFJ;
        private System.Windows.Forms.Button btnFJ;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

