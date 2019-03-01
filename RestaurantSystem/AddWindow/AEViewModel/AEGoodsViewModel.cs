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
    class AEGoodsViewModel : BaseViewModel
    {
        private List<Unit> _Unit;
        public List<Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }
        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private Unit _SelectedUnit;
        public Unit SelectedUnit { get => _SelectedUnit; set { _SelectedUnit = value; OnPropertyChanged(); } }

        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        private void Load()
        {
           
                Unit = new List<Unit>(DataProvider.Ins.DB.Unit);
            
        }
        public AEGoodsViewModel()
        {
            Load();
            MouseMoveWindowCommand = new RelayCommand<Window>(p => { return p == null ? false : true; }, p => p.DragMove());

            LoadCommand = new RelayCommand<Window>(p => true, p =>
            {
                if (Unit == null || Unit.Count == 0)
                {
                    MessageBox.Show("Chưa có đơn vị tính nào, vui lòng thêm đơn vị tính");
                    p.Close();
                }
                else
                {
                    SelectedUnit = Unit[0];
                }               
            });           

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
                p.Close();
            });
          
        }
    }
}
