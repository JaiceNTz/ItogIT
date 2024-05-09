using HouseTempleApp.Classes;
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

namespace HouseTempleApp.AppPage
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var user = AppConnect.HouseDB.User.Where(u => u.Login == txtUsername.Text && u.Password == txtPassword.Password).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль. ");
            }

            else if (user.IdRole == 2)
            {
                NavigationService.Navigate(new PageCustomer());
            }
            else if (user.IdRole == 1)
            {
                NavigationService.Navigate(new PageRieltor());
            }
        }
        private void Registr(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AppPage/PageRegister.xaml", UriKind.Relative));
        }

    }
}