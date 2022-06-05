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
        static double R, G, B;
        static double C, M, Y, K;

        ///////////////////////////////////////////void randomShapes(int nrOfShapes)

        //static void randomLines(int nrOfShapes)
        void randomLines(Graphics g, Bitmap bmp, int nrOfShapes)
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

        void randomRectangles(Graphics g, Bitmap bmp, int nrOfShapes)
        {
            var rand = new Random();

            for (int i = 0; i < nrOfShapes; i++)
            {
                HashSet<Point> points = new HashSet<Point>();
                while (points.Count < 2)
                {
                    points.Add(new Point(rand.Next(0, bmp.Width), rand.Next(0, bmp.Height)));
                }

                Dreptunghi r = new Dreptunghi(points.ElementAt(0), points.ElementAt(1));
                r.deseneaza(g);
            }
        }

        void randomTriangles(Graphics g, Bitmap bmp, int nrOfShapes)
        {
            var rand = new Random();

            for (int i = 0; i < nrOfShapes; i++)
            {
                HashSet<Point> points = new HashSet<Point>();
                while (points.Count < 3)
                {
                    points.Add(new Point(rand.Next(0, bmp.Width), rand.Next(0, bmp.Height)));
                }

                Triunghi t = new Triunghi(points.ElementAt(0), points.ElementAt(1), points.ElementAt(2));
                t.deseneaza(g);
            }
        }

        void randomElipses(Graphics g, Bitmap bmp, int nrOfShapes)
        {
            var rand = new Random();

            for (int i = 0; i < nrOfShapes; i++)
            {
                HashSet<Point> points = new HashSet<Point>();
                while (points.Count < 2)
                {
                    points.Add(new Point(rand.Next(0, bmp.Width), rand.Next(0, bmp.Height)));
                }

                Elipsa e = new Elipsa(points.ElementAt(0), points.ElementAt(1));
                e.deseneaza(g);
            }
        }

        void randomBeziers(Graphics g, Bitmap bmp, int nrOfShapes)
        {
            var rand = new Random();

            for (int i = 0; i < nrOfShapes; i++)
            {
                HashSet<Point> points = new HashSet<Point>();
                while (points.Count < 4)
                {
                    points.Add(new Point(rand.Next(0, bmp.Width), rand.Next(0, bmp.Height)));
                }

                Bezier b = new Bezier(points.ElementAt(0), points.ElementAt(1), points.ElementAt(2), points.ElementAt(3));
                b.deseneaza(g);
            }
                
        }

        //public static void drawShapes(int nrOfShapes, string selectedShape)
        public void drawShapes(Graphics g, Bitmap bmp, int nrOfShapes, string selectedShape)
        {
            switch(selectedShape)
            {
                case "Line":
                    randomLines(g, bmp, nrOfShapes);
                    break;
                case "Rectangle":
                    randomRectangles(g, bmp, nrOfShapes);
                    break;
                case "Triangle":
                    randomTriangles(g, bmp, nrOfShapes);
                    break;
                case "Elipse":
                    randomElipses(g, bmp, nrOfShapes);
                    break;
                case "Bezier":
                    randomBeziers(g, bmp, nrOfShapes);
                    break;
            }
        }

        //static bool inside(Point p)
        bool inside(Bitmap bmp, Point p)
        {
            return p.X >= 0 && p.X < bmp.Width && p.Y >= 0 && p.Y < bmp.Height;
        }
        //static bool validPoint(Point origin, Point p)
        bool validPoint(Bitmap bmp, Point origin, Point p)
        {
            if (bmp.GetPixel(p.X, p.Y) == Figura.ShapeColor ||
                bmp.GetPixel(p.X, p.Y) == bmp.GetPixel(origin.X, origin.Y))
            {
                return false;
            }
                
            return true;
        }
        //public static void fill(Point origin, Color fillColor)
        public void fill(Bitmap bmp, Point origin, Color fillColor)
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

                    R += fillColor.R/255d;
                    G += fillColor.G/255d;
                    B += fillColor.B/255d;
                }

                foreach (Point d in directions)
                {
                    Point neighbour = new Point(current.X + d.X, current.Y + d.Y);
                    if (inside(bmp, neighbour) && validPoint(bmp, current, neighbour) && !pointsToFill.Contains(neighbour))
                    {
                        pointsToFill.Enqueue(neighbour);
                    }
                }
            }   
        }

        public Dictionary<char, double> calculateInk(double sideLength, double inkConsumption)
        {
            var consumption = new Dictionary<char, double>();

            K = 1 - Math.Max(Math.Max(R, G), B);

            if(K == 1)
            {
                C = M = Y = 0;
            }
            else
            {
                C = (1d - R - K) / (1d - K);
                M = (1d - G - K) / (1d - K);
                Y = (1d - B - K) / (1d - K);
            }

            double S = sideLength * sideLength;
            double cT = S / inkConsumption;

            consumption['C'] = cT * C / (C + M + Y + K);
            consumption['M'] = cT * M / (C + M + Y + K);
            consumption['Y'] = cT * Y / (C + M + Y + K);
            consumption['K'] = cT * K / (C + M + Y + K);

            //consumption['C'] = R;
            //consumption['M'] = G;
            //consumption['Y'] = B;
            //consumption['K'] = K ;

            return consumption;
        }



    }
}
