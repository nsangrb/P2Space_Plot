using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace P2Space
{
    public partial class Form2D : Form
    {
        private bool IsSroll = true;
        public Form2D()
        {
            InitializeComponent();
        }

        private void Form2D_Load(object sender, EventArgs e)
        {


        }
        public void Init(string title_vert,string title_horiz, Color colr)
        {
            GraphPane myPane = zed.GraphPane;
            myPane.Title.Text = "2D Graph";
            myPane.XAxis.Title.Text = title_vert;
            myPane.YAxis.Title.Text = title_horiz;
            RollingPointPairList list = new RollingPointPairList(60000);
            LineItem curve = myPane.AddCurve("Plot", list, colr, SymbolType.Square);
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 30;
            myPane.YAxis.Scale.MinorStep = 1;
            myPane.YAxis.Scale.MajorStep = 5;

            zed.AxisChange();
        }
        public void Draw(string x, string y)
        {
            double intx;
            double inty;
            double.TryParse(x, out intx);
            double.TryParse(y, out inty);

            if (zed.GraphPane.CurveList.Count <= 0) return;

            LineItem curve = zed.GraphPane.CurveList[0] as LineItem;
            if (curve == null) return;
            zed.GraphPane.CurveList[0].AddPoint(new PointPair(intx, inty));

            Scale xScale = zed.GraphPane.XAxis.Scale;
            if (intx > xScale.Max - xScale.MajorStep)
            {
                if (IsSroll)
                {
                    xScale.Max = intx + xScale.MajorStep;
                    xScale.Min = xScale.Max - 30;
                }
                else
                {
                    xScale.Max = intx + xScale.MajorStep;
                    xScale.Min = 0;
                }
            }

            Scale yScale = zed.GraphPane.YAxis.Scale;
            if (inty > yScale.Max - yScale.MajorStep)
            {
                if (IsSroll)
                {
                    yScale.Max = inty + yScale.MajorStep;
                    yScale.Min = yScale.Max - 30;
                }
                else
                {
                    yScale.Max = inty + yScale.MajorStep;
                    yScale.Min = 0;
                }
            }

            zed.AxisChange();
            zed.Invalidate();
        }
        public void Set_IsSroll(bool value)
        {
            IsSroll = value;
        }
    }
}
