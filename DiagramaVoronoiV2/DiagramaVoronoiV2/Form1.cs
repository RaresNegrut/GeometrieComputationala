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
            Voronoi.InitializeRealm(20);
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
    }
}
