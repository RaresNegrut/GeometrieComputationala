using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triunghi
{
    public partial class Form1 : Form
    {
        static Graphics gfx;
        static Pen pen = new Pen(Color.Black);
        static PointF[] points;
        public Form1()
        {
            InitializeComponent();
        }

        private void Draw_Click(object sender, EventArgs e)
        {

            points = new PointF[]
            {
                new PointF(float.Parse(textBox1.Text),float.Parse(textBox2.Text)),
                new PointF(float.Parse(textBox4.Text),float.Parse(textBox3.Text)),
                new PointF(float.Parse(textBox6.Text),float.Parse(textBox5.Text)),
            };

            gfx.Clear(Color.White);
            gfx.DrawPolygon(pen, points);
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gfx = pictureBox1.CreateGraphics();
        }

        private void Medians_Click(object sender, EventArgs e)
        {
            PointF midline1 = new PointF(((points[1].X + points[2].X) / 2), ((points[1].Y + points[2].Y) / 2));
            gfx.DrawLine(pen, points[0], midline1);
            PointF midline2 = new PointF(((points[0].X + points[2].X) / 2), ((points[0].Y + points[2].Y) / 2));
            gfx.DrawLine(pen, points[1], midline2);
            PointF midline3 = new PointF(((points[0].X + points[1].X) / 2), ((points[0].Y + points[1].Y) / 2));
            gfx.DrawLine(pen, points[2], midline3);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            gfx.Clear(Color.White);
        }
    }
}
