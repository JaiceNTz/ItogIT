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
    /// Логика взаимодействия для PageRegister.xaml
    /// </summary>
    public partial class PageRegister : Page
    {
        public PageRegister()
        {
            InitializeComponent();
        }
        private void clickButtonRegister(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            string messageWarning = "";
            string newLogin = TextBoxLogin.Text;
            var loginCheck = HouseTempleEntities.GetContext().User.Where(i => i.Login == newLogin).ToList();
            TextBoxLogin.Background = Brushes.White;
            PasswordBoxPassword.Background = Brushes.White;
            PasswordBoxDoublePassword.Background = Brushes.White;
            WarningContactItem.Foreground = (Brush)bc.ConvertFrom("#546e7a");
            TextBoxNumberPhone.Background = Brushes.White;

            if (!(TextBoxLogin.Text.Length > 0))
            {
                messageWarning = "Логин - обязателен для заполнения";
                TextBoxLogin.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if (PasswordBoxPassword.Password.ToString() != PasswordBoxDoublePassword.Password.ToString())
            {
                messageWarning += "\nПароли не совпадают";
                PasswordBoxPassword.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
                PasswordBoxDoublePassword.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }


            if (messageWarning.Length > 2)
            {
                TextBlockWarning.Text = messageWarning;
            }
            else
            {
                User User = new User();
                User.Login = TextBoxLogin.Text;
                User.Password = PasswordBoxPassword.Password.ToString();

                HouseTempleEntities.GetContext().User.Add(User);

                Client newClient = new Client();

                HouseTempleEntities.GetContext().Client.Add(newClient);
                HouseTempleEntities.GetContext().SaveChanges();

                MessageBox.Show("Регистрация прошла успешно");

                if (Application.Current.Resources["Role"].ToString() == "2")
                {
                    this.NavigationService.Navigate(new Uri("AppPage/PageRieltor.xaml", UriKind.Relative));
                }
            }
        }
    }
}
