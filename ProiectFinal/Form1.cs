using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectFinal
{
    public partial class Form1 : Form
    {
        Graphics? g;
        Bitmap bmp;
        Pen mainPen;
        Brush mainBrush;
        Color mainColor;

        public Form1()
        {
            InitializeComponent();

            imgInitializer();
            shapesInitializer();
        }

        void imgInitializer()
        {
            mainColor = Color.White;
            mainPen = new Pen(Color.Black, 2f);
            mainBrush = new SolidBrush(mainColor);

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
            g = Graphics.FromImage(bmp);
            Rectangle imageRectangle = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            g.FillRectangle(mainBrush, imageRectangle);

            pictureBox1.Refresh();
        }

        void shapesInitializer()
        {
            Pen dropdownPen = new Pen(Color.Blue, 3f);

            shapesDropdown.DropDownItems.Add("Linie");
            shapesDropdown.DropDownItems.Add("Dreptunghi");
            shapesDropdown.DropDownItems.Add("Elipsa");
            //select linie by default

            foreach (ToolStripItem item in shapesDropdown.DropDownItems)
            {
                Image bmp = new Bitmap(32, 32);
                Graphics g = Graphics.FromImage(bmp);
                Rectangle r = new Rectangle(2, 6, bmp.Height - 4, bmp.Height - 12);

                switch (item.Text)
                {
                    case "Linie":
                        g.DrawLine(dropdownPen, r.Location, new Point(r.Width, r.Height));
                        break;
                    case "Dreptunghi":
                        g.DrawRectangle(dropdownPen, r);
                        break;
                    case "Elipsa":
                        g.DrawEllipse(dropdownPen, r);
                        break;
                }

                item.ImageAlign = ContentAlignment.MiddleCenter;
                item.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                item.Image = bmp;
            }
        }

        /*EVENTS*/
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void fillButton_Click(object sender, EventArgs e)
        {

        }

        private void inkQtyButton_Click(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.DefaultExt = "jpeg";
                saveFileDialog.FileName = "Figura.jpeg";
                saveFileDialog.Filter = "JPEG files (*.jpeg)|*.jpeg|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.ShowDialog();
            }
            catch (Exception) { }
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog.FileName != "")
            {
                bmp.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void shapesDropdown_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripItem item in shapesDropdown.DropDownItems)
            {
                item.BackColor = Color.White;
            }
                
            e.ClickedItem.BackColor = Color.LightGray;
        }
    }
}
