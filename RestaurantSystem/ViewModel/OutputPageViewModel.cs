using RestaurantSystem.Model;
using RestaurantSystem.ReportView;
using RestaurantSystem.ResourcesXAML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RestaurantSystem.ViewModel
{
    //lớp tương tự như phiếu nhập, chỉ ko có nhà cung cấp và giá nhập
    class OutputPageViewModel : BaseViewModel,IUserControl
    {
        #region list and entities
        private Staff _LoginningAccount;
        public Staff LoginningAccount { get => _LoginningAccount; set { _LoginningAccount = value; OnPropertyChanged(); } }

        private bool _IsAdd;
        public bool IsAdd { get => _IsAdd; set { _IsAdd = value; OnPropertyChanged(); } }
        private bool _IsSave;
        public bool IsSave { get => _IsSave; set { _IsSave = value; OnPropertyChanged(); } }

        private ObservableCollection<OutputInfo> _OutputInfoList;
        public ObservableCollection<OutputInfo> OutputInfoList { get => _OutputInfoList; set { _OutputInfoList = value; OnPropertyChanged(); } }
        private OutputInfo _SelectedOutputInfo;
        public OutputInfo SelectedOutputInfo { get => _SelectedOutputInfo; set { _SelectedOutputInfo = value; OnPropertyChanged(); } }

        private List<Goods> _GoodsList;
        public List<Goods> GoodsList { get => _GoodsList; set { _GoodsList = value; OnPropertyChanged(); } }
        private Goods _SelectedGoods;
        public Goods SelectedGoods { get => _SelectedGoods; set { _SelectedGoods = value; OnPropertyChanged(); } }
        private int _Count;
        public int Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }

        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private DateTime? _DateOutput;
        public DateTime? DateOutput { get => _DateOutput; set { _DateOutput = value; OnPropertyChanged(); } }
        private string _StaffName;
        public string StaffName { get => _StaffName; set { _StaffName = value; OnPropertyChanged(); } }
        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }
        #endregion

        #region commands
        public ICommand AddCommand { get; set; }
        public ICommand AddNewCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DeleteOutputInfoCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        #endregion

        public OutputPageViewModel()
        {
            IsAdd = false;
            IsSave = true;
            //thêm mới phiếu
            AddNewCommand = new RelayCommand<object>(p => true, p =>
            {
                IsAdd = true;
                IsSave = false;

                LoginningAccount = LoginViewModel.LoginAccount;

                GoodsList = new List<Goods>(DataProvider.Ins.DB.Goods);

                if (GoodsList == null || GoodsList.Count == 0)
                {
                    MessageBox.Show("Chưa có hàng hóa nào, vui lòng thêm hàng hóa");
                    IsAdd = false;
                    IsSave = true;
                    return;
                }

                Id = "HDX" + DataProvider.RandomString(6);
                while (DataProvider.Ins.DB.Output.Where(w => w.Id == Id).Count() != 0)
                {
                    Id = "HDX" + DataProvider.RandomString(6);
                }
                SelectedGoods = GoodsList[0];
                StaffName = LoginningAccount.Id + " - " + LoginningAccount.Name;
                DateOutput = DateTime.Now;
                OutputInfoList = new ObservableCollection<OutputInfo>();
            });
            //thêm hàng hóa vào phiếu
            AddCommand = new RelayCommand<object>(p => true, p =>
            {
                if (SelectedGoods == null)
                {
                    MessageBox.Show("Chưa có hoặc chưa đúng như trong danh sách");
                    return;
                }
                if (Count <= 0)
                {
                    MessageBox.Show("Số lượng nhập hoặc giá phải phải lớn hơn 0");
                    return;
                }
                OutputInfo newOutputInfo = new OutputInfo()
                {
                    IdOutput = Id,
                    IdGoods = SelectedGoods.Id,
                    Goods = SelectedGoods,
                    Count = Count,
                };
                OutputInfoList.Add(newOutputInfo);
            });
            //lưu phiếu vào csdl
            SaveCommand = new RelayCommand<object>(p => 
            {
                if (OutputInfoList == null || OutputInfoList.Count < 1)
                    return false;
                return true;
            }, p =>
            {
                MessageBoxResult rs = MessageBox.Show("Xác nhận lưu hóa đơn ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (rs == MessageBoxResult.Cancel)
                    return;
                Output output = new Output()
                {
                    Id = Id,
                    DateOutput = DateOutput,
                    MoreInfo = MoreInfo,
                    IdStaff = LoginningAccount.Id
                };

                DataProvider.Ins.DB.Output.Add(output);
                DataProvider.Ins.DB.OutputInfo.AddRange(OutputInfoList);
                DataProvider.Ins.DB.SaveChanges();

                IsAdd = false;
                IsSave = true;
            });
            //in
            PrintCommand = new RelayCommand<object>(p =>
            {
                //khi chưa có id thì ko cho in
                if (Id == null)
                    return false;
                int count = 0;

                count = DataProvider.Ins.DB.Output.Where(w => w.Id == Id).Count();

                if (count < 1)
                    return false;
                return true;
            }, p =>
            {
                Output billoutput;

                billoutput = DataProvider.Ins.DB.Output.FirstOrDefault(b => b.Id == Id);
                if (billoutput == null)
                {
                    MessageBox.Show("Error");
                }
                rpOutputWindow f = new rpOutputWindow(billoutput);
                f.ShowDialog();
            });
            //xóa phiếu
            DeleteCommand = new RelayCommand<object>(p => true, p =>
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn xuất này", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (rs == MessageBoxResult.Cancel)
                    return;

                OutputInfoList.Clear();
                Id = null;
                DateOutput = null;
                SelectedGoods = null;               
                SelectedOutputInfo = null;
                StaffName = null;
                MoreInfo = null;
                Count = 0;

                IsAdd = false;
                IsSave = true;
            });
            //xóa hàng hóa khỏi phiếu
            DeleteOutputInfoCommand = new RelayCommand<object>(p => true, p =>
            {
                OutputInfoList.Remove(SelectedOutputInfo);
            });

            ChangePageCommandIsEnabled = true;
        }
        private bool _ChangePageCommandIsEnabled;
        public bool ChangePageCommandIsEnabled { get => _ChangePageCommandIsEnabled; set { _ChangePageCommandIsEnabled = value; OnPropertyChanged(); } }
    }
}

