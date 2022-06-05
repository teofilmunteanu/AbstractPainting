using System;
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
    public partial class InkCalculator : Form
    {
        private static InkCalculator? instance = null;
        string sideLength, inkConsumption;
        Manager mng;

        private InkCalculator()
        {
            InitializeComponent();
            mng = new Manager();
        }

        public static InkCalculator getInkCalculator()
        {
            if (instance == null)
            {
                instance = new InkCalculator();
            }
            return instance;
        }

        private void InkCalculator_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            sideLength = getInkCalculator().printLengthBox.Text.ToString();
            inkConsumption = getInkCalculator().inkConsumptionBox.Text.ToString();

            double sL, iC;
            if (double.TryParse(sideLength, out sL) && double.TryParse(inkConsumption, out iC))
            {
                Dictionary<char, double> consumptions = mng.calculateInk(sL, iC);

                cyanQty.Text = consumptions['C'].ToString();
                magentaQty.Text = consumptions['M'].ToString();
                yellowQty.Text = consumptions['Y'].ToString();
                blackQty.Text = consumptions['K'].ToString();
            }
        }
        //mng.CalculateInk(); -- singleton
    }
}
