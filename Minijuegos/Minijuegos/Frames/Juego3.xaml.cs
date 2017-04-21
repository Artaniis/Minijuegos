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

namespace Minijuegos.Frames
{
    /// <summary>
    /// Lógica de interacción para Juego3.xaml
    /// </summary>
    public partial class Juego3 : Page
    {
        #region Constructor
        public Juego3()
        {
            InitializeComponent();
            NewGame();

        }
        #endregion
        #region Private Members
        private MarkType[] mResults;
        private bool mPlayer1Turn;
        private bool mGameEnded;
        #endregion
        private void NewGame()
        {
            mResults = new MarkType[9];
            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;

            mPlayer1Turn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;

            });
            mGameEnded = false;
        }

        private void Boton_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnded)
            {
                NewGame();
                return;

            }

            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if (mResults[index] != MarkType.Free)
                return;

            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;
            button.Content = mPlayer1Turn ? "X" : "O";

            if (!mPlayer1Turn)
                button.Foreground = Brushes.Red;

            mPlayer1Turn ^= true;

            CheckForWinner();
        }

        private void CheckForWinner()
        {

            #region Horizontal Wins

            // Check for horizontal wins
            //
            //  - Row 0
            //
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in green
                Boton0_0.Background = Boton1_0.Background = Boton2_0.Background = Brushes.Green;
            }
            //
            //  - Row 1
            //
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in green
                Boton0_1.Background = Boton1_1.Background = Boton2_1.Background = Brushes.Green;
            }
            //
            //  - Row 2
            //
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in green
                Boton0_2.Background = Boton1_2.Background = Boton2_2.Background = Brushes.Green;
            }

            #endregion

            #region Vertical Wins

            // Check for vertical wins
            //
            //  - Column 0
            //
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in green
                Boton0_0.Background = Boton0_1.Background = Boton0_2.Background = Brushes.Green;
            }
            //
            //  - Column 1
            //
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in green
                Boton1_0.Background = Boton1_1.Background = Boton1_2.Background = Brushes.Green;
            }
            //
            //  - Column 2
            //
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in green
                Boton2_0.Background = Boton2_1.Background = Boton2_2.Background = Brushes.Green;
            }

            #endregion

            #region Diagonal Wins

            // Check for diagonal wins
            //
            //  - Top Left Bottom Right
            //
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in green
                Boton0_0.Background = Boton1_1.Background = Boton2_2.Background = Brushes.Green;
            }
            //
            //  - Top Right Bottom Left
            //
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in green
                Boton2_0.Background = Boton1_1.Background = Boton0_2.Background = Brushes.Green;
            }

            #endregion

            #region No Winners

            // Check for no winner and full board
            if (!mResults.Any(f => f == MarkType.Free))
            {
                // Game ended
                mGameEnded = true;

                // Turn all cells orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }

            #endregion

        }
    }
}
