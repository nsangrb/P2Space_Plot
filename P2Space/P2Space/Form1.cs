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
using ZedGraph;

namespace P2Space
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Window1 a = new Window1();
        Form2D formxy = new Form2D();
        Form2D formxz = new Form2D();
        Form2D formzy = new Form2D();
        private void Form1_Load(object sender, EventArgs e)
        {
            btConnect.Enabled = true;
            btDisconnect.Enabled = false;
            tbBaud.Text = "115200";

            a.Width = 1000;
            a.Height = 1000;
            a.Show();

            formxy.Width = 705;
            formxy.Height = 705;
            formxy.Init("X,m", "Y,m", Color.Red);

            formxz.Width = 705;
            formxz.Height = 705;
            formxz.Init("X,m", "Z,m", Color.Green);

            formzy.Width = 705;
            formzy.Height = 705;
            formzy.Init("Z,m", "Y,m", Color.Blue);

            formxy.Show();
            formxz.Show();
            formzy.Show();
            formxz.Hide();
            formzy.Hide();

            cBAxis.Items.Add("X-Y");
            cBAxis.Items.Add("X-Z");
            cBAxis.Items.Add("Y-Z");
            cBAxis.Text = "X-Y";

        }
        private void btShow3d_Click(object sender, EventArgs e)
        {
            if(btShow3d.Text=="Hide 3D")
            {
                a.Hide();
                btShow3d.Text = "Show 3D";
            }
            else
            {
                a.Show();
                btShow3d.Text = "Hide 3D";
            }
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

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            if (ComPort.IsOpen)
                ComPort.Close();
            btConnect.Enabled = true;
            btDisconnect.Enabled = false;
        }

        private void btClearR_Click(object sender, EventArgs e)
        {
            tbReceive.Text = "";
        }

        private void btClearS_Click(object sender, EventArgs e)
        {
            tbSend.Text = "";
        }
        int intlen = 0;
        double X=0, Y=0, Z=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            Random randomObject = new Random();
            if (intlen != ports.Length)
            {
                intlen = ports.Length;
                cbCom.Items.Clear();
                for (int j = 0; j < intlen; j++)
                {
                    cbCom.Items.Add(ports[j]);
                }
            }

            X = randomObject.NextDouble() * 200;
            Y = randomObject.NextDouble() * 200;
            Z = randomObject.NextDouble() * 200;
            double argX = randomObject.NextDouble() * 360;
            double argY = randomObject.NextDouble() * 360;

            formxy.Draw(X.ToString(), Y.ToString());
            formxz.Draw(X.ToString(), Z.ToString());
            formzy.Draw(Z.ToString(), (Y).ToString());

            a.Plot_3D(++X + 1, ++Y + 1, ++Z + 1, 0, 0);


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
            if (btDisconnect.Enabled == true)
            {
                s = tbSend.Text + "\r";
                ComPort.Write(s);
            }
            else
                MessageBox.Show("Connect ComPort");
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            string s;
            if (btDisconnect.Enabled == true)
            {

                s = tbSend.Text + (char)26;
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
            string str = "";
            char[] Arrchar;
            Arrchar = s.ToCharArray();
            for (int i = 0; i < Arrchar.Length; i++)
            {
                int a = (int)Arrchar[i];
                str += a.ToString("X") + " ";
            }
            return str;
        }
        string tmp_str;

        private void btMode_Click(object sender, EventArgs e)
        {
            if (btMode.Text == "Sroll")
            {
                formxy.Set_IsSroll(false);
                formxz.Set_IsSroll(false);
                formyz.Set_IsSroll(false);
                btMode.Text = "Compact";
            }
            else
            {
                formxy.Set_IsSroll(true);
                formxz.Set_IsSroll(true);
                formyz.Set_IsSroll(true);
                btMode.Text = "Sroll";
            }
        }

        private void chckBHexa_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBHexa.Checked == true)
            {
                tmp_str = tbReceive.Text;
                tbReceive.Text = _Str_Hexa(tbReceive.Text);
            }
            else
            {
                tbReceive.Text = tmp_str;
            }
        }

        private void btShow2D_Click(object sender, EventArgs e)
        {
            if (cBAxis.Text=="X-Y")
            {
                formxy.Show();
                formxz.Hide();
                formyz.Hide();
            }
            else if(cBAxis.Text=="X-Z")
            {
                formxy.Hide();
                formxz.Show();
                formyz.Hide();
            }
            else
            {
                formxy.Hide();
                formxz.Hide();
                formyz.Show();
            }
        }
    }
}
                                