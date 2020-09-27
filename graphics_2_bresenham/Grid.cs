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
    class Grid
    {
        public void DrawBitMap(Pen pen, Graphics g)
        {
            for (short i = 0; i <= 440; i += 20)
            {
                PointF linePoint1 = new PointF(0, i);
                PointF linePoint2 = new PointF(440, i);
                g.DrawLine(pen, linePoint1, linePoint2);

                PointF linePoint3 = new PointF(i, 0);
                PointF linePoint4 = new PointF(i, 440);
                g.DrawLine(pen, linePoint3, linePoint4);
            }
        }
        public void DrawPixel(Brush brush, int CoordinateX, int CoordinateY, Graphics g)
        {
            int bitMapXCoordinate = (CoordinateX - 1) * 20;
            int bitMapYCoordinate = (CoordinateY - 1) * 20;

            Rectangle drawPixelRect = new Rectangle(bitMapXCoordinate, bitMapYCoordinate, 20, 20);
            g.FillRectangle(brush, drawPixelRect);
        }
    }
}
