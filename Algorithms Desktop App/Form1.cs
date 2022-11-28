using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms_Desktop_App.BL;
using Algorithms_Desktop_App.DL;
using ComponentFactory.Krypton.Toolkit;

namespace Algorithms_Desktop_App
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Location = new System.Drawing.Point(20, 60);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(245, 45);
            comboBox1.BackColor = System.Drawing.Color.Orange;
            comboBox1.ForeColor = System.Drawing.Color.Black;
            this.Controls.Add(comboBox1);
        }




    }
}
