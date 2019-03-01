using RestaurantSystem.AddWindow;
using RestaurantSystem.AddWindow.AEViewModel;
using RestaurantSystem.Model;
using RestaurantSystem.ResourcesXAML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace RestaurantSystem.ViewModel
{
    class StaffPageViewModel : BaseViewModel, IUserControl
    {
        #region list and entities

        public List<string> ListOrder { get; set; }
        public List<string> ListOrderKind { get; set; }

        private ObservableCollection<Staff> _List;
        public ObservableCollection<Staff> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<Role> _Role;
        public ObservableCollection<Role> Role { get => _Role; set { _Role = value; OnPropertyChanged(); } }

        private int _CountOfStaff;
        public int CountOfStaff { get => _CountOfStaff; set { _CountOfStaff = value; OnPropertyChanged(); } }
        private int _Index;
        public int Index { get => _Index; set { _Index = value; OnPropertyChanged(); } }
        private int _IndexOrder;
        public int IndexOrder { get => _IndexOrder; set { _IndexOrder = value; OnPropertyChanged(); } }
        private string _SearchTextbox;
        public string SearchTextbox { get => _SearchTextbox; set { _SearchTextbox = value; OnPropertyChanged(); } }

        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private Role _SelectedRole;
        public Role SelectedRole { get => _SelectedRole; set { _SelectedRole = value; OnPropertyChanged(); } }
        private Staff _SelectedItem;
        public Staff SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id = SelectedItem.Id;
                    UserName = SelectedItem.UserName;
                    Name = SelectedItem.Name;
                    SelectedRole = SelectedItem.Role;
                }
            }
        }
        #endregion

        public ICommand OrderCommand { get; set; }
        public ICommand OrderByCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public StaffPageViewModel()
        {
            Index = 0;
            IndexOrder = 0;
            ListOrder = new List<string>() { "ID", "Quyền hành" };
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
                AddStaff f = new AddStaff();
                f.ShowDialog();
                var id = (f.DataContext as AEStaffViewModel).Id;
                if (id == null)
                    return;
                Staff staff = new Staff()
                {
                    Id = id,
                    UserName = (f.DataContext as AEStaffViewModel).UserName,
                    Password = DataProvider.MD5Hash(DataProvider.EncodeTo64("1")),
                    Name = (f.DataContext as AEStaffViewModel).Name,
                    IdRole = (f.DataContext as AEStaffViewModel).SelectedRole.Id
                };
                    DataProvider.Ins.DB.Staff.Add(staff);
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
                    var staff = DataProvider.Ins.DB.Staff.FirstOrDefault(s => s.Id == SelectedItem.Id);
                    staff.Name = Name;
                    staff.IdRole = SelectedRole.Id;
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
            DeleteCommand = new RelayCommand<object>(p => true, p =>
            {

            });
            ChangePageCommandIsEnabled = true;
        }
        ObservableCollection<Staff> SetNewList(int index, int indexby)
        {
            
            {
                if (indexby == 0 && index == 0)
                {
                    return new ObservableCollection<Staff>(DataProvider.Ins.DB.Staff.OrderBy(o => o.Id));
                }
                else if (indexby == 0 && index == 1)
                {
                    return new ObservableCollection<Staff>(DataProvider.Ins.DB.Staff.OrderByDescending(o => o.Id));
                }
                else if (indexby == 1 && index == 0)
                {
                    return new ObservableCollection<Staff>(DataProvider.Ins.DB.Staff.OrderBy(o => o.Role.Name));
                }
                else
                {
                    return new ObservableCollection<Staff>(DataProvider.Ins.DB.Staff.OrderByDescending(o => o.Role.Name));
                }
            }
        }

        public bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchTextbox))
                return true;
            else
                return (item as Staff).Id.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as Staff).Name.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as Staff).Role.Name.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as Staff).UserName.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        void Load()
        {
                CountOfStaff = DataProvider.Ins.DB.Staff.Count();
                Role = new ObservableCollection<Role>(DataProvider.Ins.DB.Role);
            List = SetNewList(Index, IndexOrder);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
            view.Filter = UserFilter;
        }
       

        private bool _ChangePageCommandIsEnabled;
        public bool ChangePageCommandIsEnabled { get => _ChangePageCommandIsEnabled; set { _ChangePageCommandIsEnabled = value; OnPropertyChanged(); } }
    }
}
