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

        public static Pen ShapePen { get; set; }

        abstract public void deseneaza();

        abstract public double daLungime();

    }

    public class Linie : Figura
    {
        public Linie(Point origin, Point final)
        {
            this.origin = origin;
            this.final = final;   
        }

        override public void deseneaza()
        {
            Form1.g.DrawLine(ShapePen, origin, final);
        }

        override public double daLungime()
        {
            return Math.Sqrt(Math.Pow(origin.X - final.X, 2) + Math.Pow(origin.Y - final.Y, 2));
        }
    }

    //class Dreptunghi : Figura
    //{
    //    Size size;
    //    public Dreptunghi(Point origin, Point final)
    //    {
    //        this.origin = origin;
    //        size = new Size(Math.Abs(final.X - origin.X), Math.Abs(final.Y - origin.Y));
    //    }
         
    //    override public void deseneaza()
    //    {
    //        Rectangle r = new Rectangle(origin, size);
    //        Manager.g.DrawRectangle(shapePen, r);
    //    }
    //}

    //class Elipsa : Figura
    //{

    //}
}
