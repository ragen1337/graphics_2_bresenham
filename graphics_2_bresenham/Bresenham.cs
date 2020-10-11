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
    class Bresenham
    {
        public void MyDrawLine(Brush brush, int CoordinateX1, int CoordinateY1, int CoordinateX2, int CoordinateY2, Graphics g)
        {
            Grid grid = new Grid();
            bool infinityMarker = false;
            if (CoordinateX1 == CoordinateX2)
            {
                infinityMarker = true;
            }
            float k = (float)(CoordinateY2 - CoordinateY1) / (float)(CoordinateX2 - CoordinateX1);
            float b = (float)(CoordinateY1 * CoordinateX2 - CoordinateY2 * CoordinateX1) / (float)(CoordinateX2 - CoordinateX1);
            grid.DrawPixel(brush, CoordinateX1, CoordinateY1, g);
            grid.DrawPixel(brush, CoordinateX2, CoordinateY2, g);

            if (Math.Abs(k) <= 1)
            {
                if (CoordinateX1 > CoordinateX2)
                {
                    int temp = CoordinateX1;
                    CoordinateX1 = CoordinateX2;
                    CoordinateX2 = temp;

                    temp = CoordinateY1;
                    CoordinateY1 = CoordinateY2;
                    CoordinateY2 = temp;
                }

                int Y1 = CoordinateY1;
                int Ydraw;

                for (int i = CoordinateX1 + 1; i < CoordinateX2; i++)
                {
                    float Y2 = k * i + b;

                    double delta = Math.Abs(Y2 - Y1);

                    if (delta < 0.5)
                    {
                        Ydraw = Y1;
                    }
                    else
                    {
                        if ((Y2 - Y1) > 0)
                        {
                            Ydraw = Y1 + 1;
                        }
                        else
                        {
                            Ydraw = Y1 - 1;
                        }
                    }
                    Y1 = (int)Math.Round(Y2);

                    grid.DrawPixel(brush, i, Ydraw, g);
                }
            }
            else
            {
                if (CoordinateY1 > CoordinateY2)
                {
                    int temp = CoordinateX1;
                    CoordinateX1 = CoordinateX2;
                    CoordinateX2 = temp;

                    temp = CoordinateY1;
                    CoordinateY1 = CoordinateY2;
                    CoordinateY2 = temp;
                }

                int X1 = CoordinateX1;
                int Xdraw;

                if (!infinityMarker)
                {
                    for (int i = CoordinateY1 + 1; i < CoordinateY2; i++)
                    {
                        float X2 = (i - b) / k;

                        double delta = Math.Abs(X2 - X1);

                        if (delta < 0.5)
                        {
                            Xdraw = X1;
                        }
                        else
                        {
                            if ((X2 - X1) > 0)
                            {
                                Xdraw = X1 + 1;
                            }
                            else
                            {
                                Xdraw = X1 - 1;
                            }
                        }
                        X1 = (int)Math.Round(X2);

                        grid.DrawPixel(brush, Xdraw, i, g);
                    }
                }
                else
                {
                    for (int i = CoordinateY1 + 1; i < CoordinateY2; i++)
                    {
                        Xdraw = X1;
                        grid.DrawPixel(brush, Xdraw, i, g);
                    }
                }
            }
        }

        public void MyDrawEllipse(Brush brush, Graphics graphics, Grid grid, int xc, int yc, int rx, int ry)
        {
            //Grid grid = new Grid();
            double dx, dy, d1, d2;
            int x, y;
            x = 0;
            y = ry;

            // Initial decision parameter of region 1 
            d1 = (ry * ry) - (rx * rx * ry) + (0.25 * rx * rx);
            dx = 2 * ry * ry * x;
            dy = 2 * rx * rx * y;

            // For region 1 
            while (dx < dy)
            {

                // Print points based on 4-way symmetry 
                grid.DrawPixel(brush, x + xc, y + yc, graphics);
                grid.DrawPixel(brush, -x + xc, y + yc, graphics);
                grid.DrawPixel(brush, x + xc, -y + yc, graphics);
                grid.DrawPixel(brush, -x + xc, -y + yc, graphics);

                // Checking and updating value of 
                // decision parameter based on algorithm 
                if (d1 < 0)
                {
                    x++;
                    dx = dx + (2 * ry * ry);
                    d1 = d1 + dx + (ry * ry);
                }
                else
                {
                    x++;
                    y--;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d1 = d1 + dx - dy + (ry * ry);
                }
            }

            // Decision parameter of region 2 
            d2 = ((ry * ry) * ((x + 0.5) * (x + 0.5))) +
                 ((rx * rx) * ((y - 1) * (y - 1))) -
                  (rx * rx * ry * ry);

            // Plotting points of region 2 
            while (y >= 0)
            {

                // Print points based on 4-way symmetry 
                grid.DrawPixel(brush, x + xc, y + yc, graphics);
                grid.DrawPixel(brush, -x + xc, y + yc, graphics);
                grid.DrawPixel(brush, x + xc, -y + yc, graphics);
                grid.DrawPixel(brush, -x + xc, -y + yc, graphics);

                // Checking and updating parameter 
                // value based on algorithm 
                if (d2 > 0)
                {
                    y--;
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + (rx * rx) - dy;
                }
                else
                {
                    y--;
                    x++;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + dx - dy + (rx * rx);
                }
            }
        }
    }
       
}
