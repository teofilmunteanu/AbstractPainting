using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectFinal
{
    public partial class Info : Form
    {
        private static Info? instance = null;

        private Info()
        {
            InitializeComponent();

            pictureBoxInfo.Image = resizeImage(pictureBoxInfo.Image, pictureBoxInfo.Width, pictureBoxInfo.Height);
        }

        public static Info getInfo()
        {
            if (instance == null)
            {
                instance = new Info();
            }
            return instance;
        }

        private void Info_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        static Bitmap resizeImage(Image img, int width, int height)
        {
            Bitmap newImage = new Bitmap(width, height);
            Rectangle r = new Rectangle(0, 0, width, height);

            newImage.SetResolution(img.HorizontalResolution, img.VerticalResolution);
            Graphics graphics = Graphics.FromImage(newImage);
            
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var wrap = new ImageAttributes();
            wrap.SetWrapMode(WrapMode.TileFlipXY);
            graphics.DrawImage(img, r, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrap);

            return newImage;
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}
