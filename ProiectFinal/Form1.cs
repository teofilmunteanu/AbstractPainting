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
        public Form1()
        {
            InitializeComponent();

            imgInitializer();
            shapesInitializer();
        }

        void imgInitializer()
        {
            Manager.bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Manager.g = Graphics.FromImage(Manager.bmp);
            Rectangle imageRectangle = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            Manager.g.FillRectangle(Manager.mainBrush, imageRectangle);

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
                Image shapeBmp = new Bitmap(32, 32);
                Graphics shapeG = Graphics.FromImage(shapeBmp);
                Rectangle r = new Rectangle(2, 6, shapeBmp.Height - 4, shapeBmp.Height - 12);

                switch (item.Text)
                {
                    case "Linie":
                        shapeG.DrawLine(dropdownPen, r.Location, new Point(r.Width, r.Height));
                        break;
                    case "Dreptunghi":
                        shapeG.DrawRectangle(dropdownPen, r);
                        break;
                    case "Elipsa":
                        shapeG.DrawEllipse(dropdownPen, r);
                        break;
                }

                item.ImageAlign = ContentAlignment.MiddleCenter;
                item.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                item.Image = shapeBmp;
            }
        }

        /*EVENTS*/
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Manager.bmp, 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
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
                Manager.bmp.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void shapesDropdown_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripItem item in shapesDropdown.DropDownItems)
            {
                item.BackColor = Color.White;
            }
                
            e.ClickedItem.BackColor = Color.LightGray;

            shapesDropdown.Image = e.ClickedItem.Image;
        }

        
    }
}
