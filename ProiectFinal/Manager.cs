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
        void randomLines(Graphics g, Bitmap bmp, int nrOfShapes)
        {
            var rand = new Random();

            for (int i= 0; i < nrOfShapes; i++)
            {
                Point leftPoint = new Point(rand.Next(-1, bmp.Height + 2), -1);
                Point downPoint = new Point(bmp.Height + 2, rand.Next(0, bmp.Width + 2));
                Point rightPoint = new Point(rand.Next(-1, bmp.Height + 2), bmp.Width + 2);
                Point upPoint = new Point(-1, rand.Next(-1, bmp.Width + 2));

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

        void randomShapes(Graphics g, Bitmap bmp, int nrOfShapes)
        {
            var rand = new Random();

            for (int i = 0; i < nrOfShapes; i++)
            {
                int shapeChosen = rand.Next(0, 5);
                switch (shapeChosen)
                {
                    case 0:
                        randomLines(g, bmp, 1);
                        break;
                    case 1:
                        randomRectangles(g, bmp, 1);
                        break;
                    case 2:
                        randomTriangles(g, bmp, 1);
                        break;
                    case 3:
                        randomElipses(g, bmp, 1);
                        break;
                    case 4:
                        randomBeziers(g, bmp, 1);
                        break;
                }
            }
        }

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
                case "Random":
                    randomShapes(g, bmp, nrOfShapes);
                    break;
            }
        }

        bool inside(Bitmap bmp, Point p)
        {
            return p.X >= 0 && p.X < bmp.Width && p.Y >= 0 && p.Y < bmp.Height;
        }

        bool validPoint(Bitmap bmp, Point origin, Point p)
        {
            if (bmp.GetPixel(p.X, p.Y) == Figura.ShapeColor ||
                bmp.GetPixel(p.X, p.Y) == bmp.GetPixel(origin.X, origin.Y))
            {
                return false;
            }
                
            return true;
        }

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

       
        public Dictionary<char, double> calculateInk(Bitmap bitmap, double sideLength, double inkConsumption)
        {
            const double cmPerPx = 0.0264583333;

            double C = 0, M = 0, Y = 0, K = 0;

            for(int i=0;i<bitmap.Width;i++)
            {
                for(int j=0;j<bitmap.Height;j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    double R1 = c.R / 255d;
                    double G1 = c.G / 255d;
                    double B1 = c.B / 255d;
                    double K1 = 1 - Math.Max(Math.Max(R1, G1), B1);
                    
                    if(K1 != 1)
                    {
                        C += (1d - R1 - K1) / (1d - K1);
                        M += (1d - G1 - K1) / (1d - K1);
                        Y += (1d - B1 - K1) / (1d - K1);
                    }
                    
                    K += K1;
                }
            }

            var consumption = new Dictionary<char, double>();

            double S = (bitmap.Width * cmPerPx) * (bitmap.Width * cmPerPx); //surface of the bitmap(converted in cm)
            double cT = S * inkConsumption; //consumption for the entire surface

            consumption['C'] = cT * C / (C + M + Y + K);
            consumption['M'] = cT * M / (C + M + Y + K);
            consumption['Y'] = cT * Y / (C + M + Y + K);
            consumption['K'] = cT * K / (C + M + Y + K);


            double convertMultiplier = sideLength / (bitmap.Width * cmPerPx);

            consumption['C'] *= convertMultiplier; 
            consumption['M'] *= convertMultiplier;
            consumption['Y'] *= convertMultiplier;
            consumption['K'] *= convertMultiplier;

            return consumption;
        }
    }
}
