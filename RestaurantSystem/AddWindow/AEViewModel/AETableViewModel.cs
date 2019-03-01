using RestaurantSystem.Model;
using RestaurantSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RestaurantSystem.AddWindow.AEViewModel
{
    class AETableViewModel : BaseViewModel
    {
        private List<Region> _Region;
        public List<Region> Region { get=> _Region; set { _Region = value;OnPropertyChanged(); } }

        private Region _SelectedRegion;
        public Region SelectedRegion { get => _SelectedRegion; set { _SelectedRegion = value;OnPropertyChanged(); } }

        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        private void Load()
        {
            
            {
                Region = new List<Region>(DataProvider.Ins.DB.Region);
            }
        }

        public AETableViewModel()
        {
            Load();
            LoadCommand = new RelayCommand<Window>(p => true, p => 
            {
                if(Region==null || Region.Count==0)
                {
                    MessageBox.Show("Chưa có khu vực, vui lòng thêm khu vực");
                    p.Close();
                }
                else
                {
                    SelectedRegion = Region[0];
                }
            });           

            MouseMoveWindowCommand = new RelayCommand<Window>(p => { return p == null ? false : true; }, p => p.DragMove());

            OKCommand = new RelayCommand<Window>(p =>
            {
                if (string.IsNullOrEmpty(Name))
                    return false;
                return true;
            }, p =>
            {
                Id = 1;
                p.Close();
            });

            ExitCommand = new RelayCommand<Window>(p => true, p =>
            {
                Id = 0;
                Name = null;
                p.Close();
            });
        }
    }
}
