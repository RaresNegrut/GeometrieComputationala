using System;
using System.Drawing;
namespace DiagramaVoronoi.Entities
{
    public class MyPoint
    {
        static Random RandomColor = new Random();
        static Random RandomCoordinate = new Random();
        public static Point DrawableSurface { get; set; } = Renderer.Renderer.GetDrawableSurface();
        public static int Size { get; private set; } = 5;
        public float X { get; private set; }
        public float Y { get; private set; }
        public Color FillColor { get; private set; }
        public MyPoint(float x,float y)
        {
            X = x;
            Y = y;
            FillColor = GetRandomColor();
        }
        public MyPoint()
        {
            PointF RandomPoint = GetRandomPoint();
            X = RandomPoint.X;
            Y = RandomPoint.Y;
            FillColor = GetRandomColor();
        }
        public static Color GetRandomColor()
        {
            
            return Color.FromArgb(RandomColor.Next(256), RandomColor.Next(256), RandomColor.Next(256));
        }
        public static PointF GetRandomPoint()
        {
            
            PointF RandomPoint = new PointF(RandomCoordinate.Next(DrawableSurface.X),RandomCoordinate.Next(DrawableSurface.Y));
            return RandomPoint;
        }
        public void Draw()
        {
            Renderer.Renderer.grp.FillEllipse(new SolidBrush(FillColor), X - Size, Y - Size, 2 * Size + 1, 2 * Size + 1);
            Renderer.Renderer.grp.DrawEllipse(new Pen(Color.Black), X - Size, Y - Size, 2 * Size + 1, 2 * Size + 1);
        }
        public PointF GetPoint()
        {
            return new PointF(X, Y);
        }
    }
}
