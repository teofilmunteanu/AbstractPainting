using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProiectFinal
{
    public abstract class Figura
    {
        protected Point origin, final;
        protected Pen shapePen;
        public static Color ShapeColor { get; protected set; }
        public static float ShapeWidth { get; protected set; }

        public Figura()
        {
            ShapeColor = Color.FromArgb(255, 0, 0, 0);
            ShapeWidth = 2;

            shapePen = new Pen(ShapeColor, ShapeWidth);
        }

        abstract public void deseneaza(Graphics g);

        abstract public double daLungime();

    }

    public class Linie : Figura
    {
        public Linie(Point origin, Point final)
        {
            this.origin = origin;
            this.final = final;   
        }

        override public void deseneaza(Graphics g)
        {
            g.DrawLine(shapePen, origin, final);
        }

        override public double daLungime()
        {
            return Math.Sqrt(Math.Pow(origin.X - final.X, 2) + Math.Pow(origin.Y - final.Y, 2));
        }
    }

    class Dreptunghi : Figura
    {
        Size size;
        public Dreptunghi(Point origin, Point final)
        {
            this.origin = origin;
            size = new Size(Math.Abs(final.X - origin.X), Math.Abs(final.Y - origin.Y));
        }

        override public void deseneaza(Graphics g)
        {
            Rectangle r = new Rectangle(origin, size);
            g.DrawRectangle(shapePen, r);
        }

        override public double daLungime()
        {
            return 2 * size.Width + 2 * size.Height;
        }
    }

    class Triunghi : Figura
    {
        Linie l1, l2, l3;
        Point inter;

        public Triunghi(Point origin, Point inter, Point final)
        {
            this.origin = origin;
            this.inter = inter;
            this.final = final;
        }

        override public void deseneaza(Graphics g)
        {
            l1 = new Linie(origin, inter);
            l2 = new Linie(inter, final);
            l3 = new Linie(final, origin);

            l1.deseneaza(g);
            l2.deseneaza(g);
            l3.deseneaza(g);
        }

        override public double daLungime()
        {
            return l1.daLungime() + l2.daLungime() + l3.daLungime();
        }
    }

    class Elipsa : Figura
    {
        Size size;
        public Elipsa(Point origin, Point final)
        {
            this.origin = origin;
            size = new Size(Math.Abs(final.X - origin.X), Math.Abs(final.Y - origin.Y));
        }

        override public void deseneaza(Graphics g)
        {
            Rectangle r = new Rectangle(origin, size);
            g.DrawEllipse(shapePen, r);
        }

        override public double daLungime()
        {
            //Ramanujan
            double a = size.Width / 2; //semiMajorAxis
            double b = size.Height / 2;//semiMinorAxis
            double h = (a - b) * (a - b) / ((a + b) * (a + b));
            return Math.PI * (a + b) * (1 + 3 * h / (10 + Math.Sqrt(4 - 3 * h)));
        }
    }

    class Bezier : Figura
    {
        Point inter1, inter2;
        public Bezier(Point p1, Point p2, Point p3, Point p4)
        {
            origin = p1;
            inter1 = p2;
            inter2 = p3;
            final = p4;
        }

        override public void deseneaza(Graphics g)
        {
            g.DrawBezier(shapePen, origin, inter1, inter2, final);
        }

        override public double daLungime() //very rough aproximation
        {
            Linie line = new Linie(origin, final);

            Linie segment1 = new Linie(origin, inter1);
            Linie segment2 = new Linie(inter1, inter2);
            Linie segment3 = new Linie(inter2, final);

            double aprox_length = ((segment1.daLungime() + segment2.daLungime() + segment3.daLungime()) + line.daLungime()) / 2;

            return aprox_length;
        }
    }
}
