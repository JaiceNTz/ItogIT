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
    /// Логика взаимодействия для PageStoreEarth.xaml
    /// </summary>
    public partial class PageStoreEarth : Page
    {
        private Button selectNmobles;

        public PageStoreEarth(object sender)
        {
            InitializeComponent();
            selectNmobles = (sender as Button);

        }
        private void ScrolPage(object sender, RoutedEventArgs e)
        {
            FrameNever.Content = null;

            //Меняем цвет в normal
            ButtonGoLand.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            ButtonGoHouse.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            ButtonGoApartaments.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");

            //Меняем цвет нажатую кнопку в Hover
            (sender as Button).Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey1");

        }
    }
}
