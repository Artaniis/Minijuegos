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
    class Puck
    {
        Rectangle rect = new Rectangle();
        public int x, y; //initlal puck coordinates
        public int s; //puck size. its a square, so 1 value is required.
        int speed = 7;
        int xvelocity, yvelocity;

        public Puck(Canvas c)
        {
            SolidColorBrush color = new SolidColorBrush();
            x = 80;
            y = 80;
            s = 25;
            xvelocity = speed;
            yvelocity = speed;

            color.Color = Color.FromRgb(0, 0, 0); //puck will be black

            rect.Fill = color;
            rect.Width = s;
            rect.Height = s; //make puck black, and give it a size of 25x25

            Canvas.SetTop(rect, y);
            Canvas.SetLeft(rect, x);
            c.Children.Add(rect); //puck position within the canvas
        }

        public void movement()
        {
            x = x + xvelocity;
            y = y + yvelocity; //changes puck coordinates
            Canvas.SetTop(rect, y);
            Canvas.SetLeft(rect, x); //repositions the puck, so canvas must be called again
        }

        public void xbounce() //horizontal bounce
        {
            if (xvelocity == 7)
            {
                xvelocity = -7; //make x component negative
            }
            else
            {
                xvelocity = 7;
            }
        }

        public void ybounce() //vertical bounce
        {
            if (yvelocity == 7)
            {
                yvelocity = -7; //make y component negative
            }
            else
            {
                yvelocity = 7;
            }
        }
    }
}
