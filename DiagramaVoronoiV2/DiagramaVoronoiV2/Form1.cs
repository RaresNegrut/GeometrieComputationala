using DiagramaVoronoi.BusinessLogic;
using DiagramaVoronoi.Entities;
using DiagramaVoronoi.Renderer;
using System.Drawing;
using System.Windows.Forms;

namespace DiagramaVoronoiV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            Renderer.InitGraph(pictureBox1);
            this.BackColor = Color.Aquamarine;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Voronoi.InitializeRealm(10);
            Voronoi.DrawRealm();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < Renderer.rezx; i++)
            {
                for (int j = 0; j < Renderer.rezy; j++)
                {
                    MyPoint A = Voronoi.GetNearestObject(new PointF(i, j));
                    if (A != null)
                        Renderer.grp.FillEllipse(new SolidBrush(A.FillColor), i, j, 2, 2);
                }
            }
            Voronoi.DrawRealm();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            Renderer.ClearGraph();
            Voronoi.Points.Clear();
            Renderer.RefreshGraph();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Voronoi.Points = File.LoadFile(@"..\..\Points.txt");
            Voronoi.DrawRealm();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            string[] point = richTextBox1.Text.Split(' ');
            MyPoint minPoint = new MyPoint();

            MyPoint MyPoint = new MyPoint(float.Parse(point[0]), float.Parse(point[1]));
            MyPoint.Draw();

            float minDistance = float.MaxValue;

            for (int i = 0; i < Voronoi.Points.Count; i++)
            {
                float distance = Voronoi.EuclideanDistance(Voronoi.Points[i].GetPoint(), MyPoint.GetPoint());
                if (distance < minDistance)
                {
                    minPoint = Voronoi.Points[i];
                    minDistance = distance;
                }
            }
            richTextBox2.Text = $"{minDistance}";
            Renderer.grp.DrawLine(Pens.Black, minPoint.GetPoint(), MyPoint.GetPoint());
            Renderer.RefreshGraph();
        }
    }
}
