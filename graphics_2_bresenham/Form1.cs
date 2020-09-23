using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics_2_bresenham
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawForm(g);
        }

        private void DrawForm(Graphics g)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Brush blackSolidBrush = new SolidBrush(Color.Black);
            DrawBitMap(blackPen, g);

            for (int i = 1, j = 2; i <= 10; i++, j++)
            {
                DrawPixel(blackSolidBrush, i, j, g);
            }
        }

        private void DrawBitMap(Pen pen, Graphics g){
            for(short i = 0; i <= 1000; i += 20)
            {
                PointF linePoint1 = new PointF(0, i);
                PointF linePoint2 = new PointF(1000, i);
                g.DrawLine(pen, linePoint1, linePoint2);

                PointF linePoint3 = new PointF(i, 0);
                PointF linePoint4 = new PointF(i, 1000);
                g.DrawLine(pen, linePoint3, linePoint4);
            }
        }

        private void DrawPixel(Brush brush, int CoordinateX, int CoordinateY, Graphics g)
        {
            int bitMapXCoordinate = (CoordinateX-1) * 20;
            int bitMapYCoordinate = (CoordinateY-1) * 20;

            Rectangle drawPixelRect = new Rectangle(bitMapXCoordinate, bitMapYCoordinate, 20, 20);
            g.FillRectangle(brush, drawPixelRect);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
