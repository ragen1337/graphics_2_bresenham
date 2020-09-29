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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawFormLine(g);
        }

        private void DrawForm(Graphics g)
        {

        }

        private void DrawFormLine(Graphics g)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Brush blackSolidBrush = new SolidBrush(Color.Black);

            Grid grid = new Grid();
            grid.DrawBitMap(blackPen, g);
            int x1 = int.Parse(LineX1TextBox.Text);
            int y1 = int.Parse(LineY1TextBox.Text);
            int x2 = int.Parse(LineX2TextBox.Text);
            int y2 = int.Parse(LineY2TextBox.Text);
            Bresenham bresenham = new Bresenham();
            bresenham.MyDrawEllipse( blackSolidBrush, 3, 3, 8, 10, g);
        }


        

        private void button1_Click_1(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            DrawFormLine(g);
            pictureBox1.Refresh();
        }
    }
}
