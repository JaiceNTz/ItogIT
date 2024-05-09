using HouseTempleApp.AppPage;
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

namespace HouseTempleApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            AppConnect.HouseDB = new HouseTempleEntities();
            MainFrame.NavigationService.Navigate(new Uri("AppPage/LoginPage.xaml", UriKind.Relative));


        }
        
        private void LogClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            MainFrame.NavigationService.Navigate(new Uri("AppPage/LoginPage.xaml", UriKind.Relative));


            if (sender == ButtonRegister)
                MainFrame.NavigationService.Navigate(new Uri("AppPage/PageRegister.xaml", UriKind.Relative));
        }

        private void scrolPage(object sender, RoutedEventArgs e)
        {

            MainFrame.Content = null;

    (sender as Button).Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey1");

            //Осторожно идёт покраск кнопки, если соответсвующая кнопка отжата
            RemoteNmobles.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            Store.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
           
            DealShare.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            // Осторожно идёт покраска кнопки, если соответсвующая кнопка нажата
            if (sender == RemoteNmobles)
                MainFrame.NavigationService.Navigate(new Uri("AppPage/PageStore.xaml", UriKind.Relative));
            if (sender == Store)
                MainFrame.NavigationService.Navigate(new Uri("AppPage/PageStore.xaml", UriKind.Relative));
            if (sender == DealShare)
                MainFrame.NavigationService.Navigate(new Uri("AppPage/PageDally.xaml", UriKind.Relative));

        }
    }
}
