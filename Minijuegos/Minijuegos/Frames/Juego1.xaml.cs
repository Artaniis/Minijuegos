using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Lógica de interacción para Juego1_Matching.xaml
    /// </summary>
    public partial class Juego1 : Page
    {
        // firstClicked points to the first control  
        // that the player clicks, but it will be null  
        // if the player hasn't clicked a control yet.
        ToggleButton PrimerClic = null;

        // secondClicked points to the second control  
        // that the player clicks.
        ToggleButton SegundoClic = null;

        // Use this Random object to choose random icons for the squares.
        Random random = new Random();

        // Each of these letters is an interesting icon 
        // in the Webdings font, 
        // and each icon appears twice in this list.
        List<string> icons = new List<string>()
        {
            "", "", "", "", "", "", "", "", "", "",
            "", "", "", "", "", "", "", "", "", "",
            "", "", "", "", "", "", "", "", "", "",  
        };

        /// <summary> 
        /// Assign each icon from the list of icons to a random square 
        /// </summary> 
        private void AssignIconsToSquares()
        {
            // The TableLayoutPanel has 16 labels, 
            // and the icon list has 16 icons, 
            // so an icon is pulled at random from the list 
            // and added to each label.
            foreach (Control item in CartasControl.Children)
            {
                ToggleButton control = (ToggleButton)item;

                if (control != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    TextBlock txt = (TextBlock)control.Content;
                    txt.Text = icons[randomNumber];
                    txt.Foreground = Brushes.Black;

                    //TextBlock txt = new TextBlock();
                    //txt.Text = icons[randomNumber];
                    //txt.FontFamily = Application.Current.Resources["MaterialIconsFont"] as FontFamily;
                    //txt.FontSize = 50;
                    ////txt.Foreground = Application.Current.Resources["SecondaryAccentBrush"] as Brush;
                    //txt.Foreground = Brushes.Black;
                    //txt.Margin = new Thickness(0, 0, 0, 0);
                    //txt.HorizontalAlignment = HorizontalAlignment.Center;
                    //txt.VerticalAlignment = VerticalAlignment.Center;

                    control.Content = txt;

                    icons.RemoveAt(randomNumber);
                }
            }
        }

        public Juego1()
        {
            InitializeComponent();
            AssignIconsToSquares();
            timer1.IsEnabled = false;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = new TimeSpan(0, 0, 1);
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    foreach (Control item in CartasControl.Children)
        //    {
        //        ToggleButton prueba = (ToggleButton)item;

        //        if (prueba.IsChecked == false)
        //        {
        //            prueba.IsChecked = true;
        //        }
        //        else
        //        {
        //            prueba.IsChecked = false;
        //        }
        //    }
        //}

        //Timer timer1 = new Timer();
        DispatcherTimer timer1 = new DispatcherTimer();

        //Toggle Button Dummy
        ToggleButton btmDummy = null;


        /// <summary> 
        /// Every control's Click event is handled by this event handler.
        /// </summary> 
        /// <param name="sender">The control that was clicked.</param>
        /// <param name="e"></param>
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            // The timer is only on after two non-matching  
            // icons have been shown to the player,  
            // so ignore any clicks if the timer is running 
            if (timer1.IsEnabled == true)
            {
                btmDummy = (ToggleButton)sender;
                btmDummy.IsChecked = true;
                return;
            }
            else
            {
                ToggleButton clickedLabel = (ToggleButton)sender;

                if (clickedLabel != null)
                {
                    // If the clicked Control is is not checked, the player clicked 
                    // an icon that's already been revealed -- 
                    // ignore the click.
                    if (clickedLabel.IsChecked == false)
                    {
                        // All done - leave the if statements.
                        clickedLabel.IsChecked = false;
                        return;
                    }
                    else
                    {
                        // If firstClicked is null, this is the first icon  
                        // in the pair that the player clicked, 
                        // so set firstClicked to the label that the player  
                        // clicked, change its color to black, and return. 
                        if (PrimerClic == null)
                        {
                            PrimerClic = clickedLabel;
                            PrimerClic.IsChecked = false;

                            // All done - leave the if statements.
                            return;
                        }
                        else
                        {
                            // If the player gets this far, the timer isn't 
                            // running and firstClicked isn't null, 
                            // so this must be the second icon the player clicked 
                            // Set its color to black.
                            SegundoClic = clickedLabel;
                            SegundoClic.IsChecked = false;

                            // Check to see if the player won.
                            CheckForWinner();

                            // If the player clicked two matching icons, keep them  
                            // black and reset firstClicked and secondClicked  
                            // so the player can click another icon. 
                            if (PrimerClic.Content == SegundoClic.Content)
                            {
                                

                                PrimerClic = null;
                                SegundoClic = null;
                                return;
                            }
                            else
                            {
                                // If the player gets this far, the player  
                                // clicked two different icons, so start the  
                                // timer (which will wait three quarters of  
                                // a second, and then hide the icons)....
                                timer1.Start();
                            }

                        }

                        
                    }

                    
                }
            }
        }

        /// <summary> 
        /// This timer is started when the player clicks  
        /// two icons that don't match, 
        /// so it counts three quarters of a second  
        /// and then turns itself off and hides both icons.
        /// </summary> 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer.
            timer1.Stop();

            // Hide both icons.
            PrimerClic.IsChecked = true;
            SegundoClic.IsChecked = true;

            // Reset firstClicked and secondClicked  
            // so the next time a label is 
            // clicked, the program knows it's the first click.
            PrimerClic = null;
            SegundoClic = null;
        }

        /// <summary> 
        /// Check every icon to see if it is matched, by  
        /// comparing its foreground color to its background color.  
        /// If all of the icons are matched, the player wins. 
        /// </summary> 
        private void CheckForWinner()
        {
            // Go through all of the labels in the TableLayoutPanel,  
            // checking each one to see if its icon is matched.
            foreach (Control item in CartasControl.Children)
            {
                ToggleButton control = (ToggleButton)item;

                if (control != null)
                {
                    if (control.IsChecked == false)
                    {
                        return;
                    }
                }
            }

            // If the loop didn’t return, it didn't find 
            // any unmatched icons. 
            // That means the user won. Show a message and close the form.
            MessageBox.Show("You matched all the icons!", "Congratulations!");
        }
    }
}
