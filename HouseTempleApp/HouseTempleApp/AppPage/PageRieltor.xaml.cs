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
    /// Логика взаимодействия для PageRieltor.xaml
    /// </summary>
    public partial class PageRieltor : Page
    {
        List<Person> ListUsers;

        public PageRieltor()
        {
            InitializeComponent();
            ListUsers = HouseTempleEntities.GetContext().Person.ToList();
            UsersScan.ItemsSource = ListUsers;
        }
        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            Button selectButton = sender as Button;
            UsersScan.ItemsSource = HouseTempleEntities.GetContext().Person.ToList();
            this.NavigationService.Navigate(new Uri("AppPage/PageEditUser.xaml", UriKind.Relative));
        }

        private void AddNewUser_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AppPage/PageAddUser.xaml", UriKind.Relative));
        }

        private void ChangedTextBoxSearchBox(object sender, TextChangedEventArgs e)
        {
            List<Person> FilterListUser = new List<Person>();
            if (TextBoxSearchBox.Text.Length > 5)
            {
                foreach (Person user in ListUsers)
                {
                    if (LevenshteinDistance(user.LastName.ToString(), TextBoxSearchBox.Text) <= 2 || LevenshteinDistance(user.FirstName.ToString(), TextBoxSearchBox.Text) <= 2 || LevenshteinDistance(user.MiddleName.ToString(), TextBoxSearchBox.Text) <= 2 || user.LastName.ToString().Contains(TextBoxSearchBox.Text.ToString()) || user.FirstName.ToString().Contains(TextBoxSearchBox.Text.ToString()) || user.MiddleName.ToString().Contains(TextBoxSearchBox.Text.ToString()))
                        FilterListUser.Add(user);
                }
            }
            else
            {
                FilterListUser = ListUsers;
            }
        
            UsersScan.ItemsSource = FilterListUser;

        }

        private void DeletedUser_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Вы точно хотите удалить данную запись?",
                "Сохранить файл",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int selectedDellIdUser = (UsersScan.SelectedItem as Person).Id;
                (HouseTempleEntities.GetContext().User.Where(i => i.Id == selectedDellIdUser).ToList()[0] as User).Id = int.Parse(Application.Current.Resources["LastName"].ToString());
                HouseTempleEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись успешно удалена");
                ListUsers = HouseTempleEntities.GetContext().Person.Where(i => i.LastName == null).ToList();
                UsersScan.ItemsSource = ListUsers;
            }
        }
        public static int LevenshteinDistance(string string1, string string2)
        {
            if (string1 == null) string1 = "";
            if (string2 == null) string2 = "";
            int diff;
            int[,] m = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 0; i <= string1.Length; i++) { m[i, 0] = i; }
            for (int j = 0; j <= string2.Length; j++) { m[0, j] = j; }

            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
                }
            }
            return m[string1.Length, string2.Length];
        }
    }
}
