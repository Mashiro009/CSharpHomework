using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        //readonly double th1 = 30 * Math.PI / 180;
        //readonly double th2 = 20 * Math.PI / 180;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        readonly double per1 = 0.6;
        readonly double per2 = 0.7;
        //static int a = 100;

        public Form1()
        {
            InitializeComponent();
            this.AutoScaleBaseSize = new Size(6, 14);
            this.ClientSize = new Size(400, 300);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }


        private void drawCayleyTree(int n,
                double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + Convert.ToDouble(this.numericUpDown1.Value) * leng * Math.Cos(th);
            double y1 = y0 + Convert.ToDouble(this.numericUpDown1.Value) * leng * Math.Sin(th);
            double x2 = x0 + Convert.ToDouble(this.numericUpDown2.Value) * leng * Math.Cos(th);
            double y2 = y0 + Convert.ToDouble(this.numericUpDown2.Value) * leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }
        private void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(
                Pens.Blue,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
                graphics = this.CreateGraphics();
            else
                graphics.Clear(BackColor);
            th1 = Convert.ToDouble(this.numericUpDown3.Value) * Math.PI / 180;
            th2 = Convert.ToDouble(this.numericUpDown4.Value) * Math.PI / 180;
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }
    }
}
