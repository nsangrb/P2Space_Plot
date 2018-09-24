using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
//using WPFChart3D;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {

                ComPort.PortName = cbCom.Text;
                ComPort.BaudRate = int.Parse(tbBaud.Text);
                if (!ComPort.IsOpen)
                    ComPort.Open();
                btConnect.Enabled = false;
                btDisconnect.Enabled = true;

            }
            catch
            {
                if (cbCom.Text == "")
                {
                    MessageBox.Show("Select Comport");
                }
                else MessageBox.Show("Incorrect Baudrate");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btConnect.Enabled = true;
            btDisconnect.Enabled = false;
            tbBaud.Text = "115200";
        }

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            if (ComPort.IsOpen)
                ComPort.Close();
            btConnect.Enabled = true;
            btDisconnect.Enabled = false;
        }
        int intlen = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
                string[] ports = SerialPort.GetPortNames();
                if (intlen != ports.Length)
                {
                    intlen = ports.Length;
                    cbCom.Items.Clear();
                    for (int j = 0; j < intlen; j++)
                    {
                        cbCom.Items.Add(ports[j]);
                    }
                }
        }
        private void OnCom(object sender, SerialDataReceivedEventArgs e)
        {
            string s;
            s = ComPort.ReadExisting();
            Display(s);
        }
        private delegate void DlDisplay(string s);
        private void Display(string s)
        {
            if (tbReceive.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display);
                tbReceive.Invoke(sd, new object[] { s });
            }
            else
            {
                tbReceive.Text += s;
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            string s;
            if (btDisconnect.Enabled==true)
            {
                s = tbSend.Text+"\r";
                ComPort.Write(s);
            }
            else
                MessageBox.Show("Connect ComPort");
        }

        private void btClearR_Click(object sender, EventArgs e)
        {
            tbReceive.Text = "";
        }

        private void btClearS_Click(object sender, EventArgs e)
        {
            tbSend.Text = "";
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            string s;
            if (btDisconnect.Enabled == true)
            {
               
                s = tbSend.Text+(char)26;
                ComPort.Write(s);
            }
            else
                MessageBox.Show("Connect ComPort");
        }

        private void tbReceive_TextChanged(object sender, EventArgs e)
        {
            tbReceive.SelectionStart = tbReceive.Text.Length;
            // scroll it automatically
            tbReceive.ScrollToCaret();
        }

        private string _Str_Hexa(string s)
        {
            string str="";
            char[] Arrchar;
            Arrchar = s.ToCharArray();
            for (int i = 0; i < Arrchar.Length; i++)
            {
                int a = (int)Arrchar[i];
                str += a.ToString("X") +" ";
            }
            return str;
        }
        string tmp_str;
        private void chckBHexa_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBHexa.Checked==true)
            {
                tmp_str=tbReceive.Text;
                tbReceive.Text = _Str_Hexa(tbReceive.Text);
            }
            else
            {
                tbReceive.Text = tmp_str;
            }
        }

        private void Serial_Enter(object sender, EventArgs e)
        {

        }

        private void btWPF_Click(object sender, EventArgs e)
        {
            
        }
    }
}
