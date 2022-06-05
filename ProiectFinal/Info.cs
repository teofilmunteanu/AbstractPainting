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
    public partial class Info : Form
    {
        private static Info? instance = null;

        private Info()
        {
            InitializeComponent();
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
    }
}
