using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Minijuegos.Frames
{
    /// <summary>
    /// Lógica de interacción para Juego2.xaml
    /// </summary>
    public partial class Juego2 : Page
    {

        
        /* canvas.IsEnabled = true;
           canvas.Focusable = true;
           canvas.Focus(); */


        Puck puck;
        Pad player1, player2;

        DispatcherTimer dp;
        int player1_score = 0, player2_score = 0;

        public Juego2()
        {
            InitializeComponent();
            
            dp = new DispatcherTimer();
            dp.Interval = new TimeSpan(0, 0, 0, 0, 25); //25 milliseconds
            dp.Tick += new EventHandler(dp_tick); //the function will be ticked in the interval

            puck = new Puck(canvas); //the canvas component must be initialized first.

            player1 = new Pad(canvas, 15);
            player2 = new Pad(canvas, 618);


        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                player2.move_down();
            }
            if (e.Key == Key.Up)
            {
                player2.move_up();
            }
            if (e.Key == Key.W) //up for player 1
            {
                player1.move_up();
            }

            if (e.Key == Key.S) //down for player 1
            {
                player1.move_down();
            }
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                player2.stop();
            }
            if (e.Key == Key.Up)
            {
                player2.stop();
            }
            if (e.Key == Key.W) //up for player 1
            {
                player1.stop();
            }

            if (e.Key == Key.S) //down for player 1
            {
                player1.stop();
            }
        }

        public void dp_tick(object sender, EventArgs e)
        {
            puck.movement();
            player1.movement();
            player2.movement();

            if (puck.x <= 0) //if the left side of the puck touches the left side of the screen
            {
                puck.xbounce();
                player2_score++; //add a point to player 2
                scoredisplay2.Content = player2_score;
            }
            if (puck.x >= 633) //658 (width of canvas) - 25 (width of puck) = 633
            {
                puck.xbounce();
                player1_score++; //add a point to player 1
                scoredisplay1.Content = player1_score;
            }

            if (puck.y <= 0 || puck.y >= 236) //261 (height of canvas) - 25 (height of puck) = 236
            {
                puck.ybounce();
            }

            //collision detection with pads
            if (puck.x <= (player1.x + player1.w) && puck.y >= player1.y && puck.y <= (player1.y + player1.h))
            {
                puck.xbounce();
            }
            if ((puck.x + puck.s) >= player2.x && puck.y >= player2.y && puck.y <= (player2.y + player2.h))
            {
                puck.xbounce();
            }
        }

        private void playpause_Click(object sender, RoutedEventArgs e) //start button to start moving puck
        {
            if (dp.IsEnabled) //if the puck is moving, stop it
            {
                dp.IsEnabled = false;
                playpause.Content = "Continue";
            }
            else //if the puck is stopped, move it
            {
                dp.IsEnabled = true;
                playpause.Content = "Pause";
            }
        }

    }
}
