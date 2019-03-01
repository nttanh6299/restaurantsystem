using RestaurantSystem.Model;
using RestaurantSystem.ResourcesXAML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RestaurantSystem.ViewModel
{
    class ManageViewModel : BaseViewModel
    {
        private Staff _Account;
        public Staff Account {get=>_Account; set { _Account = value; OnPropertyChanged();} }
        private bool _IsAdmin;
        public bool IsAdmin { get => _IsAdmin; set { _IsAdmin = value; OnPropertyChanged(); } }

        public ICommand POSCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        #region change page helper
        private IUserControl _CurrentPageViewModel;
        private List<IUserControl> _ListPageViewModel;
        private ICommand _ChangePageCommand;
        private int indexOfCurrentViewModel;

        public IUserControl CurrentPageViewModel { get => _CurrentPageViewModel; set { _CurrentPageViewModel = value;OnPropertyChanged(); } }
        public List<IUserControl> ListPageViewModel
        {
            get
            {
                if (_ListPageViewModel == null)
                    _ListPageViewModel = new List<IUserControl>();
                return _ListPageViewModel;
            }
        }
        public ICommand ChangePageCommand
        {
            get
            {
                if (_ChangePageCommand == null)
                    _ChangePageCommand = new RelayCommand<IUserControl>(p => 
                    {
                        return p.ChangePageCommandIsEnabled == true ? true : false;
                    }, p => ChangeViewModel((IUserControl)p));
                return _ChangePageCommand;
            }
        }
        #endregion

        //change view model method
        private void ChangeViewModel(IUserControl p)
        {
            //nếu method này đc thực thi (tức là 1 button đc nhấn),
            //isEnabled của button đc nhấn trước đó sẽ đc set lại true
            ListPageViewModel[indexOfCurrentViewModel].ChangePageCommandIsEnabled = true;

            //trong trường hợp ngoại lệ (list chưa có viewmodel này)
            if (!ListPageViewModel.Contains(p))
                ListPageViewModel.Add(p);

            //lấy viewmodel khi button đc nhấn
            CurrentPageViewModel = ListPageViewModel.FirstOrDefault(vm => vm == p);

            //set index của viewmodel
            indexOfCurrentViewModel = ListPageViewModel.IndexOf(CurrentPageViewModel);
            //set lại isEnabled của viewmodel hiện tại (current viewmodel)
            ListPageViewModel[indexOfCurrentViewModel].ChangePageCommandIsEnabled = false;
        }

        public ManageViewModel()
        {
            //add tất cả các uc vm
            ListPageViewModel.Add(new HomeUCViewModel());
            ListPageViewModel.Add(new SupplierPageViewModel());
            ListPageViewModel.Add(new CategoryPageViewModel());
            ListPageViewModel.Add(new TablePageViewModel());
            ListPageViewModel.Add(new StaffPageViewModel());
            ListPageViewModel.Add(new InventoryInfoPageViewModel());
            ListPageViewModel.Add(new FoodPageViewModel());
            ListPageViewModel.Add(new GoodsForFoodPageViewModel());
            ListPageViewModel.Add(new InputPageViewModel());
            ListPageViewModel.Add(new OutputPageViewModel());
            ListPageViewModel.Add(new StatisticsPageViewModel());
            ListPageViewModel.Add(new RevenuePageViewModel());
            ListPageViewModel.Add(new StatisticsFoodViewModel());
            //load lại page khi có sự đăng nhập
            LoadCommand = new RelayCommand<Window>(p => true, p =>
            {              
                foreach (var item in ListPageViewModel)
                {
                    item.ChangePageCommandIsEnabled = true;
                }
                CurrentPageViewModel = ListPageViewModel[0];
                indexOfCurrentViewModel = 0;
                CurrentPageViewModel.ChangePageCommandIsEnabled = false;
                //lấy account khi đã đăng nhập
                Account = LoginViewModel.LoginAccount;

                //nếu role là 2 (nhân viên) thì chỉ có thể sử dụng page Home và Window bán hàng
                if (Account.IdRole == 1)
                    IsAdmin = true;
                else
                    IsAdmin = false;
            });
            ChangePasswordCommand = new RelayCommand<object>(p => true, p => { ChangePasswordWindow f = new ChangePasswordWindow(); f.ShowDialog(); });

            //vào quầy bán hàng
            POSCommand = new RelayCommand<Window>(p=>true,p=>
            {
                POSWindow f = new POSWindow();
                f.ShowDialog();
            });

            //đăng xuất
            LogoutCommand = new RelayCommand<Window>(p => true, p => p.Close());
        }

    }
}
