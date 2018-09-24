namespace WindowsFormsApp2
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
            this.btConnect = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.tbReceive = new System.Windows.Forms.TextBox();
            this.btDisconnect = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ComPort = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btClearR = new System.Windows.Forms.Button();
            this.btClearS = new System.Windows.Forms.Button();
            this.btTest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBaud = new System.Windows.Forms.TextBox();
            this.Serial = new System.Windows.Forms.GroupBox();
            this.chckBHexa = new System.Windows.Forms.CheckBox();
            this.btWPF = new System.Windows.Forms.Button();
            this.Serial.SuspendLayout();
            this.SuspendLayout();
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
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(392, 429);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 1;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // cbCom
            // 
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(145, 28);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(49, 21);
            this.cbCom.TabIndex = 2;
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(12, 290);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSend.Size = new System.Drawing.Size(458, 133);
            this.tbSend.TabIndex = 3;
            // 
            // tbReceive
            // 
            this.tbReceive.Location = new System.Drawing.Point(12, 141);
            this.tbReceive.Multiline = true;
            this.tbReceive.Name = "tbReceive";
            this.tbReceive.ReadOnly = true;
            this.tbReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReceive.Size = new System.Drawing.Size(458, 115);
            this.tbReceive.TabIndex = 4;
            this.tbReceive.TextChanged += new System.EventHandler(this.tbReceive_TextChanged);
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ComPort
            // 
            this.ComPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.OnCom);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Send:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Receive:";
            // 
            // btClearR
            // 
            this.btClearR.Location = new System.Drawing.Point(395, 112);
            this.btClearR.Name = "btClearR";
            this.btClearR.Size = new System.Drawing.Size(75, 23);
            this.btClearR.TabIndex = 9;
            this.btClearR.Text = "Clear";
            this.btClearR.UseVisualStyleBackColor = true;
            this.btClearR.Click += new System.EventHandler(this.btClearR_Click);
            // 
            // btClearS
            // 
            this.btClearS.Location = new System.Drawing.Point(395, 262);
            this.btClearS.Name = "btClearS";
            this.btClearS.Size = new System.Drawing.Size(75, 23);
            this.btClearS.TabIndex = 10;
            this.btClearS.Text = "Clear";
            this.btClearS.UseVisualStyleBackColor = true;
            this.btClearS.Click += new System.EventHandler(this.btClearS_Click);
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(311, 429);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(75, 23);
            this.btTest.TabIndex = 11;
            this.btTest.Text = "Ctrl+Z";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Baud";
            // 
            // tbBaud
            // 
            this.tbBaud.Location = new System.Drawing.Point(145, 58);
            this.tbBaud.Name = "tbBaud";
            this.tbBaud.Size = new System.Drawing.Size(49, 20);
            this.tbBaud.TabIndex = 14;
            // 
            // Serial
            // 
            this.Serial.Controls.Add(this.btWPF);
            this.Serial.Controls.Add(this.tbBaud);
            this.Serial.Controls.Add(this.btConnect);
            this.Serial.Controls.Add(this.label4);
            this.Serial.Controls.Add(this.cbCom);
            this.Serial.Controls.Add(this.label3);
            this.Serial.Controls.Add(this.btDisconnect);
            this.Serial.Location = new System.Drawing.Point(12, 12);
            this.Serial.Name = "Serial";
            this.Serial.Size = new System.Drawing.Size(455, 92);
            this.Serial.TabIndex = 15;
            this.Serial.TabStop = false;
            this.Serial.Text = "Serial";
            this.Serial.Enter += new System.EventHandler(this.Serial_Enter);
            // 
            // chckBHexa
            // 
            this.chckBHexa.AutoSize = true;
            this.chckBHexa.Location = new System.Drawing.Point(255, 117);
            this.chckBHexa.Name = "chckBHexa";
            this.chckBHexa.Size = new System.Drawing.Size(51, 17);
            this.chckBHexa.TabIndex = 16;
            this.chckBHexa.Text = "Hexa";
            this.chckBHexa.UseVisualStyleBackColor = true;
            this.chckBHexa.CheckedChanged += new System.EventHandler(this.chckBHexa_CheckedChanged);
            // 
            // btWPF
            // 
            this.btWPF.Location = new System.Drawing.Point(314, 26);
            this.btWPF.Name = "btWPF";
            this.btWPF.Size = new System.Drawing.Size(75, 23);
            this.btWPF.TabIndex = 15;
            this.btWPF.Text = "Show";
            this.btWPF.UseVisualStyleBackColor = true;
            this.btWPF.Click += new System.EventHandler(this.btWPF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 462);
            this.Controls.Add(this.chckBHexa);
            this.Controls.Add(this.Serial);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.btClearS);
            this.Controls.Add(this.btClearR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbReceive);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.btSend);
            this.Name = "Form1";
            this.Text = "Serial";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Serial.ResumeLayout(false);
            this.Serial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.TextBox tbReceive;
        private System.Windows.Forms.Button btDisconnect;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort ComPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btClearR;
        private System.Windows.Forms.Button btClearS;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbBaud;
        private System.Windows.Forms.GroupBox Serial;
        private System.Windows.Forms.CheckBox chckBHexa;
        private System.Windows.Forms.Button btWPF;
    }
}

