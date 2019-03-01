using RestaurantSystem.AddWindow;
using RestaurantSystem.AddWindow.AEViewModel;
using RestaurantSystem.Model;
using RestaurantSystem.ResourcesXAML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace RestaurantSystem.ViewModel
{
    class FoodPageViewModel : BaseViewModel,IUserControl
    {
        #region list and entities

        public List<string> ListOrder { get; set; }
        public List<string> ListOrderKind { get; set; }

        private ObservableCollection<Food> _List;
        public ObservableCollection<Food> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<Unit> _Unit;
        public ObservableCollection<Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }
        private ObservableCollection<CategoryFood> _CategoryFood;
        public ObservableCollection<CategoryFood> CategoryFood { get => _CategoryFood; set { _CategoryFood = value; OnPropertyChanged(); } }

        private int _CountOfFood;
        public int CountOfFood { get => _CountOfFood; set { _CountOfFood = value; OnPropertyChanged(); } }
        private int _Index;
        public int Index { get => _Index; set { _Index = value; OnPropertyChanged(); } }
        private int _IndexOrder;
        public int IndexOrder { get => _IndexOrder; set { _IndexOrder = value; OnPropertyChanged(); } }
        private string _SearchTextbox;
        public string SearchTextbox { get => _SearchTextbox; set { _SearchTextbox = value; OnPropertyChanged(); } }

        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private double _Price;
        public double Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }
        private Unit _SelectedUnit;
        public Unit SelectedUnit { get => _SelectedUnit; set { _SelectedUnit = value; OnPropertyChanged(); } }
        private CategoryFood _SelectedCategoryFood;
        public CategoryFood SelectedCategoryFood { get => _SelectedCategoryFood; set { _SelectedCategoryFood = value; OnPropertyChanged(); } }
        private Food _SelectedItem;
        public Food SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id = SelectedItem.Id;
                    Name = SelectedItem.Name;
                    SelectedUnit = SelectedItem.Unit;
                    SelectedCategoryFood = SelectedItem.CategoryFood;
                    Price = (double)SelectedItem.Price;
                }
            }
        }
        #endregion

        public ICommand OrderCommand { get; set; }
        public ICommand OrderByCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddUnitCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public FoodPageViewModel()
        {
            Index = 0;
            IndexOrder = 0;
            ListOrder = new List<string>() { "ID", "Danh mục" };
            ListOrderKind = new List<string>() { "Tăng dần", "Giảm dần" };
            Load();

            //order by
            OrderCommand = new RelayCommand<ComboBox>(c => true, c =>
            {
                List = SetNewList(Index, IndexOrder);
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                view.Filter = UserFilter;
            });

            //order by id and region
            OrderByCommand = new RelayCommand<ComboBox>(c => true, c =>
            {
                List = SetNewList(Index, IndexOrder);
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                view.Filter = UserFilter;
            });

            //add
            AddCommand = new RelayCommand<object>(p => true, p =>
            {
                AddFood f = new AddFood();
                f.ShowDialog();
                var food = (f.DataContext as AEFoodViewModel).Id;
                if (food == 0)
                    return;
                Food newfood = new Food()
                {
                    Name = (f.DataContext as AEFoodViewModel).Name,
                    Price = (f.DataContext as AEFoodViewModel).Price,
                    IdUnit = (f.DataContext as AEFoodViewModel).SelectedUnit.Id,
                    IdCategoryFood = (f.DataContext as AEFoodViewModel).SelectedCategoryFood.Id
                };
                    DataProvider.Ins.DB.Food.Add(newfood);
                    DataProvider.Ins.DB.SaveChanges();
                    Load();
            });

            //edit
            EditCommand = new RelayCommand<object>(p =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, p =>
            {
                var food = DataProvider.Ins.DB.Food.FirstOrDefault(f => f.Id == SelectedItem.Id);
                if (food == null)
                    return;
                food.Name = Name;
                food.Price = Price;
                food.IdCategoryFood = SelectedCategoryFood.Id;
                food.IdUnit = SelectedUnit.Id;
                DataProvider.Ins.DB.SaveChanges();
            });
            //add unit
            AddUnitCommand = new RelayCommand<object>(p => true, p =>
            {
                AddUnit f = new AddUnit();
                f.ShowDialog();
                var idgood = (f.DataContext as AEUnitViewModel).Id;
                if (idgood == 0)
                    return;
                Model.Unit unit = new Unit()
                {
                    Name = (f.DataContext as AEUnitViewModel).Name
                };
                
                {
                    DataProvider.Ins.DB.Unit.Add(unit);
                    DataProvider.Ins.DB.SaveChanges();
                    Unit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                }
            });
            //search
            SearchCommand = new RelayCommand<object>(p => true, p =>
            {
                if (List == null)
                    return;
                CollectionViewSource.GetDefaultView(List).Refresh();
            });

            //delete
            DeleteCommand = new RelayCommand<object>(p => true, p =>
            {

            });
            ChangePageCommandIsEnabled = true;
        }
        //set list theo chiều tang hoặc giảm và theo id hoặc danh mục
        ObservableCollection<Food> SetNewList(int index, int indexby)
        {
            
            {
                if (indexby == 0 && index == 0)
                {
                    return new ObservableCollection<Food>(DataProvider.Ins.DB.Food.OrderBy(o => o.Id));
                }
                else if (indexby == 0 && index == 1)
                {
                    return new ObservableCollection<Food>(DataProvider.Ins.DB.Food.OrderByDescending(o => o.Id));
                }
                else if (indexby == 1 && index == 0)
                {
                    return new ObservableCollection<Food>(DataProvider.Ins.DB.Food.OrderBy(o => o.CategoryFood.Name));
                }
                else
                {
                    return new ObservableCollection<Food>(DataProvider.Ins.DB.Food.OrderByDescending(o => o.CategoryFood.Name));
                }
            }
        }

        public bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchTextbox))
                return true;
            else
                return (item as Food).Id.ToString().IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as Food).Name.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as Food).CategoryFood.Name.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as Food).Price.ToString().IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        void Load()
        {
                Unit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                CategoryFood = new ObservableCollection<CategoryFood>(DataProvider.Ins.DB.CategoryFood);
                List = new ObservableCollection<Food>(DataProvider.Ins.DB.Food);
            List = SetNewList(Index, IndexOrder);
            CountOfFood = DataProvider.Ins.DB.Food.Count(); 
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
            view.Filter = UserFilter;
        }
        private bool _ChangePageCommandIsEnabled;
        public bool ChangePageCommandIsEnabled { get => _ChangePageCommandIsEnabled; set { _ChangePageCommandIsEnabled = value; OnPropertyChanged(); } }
    }
}
