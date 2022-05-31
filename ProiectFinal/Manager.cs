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
        public static Graphics? g;
        public static Bitmap bmp;
        public static Pen mainPen = new Pen(Color.Black, 2f);
        public static Brush mainBrush = new SolidBrush(mainColor);
        public static Color mainColor = Color.White;
    }
}
