using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProiectFinal
{
    static class Manager
    {
        public static int NrOfShapes { get; set; }

        public static string SelectedShape { get; set; } = "";

        static void randomLines()
        {
            var rand = new Random();

            for (int i= 0; i < NrOfShapes; i++)
            {
                Point leftPoint = new Point(rand.Next(0, Form1.bmp.Height), 0);
                Point downPoint = new Point(Form1.bmp.Height, rand.Next(0, Form1.bmp.Width));
                Point rightPoint = new Point(rand.Next(0, Form1.bmp.Height), Form1.bmp.Width);
                Point upPoint = new Point(0, rand.Next(0, Form1.bmp.Width));

                List<Point> sides = new List<Point>() { leftPoint, downPoint, rightPoint, upPoint};

                Point A = sides[rand.Next(0, sides.Count())];
                sides.Remove(A);
                Point B = sides[rand.Next(0, sides.Count())];

                Linie l = new Linie(A,B);
                l.deseneaza();
            }
        }
        
        public static void drawShapes()
        {
            switch(SelectedShape)
            {
                case "Linie":
                    randomLines();
                    break;
                case "Drepthunghi":
                    break;
            }
        }
    }
}
