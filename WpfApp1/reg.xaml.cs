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
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Page
    {
        public reg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (AutorizeEntities db = new AutorizeEntities())
            {
                var users = db.Users;
                foreach (Users u in users)
                {
                    if (login.Text == Convert.ToString(u.login))
                    {
                        MessageBox.Show("Логин занят");                      
                    }
                    if((login.Text != Convert.ToString(u.login) && login.Text != "") && (password.Text !="" && password.Text.Length >= 6) && (password2.Text == password.Text))
                    {
                        MessageBox.Show("Вы зарегестрировались");
                        AutorizeEntities.getcontext().Users.Add(new Users() { login = login.Text, password = password.Text, admin = 0}) ;
                        AutorizeEntities.getcontext().SaveChanges();
                        pages.Mainframe.Navigate(new autorize());
                    }
                    if((password2.Text != password.Text)  || password2.Text == "")
                    {
                        password2.Text = "Пароли не совпадают";                 
                    }
                    if (password.Text.Length < 6)
                    {
                        password.Text = "Пароль должен быть не менее 6 символов";                       
                    }
                    if (login.Text =="")
                    {
                        login.Text = "Введите логин";                       
                    }
                    break;
                }
            }
        }
    }
}
