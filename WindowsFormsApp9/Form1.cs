using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            double x0 = double.Parse(textBox1.Text);
            double xk = double.Parse(textBox2.Text);
            double step = double.Parse(textBox3.Text);
            double b = double.Parse(textBox4.Text);
            
            int count = Math.Abs((int)Math.Ceiling((x0 - xk) / (step * 1.0))) + 1;
            
            double[] x = new double[count];
           
            double[] y1 = new double[count];
            double[] y2 = new double[count];

            for (int i = 0; i < count; i++)
            {
                
                x[i] = x0 + step * i;
                
                y1[i] = (Math.Pow(Math.Abs(x0 - b), (1 / 2))) / (Math.Pow(Math.Abs(b * b * b - x0 * x0 * x0), (3 / 2))) + Math.Log(Math.Abs(x0 - b));
                y2[i] = Math.Cos(x[i]);
            }
            
            chart1.ChartAreas[0].AxisX.Minimum = x0;
            chart1.ChartAreas[0].AxisX.Maximum = xk;
            
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = step;
            
            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[1].Points.DataBindXY(x, y2);
        }
    }
}
