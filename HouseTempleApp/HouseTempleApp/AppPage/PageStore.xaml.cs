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
    /// Логика взаимодействия для PageStore.xaml
    /// </summary>
    public partial class PageStore : Page
    {
        public PageStore()
        {
            InitializeComponent();

        }
        private void ScrolPage(object sender, RoutedEventArgs e)
        {
            FrameNever.Content = null;

            //Единственное, что здесь можно, так это кнопки перекрашивать            ButtonNeedSupplies.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            ButtonPayment.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            GoodSdelka.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");

            //Единственное, что здесь можно, так это кнопки перекрашивать
            (sender as Button).Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey1");

            //Тут мы продаё1м в PageStoreEarth кнопку, что бы определить какую вкладку мы открываем
            if (sender == ButtonNeedSupplies || sender == ButtonPayment)
                FrameNever.NavigationService.Navigate (new PageStoreEarth(sender));

        }
    }
}
