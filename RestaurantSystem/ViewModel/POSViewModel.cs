using RestaurantSystem.Model;
using RestaurantSystem.ReportView;
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
using System.Windows.Media;

namespace RestaurantSystem.ViewModel
{
    class POSViewModel : BaseViewModel
    {
        //update home page khi nhấn nút quay lại
        private event EventHandler _ReloadHome;
        public event EventHandler ReloadHome
        {
            add { _ReloadHome += value; }
            remove { _ReloadHome -= value; }
        }

        //list billinfo in menu
        private ObservableCollection<MenuBillInfo> _ListBillInfo;
        public ObservableCollection<MenuBillInfo> ListBillInfo { get => _ListBillInfo; set { _ListBillInfo = value; OnPropertyChanged(); } }

        #region list entity
        private ObservableCollection<Food> _ListFood;
        public ObservableCollection<Food> ListFood { get => _ListFood; set { _ListFood = value; OnPropertyChanged(); } }
        private ObservableCollection<CategoryFood> _ListCategoryFood;
        public ObservableCollection<CategoryFood> ListCategoryFood { get => _ListCategoryFood; set { _ListCategoryFood = value; OnPropertyChanged(); } }
        private ObservableCollection<Bill> _ListBill;
        public ObservableCollection<Bill> ListBill { get => _ListBill; set { _ListBill = value; OnPropertyChanged(); } }
        private ObservableCollection<BillInfo> _ListBillInfoes;
        public ObservableCollection<BillInfo> ListBillInfoes { get => _ListBillInfoes; set { _ListBillInfoes = value; OnPropertyChanged(); } }
        #endregion

        #region các property        
        //binding category food
        private CategoryFood _SelectedCategoryFood;
        public CategoryFood SelectedCategoryFood { get => _SelectedCategoryFood; set { _SelectedCategoryFood = value; OnPropertyChanged(); } }

        //binding name food
        private string _NameFood;
        public string NameFood { get => _NameFood; set { _NameFood = value; OnPropertyChanged(); } }

        //binding textbox search food
        private string _SearchFood;
        public string SearchFood { get => _SearchFood; set { _SearchFood = value; OnPropertyChanged(); } }

        //binding table được chọn
        private TableFood _SelectedTable;
        public TableFood SelectedTable { get => _SelectedTable; set { _SelectedTable = value; OnPropertyChanged(); } }

        //chuyển bàn
        private TableFood _SwitchTable;
        public TableFood SwitchTable { get => _SwitchTable; set { _SwitchTable = value; OnPropertyChanged(); } }

        //binding food khi selected trong menu bill listview
        private Food _SelectedFood;
        public Food SelectedFood { get => _SelectedFood; set { _SelectedFood = value; OnPropertyChanged(); } }

        //binding số lượng food của billinfo
        private int _CountFood;
        public int CountFood { get => _CountFood; set { _CountFood = value; OnPropertyChanged(); } }

        //binding tên khu vực - tên bàn
        private string _RegionTable;
        public string RegionTable { get => _RegionTable; set { _RegionTable = value; OnPropertyChanged(); } }

        //binding thời gian vào
        private DateTime? _TimeIn;
        public DateTime? TimeIn { get => _TimeIn; set { _TimeIn = value; OnPropertyChanged(); } }

        //binding tổng tiền (chưa giảm giá)
        private int _TotalPrice;
        public int TotalPrice { get => _TotalPrice; set { _TotalPrice = value; OnPropertyChanged(); } }

        //binding giảm giá
        private int _Discount;
        public int Discount { get => _Discount; set { _Discount = value; OnPropertyChanged(); } }

        //binding thành tiền (đã giảm giá)
        private int _FinalPrice;
        public int FinalPrice { get => _FinalPrice; set { _FinalPrice = value; OnPropertyChanged(); } }

        //binding tiền khách đưa
        private int _PayPrice;
        public int PayPrice { get => _PayPrice; set { _PayPrice = value; OnPropertyChanged(); } }

        //binding tiền phải trả khách
        private int _BackPrice;
        public int BackPrice { get => _BackPrice; set { _BackPrice = value; OnPropertyChanged(); } }

        //binding khi selected billinfo trong listview
        private MenuBillInfo _SelectedItem;
        public MenuBillInfo SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                //khi item đc select thì tên món và số lượng sẽ đc show
                if (SelectedItem != null)
                {
                    NameFood = SelectedItem.Food.Name;
                    CountFood = SelectedItem.Count;
                }
                else
                {
                    NameFood = "";
                    CountFood = 0;
                }
            }
        }
        #endregion

        #region commands
        public ICommand LoadTableRegionCommand { get; set; }
        public ICommand ClickTableCommand { get; set; }
        public ICommand LoadListFoodCommand { get; set; }
        public ICommand SearchFoodCommand { get; set; }
        public ICommand AddFoodCommand { get; set; }
        public ICommand PlusCommand { get; set; }
        public ICommand MinusCommand { get; set; }
        public ICommand DeleteBillInfoCommand { get; set; }
        public ICommand DeleteBillCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand DiscountCommand { get; set; }
        public ICommand CustomerPayCommand { get; set; }
        public ICommand FinalPriceCommand { get; set; }
        public ICommand SwitchTableCommand { get; set; }
        public ICommand ShowReportBillCommand { get; set; }
        public ICommand CheckoutCommand { get; set; }
        #endregion

        #region methods
        //load ban đầu
        private void Load()
        {
            RegionTable = "";
            CategoryFood temp = new CategoryFood()
            {
                Id = 0,
                Name = "Tất cả"
            };
            SelectedCategoryFood = temp;

            //load list category
            ListCategoryFood = new ObservableCollection<CategoryFood>() { temp };
            var categories = DataProvider.Ins.DB.CategoryFood;
            foreach (var item in categories)
            {
                ListCategoryFood.Add(item);
            }
            //load list food
            IQueryable<Food> listfoods = DataProvider.Ins.DB.Food;
            ListFood = new ObservableCollection<Food>(listfoods);
            //load list bill
            ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bill);
            //load list billinfo
            ListBillInfoes = new ObservableCollection<BillInfo>(DataProvider.Ins.DB.BillInfo);
        }
        //load list food thuộc category được select
        private void LoadListFood(ComboBox p)
        {
            IQueryable<Food> listfoods = DataProvider.Ins.DB.Food;
            if (SelectedCategoryFood.Id == 0)
            {
                listfoods = DataProvider.Ins.DB.Food;
            }
            else
            {
                listfoods = listfoods.Where(f => f.IdCategoryFood == SelectedCategoryFood.Id);
            }
            ListFood = new ObservableCollection<Food>(listfoods);
            //filter
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListFood);
            view.Filter = UserFilter;
        }

        //add food vào bill
        private void AddFood(StackPanel addfood)
        {
            var bill = DataProvider.Ins.DB.Bill.SingleOrDefault(getbill => getbill.IdTable == SelectedTable.Id && getbill.Status == 0);
            if (bill == null)
            {
                //nếu bàn chưa có bill thì tạo mới bill
                Bill newbill = new Bill()
                {
                    TimeIn = DateTime.Now,
                    TotalPrice = 0,
                    IdTable = SelectedTable.Id,
                    IdStaff = "QL001",
                    Status = 0
                };
                TimeIn = DateTime.Now;
                //add bill
                DataProvider.Ins.DB.Bill.Add(newbill);
                DataProvider.Ins.DB.SaveChanges();
                ListBill.Add(newbill);

                //add billinfo
                BillInfo newbillinfo = new BillInfo()
                {
                    IdBill = ListBill.Max(max => max.Id),
                    IdFood = SelectedFood.Id,
                    Count = 1
                };
                DataProvider.Ins.DB.BillInfo.Add(newbillinfo);
                DataProvider.Ins.DB.SaveChanges();
                ListBillInfoes.Add(newbillinfo);

                //add billinfo menu trong UI
                MenuBillInfo menu = new MenuBillInfo()
                {
                    IdBillInfo = newbillinfo.Id,
                    Food = SelectedFood,
                    Unit = SelectedFood.Unit,
                    Count = 1,
                    TotalPrice = (int)SelectedFood.Price
                };
                ListBillInfo.Add(menu);

                //change status of table
                SelectedTable.Status = "Đang sử dụng";
                var table = DataProvider.Ins.DB.TableFood.FirstOrDefault(tableid => tableid.Id == SelectedTable.Id);
                if (table == null)
                    return;
                table.Status = "Đang sử dụng";
                DataProvider.Ins.DB.SaveChanges();
                TotalPrice = ListBillInfo.Sum(sum => sum.TotalPrice);
                FinalPrice = TotalPrice;
                LoadTableAccordingRegion(addfood);
            }
            else
            {
                //ngược lại thì chỉ add billinfo va menu
                BillInfo newbillinfo = new BillInfo()
                {
                    IdBill = bill.Id,
                    IdFood = SelectedFood.Id,
                    Count = 1
                };
                DataProvider.Ins.DB.BillInfo.Add(newbillinfo);
                DataProvider.Ins.DB.SaveChanges();
                ListBillInfoes.Add(newbillinfo);
                MenuBillInfo menu = new MenuBillInfo()
                {
                    IdBillInfo = newbillinfo.Id,
                    Food = SelectedFood,
                    Unit = SelectedFood.Unit,
                    Count = 1,
                    TotalPrice = (int)SelectedFood.Price
                };
                ListBillInfo.Add(menu);
                TotalPrice = ListBillInfo.Sum(sum => sum.TotalPrice);
                FinalPrice = TotalPrice;
            }
        }

        //+1 số lượng của billinfo
        private void PlusFood()
        {
            //lấy bill của billinfo
            var getbill = ListBill.FirstOrDefault(bill => bill.IdTable == SelectedTable.Id && bill.Status == 0);
            if (getbill == null)
                throw new ArgumentNullException();
            //lấy billinfo khi selected
            var getbillinfo = DataProvider.Ins.DB.BillInfo.FirstOrDefault(bi => bi.IdBill == getbill.Id && bi.IdFood == SelectedItem.Food.Id && SelectedItem.IdBillInfo == bi.Id);
            getbillinfo.Count = getbillinfo.Count + 1;
            DataProvider.Ins.DB.SaveChanges();
            //load lại listview
            LoadMenuBillInfo();
        }

        //-1 số lượng 
        private void MinusFood()
        {
            var getbill = ListBill.FirstOrDefault(bill => bill.IdTable == SelectedTable.Id && bill.Status == 0);
            if (getbill == null)
                throw new ArgumentNullException();
            var getbillinfo = DataProvider.Ins.DB.BillInfo.FirstOrDefault(bi => bi.IdBill == getbill.Id && bi.IdFood == SelectedItem.Food.Id && SelectedItem.IdBillInfo == bi.Id);
            if (getbillinfo.Count == 1)
                return;
            getbillinfo.Count = getbillinfo.Count - 1;
            DataProvider.Ins.DB.SaveChanges();
            LoadMenuBillInfo();
        }

        //xóa billinfo
        private void DeleteFood()
        {
            var getbill = ListBill.FirstOrDefault(bill => bill.IdTable == SelectedTable.Id && bill.Status == 0);
            if (getbill == null)
                throw new ArgumentNullException();
            var getbillinfo = ListBillInfoes.FirstOrDefault(deletebillinfo => deletebillinfo.IdBill == getbill.Id && deletebillinfo.IdFood == SelectedItem.Food.Id && SelectedItem.IdBillInfo == deletebillinfo.Id);
            DataProvider.Ins.DB.BillInfo.Remove(getbillinfo);
            DataProvider.Ins.DB.SaveChanges();
            LoadMenuBillInfo();
        }

        //hủy hóa đơn
        private void DeleteBill(StackPanel deletebill)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn của " + RegionTable, "Chú ý", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Cancel)
                return;

            //set các property khi đã hủy hóa đơn
            var bill = DataProvider.Ins.DB.Bill.SingleOrDefault(havebill => havebill.IdTable == SelectedTable.Id && havebill.Status == 0);
            bill.Status = -1;
            bill.TimeOut = DateTime.Now;
            //set lại tình trạng bàn
            var table = DataProvider.Ins.DB.TableFood.Single(t => t.Id == SelectedTable.Id);
            if (table != null)
                table.Status = "Đang trống";
            DataProvider.Ins.DB.SaveChanges();

            //load lại sơ đồ bàn và listview
            LoadMenuBillInfo();
            LoadTableAccordingRegion(deletebill);

            //clear property thời gian vào
            TimeIn = null;
        }

        //đổi bàn
        private void SwitchTableWithOther(StackPanel sw)
        {
            SwitchTableWindow f = new SwitchTableWindow();
            f.ShowDialog();
            SwitchTable = (f.DataContext as SwitchTableViewModel).SelectedTable;
            int id = (f.DataContext as SwitchTableViewModel).Id;
            if (id < 1)
                return;
            /*
             * Nếu switchtable chưa có bill đổi idtable bill của selectedtable sang switchtable
             * ngược lại
             * nếu switchtable có bill thì đổi trực tiếp 2 bill với nhau
             */

            var billswitchtable = ListBill.SingleOrDefault(b => b.IdTable == SwitchTable.Id && b.Status == 0);

            if (billswitchtable == null)
            {
                var bill = DataProvider.Ins.DB.Bill.SingleOrDefault(bi => bi.IdTable == SelectedTable.Id && bi.Status == 0);
                bill.IdTable = SwitchTable.Id;
                var swt = DataProvider.Ins.DB.TableFood.SingleOrDefault(swtable => swtable.Id == SwitchTable.Id);
                swt.Status = "Đang sử dụng";
                var st = DataProvider.Ins.DB.TableFood.SingleOrDefault(s => s.Id == SelectedTable.Id);
                st.Status = "Đang trống";
                DataProvider.Ins.DB.SaveChanges();
            }
            else
            {
                //đổi trực tiếp 2 bill với nhau 
                var billswt = DataProvider.Ins.DB.Bill.SingleOrDefault(swtable => swtable.IdTable == SwitchTable.Id && swtable.Status == 0);
                var bills = DataProvider.Ins.DB.Bill.SingleOrDefault(stable => stable.IdTable == SelectedTable.Id && stable.Status == 0);
                billswt.IdTable = SelectedTable.Id;
                bills.IdTable = SwitchTable.Id;
                DataProvider.Ins.DB.SaveChanges();
            }
            //load lại sở đồ bàn
            LoadTableAccordingRegion(sw);
            var timein = ListBill.SingleOrDefault(time => time.IdTable == SelectedTable.Id && time.Status == 0);

            //load lại timein của bàn
            if (timein != null)
            {
                TimeIn = timein.TimeIn;
            }
            else
            {
                TimeIn = null;
            }
            //load lại listview
            LoadMenuBillInfo();
        }

        //thanh toán hóa đơn
        private void CheckoutBill(StackPanel p)
        {
            MessageBoxResult rs = MessageBox.Show("Bạn có muốn thanh toán hóa đơn này?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (rs == MessageBoxResult.Cancel)
                return;
            Bill bill;
            //set các property khi thanh toán
            bill = DataProvider.Ins.DB.Bill.SingleOrDefault(havebill => havebill.IdTable == SelectedTable.Id && havebill.Status == 0);
            bill.Discount = Discount;
            bill.TotalPrice = FinalPrice;
            bill.Status = 1;
            bill.TimeOut = DateTime.Now;
            //set lại tình trạng bàn
            var table = DataProvider.Ins.DB.TableFood.Single(t => t.Id == SelectedTable.Id);
            if (table != null)
                table.Status = "Đang trống";
            DataProvider.Ins.DB.SaveChanges();
            //show window report hóa đơn
            rpBillWindow f = new rpBillWindow(bill);
            f.ShowDialog();
            //load lại sơ đồ bàn và menu listview
            LoadMenuBillInfo();
            LoadTableAccordingRegion(p);
        }
        //method filter
        public bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchFood))
                return true;
            else
                return ((item as Food).Name.IndexOf(SearchFood, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        //load bàn theo khu vực
        void LoadTableAccordingRegion(StackPanel p)
        {
            p.Children.Clear();

            //lấy list khu vực trước
            var listRegion = DataProvider.Ins.DB.Region;
            if (listRegion == null)
                return;
            //
            foreach (var region in listRegion)
            {
                //lấy list bàn theo khu vực
                var listTable = DataProvider.Ins.DB.TableFood.Where(w => w.IdRegion == region.Id).ToList();
                if (listTable.Count <= 0)
                    continue;
                string format = region.Name + " - " + listTable.Where(c => c.Status == "Đang sử dụng").Count() + "/" + listTable.Count + " bàn";
                Expander exp = new Expander()
                {
                    Header = format,
                    Width = 450,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                    Background = new SolidColorBrush(Colors.Transparent),
                    IsExpanded = true
                };
                WrapPanel wrap = new WrapPanel();
                foreach (var item in listTable)
                {
                    Button btn = new Button()
                    {
                        Tag = item,
                        Content = item.Name,
                        Width = 100,
                        Height = 60,
                        BorderThickness = new System.Windows.Thickness(0),
                        Margin = new System.Windows.Thickness(5)
                    };
                    btn.Click += Btn_Click;
                    if (item.Status == "Đang sử dụng")
                    {
                        btn.Background = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        btn.Background = new SolidColorBrush(Colors.Green);
                    }
                    wrap.Children.Add(btn);
                }
                exp.Content = wrap;
                p.Children.Add(exp);
            }
        }
        //load các món ăn khi click vào bàn ăn
        void LoadMenuBillInfo()
        {
            #region set bill's price
            TotalPrice = 0;
            FinalPrice = 0;
            PayPrice = 0;
            BackPrice = 0;
            #endregion

            //nếu bàn ko có bill thì thôi, ngược lại show ra các món ăn của bill
            ListBillInfo = new ObservableCollection<MenuBillInfo>();
            Bill bill = ListBill.SingleOrDefault(idb => idb.IdTable == SelectedTable.Id && idb.Status == 0);
            if (bill == null)
                return;
            int idbill = bill.Id;
            var billInfos = ListBillInfoes.Where(billinfo => billinfo.IdBill == idbill);
            if (billInfos == null)
                return;
            foreach (var item in billInfos)
            {
                MenuBillInfo menu = new MenuBillInfo()
                {
                    IdBillInfo = item.Id,
                    Food = item.Food,
                    Unit = item.Food.Unit,
                    Count = (int)item.Count,
                    TotalPrice = (int)(((int)item.Count) * item.Food.Price)
                };
                ListBillInfo.Add(menu);
            }
            TotalPrice = ListBillInfo.Sum(sum => sum.TotalPrice);
            FinalPrice = TotalPrice;
        }
        #endregion
        //initialize
        public POSViewModel()
        {
            Load();
            #region load list
            //load food thuộc category
            LoadListFoodCommand = new RelayCommand<ComboBox>(p =>
            {
                if (SelectedCategoryFood == null)
                    return false;
                return true;
            }, p => LoadListFood(p));
            //load table
            LoadTableRegionCommand = new RelayCommand<StackPanel>(p => true, p => LoadTableAccordingRegion(p));
            #endregion

            #region tìm food và thêm food vào listview menu
            //search food in list food
            SearchFoodCommand = new RelayCommand<TextBox>(search => true, search =>
            {
                if (ListFood == null)
                    return;
                CollectionViewSource.GetDefaultView(ListFood).Refresh();
            });
            //add food to menu
            AddFoodCommand = new RelayCommand<StackPanel>(addfood =>
            {
                if (SelectedTable == null || SelectedTable.Status == "Đang bảo trì")
                    return false;
                return true;
            }, addfood => AddFood(addfood));
            #endregion

            #region + - xóa billinfo trong listview menu
            //plus 1 amount of food
            PlusCommand = new RelayCommand<object>(plus =>
            {
                if (SelectedTable == null || SelectedTable.Status == "Đang bảo trì")
                    return false;
                return true;
            }, plus => PlusFood());
            //minus 1 amount of food
            MinusCommand = new RelayCommand<object>(minus =>
            {
                if (SelectedTable == null || SelectedTable.Status == "Đang bảo trì")
                    return false;
                return true;
            }, minus => MinusFood());
            //delete billinfo of bill
            DeleteBillInfoCommand = new RelayCommand<object>(delete =>
            {
                if (SelectedTable == null || SelectedTable.Status == "Đang bảo trì")
                    return false;
                return true;
            }, delete => DeleteFood());
            #endregion

            #region Other command
            //delete bill
            DeleteBillCommand = new RelayCommand<StackPanel>(deletebill =>
            {
                if (SelectedTable == null || SelectedTable.Status == "Đang bảo trì")
                    return false;
                var bill = ListBill.SingleOrDefault(havebill => havebill.IdTable == SelectedTable.Id && havebill.Status == 0);
                if (bill == null)
                    return false;
                return true;
            }, deletebill => DeleteBill(deletebill));

            //return home
            HomeCommand = new RelayCommand<Window>(wd => true, wd =>
            {
                wd.Close();
                if (_ReloadHome != null)
                {
                    _ReloadHome(this, new EventArgs());
                }
            });

            //discount
            DiscountCommand = new RelayCommand<object>(dc => true, dc => FinalPrice = (int)(TotalPrice - ((1.0 * Discount * TotalPrice) / 100)));
            //customer pay bill
            CustomerPayCommand = new RelayCommand<object>(pay => true, pay => BackPrice = PayPrice - FinalPrice);
            //when final price changes
            FinalPriceCommand = new RelayCommand<object>(fn => true, fn => BackPrice = PayPrice - FinalPrice);
            //switch table
            SwitchTableCommand = new RelayCommand<StackPanel>(sw =>
            {
                if (SelectedTable == null || SelectedTable.Status == "Đang bảo trì")
                    return false;
                var bill = ListBill.SingleOrDefault(havebill => havebill.IdTable == SelectedTable.Id && havebill.Status == 0);
                if (bill == null)
                    return false;

                return true;
            }, sw => SwitchTableWithOther(sw));
            //checkout
            CheckoutCommand = new RelayCommand<StackPanel>(p =>
            {
                if (SelectedTable == null || SelectedTable.Status == "Đang bảo trì")
                    return false;
                var bill = ListBill.SingleOrDefault(havebill => havebill.IdTable == SelectedTable.Id && havebill.Status == 0);
                if (bill == null)
                    return false;
                return true;
            }, p => CheckoutBill(p));
            #endregion

        }

        //btn click
        private void Btn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //binding table khi click vào button table
            SelectedTable = (sender as Button).Tag as TableFood;

            //binding tên bàn và khu vực khi click vào button table
            int idregion = (int)SelectedTable.IdRegion;
            string getRegion;
            getRegion = DataProvider.Ins.DB.Region.SingleOrDefault(p => p.Id == idregion).Name;
            RegionTable = getRegion + " - " + SelectedTable.Name;
            //binding thời gian vào
            var timein = ListBill.SingleOrDefault(time => time.IdTable == SelectedTable.Id && time.Status == 0);
            if (timein != null)
            {
                TimeIn = timein.TimeIn;
            }
            else
            {
                TimeIn = null;
            }
            //load menu khi click 
            LoadMenuBillInfo();
        }
    }
}
