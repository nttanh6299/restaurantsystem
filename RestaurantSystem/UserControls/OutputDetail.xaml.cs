using RestaurantSystem.ViewModel;
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
    /// Interaction logic for OutputDetail.xaml
    /// </summary>
    public partial class OutputDetail : UserControl
    {
        OutputDetailViewModel vm { get; set; }
        public OutputDetail()
        {
            InitializeComponent();
            this.DataContext = vm = new OutputDetailViewModel();
        }
    }
}
