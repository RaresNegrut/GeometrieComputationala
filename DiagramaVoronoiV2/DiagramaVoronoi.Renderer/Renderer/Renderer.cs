using System.Drawing;
using System.Windows.Forms;

namespace DiagramaVoronoi.Renderer
{
    public static class Renderer
    {
        public static Graphics grp;
        public static Bitmap bmp;
        public static Color backColor = Color.Aquamarine;

        public static int rezx, rezy;
        public static PictureBox display;
        public static void InitGraph(PictureBox T)
        {
            display = T;
            rezx = T.Width;
            rezy = T.Height;
            bmp = new Bitmap(rezx, rezy);
            grp = Graphics.FromImage(bmp);
            center = new PointF(rezx / 2, rezy / 2);
            ClearGraph();
            RefreshGraph();
        }
        public static void ClearGraph()
        {
            grp.Clear(backColor);
        }
        public static void RefreshGraph()
        {
            display.Image = bmp;
        }
        public static Point GetDrawableSurface()
        {
            return new Point(rezx, rezy);
        } 
        public static System.Drawing.PointF center;
    }
}
