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
using System.IO;

namespace ProiectFinal
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Manager mng;

        bool imageSaved;

        string selectedShape;
        int nrOfShapes;

        Cursor fillCursor;
        Color fillColor;
        Color bgColor;

        public Form1()
        {
            InitializeComponent();

            imgInitializer();
            shapesInitializer();

            fillColor = Color.Silver;
            bgColor = Color.White;

            try
            {
                string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                fillCursor = new Cursor("..\\..\\..\\resources\\fill2.cur");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            imageSaved = true;
        }

        void imgInitializer()
        {
            //Manager.Bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Manager.G = Graphics.FromImage(Manager.Bmp);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(bgColor);

            mng = new Manager();

            pictureBox1.Refresh();
        }

        void shapesInitializer()
        {
            Pen dropdownPen = new Pen(Color.Blue, 3f);

            shapesDropdown.DropDownItems.Add("Line");
            shapesDropdown.DropDownItems.Add("Rectangle");
            shapesDropdown.DropDownItems.Add("Triangle");
            shapesDropdown.DropDownItems.Add("Elipse");
            shapesDropdown.DropDownItems.Add("Bezier");

            foreach (ToolStripItem item in shapesDropdown.DropDownItems)
            {
                Image shapeBmp = new Bitmap(32, 32);
                Graphics shapeG = Graphics.FromImage(shapeBmp);
                Rectangle r = new Rectangle(2, 6, shapeBmp.Height - 4, shapeBmp.Height - 12);
                Point[] pts;

                switch (item.Text)
                {
                    case "Line":
                        shapeG.DrawLine(dropdownPen, r.Location, new Point(r.Width, r.Height));
                        break;
                    case "Rectangle":
                        shapeG.DrawRectangle(dropdownPen, r);
                        break;
                    case "Triangle":
                        pts = new Point[] { 
                            new Point(r.X, r.Height), 
                            new Point((r.X+r.Width)/2, r.Y), 
                            new Point(r.Width, r.Height) 
                        };
                        shapeG.DrawPolygon(dropdownPen, pts);
                        break;
                    case "Elipse":
                        shapeG.DrawEllipse(dropdownPen, r);
                        break;
                    case "Bezier":
                        pts = new Point[] {
                            r.Location,
                            new Point((r.X+r.Width)/3, r.Height),
                            new Point((r.X+r.Width)*2/3, r.Y),
                            new Point(r.Width, r.Height)
                        };
                        shapeG.DrawBezier(dropdownPen,pts[0], pts[1], pts[2], pts[3]);
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
            e.Graphics.DrawImage(bmp, 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (imageSaved)
            {
                Application.Exit();
            }
            else
            {
                DialogResult raspuns = MessageBox.Show("Unsaved changes? Exit?", "Confirm", MessageBoxButtons.YesNo);
                if (raspuns == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            g.Clear(bgColor);
            try
            {
                if(selectedShape == null)
                {
                    throw new Exception("Choose a shape!");
                }

                if(!int.TryParse(ShapeNrTextBox.Text, out nrOfShapes))
                {
                    throw new Exception("Enter the number of shapes!");
                }

                if (nrOfShapes < 1 || nrOfShapes > 5000)
                {
                    throw new Exception("The number of shapes must be within the 1-5000 range!");
                }

                mng.drawShapes(g, bmp, nrOfShapes, selectedShape);
                imageSaved = false;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
            pictureBox1.Refresh();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.DefaultExt = "jpeg";
                saveFileDialog1.FileName = "Shapes.jpeg";
                saveFileDialog1.Filter = "JPEG files (*.jpeg)|*.jpeg|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.ShowDialog();
            }
            catch (Exception) { }
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog1.FileName != "")
            {
                bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                imageSaved = true;
            }
        }

        private void shapesDropdown_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            selectedShape = e.ClickedItem.Text;

            Color colorInactive = Color.White;
            Color colorActive = Color.LightGray;

            foreach (ToolStripItem item in shapesDropdown.DropDownItems)
            {
                item.BackColor = colorInactive;
            }
   
            e.ClickedItem.BackColor = colorActive;
        }

        private void ShapeNrTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                runButton_Click(null, null);
            }
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                while (colorDialog1.Color.ToArgb() == Figura.ShapeColor.ToArgb())
                {
                    MessageBox.Show("The shapes' interior cannot be black!");
                    colorDialog1.ShowDialog();
                }
                fillColor = colorDialog1.Color;
            }
                
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Cursor != fillCursor)
            {
                pictureBox1.Cursor = fillCursor;
                toolStrip1.Items[toolStrip1.Items.IndexOf(fillButton)].BackColor = Color.Silver;
            }
            else
            {
                pictureBox1.Cursor = Cursors.Default;
                toolStrip1.Items[toolStrip1.Items.IndexOf(fillButton)].BackColor = Color.Gainsboro;
            }    
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(pictureBox1.Cursor == fillCursor)
            {
                mng.fill(bmp, e.Location, fillColor);
                imageSaved = false;
                pictureBox1.Refresh();
            }
        }

        private void inkQtyButton_Click(object sender, EventArgs e)
        {
            InkCalculator iq = InkCalculator.getInkCalculator(bmp);
            iq.Visible = true;
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sup\n woah");
        }
    }
}
