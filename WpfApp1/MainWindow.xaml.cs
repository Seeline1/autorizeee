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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pages.Mainframe = MainFrame;
            pages.Mainframe.Navigate(new autorize());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pages.Mainframe.Navigate(new autorize());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            pages.Mainframe.Navigate(new reg());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            pages.Mainframe.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if(MainFrame.CanGoBack)
            {
                btnback.Visibility = Visibility.Visible;
            }
            else
            {
                btnback.Visibility = Visibility.Hidden;
            }
        }
    }
}
