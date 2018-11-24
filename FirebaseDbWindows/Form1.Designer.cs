namespace FirebaseDbWindows
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblInter = new System.Windows.Forms.Label();
            this.lblqno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl1q = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBeforeLive = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSleepRemain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(412, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Location = new System.Drawing.Point(104, 82);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(35, 13);
            this.lblSec.TabIndex = 1;
            this.lblSec.Text = "label1";
            // 
            // lblInter
            // 
            this.lblInter.AutoSize = true;
            this.lblInter.Location = new System.Drawing.Point(104, 119);
            this.lblInter.Name = "lblInter";
            this.lblInter.Size = new System.Drawing.Size(35, 13);
            this.lblInter.TabIndex = 2;
            this.lblInter.Text = "label1";
            // 
            // lblqno
            // 
            this.lblqno.AutoSize = true;
            this.lblqno.Location = new System.Drawing.Point(104, 153);
            this.lblqno.Name = "lblqno";
            this.lblqno.Size = new System.Drawing.Size(35, 13);
            this.lblqno.TabIndex = 3;
            this.lblqno.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sec";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Intereption";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Question No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "1st Sleep";
            // 
            // lbl1q
            // 
            this.lbl1q.AutoSize = true;
            this.lbl1q.Location = new System.Drawing.Point(104, 189);
            this.lbl1q.Name = "lbl1q";
            this.lbl1q.Size = new System.Drawing.Size(35, 13);
            this.lbl1q.TabIndex = 8;
            this.lbl1q.Text = "label1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "BeforeLive";
            // 
            // lblBeforeLive
            // 
            this.lblBeforeLive.AutoSize = true;
            this.lblBeforeLive.Location = new System.Drawing.Point(104, 226);
            this.lblBeforeLive.Name = "lblBeforeLive";
            this.lblBeforeLive.Size = new System.Drawing.Size(35, 13);
            this.lblBeforeLive.TabIndex = 10;
            this.lblBeforeLive.Text = "label1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "SleepRemaining";
            // 
            // lblSleepRemain
            // 
            this.lblSleepRemain.AutoSize = true;
            this.lblSleepRemain.Location = new System.Drawing.Point(102, 258);
            this.lblSleepRemain.Name = "lblSleepRemain";
            this.lblSleepRemain.Size = new System.Drawing.Size(35, 13);
            this.lblSleepRemain.TabIndex = 12;
            this.lblSleepRemain.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSleepRemain);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblBeforeLive);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl1q);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblqno);
            this.Controls.Add(this.lblInter);
            this.Controls.Add(this.lblSec);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblInter;
        private System.Windows.Forms.Label lblqno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl1q;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBeforeLive;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSleepRemain;
    }
}

