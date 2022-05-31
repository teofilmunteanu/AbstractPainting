using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProiectFinal
{
    abstract class Figura
    {
        protected Rectangle r;
        Bitmap bmp;

        public Figura()
        {

        }

        abstract public void deseneaza(Point origin, Point final);

    }

    class Linie : Figura
    {
        override public void deseneaza(Point origin, Point final)
        {

        }
    }

    //class Dreptunghi : Figura
    //{

    //}

    //class Elipsa : Figura
    //{

    //}
}
