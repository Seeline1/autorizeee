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
    /// Логика взаимодействия для autorize.xaml
    /// </summary>
    public partial class autorize : Page
    {
        public autorize()
        {
            InitializeComponent();
        }

        private void txtlog_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (AutorizeEntities db = new AutorizeEntities())
            {
                var users = db.Users;
                foreach (Users u in users)
                {
                    if (login.Text == Convert.ToString(u.login) && password.Text == Convert.ToString(u.password))
                    {
                        MessageBox.Show("Вы вошли в систему");
                        if (u.admin == 1)
                            pages.Mainframe.Navigate(new adminpage());
                        if (u.admin == 0)
                            pages.Mainframe.Navigate(new clientpage());
                        break;
                    }
                    if (login.Text != Convert.ToString(u.login) && (password.Text == Convert.ToString(u.password) || password.Text != Convert.ToString(u.password)))
                    {
                        login.Text = "Неверный логин";
                        password.Text = "";
                        break;
                    }
                    if (login.Text == Convert.ToString(u.login) && password.Text != Convert.ToString(u.password))
                    {
                        password.Text = "Неверный пароль";
                        break;
                    }
                }
            }
        }
    }
}
