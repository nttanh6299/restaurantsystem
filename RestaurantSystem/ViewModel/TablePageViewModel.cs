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
    class TablePageViewModel : BaseViewModel, IUserControl
    {
        #region list and entities

        public List<string> ListOrder { get; set; }
        public List<string> ListOrderKind { get; set; }

        private ObservableCollection<TableFood> _List;
        public ObservableCollection<TableFood> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<Region> _Region;
        public ObservableCollection<Region> Region { get => _Region; set { _Region = value; OnPropertyChanged(); } }

        private int _CountOfTable;
        public int CountOfTable { get => _CountOfTable; set { _CountOfTable = value; OnPropertyChanged(); } }
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
        private string _Status;
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }
        private Region _SelectedRegion;
        public Region SelectedRegion { get => _SelectedRegion; set { _SelectedRegion = value; OnPropertyChanged(); } }
        private TableFood _SelectedItem;
        public TableFood SelectedItem
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
                    SelectedRegion = SelectedItem.Region;
                    Status = SelectedItem.Status;
                }
            }
        }
        #endregion

        public ICommand OrderCommand { get; set; }
        public ICommand OrderByCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddRegionCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public TablePageViewModel()
        {
            Index = 0;
            IndexOrder = 0;

            ListOrder = new List<string>() { "ID Bàn", "Khu vực" };
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

            //add bàn
            AddCommand = new RelayCommand<object>(p => true, p =>
               {
                   AddTable f = new AddTable();
                   f.ShowDialog();
                   var id = (f.DataContext as AETableViewModel).Id;
                   if (id < 1)
                       return;
                   TableFood table = new TableFood() { Name = (f.DataContext as AETableViewModel).Name, IdRegion = (f.DataContext as AETableViewModel).SelectedRegion.Id, Status = "Đang trống" };

                   DataProvider.Ins.DB.TableFood.Add(table);
                   DataProvider.Ins.DB.SaveChanges();

                   Load();
               });

            //edit bàn
            EditCommand = new RelayCommand<object>(p => 
            {
                if (SelectedItem == null)
                    return false;
                return true;
            },p=>
            {
                var t = DataProvider.Ins.DB.TableFood.SingleOrDefault(table => table.Id == SelectedItem.Id);
                t.Name = Name;
                t.IdRegion = SelectedRegion.Id;
                DataProvider.Ins.DB.SaveChanges();
            });

            //tìm kiếm
            SearchCommand = new RelayCommand<object>(p => true, p =>
            {
                if (List == null)
                    return;
                CollectionViewSource.GetDefaultView(List).Refresh();
            });
            //thêm khu vực
            AddRegionCommand = new RelayCommand<object>(p => true, p => 
            {
                AddRegion f = new AddRegion();
                f.ShowDialog();
                var id = (f.DataContext as AERegionViewModel).Id;
                if (id == 0)
                    return;
                Region region = new Region()
                {
                    Name = (f.DataContext as AERegionViewModel).Name
                };
                DataProvider.Ins.DB.Region.Add(region);
                DataProvider.Ins.DB.SaveChanges();
                //load lại region
                Region = new ObservableCollection<Region>(DataProvider.Ins.DB.Region);
            });

            //delete
            DeleteCommand = new RelayCommand<object>(p => true, p => 
            {
                
            });
            ChangePageCommandIsEnabled = true;
        }
        /*
         * 0:id         | 0: tang dan
         * 1:khu vực  | 1: giam dan
         */
        ObservableCollection<TableFood> SetNewList(int index,int indexby)
        {
                if (indexby == 0 && index == 0)
                {
                    return new ObservableCollection<TableFood>(DataProvider.Ins.DB.TableFood.OrderBy(o => o.Id));
                }
                else if (indexby == 0 && index == 1)
                {
                    return new ObservableCollection<TableFood>(DataProvider.Ins.DB.TableFood.OrderByDescending(o => o.Id));
                }
                else if (indexby == 1 && index == 0)
                {
                    return new ObservableCollection<TableFood>(DataProvider.Ins.DB.TableFood.OrderBy(o => o.Region.Name));
                }
                else
                {
                    return new ObservableCollection<TableFood>(DataProvider.Ins.DB.TableFood.OrderByDescending(o => o.Region.Name));
                }
        }

        public bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchTextbox))
                return true;
            else
                return (item as TableFood).Id.ToString().IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as TableFood).Name.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as TableFood).Region.Name.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as TableFood).Status.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        void Load()
        {
            
                CountOfTable = DataProvider.Ins.DB.TableFood.Count();
                Region = new ObservableCollection<Region>(DataProvider.Ins.DB.Region);

            List = SetNewList( Index,IndexOrder);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
            view.Filter = UserFilter;
        }

        private bool _ChangePageCommandIsEnabled;
        public bool ChangePageCommandIsEnabled { get => _ChangePageCommandIsEnabled; set { _ChangePageCommandIsEnabled = value; OnPropertyChanged(); } }
    }
}
