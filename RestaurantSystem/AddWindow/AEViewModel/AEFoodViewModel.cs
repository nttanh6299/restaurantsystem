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
    class AEFoodViewModel : BaseViewModel
    {
        private List<CategoryFood> _CategoryFood;
        public List<CategoryFood> CategoryFood { get => _CategoryFood; set { _CategoryFood = value; OnPropertyChanged(); } }
        private List<Unit> _Unit;
        public List<Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }

        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private double _Price;
        public double Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private Unit _SelectedUnit;
        public Unit SelectedUnit { get => _SelectedUnit; set { _SelectedUnit = value; OnPropertyChanged(); } }
        private CategoryFood _SelectedCategoryFood;
        public CategoryFood SelectedCategoryFood { get => _SelectedCategoryFood; set { _SelectedCategoryFood = value; OnPropertyChanged(); } }

        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        private void Load()
        {
            CategoryFood = new List<CategoryFood>(DataProvider.Ins.DB.CategoryFood);
            Unit = new List<Unit>(DataProvider.Ins.DB.Unit);
        }

        public AEFoodViewModel()
        {
            Load();

            LoadCommand = new RelayCommand<Window>(p => true, p =>
            {
                //khi chưa có danh mục hoặc đơn vị tính thì thoát khỏi window này
                if(CategoryFood==null || CategoryFood.Count==0)
                {
                    MessageBox.Show("Chưa có danh mục, vui lòng thêm danh mục");
                    p.Close();
                }
                else if(Unit==null || Unit.Count==0)
                {
                    MessageBox.Show("Chưa có đơn vị tính, vui lòng thêm đơn vị tính");
                    p.Close();
                }
                
                else
                {
                    SelectedUnit = Unit[0];
                    SelectedCategoryFood = CategoryFood[0];
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
