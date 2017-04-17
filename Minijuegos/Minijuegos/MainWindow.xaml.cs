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
            if (Paginas.SelectedItem == Juego1)
            {
                ContentFrame.Navigate(new Juego1_Matching());
            }
            //else if (Paginas.SelectedItem == Juego2)
            //{
            //    ContentFrame.Navigate(new Page1());
            //}
        }
    }
}
