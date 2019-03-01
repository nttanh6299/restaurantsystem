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
    class CategoryPageViewModel : BaseViewModel,IUserControl
    {
        #region list and entities

        public List<string> ListOrder { get; set; }
        public List<string> ListOrderKind { get; set; }

        private ObservableCollection<CategoryFood> _List;
        public ObservableCollection<CategoryFood> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private int _CountOfCategory;
        public int CountOfCategory { get => _CountOfCategory; set { _CountOfCategory = value; OnPropertyChanged(); } }
        private int _Index;
        public int Index { get => _Index; set { _Index = value; OnPropertyChanged(); } }
        private string _SearchTextbox;
        public string SearchTextbox { get => _SearchTextbox; set { _SearchTextbox = value; OnPropertyChanged(); } }

        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private CategoryFood _SelectedItem;
        public CategoryFood SelectedItem
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
                }
            }
        }
        #endregion

        public ICommand OrderCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        private bool _ChangePageCommandIsEnabled;
        public bool ChangePageCommandIsEnabled { get => _ChangePageCommandIsEnabled; set { _ChangePageCommandIsEnabled = value; OnPropertyChanged(); } }

        public CategoryPageViewModel()
        {
            Index = 0;           
            ListOrder = new List<string>() { "ID" };
            ListOrderKind = new List<string>() { "Tăng dần", "Giảm dần" };

            Load();

            //order by
            OrderCommand = new RelayCommand<ComboBox>(c => true, c =>
            {
                if (c.SelectedIndex < 1)
                {
                    List = SetNewList(Index);
                }
                else
                {
                    List = SetNewList(Index);
                }
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                view.Filter = UserFilter;
            });

            //add danh mục
            AddCommand = new RelayCommand<object>(p => true, p =>
               {
                   AECategoryWindow f = new AECategoryWindow();
                   f.ShowDialog();
                   var category = (f.DataContext as AECategoryViewModel).Id;
                   if (category<1)
                       return;
                   CategoryFood c = new CategoryFood() { Name = (f.DataContext as AECategoryViewModel).Name };
                       DataProvider.Ins.DB.CategoryFood.Add(c);
                       DataProvider.Ins.DB.SaveChanges();

                       Load();
               });

            //sửa danh mục
            EditCommand = new RelayCommand<object>(p =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, p =>
            {
                
                {
                    var s = DataProvider.Ins.DB.CategoryFood.FirstOrDefault(c => c.Id == SelectedItem.Id);
                    s.Name = Name;
                    DataProvider.Ins.DB.SaveChanges();
                }
            });

            //tìm kiếm danh mục
            SearchCommand = new RelayCommand<object>(p => true, p =>
            {
                if (List == null)
                    return;
                CollectionViewSource.GetDefaultView(List).Refresh();
            });

            ChangePageCommandIsEnabled = true;
        }
        //set list theo chiều tăng or giảm
        ObservableCollection<CategoryFood> SetNewList(int asORde)
        {
                if (asORde < 1)
                {
                    return new ObservableCollection<CategoryFood>(DataProvider.Ins.DB.CategoryFood.OrderBy(o => o.Id));
                }
                return new ObservableCollection<CategoryFood>(DataProvider.Ins.DB.CategoryFood.OrderByDescending(o => o.Id));
        }
        //method tìm kiếm
        public bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchTextbox))
                return true;
            else
                return (item as CategoryFood).Id.ToString().IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as CategoryFood).Name.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0;
        }
        //load ban đầu
        void Load()
        {
            CountOfCategory = DataProvider.Ins.DB.CategoryFood.Count(); 
            List = SetNewList(Index);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
            view.Filter = UserFilter;
        }
    }
}
