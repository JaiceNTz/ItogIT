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
    /// Логика взаимодействия для PageAddUser.xaml
    /// </summary>
    public partial class PageAddUser : Page
    {
        public PageAddUser()
        {
            InitializeComponent();
        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender == Client)
                this.NavigationService.Navigate(new Uri("AppPage/PageRegister.xaml", UriKind.Relative));
            if (sender == Rieltor)
                this.NavigationService.Navigate(new Uri("AppPage/PageRegisterUser.xaml", UriKind.Relative));
        }
    }
}
