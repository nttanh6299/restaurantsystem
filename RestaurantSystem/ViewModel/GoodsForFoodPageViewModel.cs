using RestaurantSystem.Model;
using RestaurantSystem.ResourcesXAML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace RestaurantSystem.ViewModel
{
    class GoodsForFoodPageViewModel : BaseViewModel, IUserControl
    {
        #region list and entities
        private bool _IsSelectedFood;
        public bool IsSelectedFood { get => _IsSelectedFood; set { _IsSelectedFood = value; OnPropertyChanged(); } }

        private ObservableCollection<Food> _ListFood;
        public ObservableCollection<Food> ListFood { get => _ListFood; set { _ListFood = value; OnPropertyChanged(); } }
        private ObservableCollection<Goods> _ListGoods;
        public ObservableCollection<Goods> ListGoods { get => _ListGoods; set { _ListGoods = value; OnPropertyChanged(); } }
        private ObservableCollection<GoodsForFood> _ListGoodsForFood;
        public ObservableCollection<GoodsForFood> ListGoodsForFood { get => _ListGoodsForFood; set { _ListGoodsForFood = value; OnPropertyChanged(); } }

        private int _NewCount;
        public int NewCount { get => _NewCount; set { _NewCount = value; OnPropertyChanged(); } }
        private string _SearchFoodTextbox;
        public string SearchFoodTextbox { get => _SearchFoodTextbox; set { _SearchFoodTextbox = value; OnPropertyChanged(); } }
        private string _SearchGoodsTextbox;
        public string SearchGoodsTextbox { get => _SearchGoodsTextbox; set { _SearchGoodsTextbox = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private Unit _Unit;
        public Unit Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }
        private int _Count;
        public int Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }

        private Food _SelectedFood;
        public Food SelectedFood
        {
            get => _SelectedFood;
            set
            {
                _SelectedFood = value;
                OnPropertyChanged();
                if (SelectedFood != null)
                {
                    //khi món ăn đc select thì bảng nguyên liệu chế biến sẽ đc show ra
                    ListGoodsForFood = new ObservableCollection<GoodsForFood>(DataProvider.Ins.DB.GoodsForFood.Where(gf => gf.IdFood == SelectedFood.Id));
                    IsSelectedFood = true;
                }
            }
        }
        private Goods _SelectedGoods;
        public Goods SelectedGoods { get => _SelectedGoods; set { _SelectedGoods = value; OnPropertyChanged(); } }

        private GoodsForFood _SelectedGoodsForFood;
        public GoodsForFood SelectedGoodsForFood
        {
            get => _SelectedGoodsForFood;
            set
            {
                _SelectedGoodsForFood = value;
                OnPropertyChanged();
                if (SelectedGoodsForFood != null)
                {
                    Name = SelectedGoodsForFood.Goods.Name;
                    Unit = SelectedGoodsForFood.Goods.Unit;
                    Count = (int)SelectedGoodsForFood.Count;
                }
                else
                {
                    Name = null;
                    Unit = null;
                    Count = 0;
                }
            }
        }
        #endregion

        public ICommand SaveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchFoodCommand { get; set; }
        public ICommand SearchGoodsCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        public GoodsForFoodPageViewModel()
        {
            IsSelectedFood = false;
            //load ban đầu
            LoadCommand = new RelayCommand<object>(p => true, p => LoadList());

            //lưu nguyên liệu chế biến vào món ăn
            SaveCommand = new RelayCommand<object>(p =>
            {
                if (SelectedGoods == null)
                    return false;
                int count;
                //nếu đã có nguyên liệu này rồi thì ko cho thêm nữa
                count = DataProvider.Ins.DB.GoodsForFood.Where(w => w.IdGoods == SelectedGoods.Id && w.IdFood == SelectedFood.Id).Count();
                if (SelectedGoods != null && count != 0)
                    return false;
                return true;
            }, p =>
             {
                 GoodsForFood t = new GoodsForFood()
                 {
                     IdFood = SelectedFood.Id,
                     IdGoods = SelectedGoods.Id,
                     Count = NewCount
                 };

                 DataProvider.Ins.DB.GoodsForFood.Add(t);
                 DataProvider.Ins.DB.SaveChanges();

				 ListGoodsForFood = new ObservableCollection<GoodsForFood>(DataProvider.Ins.DB.GoodsForFood.Where(gf => gf.IdFood == SelectedFood.Id));
				 SelectedGoods = null;
				 NewCount = 0;
             });
            //sửa số lượng của nguyên liệu
            EditCommand = new RelayCommand<object>(p =>
            {
                if (SelectedGoodsForFood != null)
                    return true;
                return false;
            }, p =>
             {
                 var gff = DataProvider.Ins.DB.GoodsForFood.FirstOrDefault(f => f.Id == SelectedGoodsForFood.Id);
                 if (gff == null)
                     return;
                 gff.Count = Count;
                 DataProvider.Ins.DB.SaveChanges();
             });
            //xóa nguyên liệu chế biến khỏi món ăn
            DeleteCommand = new RelayCommand<object>(p =>
            {
                if (SelectedGoodsForFood != null)
                    return true;
                return false;
            }, p =>
             {
                 var temp = DataProvider.Ins.DB.GoodsForFood.FirstOrDefault(q => q.Id == SelectedGoodsForFood.Id);
                 if (temp == null)
                     return;
                 DataProvider.Ins.DB.GoodsForFood.Remove(temp);
                 DataProvider.Ins.DB.SaveChanges();

				 ListGoodsForFood = new ObservableCollection<GoodsForFood>(DataProvider.Ins.DB.GoodsForFood.Where(gf => gf.IdFood == SelectedFood.Id));
			 });
            //tìm kiếm món ăn
            SearchFoodCommand = new RelayCommand<object>(p => true, p =>
            {
                if (ListFood == null)
                    return;
                CollectionViewSource.GetDefaultView(ListFood).Refresh();
            });
            //tìm kiếm nguyên liệu
            SearchGoodsCommand = new RelayCommand<object>(p => true, p =>
            {
                if (ListGoods == null)
                    return;
                CollectionViewSource.GetDefaultView(ListGoods).Refresh();
            });

            ChangePageCommandIsEnabled = true;
        }

        public bool UserFilterFood(object item)
        {
            if (string.IsNullOrEmpty(SearchFoodTextbox))
                return true;
            else
                return (item as Food).Unit.Name.ToString().IndexOf(SearchFoodTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as Food).Name.IndexOf(SearchFoodTextbox, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public bool UserFilterGoods(object item)
        {
            if (string.IsNullOrEmpty(SearchGoodsTextbox))
                return true;
            else
                return (item as Goods).Unit.Name.ToString().IndexOf(SearchGoodsTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as Goods).Name.IndexOf(SearchGoodsTextbox, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void LoadList()
        {
            ListFood = new ObservableCollection<Food>(DataProvider.Ins.DB.Food);
            ListGoods = new ObservableCollection<Goods>(DataProvider.Ins.DB.Goods);
            CollectionView viewfood = (CollectionView)CollectionViewSource.GetDefaultView(ListFood);
            viewfood.Filter = UserFilterFood;
            CollectionView viewgoods = (CollectionView)CollectionViewSource.GetDefaultView(ListGoods);
            viewgoods.Filter = UserFilterGoods;
        }

        private bool _ChangePageCommandIsEnabled;
        public bool ChangePageCommandIsEnabled { get => _ChangePageCommandIsEnabled; set { _ChangePageCommandIsEnabled = value; OnPropertyChanged(); } }
    }
}
