namespace P2Space
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
            this.btShow3d = new System.Windows.Forms.Button();
            this.Serial = new System.Windows.Forms.GroupBox();
            this.tbBaud = new System.Windows.Forms.TextBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btDisconnect = new System.Windows.Forms.Button();
            this.chckBHexa = new System.Windows.Forms.CheckBox();
            this.btTest = new System.Windows.Forms.Button();
            this.btClearS = new System.Windows.Forms.Button();
            this.btClearR = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbReceive = new System.Windows.Forms.TextBox();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.ComPort = new System.IO.Ports.SerialPort(this.components);
            this.btShow2D = new System.Windows.Forms.Button();
            this.cBAxis = new System.Windows.Forms.ComboBox();
            this.btMode = new System.Windows.Forms.Button();
            this.Serial.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btShow3d
            // 
            this.btShow3d.Location = new System.Drawing.Point(310, 55);
            this.btShow3d.Name = "btShow3d";
            this.btShow3d.Size = new System.Drawing.Size(75, 23);
            this.btShow3d.TabIndex = 0;
            this.btShow3d.Text = "Hide 3D";
            this.btShow3d.UseVisualStyleBackColor = true;
            this.btShow3d.Click += new System.EventHandler(this.btShow3d_Click);
            // 
            // Serial
            // 
            this.Serial.Controls.Add(this.tbBaud);
            this.Serial.Controls.Add(this.btConnect);
            this.Serial.Controls.Add(this.label4);
            this.Serial.Controls.Add(this.cbCom);
            this.Serial.Controls.Add(this.label3);
            this.Serial.Controls.Add(this.btDisconnect);
            this.Serial.Location = new System.Drawing.Point(23, 27);
            this.Serial.Name = "Serial";
            this.Serial.Size = new System.Drawing.Size(207, 92);
            this.Serial.TabIndex = 16;
            this.Serial.TabStop = false;
            this.Serial.Text = "Serial";
            // 
            // tbBaud
            // 
            this.tbBaud.Location = new System.Drawing.Point(145, 58);
            this.tbBaud.Name = "tbBaud";
            this.tbBaud.Size = new System.Drawing.Size(49, 20);
            this.tbBaud.TabIndex = 14;
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(17, 27);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Baud";
            // 
            // cbCom
            // 
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(145, 28);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(49, 21);
            this.cbCom.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Name";
            // 
            // btDisconnect
            // 
            this.btDisconnect.Location = new System.Drawing.Point(17, 56);
            this.btDisconnect.Name = "btDisconnect";
            this.btDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btDisconnect.TabIndex = 6;
            this.btDisconnect.Text = "Disconnect";
            this.btDisconnect.UseVisualStyleBackColor = true;
            this.btDisconnect.Click += new System.EventHandler(this.btDisconnect_Click);
            // 
            // chckBHexa
            // 
            this.chckBHexa.AutoSize = true;
            this.chckBHexa.Location = new System.Drawing.Point(266, 133);
            this.chckBHexa.Name = "chckBHexa";
            this.chckBHexa.Size = new System.Drawing.Size(51, 17);
            this.chckBHexa.TabIndex = 25;
            this.chckBHexa.Text = "Hexa";
            this.chckBHexa.UseVisualStyleBackColor = true;
            this.chckBHexa.CheckedChanged += new System.EventHandler(this.chckBHexa_CheckedChanged);
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(322, 445);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(75, 23);
            this.btTest.TabIndex = 24;
            this.btTest.Text = "Ctrl+Z";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // btClearS
            // 
            this.btClearS.Location = new System.Drawing.Point(406, 278);
            this.btClearS.Name = "btClearS";
            this.btClearS.Size = new System.Drawing.Size(75, 23);
            this.btClearS.TabIndex = 23;
            this.btClearS.Text = "Clear";
            this.btClearS.UseVisualStyleBackColor = true;
            this.btClearS.Click += new System.EventHandler(this.btClearS_Click);
            // 
            // btClearR
            // 
            this.btClearR.Location = new System.Drawing.Point(406, 128);
            this.btClearR.Name = "btClearR";
            this.btClearR.Size = new System.Drawing.Size(75, 23);
            this.btClearR.TabIndex = 22;
            this.btClearR.Text = "Clear";
            this.btClearR.UseVisualStyleBackColor = true;
            this.btClearR.Click += new System.EventHandler(this.btClearR_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Receive:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Send:";
            // 
            // tbReceive
            // 
            this.tbReceive.Location = new System.Drawing.Point(23, 157);
            this.tbReceive.Multiline = true;
            this.tbReceive.Name = "tbReceive";
            this.tbReceive.ReadOnly = true;
            this.tbReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReceive.Size = new System.Drawing.Size(458, 115);
            this.tbReceive.TabIndex = 19;
            this.tbReceive.TextChanged += new System.EventHandler(this.tbReceive_TextChanged);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(23, 306);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSend.Size = new System.Drawing.Size(458, 133);
            this.tbSend.TabIndex = 18;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(403, 445);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 17;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btShow2D
            // 
            this.btShow2D.Location = new System.Drawing.Point(310, 84);
            this.btShow2D.Name = "btShow2D";
            this.btShow2D.Size = new System.Drawing.Size(75, 23);
            this.btShow2D.TabIndex = 15;
            this.btShow2D.Text = "Show 2D";
            this.btShow2D.UseVisualStyleBackColor = true;
            this.btShow2D.Click += new System.EventHandler(this.btShow2D_Click);
            // 
            // cBAxis
            // 
            this.cBAxis.FormattingEnabled = true;
            this.cBAxis.Location = new System.Drawing.Point(255, 84);
            this.cBAxis.Name = "cBAxis";
            this.cBAxis.Size = new System.Drawing.Size(49, 21);
            this.cBAxis.TabIndex = 16;
            // 
            // btMode
            // 
            this.btMode.Location = new System.Drawing.Point(391, 84);
            this.btMode.Name = "btMode";
            this.btMode.Size = new System.Drawing.Size(75, 23);
            this.btMode.TabIndex = 17;
            this.btMode.Text = "Sroll";
            this.btMode.UseVisualStyleBackColor = true;
            this.btMode.Click += new System.EventHandler(this.btMode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 532);
            this.Controls.Add(this.btMode);
            this.Controls.Add(this.cBAxis);
            this.Controls.Add(this.btShow2D);
            this.Controls.Add(this.chckBHexa);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.btShow3d);
            this.Controls.Add(this.btClearS);
            this.Controls.Add(this.btClearR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbReceive);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.Serial);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Serial.ResumeLayout(false);
            this.Serial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btShow3d;
        private System.Windows.Forms.GroupBox Serial;
        private System.Windows.Forms.TextBox tbBaud;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btDisconnect;
        private System.Windows.Forms.CheckBox chckBHexa;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.Button btClearS;
        private System.Windows.Forms.Button btClearR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbReceive;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Button btSend;
        private System.IO.Ports.SerialPort ComPort;
        private System.Windows.Forms.ComboBox cBAxis;
        private System.Windows.Forms.Button btShow2D;
        private System.Windows.Forms.Button btMode;
    }
}

