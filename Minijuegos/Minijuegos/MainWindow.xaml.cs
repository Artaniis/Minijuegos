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
using Minijuegos.Frames;
using Minijuegos;

namespace Minijuegos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Navigate(new HomePage());
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            if (!PanelMenu.IsLeftDrawerOpen)
            {
                PanelMenu.IsLeftDrawerOpen = true;
            }
            else if (PanelMenu.IsLeftDrawerOpen)
            {
                PanelMenu.IsLeftDrawerOpen = false;
            }
        }

        private void Paginas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Paginas.SelectedItem == Inicio)
            {
                ContentFrame.Navigate(new HomePage());
            }
            else if (Paginas.SelectedItem == Juego1)
            {
                ContentFrame.Navigate(new Juego1());
            }
            else if (Paginas.SelectedItem == Juego2)
            {
                ContentFrame.Navigate(new Juego2());
            }
            else if (Paginas.SelectedItem == Juego3)
            {
                ContentFrame.Navigate(new Juego3());
            }
            else if (Paginas.SelectedItem == Juego4)
            {
                ContentFrame.Navigate(new Juego4());
            }
        }
    }
}
