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
        Manager mng;

        bool imageSaved;

        string selectedShape;
        int nrOfShapes;

        Cursor fillCursor;
        Color fillColor;
        
        public Form1()
        {
            InitializeComponent();

            imgInitializer();
            shapesInitializer();

            fillColor = Color.Silver;

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
            mng = new Manager(bmp);
            mng.reset();

            pictureBox1.Refresh();
        }

        void shapesInitializer()
        {
            Pen dropdownPen = new Pen(Color.Blue, 3f);

            shapesDropdown.DropDownItems.Add("Linie");
            shapesDropdown.DropDownItems.Add("Dreptunghi");
            shapesDropdown.DropDownItems.Add("Elipsa");

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
                DialogResult raspuns = MessageBox.Show("Schimbari nesalvate! Inchideti?", "Confirmare", MessageBoxButtons.YesNo);
                if (raspuns == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            mng.reset();
            try
            {
                if(selectedShape == "")
                {
                    throw new Exception("Alegeti o forma!");
                }

                if(!int.TryParse(ShapeNrTextBox.Text, out nrOfShapes))
                {
                    throw new Exception("Introduceti un numar de forme!");
                }

                if (nrOfShapes < 1 || nrOfShapes > 5000)
                {
                    throw new Exception("Numarul de forme este minim 1 si maxim 5000!");
                }

                mng.drawShapes(nrOfShapes, selectedShape);
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
                saveFileDialog1.FileName = "Figura.jpeg";
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
                    MessageBox.Show("Formele nu pot fi negre!");
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
                mng.fill(e.Location, fillColor);
                imageSaved = false;
                pictureBox1.Refresh();
            }
        }

        private void inkQtyButton_Click(object sender, EventArgs e)
        {
            InkCalculator iq = InkCalculator.getInkCalculator();
            iq.Visible = true;
        }
    }
}
