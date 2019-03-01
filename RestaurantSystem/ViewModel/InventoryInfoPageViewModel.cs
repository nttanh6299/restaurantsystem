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
using Excel = Microsoft.Office.Interop.Excel;

namespace RestaurantSystem.ViewModel
{
    class InventoryInfoPageViewModel : BaseViewModel, IUserControl
    {
        #region list and entities
        private ObservableCollection<Inventory> _InventoryList;
        public ObservableCollection<Inventory> InventoryList { get => _InventoryList; set { _InventoryList = value; OnPropertyChanged(); } }
        private ObservableCollection<Unit> _Unit;
        public ObservableCollection<Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }

        private int _CountOfGoods;
        public int CountOfGoods { get => _CountOfGoods; set { _CountOfGoods = value; OnPropertyChanged(); } }
        private string _SearchTextbox;
        public string SearchTextbox { get => _SearchTextbox; set { _SearchTextbox = value; OnPropertyChanged(); } }

        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private Unit _SelectedUnit;
        public Unit SelectedUnit { get => _SelectedUnit; set { _SelectedUnit = value; OnPropertyChanged(); } }
        private int _Count;
        public int Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }

        private Inventory _SelectedItem;
        public Inventory SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id = SelectedItem.Goods.Id;
                    Name = SelectedItem.Goods.Name;
                    SelectedUnit = SelectedItem.Unit;
                    Count = SelectedItem.Count;
                }
            }
        }
        #endregion

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddUnitCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand ExcelCommand { get; set; }

        public InventoryInfoPageViewModel()
        {           
            LoadTonKho();
            //thêm mới hàng hóa
            AddCommand = new RelayCommand<object>(p => true, p => 
            {
                AddGoods f = new AddGoods();
                f.ShowDialog();
                //khi nhấn nút hủy thì ko làm gì cả
                var idgood = (f.DataContext as AEGoodsViewModel).Id;
                if (idgood == 0)
                    return;
                //lưu hàng hóa vào csdl
                Goods g = new Goods()
                {
                    Name = (f.DataContext as AEGoodsViewModel).Name,
                    IdUnit = (f.DataContext as AEGoodsViewModel).SelectedUnit.Id
                };

                DataProvider.Ins.DB.Goods.Add(g);
                DataProvider.Ins.DB.SaveChanges();
                LoadTonKho();
            });
            //edit goods
            EditCommand = new RelayCommand<object>(p =>
            {
                //khi chưa selected hàng hóa nào thì disable nút edit
                if (SelectedItem == null)
                    return false;
                return true;
            },p=> 
            {
                //sửa và load lại list
                var good = DataProvider.Ins.DB.Goods.FirstOrDefault(g => g.Id == SelectedItem.Goods.Id);
                good.Name = Name;
                good.Unit = SelectedUnit;
                DataProvider.Ins.DB.SaveChanges();

                LoadTonKho();
            });
            //thêm đơn vị tính
            AddUnitCommand = new RelayCommand<object>(p => true, p => 
            {
                AddUnit f = new AddUnit();
                f.ShowDialog();
                var id = (f.DataContext as AEUnitViewModel).Id;
                if (id == 0)
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
            //tìm hàng hóa
            SearchCommand = new RelayCommand<object>(p => true, p => 
            {
                if (InventoryList == null)
                    return;
                CollectionViewSource.GetDefaultView(InventoryList).Refresh();
            });
            //xuất excel
            ExcelCommand = new RelayCommand<object>(p => 
            {
                if (InventoryList.Count > 0)
                    return true;
                return false;
            }, p =>
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog1.Filter = "Excel (*.xlsx)|*.xlsx";
                saveFileDialog1.ShowDialog();
                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                Excel.Worksheet s = null;
                try
                {
                    s = wb.ActiveSheet;
                    s.Name = "Dữ liệu xuất";
                    s.Range[s.Cells[1, 1], s.Cells[1, 4]].Merge();
                    s.Cells[1, 1].Value = "Danh sách hàng hóa tồn";
                    s.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    s.Cells[1, 1].Font.Size = 16;

                    s.Range[s.Cells[2, 1], s.Cells[2, 4]].Merge();
                    s.Cells[2, 1].Value = "Xuất ngày: " + DateTime.Now.ToShortDateString();
                    s.Cells[2, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //header table
                    s.Cells[3, 1] = "ID";
                    s.Cells[3, 2] = "Tên hàng hóa";
                    s.Cells[3, 3] = "ĐVT";
                    s.Cells[3, 4] = "Số lượng tồn";

                    //data
                    int i = 4;
                    foreach (var item in InventoryList)
                    {
                        s.Cells[i, 1] = item.Goods.Id;
                        s.Cells[i, 2] = item.Goods.Name;
                        s.Cells[i, 3] = item.Unit.Name;
                        s.Cells[i, 4] = item.Count;       
                        i++;
                    }

                    wb.SaveAs(saveFileDialog1.FileName);
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    app.Quit();
                    wb = null;
                }
            });

            ChangePageCommandIsEnabled = true;            
        }
        //method tìm kiếm hàng hóa
        public bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchTextbox))
                return true;
            else
                return (item as Inventory).Goods.Id.ToString().IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as Inventory).Goods.Name.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as Inventory).Unit.Name.IndexOf(SearchTextbox, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        //load ban đầu
        void LoadTonKho()
        {
            CountOfGoods = DataProvider.Ins.DB.Goods.Count();
            Unit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
            InventoryList = new ObservableCollection<Inventory>();
            var goods = DataProvider.Ins.DB.Goods;

            //tồn kho = số lượng nhập - số lượng xuất
            foreach (var item in goods)
            {
                Inventory i = new Inventory();
                i.Goods = item;
                i.Unit = item.Unit;
                var inputlist = DataProvider.Ins.DB.InputInfo.Where(w => w.IdGoods == item.Id);
                var outputlist = DataProvider.Ins.DB.OutputInfo.Where(w => w.IdGoods == item.Id);

                int suminput = 0;
                int sumoutput = 0;
                if (inputlist != null && inputlist.Count() != 0)
                {
                    suminput = (int)inputlist.Sum(sum => sum.Count);
                }
                if (outputlist != null && outputlist.Count() != 0)
                {
                    sumoutput = (int)outputlist.Sum(sum => sum.Count);
                }
                i.Count = suminput - sumoutput;
                InventoryList.Add(i);

                //
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(InventoryList);
                view.Filter = UserFilter;
            }
        }

        private bool _ChangePageCommandIsEnabled;
        public bool ChangePageCommandIsEnabled { get => _ChangePageCommandIsEnabled; set { _ChangePageCommandIsEnabled = value; OnPropertyChanged(); } }
    }
}
