﻿using System;
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
    /// Логика взаимодействия для PageCustomer.xaml
    /// </summary>
    public partial class PageCustomer : Page
    {
        public PageCustomer()
        {
            InitializeComponent();
        }
        private void Redaction_Card(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AppPage/PageEditUser.xaml", UriKind.Relative));
        }
    }
}
