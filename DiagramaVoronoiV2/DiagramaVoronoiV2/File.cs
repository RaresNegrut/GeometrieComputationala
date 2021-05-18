using DiagramaVoronoi.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramaVoronoiV2
{
    public static class File
    {
        public static List<MyPoint> LoadFile(string fileName)
        {
            TextReader dataLoad = new StreamReader(fileName);
            List<string[]> data = new List<string[]>();
            string buffer;
            while ((buffer = dataLoad.ReadLine()) != null)
                data.Add(buffer.Split(' '));

            List<MyPoint> points = new List<MyPoint>();
            for (int i = 0; i < data.Count; i++)
                points.Add(new MyPoint(float.Parse(data[i][0]), float.Parse(data[i][1])));
            return points;
        }
    }
}
