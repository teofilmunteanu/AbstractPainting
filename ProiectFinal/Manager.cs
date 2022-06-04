using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProiectFinal
{
    class Manager
    {
        //public static Graphics G { get; set; }
        //public static Bitmap Bmp { get; set; }
        Graphics g;
        Bitmap bmp;
        double R, G, B;
        double C, M, Y, K;

        public Manager(Bitmap b)
        {
            bmp = b;
            g = Graphics.FromImage(bmp);
        }
        //public static void reset()
        public void reset()
        {
            Color bgColor = Color.White;
            g.Clear(bgColor);
        }

        ///////////////////////////////////////////void randomShapes(int nrOfShapes)

        //static void randomLines(int nrOfShapes)
        void randomLines(int nrOfShapes)
        {
            var rand = new Random();

            for (int i= 0; i < nrOfShapes; i++)
            {
                Point leftPoint = new Point(rand.Next(0, bmp.Height), 0);
                Point downPoint = new Point(bmp.Height, rand.Next(0, bmp.Width));
                Point rightPoint = new Point(rand.Next(0, bmp.Height), bmp.Width);
                Point upPoint = new Point(0, rand.Next(0, bmp.Width));

                List<Point> sides = new List<Point>() { leftPoint, downPoint, rightPoint, upPoint};

                Point A = sides[rand.Next(0, sides.Count())];
                sides.Remove(A);
                Point B = sides[rand.Next(0, sides.Count())];

                Linie l = new Linie(A,B);
                l.deseneaza(g);  
            }
        }

        //public static void drawShapes(int nrOfShapes, string selectedShape)
        public void drawShapes(int nrOfShapes, string selectedShape)
        {
            switch(selectedShape)
            {
                case "Line":
                    randomLines(nrOfShapes);
                    break;
                case "Rectangle":
                    break;
                case "Elipse":
                    break;
            }
        }

        //static bool inside(Point p)
        bool inside(Point p)
        {
            return p.X >= 0 && p.X < bmp.Width && p.Y >= 0 && p.Y < bmp.Height;
        }
        //static bool validPoint(Point origin, Point p)
        bool validPoint(Point origin, Point p)
        {
            if (bmp.GetPixel(p.X, p.Y) == Figura.ShapeColor ||
                bmp.GetPixel(p.X, p.Y) == bmp.GetPixel(origin.X, origin.Y))
            {
                return false;
            }
                
            return true;
        }
        //public static void fill(Point origin, Color fillColor)
        public void fill(Point origin, Color fillColor)
        {
            Point[] directions = { new Point(-1, 0), new Point(0, -1), new Point(1, 0), new Point(0, 1) };
            Queue<Point> pointsToFill = new Queue<Point>();
            pointsToFill.Enqueue(origin);

            while(pointsToFill.Any())
            {
                Point current = pointsToFill.Dequeue();

                if(bmp.GetPixel(current.X, current.Y) != Figura.ShapeColor)
                {
                    bmp.SetPixel(current.X, current.Y, fillColor);

                    R += fillColor.R / 255;
                    G += fillColor.G / 255;
                    B += fillColor.B / 255;
                }

                foreach (Point d in directions)
                {
                    Point neighbour = new Point(current.X + d.X, current.Y + d.Y);
                    if (inside(neighbour) && validPoint(current, neighbour) && !pointsToFill.Contains(neighbour))
                    {
                        pointsToFill.Enqueue(neighbour);
                    }
                }
            }   
        }

        public Dictionary<char, double> CalculateInk(double sideLength, double inkConsumption)
        {
            var consumption = new Dictionary<char, double>();

            K = 1 - Math.Max(Math.Max(R, G), B);

            if(K == 1)
            {
                C = M = Y = 0;
            }
            else
            {
                C = (1 - R - K) / (1 - K);
                M = (1 - G - K) / (1 - K);
                Y = (1 - B - K) / (1 - K);
            }

            double S = sideLength * sideLength;
            double cT = S / inkConsumption;

            consumption['C'] = cT * C / (C + M + Y + K);
            consumption['M'] = cT * M / (C + M + Y + K);
            consumption['Y'] = cT * Y / (C + M + Y + K);
            consumption['k'] = cT * K / (C + M + Y + K);

            return consumption;
        }



    }
}
