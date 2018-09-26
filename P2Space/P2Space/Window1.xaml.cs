//------------------------------------------------------------------
// (c) Copywrite Jianzhong Zhang
// This code is under The Code Project Open License
// Please read the attached license document before using this class
//------------------------------------------------------------------

// window class for testing 3d chart using WPF
// version 0.1

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System;
using System.Collections;
using System.Windows.Threading;
namespace P2Space
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        // transform class object for rotate the 3d model
        public P2Space.TransformMatrix m_transformMatrix = new P2Space.TransformMatrix();

        // ***************************** 3d chart ***************************
        private P2Space.Chart3D m_3dChart;       // data for 3d chart
        public int m_nChartModelIndex = -1;         // model index in the Viewport3d
        public int m_nSurfaceChartGridNo = 100;     // surface chart grid no. in each axis
        public int m_nScatterPlotDataNo = 5000;     // total data number of the scatter plot
        public ArrayList meshes_all = new ArrayList();
        public ArrayList meshes_pre = new ArrayList();
        public Quaternion q;
        // ***************************** selection rect ***************************
        ViewportRect m_selectRect = new ViewportRect();
        public int m_nRectModelIndex = -1, arg = 0;

        public Point3D pre_point, start_point;
        public Quaternion pre_q;
        public struct Arg { public double X, Y; };
        Arg pre_arg;

        public Window1()
        {
            InitializeComponent();
            this.MouseWheel += Form_MouseWheel;
            axis.x_l = 100;
            axis.y_l = 100;
            axis.z_l = 100;
            //
            pre_arg.X = 0; pre_arg.Y = 0;

            //DispatcherTimer dispatcherTimer = new DispatcherTimer();
            //dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            //dispatcherTimer.Start();
            // selection rect
            //m_selectRect.SetRect(new Point(-0.5, -0.5), new Point(-0.5, -0.5));
            //P2Space.Model3D model3d = new P2Space.Model3D();
            //ArrayList meshs = m_selectRect.GetMeshes();
            //m_nRectModelIndex = model3d.UpdateModel(meshs, null, m_nRectModelIndex, this.mainViewport);

            //// display the 3d chart data no.
            //gridNo.Text = String.Format("{0:d}", m_nSurfaceChartGridNo);
            //dataNo.Text = String.Format("{0:d}", m_nScatterPlotDataNo);

            //// display surface chart
            //TestScatterPlot(1000);
            //TransformChart();
            Init_plot(axis, 1, 1, 1, 0, 0);
        }
        void Form_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            m_transformMatrix.OnWheelScroll(e.Delta > 0);
            TransformChart();
        }
        public float testx = 0, testy = 0, testz = 0;
        public struct Axis_L
        {
            public float x_l, y_l, z_l;
        }
        public Axis_L axis;
        public Axis_L Set_range(Axis_L a, float x, float y, float z)
        {
            if (x + 25 >= a.x_l) a.x_l = x + 25;
            if (y + 25 >= a.y_l) a.y_l = y + 25;
            if (z + 25 >= a.z_l) a.z_l = z + 25;

            return a;
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Random randomObject = new Random();
            arg += 40;

            q = new Quaternion(new Vector3D(0, 0, 1), 45);
            //  q *= new Quaternion(new Vector3D(0, 0, 1), 45);
            //Move_plot(0, axis, testx, testy, testz, randomObject.NextDouble() * 360, randomObject.NextDouble() * 360);
            //  Move_plot(axis, testx, testy, testz,90,0);
            Move_plot(axis, q);
            //Tr(0, 100, (float)-0.5, (float)-0.5, (float)-0.5);
            // Tr(0, 100, (float)0.5, (float)0.5, (float)0.5);
            // aa += 10;
            testx += (float)5;
            testy += (float)5;
            testz += (float)5;
            axis = Set_range(axis, (float)pre_point.X, (float)pre_point.Y, (float)pre_point.Z);
        }
        public void Plot_3D(double x,double y,double z, double w)
        {
            q = new Quaternion(x,y,z,w);
            //  q *= new Quaternion(new Vector3D(0, 0, 1), 45);
            //Move_plot(0, axis, testx, testy, testz, randomObject.NextDouble() * 360, randomObject.NextDouble() * 360);
            //  Move_plot(axis, testx, testy, testz,90,0);
            Move_plot(axis, q);
            //Tr(0, 100, (float)-0.5, (float)-0.5, (float)-0.5);
            // Tr(0, 100, (float)0.5, (float)0.5, (float)0.5);
            // aa += 10;
         //   axis = Set_range(axis, (float)pre_point.X, (float)pre_point.Y, (float)pre_point.Z);
        }
        public void Plot_3D(double x,double y,double z,double argX,double argY)
        {
            //  q *= new Quaternion(new Vector3D(0, 0, 1), 45);
            //Move_plot(0, axis, testx, testy, testz, randomObject.NextDouble() * 360, randomObject.NextDouble() * 360);
            //  Move_plot(axis, testx, testy, testz,90,0);
            Move_plot(axis,(float)x,(float)y,(float)z,argX, argY);
            //Tr(0, 100, (float)-0.5, (float)-0.5, (float)-0.5);
            // Tr(0, 100, (float)0.5, (float)0.5, (float)0.5);
            // aa += 10;
            //   axis = Set_range(axis, (float)pre_point.X, (float)pre_point.Y, (float)pre_point.Z);
        }
        // function for testing surface chart
        public void TestSurfacePlot(int nGridNo)
        {
            int nXNo = nGridNo;
            int nYNo = nGridNo;
            // 1. set the surface grid
            m_3dChart = new UniformSurfaceChart3D();
            ((UniformSurfaceChart3D)m_3dChart).SetGrid(nXNo, nYNo, -100, 100, -100, 100);

            // 2. set surface chart z value
            double xC = m_3dChart.XCenter();
            double yC = m_3dChart.YCenter();
            int nVertNo = m_3dChart.GetDataNo();
            double zV;
            for (int i = 0; i < nVertNo; i++)
            {
                Vertex3D vert = m_3dChart[i];

                double r = 0.15 * Math.Sqrt((vert.x - xC) * (vert.x - xC) + (vert.y - yC) * (vert.y - yC));
                if (r < 1e-10) zV = 1;
                else zV = Math.Sin(r) / r;

                m_3dChart[i].z = (float)zV;
            }
            m_3dChart.GetDataRange();

            // 3. set the surface chart color according to z vaule
            double zMin = m_3dChart.ZMin();
            double zMax = m_3dChart.ZMax();
            for (int i = 0; i < nVertNo; i++)
            {
                Vertex3D vert = m_3dChart[i];
                double h = (vert.z - zMin) / (zMax - zMin);

                Color color = P2Space.TextureMapping.PseudoColor(h);
                m_3dChart[i].color = color;
            }

            // 4. Get the Mesh3D array from surface chart
            ArrayList meshs = ((UniformSurfaceChart3D)m_3dChart).GetMeshes();

            // 5. display vertex no and triangle no of this surface chart
            UpdateModelSizeInfo(meshs);

            // 6. Set the model display of surface chart
            P2Space.Model3D model3d = new P2Space.Model3D();
            Material backMaterial = new DiffuseMaterial(new SolidColorBrush(Colors.Gray));
            m_nChartModelIndex = model3d.UpdateModel(meshs, backMaterial, m_nChartModelIndex, this.mainViewport);

            // 7. set projection matrix, so the data is in the display region
            float xMin = m_3dChart.XMin();
            float xMax = m_3dChart.XMax();
            m_transformMatrix.CalculateProjectionMatrix(xMin, xMax, xMin, xMax, zMin, zMax, 0.5);
            TransformChart();
        }

        // function for testing 3d scatter plot
        public void TestScatterPlot(int nDotNo)
        {
            // 1. set scatter chart data no.
            m_3dChart = new ScatterChart3D();
            m_3dChart.SetDataNo(nDotNo);

            // 2. set property of each dot (size, position, shape, color)
            Random randomObject = new Random();
            int nDataRange = 200;
            for (int i = 0; i < nDotNo; i++)
            {
                ScatterPlotItem plotItem = new ScatterPlotItem();

                plotItem.w = 4;
                plotItem.h = 6;

                plotItem.x = (float)randomObject.Next(nDataRange);
                plotItem.y = (float)randomObject.Next(nDataRange);
                plotItem.z = (float)randomObject.Next(nDataRange);

                plotItem.shape = randomObject.Next(4);

                Byte nR = (Byte)randomObject.Next(256);
                Byte nG = (Byte)randomObject.Next(256);
                Byte nB = (Byte)randomObject.Next(256);

                plotItem.color = Color.FromRgb(nR, nG, nB);
                ((ScatterChart3D)m_3dChart).SetVertex(i, plotItem);
            }

            // 3. set the axes
            m_3dChart.GetDataRange();
            m_3dChart.SetAxes();

            // 4. get Mesh3D array from the scatter plot
            ArrayList meshs = ((ScatterChart3D)m_3dChart).GetMeshes();

            // 5. display model vertex no and triangle no
            UpdateModelSizeInfo(meshs);

            // 6. display scatter plot in Viewport3D
            P2Space.Model3D model3d = new P2Space.Model3D();
            m_nChartModelIndex = model3d.UpdateModel(meshs, null, m_nChartModelIndex, this.mainViewport);

            // 7. set projection matrix
            float viewRange = (float)nDataRange;
            m_transformMatrix.CalculateProjectionMatrix(0, viewRange, 0, viewRange, 0, viewRange, 0.5);
            TransformChart();
        }

        // function for set a scatter plot, every dot is just a simple pyramid.
        public void TestSimpleScatterPlot(int nDotNo)
        {
            // 1. set the scatter plot size
            m_3dChart = new ScatterChart3D();
            m_3dChart.SetDataNo(nDotNo);

            // 2. set the properties of each dot
            Random randomObject = new Random();
            int nDataRange = 200;
            for (int i = 0; i < nDotNo; i++)
            {
                ScatterPlotItem plotItem = new ScatterPlotItem();

                plotItem.w = 2;
                plotItem.h = 2;

                plotItem.x = (float)randomObject.Next(nDataRange);
                plotItem.y = (float)randomObject.Next(nDataRange);
                plotItem.z = (float)randomObject.Next(nDataRange);

                plotItem.shape = (int)Chart3D.SHAPE.PYRAMID;

                Byte nR = (Byte)randomObject.Next(256);
                Byte nG = (Byte)randomObject.Next(256);
                Byte nB = (Byte)randomObject.Next(256);

                plotItem.color = Color.FromRgb(nR, nG, nB);
                ((ScatterChart3D)m_3dChart).SetVertex(i, plotItem);
            }
            // 3. set axes
            m_3dChart.GetDataRange();
            m_3dChart.SetAxes();

            // 4. Get Mesh3D array from scatter plot
            ArrayList meshs = ((ScatterChart3D)m_3dChart).GetMeshes();

            // 5. display vertex no and triangle no.
            UpdateModelSizeInfo(meshs);

            // 6. show 3D scatter plot in Viewport3d
            P2Space.Model3D model3d = new P2Space.Model3D();
            m_nChartModelIndex = model3d.UpdateModel(meshs, null, m_nChartModelIndex, this.mainViewport);

            // 7. set projection matrix
            float viewRange = (float)nDataRange;
            m_transformMatrix.CalculateProjectionMatrix(0, viewRange, 0, viewRange, 0, viewRange, 0.5);
            TransformChart();
        }
        private void Init_plot(Axis_L a, float x, float y, float z, double argX, double argY)
        {
            // 1. set the scatter plot size
            Random randomObject = new Random();
            m_3dChart = new Chart3D();
            Chart3D tmp_3dChart = new Chart3D();
            ScatterPlotItem plotItem = new ScatterPlotItem();

            plotItem.w = 0.5f;
            plotItem.h = 0.5f;
            plotItem.x = x;
            plotItem.y = y;
            plotItem.z = z;
            plotItem.shape = (int)Chart3D.SHAPE.ELLIPSE;

            Byte nR = (Byte)randomObject.Next(256);
            Byte nG = (Byte)randomObject.Next(256);
            Byte nB = (Byte)randomObject.Next(256);

            plotItem.color = Color.FromRgb(nR, nG, nB);

            Mesh3D dot = new Ellipse3D(1, 1, 1, 10);

            TransformMatrix.Transform(dot, new Point3D(plotItem.x, plotItem.y, plotItem.z), 0, 0);
            tmp_3dChart.SetAxes(plotItem.x, plotItem.y, plotItem.z, 20, 20, 20);
            dot.SetColor(plotItem.color);
            m_3dChart.SetAxes(0, 0, 0, a.x_l, a.y_l, a.z_l);

            // 4. Get Mesh3D array from scatter plot
            ArrayList meshs = meshes_all;
            m_3dChart.AddAxesMeshes(meshs);
            tmp_3dChart.AddAxesMeshes2point(meshs, argX, argY);
            meshs.Add(dot);
            // 5. display vertex no and triangle no.
            meshes_all = meshs;
            pre_point = new Point3D(x, y, z);
            start_point = new Point3D(x, y, z);
        }
        private void Move_plot(Axis_L a, float x, float y, float z, double argX, double argY)
        {
            axis = Set_range(axis, (float)pre_point.X, (float)pre_point.Y, (float)pre_point.Z);
            // 1. set the scatter plot size
            Random randomObject = new Random();
            m_3dChart = new Chart3D();
            Chart3D tmp_3dChart = new Chart3D();
            int nDataRange = 200;
            ScatterPlotItem plotItem = new ScatterPlotItem();

            plotItem.w = 0.5f;
            plotItem.h = 0.5f;
            plotItem.x = x;
            plotItem.y = y;
            plotItem.z = z;
            plotItem.shape = (int)Chart3D.SHAPE.ELLIPSE;

            Byte nR = (Byte)randomObject.Next(256);
            Byte nG = (Byte)randomObject.Next(256);
            Byte nB = (Byte)randomObject.Next(256);

            plotItem.color = Color.FromRgb(nR, nG, nB);

            Mesh3D dot = new Ellipse3D(1, 1, 1, 10);

            TransformMatrix.Transform(dot, new Point3D(plotItem.x, plotItem.y, plotItem.z), 0, 0);
            tmp_3dChart.SetAxes(plotItem.x, plotItem.y, plotItem.z, 20, 20, 20);
            dot.SetColor(plotItem.color);
            m_3dChart.SetAxes(0, 0, 0, a.x_l, a.y_l, a.z_l);

            // 4. Get Mesh3D array from scatter plot
            ArrayList meshs = meshes_all;
            pre_arg.X += argX;
            pre_arg.Y += argY;
            m_3dChart.AddAxesMeshes(meshs);
            tmp_3dChart.AddAxesMeshes2point(meshs, pre_arg.X, pre_arg.Y);
            meshs.Add(dot);
            // 5. display vertex no and triangle no.
            UpdateModelSizeInfo(meshs);

            // 6. show 3D scatter plot in Viewport3d
            P2Space.Model3D model3d = new P2Space.Model3D();
            m_nChartModelIndex = model3d.UpdateModel(meshs, null, m_nChartModelIndex, this.mainViewport);
            float viewRange = (float)nDataRange;
            m_transformMatrix.CalculateProjectionMatrix(0, viewRange, 0, viewRange, 0, viewRange, 0.5);

            TransformChart();
            meshes_all = meshs;
            pre_point = new Point3D(x, y, z);
          
        }
        private void Move_plot(Axis_L a, Quaternion q)
        {
            axis = Set_range(axis, (float)pre_point.X, (float)pre_point.Y, (float)pre_point.Z);
            // 1. set the scatter plot size
            Random randomObject = new Random();
            m_3dChart = new Chart3D();
            Chart3D tmp_3dChart = new Chart3D();
            int nDataRange = 200;

            tmp_3dChart.SetAxes((float)start_point.X, (float)start_point.Y, (float)start_point.Z, 20, 20, 20);
            m_3dChart.SetAxes(0, 0, 0, a.x_l, a.y_l, a.z_l);

            // 4. Get Mesh3D array from scatter plot
            ArrayList meshs = meshes_all;
            pre_q *= q;
            m_3dChart.AddAxesMeshes(meshs);
            tmp_3dChart.AddAxesMeshes2point(meshs, pre_q);
            pre_point = TransformMatrix.Transform(start_point, pre_q);
            ScatterPlotItem plotItem = new ScatterPlotItem();

            plotItem.w = 0.5f;
            plotItem.h = 0.5f;
            plotItem.x = (float)pre_point.X;
            plotItem.y = (float)pre_point.Y;
            plotItem.z = (float)pre_point.Z;
            plotItem.shape = (int)Chart3D.SHAPE.ELLIPSE;

            Byte nR = (Byte)randomObject.Next(256);
            Byte nG = (Byte)randomObject.Next(256);
            Byte nB = (Byte)randomObject.Next(256);

            plotItem.color = Color.FromRgb(nR, nG, nB);

            Mesh3D dot = new Ellipse3D(1, 1, 1, 10);
            dot.SetColor(plotItem.color);
            TransformMatrix.Transform(dot, new Point3D(pre_point.X, pre_point.Y, pre_point.Z), 0, 0);
            meshs.Add(dot);
            //     meshs.Add(dot);
            // 5. display vertex no and triangle no.
            UpdateModelSizeInfo(meshs);

            // 6. show 3D scatter plot in Viewport3d
            P2Space.Model3D model3d = new P2Space.Model3D();
            m_nChartModelIndex = model3d.UpdateModel(meshs, null, m_nChartModelIndex, this.mainViewport);
            float viewRange = (float)nDataRange;
            m_transformMatrix.CalculateProjectionMatrix(0, viewRange, 0, viewRange, 0, viewRange, 0.5);

            TransformChart();
            meshes_all = meshs;
           
        }
        public void OnViewportMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs args)
        {
            Point pt = args.GetPosition(mainViewport);
            if (args.ChangedButton == MouseButton.Left)         // rotate or drag 3d model
            {
                m_transformMatrix.OnLBtnDown(pt, 0);
            }
            else if (args.ChangedButton == MouseButton.Right)   // select rect
            {
                //  m_selectRect.OnMouseDown(pt, mainViewport, m_nRectModelIndex);
                m_transformMatrix.OnLBtnDown(pt, 1);
            }
        }

        public void OnViewportMouseMove(object sender, System.Windows.Input.MouseEventArgs args)
        {
            Point pt = args.GetPosition(mainViewport);

            //if (args.LeftButton == MouseButtonState.Pressed)                // rotate or drag 3d model
            //{
            if (args.RightButton != MouseButtonState.Pressed) m_transformMatrix.OnLBtnUp(1);
            if (args.LeftButton != MouseButtonState.Pressed) m_transformMatrix.OnLBtnUp(0);

            m_transformMatrix.OnMouseMove(pt, mainViewport);

            TransformChart();
            //}
            //else if (args.RightButton == MouseButtonState.Pressed)          // select rect
            //{
            //    m_selectRect.OnMouseMove(pt, mainViewport, m_nRectModelIndex);
            //}
            //else
            //{
            //    /*
            //    String s1;
            //    Point pt2 = m_transformMatrix.VertexToScreenPt(new Point3D(0.5, 0.5, 0.3), mainViewport);
            //    s1 = string.Format("Screen:({0:d},{1:d}), Predicated: ({2:d}, H:{3:d})", 
            //        (int)pt.X, (int)pt.Y, (int)pt2.X, (int)pt2.Y);
            //    this.statusPane.Text = s1;
            //    */
            //}
        }

        public void OnViewportMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs args)
        {
            Point pt = args.GetPosition(mainViewport);
            if (args.ChangedButton == MouseButton.Left)
            {
                m_transformMatrix.OnLBtnUp(0);
            }
            else if (args.ChangedButton == MouseButton.Right)
            {
                //if (m_nChartModelIndex == -1) return;
                //// 1. get the mesh structure related to the selection rect
                //MeshGeometry3D meshGeometry = Model3D.GetGeometry(mainViewport, m_nChartModelIndex);
                //if (meshGeometry == null) return;

                //// 2. set selection in 3d chart
                //m_3dChart.Select(m_selectRect, m_transformMatrix, mainViewport);

                //// 3. update selection display
                //m_3dChart.HighlightSelection(meshGeometry, Color.FromRgb(200, 200, 200));
                m_transformMatrix.OnLBtnUp(1);
            }
        }

        // zoom in 3d display
        public void OnKeyDown(object sender, System.Windows.Input.KeyEventArgs args)
        {
            m_transformMatrix.OnKeyDown(args);
            TransformChart();
        }

        //private void surfaceButton_Click(object sender, RoutedEventArgs e)
        //{
        //    int nGridNo = Int32.Parse(gridNo.Text);
        //    if (nGridNo < 2) return;
        //    if (nGridNo > 500)
        //    {
        //        MessageBox.Show("too many data");
        //        return;
        //    }
        //    TestSurfacePlot(nGridNo);
        //}

        //private void scatterButton_Click(object sender, RoutedEventArgs e)
        //{
        //    int nDataNo = Int32.Parse(dataNo.Text);
        //    if (nDataNo < 3) return;

        //    if ((bool)checkBoxShape.IsChecked)
        //    {
        //        if (nDataNo > 10000)
        //        {
        //            MessageBox.Show("too many data");
        //            return;
        //        }
        //        TestScatterPlot(nDataNo);
        //    }
        //    else
        //    {
        //        if (nDataNo > 100000)
        //        {
        //            MessageBox.Show("too many data");
        //            return;
        //        }
        //        TestSimpleScatterPlot(nDataNo);
        //    }
        //}

        private void UpdateModelSizeInfo(ArrayList meshs)
        {
            int nMeshNo = meshs.Count;
            int nChartVertNo = 0;
            int nChartTriangelNo = 0;
            for (int i = 0; i < nMeshNo; i++)
            {
                nChartVertNo += ((Mesh3D)meshs[i]).GetVertexNo();
                nChartTriangelNo += ((Mesh3D)meshs[i]).GetTriangleNo();
            }
            //labelVertNo.Content = String.Format("Vertex No: {0:d}", nChartVertNo);
            //labelTriNo.Content = String.Format("Triangle No: {0:d}", nChartTriangelNo);
        }

        // this function is used to rotate, drag and zoom the 3d chart
        private void TransformChart()
        {
            if (m_nChartModelIndex == -1) return;
            ModelVisual3D visual3d = (ModelVisual3D)(this.mainViewport.Children[m_nChartModelIndex]);
            if (visual3d.Content == null) return;
            Transform3DGroup group1 = visual3d.Content.Transform as Transform3DGroup;
            group1.Children.Clear();
            group1.Children.Add(new MatrixTransform3D(m_transformMatrix.m_totalMatrix));
        }
        int aa = 100;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Tr(100, aa);
            aa += 10;
        }
    }
}
