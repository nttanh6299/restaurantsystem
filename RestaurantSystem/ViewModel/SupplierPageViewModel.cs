
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace RestaurantSystem.ViewModel
{
    class SupplierPageViewModel : BaseViewModel, IUserControl
    {
        #region lists and entities

        public List<string> ListOrder { get; set; }
        public List<string> ListOrderKind { get; set; }

        private ObservableCollection<Supplier> _List;
        public ObservableCollection<Supplier> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private int _CountOfSupplier;
        public int CountOfSupplier { get => _CountOfSupplier; set { _CountOfSupplier = value; OnPropertyChanged(); } }
        private int _Index;
        public int Index { get => _Index; set { _Index = value; OnPropertyChanged(); } }
        private string _SearchTextbox;
        public string SearchTextbox { get => _SearchTextbox; set { _SearchTextbox = value; OnPropertyChanged(); } }

        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }
        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }

        private Supplier _SelectedItem;
        public Supplier SelectedItem
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
                    Address = SelectedItem.Address;
                    Phone = SelectedItem.Phone;
                    Email = SelectedItem.Email;
                    MoreInfo = SelectedItem.MoreInfo;
                    ContractDate = SelectedItem.ContractDate;
                }
            }
        }
        #endregion

        #region commands
        public ICommand SearchCommand { get; set; }
        public ICommand OrderCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        #endregion

        public SupplierPageViewModel()
        {
            //index của combobox sắp xếp
            Index = 0;

            ListOrder = new List<string>() { "ID NCC" };
            ListOrderKind = new List<string>() { "Tăng dần", "Giảm dần" };

            Load();          

            //sắp xếp lại list
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
           
            //add
            AddCommand = new RelayCommand<object>(p => true, p =>
            {
                AddSupplier f = new AddSupplier();
                f.ShowDialog();
                var IdSupplier = (f.DataContext as AESupplierViewModel).Id;
                if (IdSupplier == null)
                    return;
                Supplier s = new Supplier()
                {
                    Id = IdSupplier,
                    Name = (f.DataContext as AESupplierViewModel).Name,
                    Phone = (f.DataContext as AESupplierViewModel).Phone,
                    Address = (f.DataContext as AESupplierViewModel).Address,
                    Email = (f.DataContext as AESupplierViewModel).Email,
                    MoreInfo = (f.DataContext as AESupplierViewModel).MoreInfo,
                    ContractDate = (f.DataContext as AESupplierViewModel).ContractDate
                };
                DataProvider.Ins.DB.Supplier.Add(s);
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
                var s = DataProvider.Ins.DB.Supplier.FirstOrDefault(sp => sp.Id == SelectedItem.Id);
                s.Name = Name;
                s.Address = Address;
                s.Phone = Phone;
                s.Email = Email;
                s.ContractDate = ContractDate;
                s.MoreInfo = MoreInfo;
                DataProvider.Ins.DB.SaveChanges();
            });

            //tìm kiếm
            SearchCommand = new RelayCommand<object>(p => true, p => 
            {
                if (List == null)
                    return;
                CollectionViewSource.GetDefaultView(List).Refresh();
            });

            //delete
            DeleteCommand = new RelayCommand<object>(p =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, p =>
            {

            });

            ChangePageCommandIsEnabled = true;
        }
        //method set list theo chiều tăng hoặc giảm
        ObservableCollection<Supplier> SetNewList(int asORde )//tăng dần hay giảm dần
        {
                if (asORde < 1)
                {
                    return new ObservableCollection<Supplier>(DataProvider.Ins.DB.Supplier.OrderBy(o => o.Id));
                }
                return new ObservableCollection<Supplier>(DataProvider.Ins.DB.Supplier.OrderByDescending(o => o.Id));
        }
        //load ban đầu
        void Load()
        {
            CountOfSupplier = DataProvider.Ins.DB.Supplier.Count();
            List = SetNewList(Index);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
            view.Filter = UserFilter;
        }
        //method để tìm kiếm
        public bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchTextbox))
                return true;
            else
                return (item as Supplier).Id.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as Supplier).Name.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool _ChangePageCommandIsEnabled;
        public bool ChangePageCommandIsEnabled { get => _ChangePageCommandIsEnabled; set { _ChangePageCommandIsEnabled = value; OnPropertyChanged(); } }
    }
}
