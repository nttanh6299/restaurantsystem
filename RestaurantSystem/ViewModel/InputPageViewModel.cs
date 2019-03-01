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
    class InputPageViewModel : BaseViewModel, IUserControl
    {
        #region list and entities
        private Staff _LoginningAccount;
        public Staff LoginningAccount { get => _LoginningAccount; set { _LoginningAccount = value; OnPropertyChanged(); } }

        //khi thêm mới phiếu thì button thêm mới sẽ disable, lưu và xóa phiếu sẽ enable và ngược lại khi lưu
        private bool _IsAdd;
        public bool IsAdd { get => _IsAdd; set { _IsAdd = value; OnPropertyChanged(); } }
        private bool _IsSave;
        public bool IsSave { get => _IsSave; set { _IsSave = value; OnPropertyChanged(); } }

        private ObservableCollection<InputInfo> _InputInfoList;
        public ObservableCollection<InputInfo> InputInfoList { get => _InputInfoList; set { _InputInfoList = value; OnPropertyChanged(); } }
        private InputInfo _SelectedInputInfo;
        public InputInfo SelectedInputInfo { get => _SelectedInputInfo; set { _SelectedInputInfo = value; OnPropertyChanged(); } }

        private List<Goods> _GoodsList;
        public List<Goods> GoodsList { get => _GoodsList; set { _GoodsList = value; OnPropertyChanged(); } }
        private Goods _SelectedGoods;
        public Goods SelectedGoods { get => _SelectedGoods; set { _SelectedGoods = value; OnPropertyChanged(); } }
        private int _Count;
        public int Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }
        private int _InputPrice;
        public int InputPrice { get => _InputPrice; set { _InputPrice = value; OnPropertyChanged(); } }

        private List<Supplier> _SupplierList;
        public List<Supplier> SupplierList { get => _SupplierList; set { _SupplierList = value; OnPropertyChanged(); } }
        private Supplier _SelectedSupplier;
        public Supplier SelectedSupplier { get => _SelectedSupplier; set { _SelectedSupplier = value; OnPropertyChanged(); } }
        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private DateTime? _DateInput;
        public DateTime? DateInput { get => _DateInput; set { _DateInput = value; OnPropertyChanged(); } }
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
        public ICommand DeleteInputInfoCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        #endregion

        #region methods
        private void AddNewBillInput()
        {
            IsAdd = true;
            IsSave = false;
            LoginningAccount = LoginViewModel.LoginAccount;
            SupplierList = new List<Supplier>(DataProvider.Ins.DB.Supplier);
            GoodsList = new List<Goods>(DataProvider.Ins.DB.Goods);
            //chưa có nhà cung cấp nào
            if (SupplierList == null || SupplierList.Count == 0)
            {
                MessageBox.Show("Chưa có nhà cung cấp nào, vui lòng thêm nhà cung cấp");
                IsAdd = false;
                IsSave = true;
                return;
            }
            //chưa có hàng hóa nào
            if (GoodsList == null || GoodsList.Count == 0)
            {
                MessageBox.Show("Chưa có hàng hóa nào, vui lòng thêm hàng hóa");
                IsAdd = false;
                IsSave = true;
                return;
            }
            //khi có rồi khi binding Id textbox với 1 id ngẫu nhiên
            Id = "HD" + DataProvider.RandomString(6);
            while (DataProvider.Ins.DB.Input.Where(w => w.Id == Id).Count() != 0)
            {
                Id = "HD" + DataProvider.RandomString(6);
            }
            //khi phiếu mới đc thêm
            SelectedSupplier = SupplierList[0];
            SelectedGoods = GoodsList[0];
            StaffName = LoginningAccount.Id + " - " + LoginningAccount.Name;
            DateInput = DateTime.Now;
            InputInfoList = new ObservableCollection<InputInfo>();
        }
        private void Add()
        {
            if (SelectedGoods == null)
            {
                MessageBox.Show("Chưa có hoặc chưa đúng như trong danh sách");
                return;
            }
            if (Count <= 0 || InputPrice <= 0)
            {
                MessageBox.Show("Số lượng nhập hoặc giá phải phải lớn hơn 0");
                return;
            }
            InputInfo newinputinfo = new InputInfo()
            {
                IdInput = Id,
                IdGoods = SelectedGoods.Id,
                Goods = SelectedGoods,
                Count = Count,
                InputPrice = InputPrice
            };
            InputInfoList.Add(newinputinfo);
        }
        private void Save()
        {
            MessageBoxResult rs = MessageBox.Show("Xác nhận lưu hóa đơn ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (rs == MessageBoxResult.Cancel)
                return;
            Input input = new Input()
            {
                Id = Id,
                DateInput = DateInput,
                MoreInfo = MoreInfo,
                IdStaff = LoginningAccount.Id,
                IdSupplier = SelectedSupplier.Id
            };
            DataProvider.Ins.DB.Input.Add(input);
            DataProvider.Ins.DB.InputInfo.AddRange(InputInfoList);
            DataProvider.Ins.DB.SaveChanges();

            IsAdd = false;
            IsSave = true;
        }
        private void Print()
        {
            Input billinput;
            billinput = DataProvider.Ins.DB.Input.FirstOrDefault(b => b.Id == Id);
            if (billinput == null)
            {
                MessageBox.Show("Error");
            }
            rpInputWindow f = new rpInputWindow(billinput);
            f.ShowDialog();
        }
        #endregion

        public InputPageViewModel()
        {
            IsAdd = false;
            IsSave = true;

            //thêm mới phiếu (chưa lưu vào csdl)
            AddNewCommand = new RelayCommand<object>(p => true, p => AddNewBillInput());
            //thêm hàng hóa vào phiếu
            AddCommand = new RelayCommand<object>(p => true, p => Add());
            //khi nhấn nút lưu thì mới lưu phiếu vào csdl
            SaveCommand = new RelayCommand<object>(p =>
            {
                if (InputInfoList == null || InputInfoList.Count < 1)
                    return false;
                return true;
            }, p => Save());
            //in phiếu vừa nhập
            PrintCommand = new RelayCommand<object>(p =>
            {
                if (Id == null)
                    return false;
                int count = 0;

                {
                    count = DataProvider.Ins.DB.Input.Where(w => w.Id == Id).Count();
                }
                if (count < 1)
                    return false;

                return true;
            }, p => Print());
            //xóa phiếu (phiếu chưa đc lưu vào csdl)
            DeleteCommand = new RelayCommand<object>(p => true, p =>
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn nhập này", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (rs == MessageBoxResult.Cancel)
                    return;

                InputInfoList.Clear();
                Id = null;
                DateInput = null;
                SelectedGoods = null;
                SelectedSupplier = null;
                SelectedInputInfo = null;
                StaffName = null;
                MoreInfo = null;
                Count = 0;
                InputPrice = 0;

                IsAdd = false;
                IsSave = true;
            });
            //xóa hàng hóa khỏi phiếu
            DeleteInputInfoCommand = new RelayCommand<object>(p => true, p =>
              {
                  InputInfoList.Remove(SelectedInputInfo);
              });

            ChangePageCommandIsEnabled = true;
        }
        private bool _ChangePageCommandIsEnabled;
        public bool ChangePageCommandIsEnabled { get => _ChangePageCommandIsEnabled; set { _ChangePageCommandIsEnabled = value; OnPropertyChanged(); } }
    }
}
