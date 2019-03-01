using RestaurantSystem.AddWindow.AEViewModel;
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
using System.Windows.Shapes;

namespace RestaurantSystem.AddWindow
{
    /// <summary>
    /// Interaction logic for AddStaff.xaml
    /// </summary>
    public partial class AddStaff : Window
    {
        AEStaffViewModel vm { get; set; }
        public AddStaff()
        {
            InitializeComponent();
            this.DataContext = vm = new AEStaffViewModel();
        }
    }
}
