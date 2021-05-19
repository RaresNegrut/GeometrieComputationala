using DiagramaVoronoi.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
namespace DiagramaVoronoi.BusinessLogic
{
    public static class Voronoi
    {
        public static List<MyPoint> Points = new List<MyPoint>();
        public static void InitializeRealm(int n)
        {
            for (int i = 0; i < n; i++)
                Points.Add(new MyPoint());
        }

        public static void DrawRealm()
        {
            foreach (MyPoint m in Points)
                m.Draw();
            Renderer.Renderer.RefreshGraph();
        }

        public static MyPoint GetNearestObject(PointF T)
        {

            float dMin = EuclideanDistance(T, Points[0].GetPoint());
            int poz = 0;
            for (int i = 1; i < Points.Count; i++)
            {
                float dcrt = ChebyshevDistance(T, Points[i].GetPoint());
                if (dMin > dcrt)
                {
                    dMin = dcrt;
                    poz = i;
                }
            }
            return Points[poz];
        }
        public static float EuclideanDistance(System.Drawing.PointF A, System.Drawing.PointF B)
        {
            return (float)Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }
        public static float ManhattanDistance(System.Drawing.PointF A, System.Drawing.PointF B)
        {
            return (float)(Math.Abs(A.X - B.X) + Math.Abs(A.Y - B.Y));
        }
        public static float ChebyshevDistance(System.Drawing.PointF A, System.Drawing.PointF B)
        {
            float dX = Math.Abs(A.X - B.X);
            float dY = Math.Abs(A.Y - B.Y);
            return Math.Max(dX, dY);
        }
    }
}
