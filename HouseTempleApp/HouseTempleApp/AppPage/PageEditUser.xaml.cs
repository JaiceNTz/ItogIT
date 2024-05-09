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
    /// Логика взаимодействия для PageEditUser.xaml
    /// </summary>
    public partial class PageEditUser : Page
    {
        User EntityEditUser;

        public PageEditUser(User user)
        {
            EntityEditUser = user;
            InitializeComponent();


          //  if (user.IdRole == "2")
            {
                TextBlockLabel.Text = "Карточка клиента";
                var clientInfo = HouseTempleEntities.GetContext().Client.Where(i => i.Id == user.Id).ToList()[0];
                TextBoxLogin.Text = user.Login;
                TextBoxNumberPhone.Text = clientInfo.Phone;
                TextBoxEmail.Text = clientInfo.Email;
                PasswordBoxOldPassword.Password = user.Password;

                TextBlockMidlName.Text = "Отчество:";
                TextBlockFirstName.Text = "Фамилия:";
                TextBlockLastName.Text = "Имя:";

            }
           // if (user.IdRole == "Риэлтор")
            {
             //   TextBlockLabel.Text = "Карточка риэлтора";
             //   var RieltorInfo = HouseTempleEntities.GetContext().Person.Where(i => i.Id == editUser.Id).ToList()[0];
             //   TextBoxLogin.Text = user.Login;
             //   TextBoxLastName.Text = RieltorInfo.LastName;
             //   TextBoxFirstName.Text = RieltorInfo.FirstName;
             //   TextBoxMidlName.Text = RieltorInfo.MiddleName;

                TextBlockMidlName.Text = "Отчество*:";
                TextBlockFirstName.Text = "Фамилия*:";
                TextBlockLastName.Text = "Имя*:";

                WarningContactItem.Text = "Поля номер телефона и Email для риелторов не заполняются.";


                TextBoxNumberPhone.IsEnabled = false;
                TextBoxEmail.IsEnabled = false;
                TextBoxNumberPhone.Background = (Brush)Application.Current.MainWindow.FindResource("Grey");
                TextBoxEmail.Background = (Brush)Application.Current.MainWindow.FindResource("Grey");

            }
        }

        public PageEditUser()
        {
            InitializeComponent();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var user = AppConnect.HouseDB.User.FirstOrDefault();

            if (user.IdRole == 2)
            {
                this.NavigationService.Navigate(new Uri("AppPage/PageRieltor.xaml", UriKind.Relative));
            }
            else
            {
                this.NavigationService.Navigate(new Uri("AppPage/PageCustomer.xaml", UriKind.Relative));
            }

            var bc = new BrushConverter();
            string messageWarning = "";
            TextBlockWarning.Text = "";
            string newLogin = TextBoxLogin.Text;

            PasswordBoxNewPassword.Background = Brushes.White;
            PasswordBoxOldPassword.Background = Brushes.White;
            WarningContactItem.Foreground = (Brush)bc.ConvertFrom("#546e7a");
            TextBoxNumberPhone.Background = Brushes.White;

            if (PasswordBoxNewPassword.Password.ToString().Length < 6 && !(PasswordBoxNewPassword.Password is null))
            {
                MessageBox.Show("Error 422\n Пароль должен содержать не меньше 6 символов");
                messageWarning = "\nПароль должен содержать не меньше 6 символов";
                PasswordBoxNewPassword.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }



            if (messageWarning.Length > 2)
            {
                TextBlockWarning.Text = messageWarning;
            }
            else
            {
                // HouseTempleEntities.Password = PasswordBoxNewPassword.Password.ToString();
                HouseTempleEntities.GetContext().SaveChanges();

                // if (HouseTempleEntities.IdRole == "2")
                // {
                //   var editClient = HouseTempleEntities.GetContext().Client.Where(i => i.Id == HouseTempleEntities.IdRole).ToList()[0];
                //   if (TextBoxLastName.Text.Length > 3)
                //   {
                //       editClient.LastName = TextBoxLastName.Text;
                //   }
                //   else
                //   {
                //       editClient.LastName = null;
                //   }
                //   if (TextBoxFirstName.Text.Length > 3)
                //   {
                //       editClient.FirstName = TextBoxFirstName.Text;
                //   }
                //   else
                //   {
                //       editClient.FirstName = null;
                //   }
                //   if (TextBoxMidlName.Text.Length > 1)
                //   {
                //       editClient.MidlName = TextBoxMidlName.Text;
                //   }
                //   else
                //   {
                //       editClient.MidlName = null;
                //   }
                //   if (TextBoxEmail.Text.Length > 3)
                //   {
                //       editClient.Email = TextBoxEmail.Text;
                //   }
                //   else
                //   {
                //       editClient.Email = null;
                //   }
                //   if (TextBoxNumberPhone.Text.Length == 12)
                //   {
                //       editClient.Phone = TextBoxNumberPhone.Text;
                //   }
                //   else
                //   {
                //       editClient.Phone = null;
                //   }
                // }


                // if (HouseTempleEntities.IdRole == 2)
                // {
                //     var editClient = HouseTempleEntities.GetContext().User.Where(i => i.Id == HouseTempleEntities.FirstName).ToList()[0];
                //     if (TextBoxLastName.Text.Length > 3)
                //         editClient.LastName = TextBoxLastName.Text;
                //     if (TextBoxFirstName.Text.Length > 3)
                //         editClient.FirstName = TextBoxFirstName.Text;
                //     if (TextBoxMidlName.Text.Length > 1)
                //         editClient.MidlName = TextBoxMidlName.Text;
                // }

                HouseTempleEntities.GetContext().SaveChanges();

                MessageBox.Show("Изменения сохранены");
            }
        }
    }
}