﻿using RestaurantSystem.ViewModel;
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

namespace RestaurantSystem.UserControls
{
    /// <summary>
    /// Interaction logic for RevenueNormal.xaml
    /// </summary>
    public partial class RevenueNormal : UserControl
    {
        RevenueNormalViewModel vm { get; set; }
        public RevenueNormal()
        {
            InitializeComponent();
            this.DataContext = vm = new RevenueNormalViewModel();
        }
    }
}
