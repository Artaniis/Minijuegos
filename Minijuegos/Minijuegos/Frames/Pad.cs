using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace Minijuegos.Frames
{
    public class Pad
    {
        Rectangle rect = new Rectangle();
        public int x, y, w, h;
        int yvelocity = 0;

        public Pad(Canvas c, int x)
        {
            SolidColorBrush color = new SolidColorBrush();
            color.Color = Color.FromRgb(250, 0, 0);
            rect.Fill = color;
            this.x = x;
            y = 80;
            w = 25;
            h = 75;
            rect.Width = w;
            rect.Height = h;

            Canvas.SetLeft(rect, this.x);
            Canvas.SetTop(rect, y);
            c.Children.Add(rect);
        }

        public void movement()
        {
            y = y + yvelocity;
            Canvas.SetTop(rect, y);
        }

        public void stop()
        {
            yvelocity = 0;
        }

        public void move_up()
        {
            if (y <= 0)
            {
                yvelocity = 0;
            }
            else
            {
                yvelocity = -5;
            }
        }

        public void move_down()
        {
            if (y >= 186)
            {
                yvelocity = 0;
            }
            else
            {
                yvelocity = 5;
            }
        }
    }
}
