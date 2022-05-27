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
        void initializer()
        {
            //instrument.Items.Add("Fundal");
            //instrument.Items.Add("Creion");
            //instrument.Items.Add("Linie");
            //instrument.Items.Add("Patrat");
            //instrument.Items.Add("Dreptunghi");
            //instrument.Items.Add("Cerc");
            //instrument.Items.Add("Elipsa");
            //instrument.Items.Add("Patrat plin");
            //instrument.Items.Add("Dreptunghi plin");
            //instrument.Items.Add("Cerc plin");
            //instrument.Items.Add("Elipsa plina");
            //instrument.Items.Add("Radiera");
            //instrument.SelectedIndex = 0;
            //shapesDropdown.DropDownItems.Add("henlo");
        }

        public Form1()
        {
            InitializeComponent();
            initializer();

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

        private void shapesDropdown_Click(object sender, EventArgs e)
        {

        }

        private void shapesDropdown_DropDownOpened(object sender, EventArgs e)
        {
            //MAKE LIST OF ITEMS AND ASSIGN TO EACH OF THEM NAME + DRAWING
            foreach (ToolStripItem item in shapesDropdown.DropDownItems)
            {
                Image bmp = new Bitmap(32, 32);
                Graphics g = Graphics.FromImage(bmp);

                Rectangle r = new Rectangle(2, 6, bmp.Height-4, bmp.Height - 12);
                g.DrawRectangle(new Pen(Color.Blue, 3), r);

                item.ImageAlign = ContentAlignment.MiddleCenter;
                item.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                item.Image = bmp;
            }
        }
    }
}
