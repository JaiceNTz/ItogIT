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
    /// Логика взаимодействия для PageDally.xaml
    /// </summary>
    public partial class PageDally : Page
    {
        public PageDally()
        {
            InitializeComponent();
            DataGridShare.ItemsSource = HouseTempleEntities.GetContext().RealEstate.ToList();
        }
    }
}
