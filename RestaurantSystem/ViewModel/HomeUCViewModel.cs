using RestaurantSystem.AddWindow;
using RestaurantSystem.AddWindow.AEViewModel;
using RestaurantSystem.Model;
using RestaurantSystem.ReportView;
using RestaurantSystem.ResourcesXAML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    //interop.excel
    class HomeUCViewModel : BaseViewModel, IUserControl
    {
        //lấy thời gian từ 0h hôm nay đến 0h ngày mai
        DateTime firstHourOfDay, lastHourOfDay;

        //list bill
        private ObservableCollection<SelectableItem<Bill>> _ListBill;
        public ObservableCollection<SelectableItem<Bill>> ListBill { get => _ListBill; set { _ListBill = value; OnPropertyChanged(); } }

        //các loại lọc
        private List<string> _KindFilterList;
        public List<string> KindFilterList { get => _KindFilterList; set { _KindFilterList = value; OnPropertyChanged(); } }

        //binding index của kindfilterlist combobox
        private int _SelectedIndex;
        public int SelectedIndex { get => _SelectedIndex; set { _SelectedIndex = value; OnPropertyChanged(); } }

        //binding textbox tìm mã hóa đơn
        private string _SearchBill;
        public string SearchBill { get => _SearchBill; set { _SearchBill = value; OnPropertyChanged(); } }

        //checkbox tất cả các bill
        //khi check = true khi tất cả các bill sẽ được check theo va ngược lại
        private bool _IsChecked;
        public bool IsChecked
        {
            get => _IsChecked;
            set
            {
                _IsChecked = value;
                OnPropertyChanged();
                if (ListBill != null)
                {
                    foreach (var item in ListBill)
                    {
                        item.IsSelected = IsChecked == true ? true : false;
                    }
                }
            }
        }
        //binding ngày bắt đầu lọc
        private DateTime _FirstDate;
        public DateTime FirstDate { get => _FirstDate; set { _FirstDate = value; OnPropertyChanged(); } }

        //binding ngày kết thúc lọc
        private DateTime _LastDate;
        public DateTime LastDate { get => _LastDate; set { _LastDate = value; OnPropertyChanged(); } }

        //4 properties ngày hôm nay
        private int _TotalPrice;
        public int TotalPrice { get => _TotalPrice; set { _TotalPrice = value; OnPropertyChanged(); } }
        private int _BillCount;
        public int BillCount { get => _BillCount; set { _BillCount = value; OnPropertyChanged(); } }
        private int _BillCancel;
        public int BillCancel { get => _BillCancel; set { _BillCancel = value; OnPropertyChanged(); } }
        private int _SeatCount;
        public int SeatCount { get => _SeatCount; set { _SeatCount = value; OnPropertyChanged(); } }

        //binding khi selected bill trong listview
        private Bill _SelectedBill;
        public Bill SelectedBill { get => _SelectedBill; set { _SelectedBill = value; OnPropertyChanged(); } }

        public ICommand DeleteCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand FilterCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand ExcelCommand { get; set; }

        public HomeUCViewModel()
        {
            //set thời gian lọc là ngày hôm nay luôn
            FirstDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            LastDate = FirstDate.AddDays(1);

            KindFilterList = new List<string>() { "Tất cả", "Đã thanh toán", "Đã hủy" };
            SelectedIndex = 0;

            //khi cửa sổ bán hàng đóng thì update lại homepage
            POSWindow f = new POSWindow();
            (f.DataContext as POSViewModel).ReloadHome += HomeUCViewModel_ReloadHome;
            f.Close();

            IsChecked = false;
            firstHourOfDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            lastHourOfDay = firstHourOfDay.AddDays(1);
            Load();
            //sửa hóa đơn (chỉ đc sửa ghi chú)
            EditCommand = new RelayCommand<object>(p => true, p => Edit(p));
            //xóa hóa đơn
            DeleteCommand = new RelayCommand<object>(p => 
            {
                if (LoginViewModel.LoginAccount.IdRole == 1)
                    return true;
                return false;
            }, p => Delete(p));
            //in hóa đơn
            PrintCommand = new RelayCommand<object>(p =>
            {
                var item = (p as SelectableItem<Bill>);
                if (item != null)
                {
                    if (item.Item.Status < 0)
                        return false;
                }
                return true;
            }, p =>
             {
                 var item = (p as SelectableItem<Bill>).Item;
                 rpBillWindow fr = new rpBillWindow(item);
                 fr.ShowDialog();
             });
            //lọc hóa đơn
            FilterCommand = new RelayCommand<object>(p => true, p => FilterList());
            //tìm hóa đơn theo mã hóa đơn
            SearchCommand = new RelayCommand<object>(p => true, p =>
            {
                if (ListBill == null)
                    return;
                CollectionViewSource.GetDefaultView(ListBill).Refresh();
            });
            //xuất excel
            ExcelCommand = new RelayCommand<object>(p =>
            {
                var bl = ListBill.Any(a => a.IsSelected == true);
                if (bl)
                    return true;
                return false;
            }, p =>
             {
                 System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                 saveFileDialog1.Filter = "Excel (*.xlsx)|*.xlsx";
                 //saveFileDialog1.RestoreDirectory = true;
                 if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                 {
                     Excel.Application app = new Excel.Application();
                     Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                     Excel.Worksheet s = null;
                     try
                     {
                         s = wb.ActiveSheet;
                         s.Name = "Dữ liệu xuất";
                         s.Range[s.Cells[1, 1], s.Cells[1, 7]].Merge();
                         s.Cells[1, 1].Value = "Danh sách hóa đơn";
                         s.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                         s.Cells[1, 1].Font.Size = 20;

                         s.Range[s.Cells[2, 1], s.Cells[2, 7]].Merge();
                         s.Cells[2, 1].Value = "Xuất ngày: " + DateTime.Now.ToShortDateString();
                         s.Cells[2, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                         //header table
                         s.Cells[3, 1] = "Mã HĐ";
                         s.Cells[3, 2] = "Ngày giờ vào";
                         s.Cells[3, 3] = "Ngày giờ ra";
                         s.Cells[3, 4] = "Bàn";
                         s.Cells[3, 5] = "Trạng thái";
                         s.Cells[3, 6] = "Giảm giá";
                         s.Cells[3, 7] = "Tiền thanh toán";

                         //data
                         int i = 4;
                         foreach (var item in ListBill.Where(w => w.IsSelected == true))
                         {
                             s.Cells[i, 1] = item.Item.Id;
                             s.Cells[i, 2] = item.Item.TimeIn;
                             s.Cells[i, 3] = item.Item.TimeOut;
                             s.Cells[i, 4] = item.Item.TableFood.Name;
                             if (item.Item.Status > 0)
                                 s.Cells[i, 5] = "Đã thanh toán";
                             else
                                 s.Cells[i, 5] = "Chưa thanh toán";
                             s.Cells[i, 6] = item.Item.Discount;
                             s.Cells[i, 7] = item.Item.TotalPrice;
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
                 }
             });

            ChangePageCommandIsEnabled = true;
        }
        //event update homepage
        private void HomeUCViewModel_ReloadHome(object sender, EventArgs e)
        {
            Load();
        }

        //load ban đầu của homepage
        private void Load()
        {
            ListBill = new ObservableCollection<SelectableItem<Bill>>();

            foreach (var item in DataProvider.Ins.DB.Bill.Where(b => (b.TimeOut >= firstHourOfDay && b.TimeOut < lastHourOfDay)))
            {
                SelectableItem<Bill> bill = new SelectableItem<Bill>();
                bill.IsSelected = false;
                bill.Item = item;
                if (item.Status < 0)
                {
                    bill.Image = "/Resources/cancel.png";
                }
                else if (item.Status > 0)
                {
                    bill.Image = "/Resources/checkout.png";
                }
                ListBill.Add(bill);
            }
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListBill);
            view.Filter = UserFilter;
            if (DataProvider.Ins.DB.Bill.Where(b => b.Status != 0 && b.TimeOut >= firstHourOfDay && b.TimeOut < lastHourOfDay).Count() != 0)
            {
                TotalPrice = (int)DataProvider.Ins.DB.Bill.Where(b => b.Status != 0 && b.TimeOut >= firstHourOfDay && b.TimeOut < lastHourOfDay).Sum(s => s.TotalPrice);
            }
            BillCount = DataProvider.Ins.DB.Bill.Where(b => b.Status >= 0 && b.TimeOut >= firstHourOfDay && b.TimeOut < lastHourOfDay).Count();
            SeatCount = DataProvider.Ins.DB.TableFood.Where(t => t.Status == "Đang sử dụng").Count();
            BillCancel = DataProvider.Ins.DB.Bill.Where(b => b.Status < 0 && b.TimeOut >= firstHourOfDay && b.TimeOut < lastHourOfDay).Count();
        }
        private void Edit(object p)
        {
            EditBill fr = new EditBill();
            fr.ShowDialog();
            //nếu id=0 thì ko làm gì cả
            if ((fr.DataContext as EditBillViewModel).Id == 0)
                return;

            //chỉnh sửa ghi chú
            var item = (p as SelectableItem<Bill>).Item;
            var temp = DataProvider.Ins.DB.Bill.FirstOrDefault(se => se.Id == item.Id);
            temp.MoreInfo = (fr.DataContext as EditBillViewModel).Name;
            DataProvider.Ins.DB.SaveChanges();
        }
        //xóa hóa đơn
        private void Delete(object p)
        {
            MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không ?", "Chú ý", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (rs == MessageBoxResult.Cancel)
                return;
            var a = p as SelectableItem<Bill>;
            DataProvider.Ins.DB.BillInfo.RemoveRange(DataProvider.Ins.DB.BillInfo.Where(w => w.IdBill == a.Item.Id));
            DataProvider.Ins.DB.Bill.Remove(a.Item);
            DataProvider.Ins.DB.SaveChanges();
            ListBill.Remove(a);
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //lọc theo các kiểu: tất cả, đã thanh toán và đã hủy
        private void FilterList()
        {
            switch (SelectedIndex)
            {
                case 0:
                    {
                        ListBill = new ObservableCollection<SelectableItem<Bill>>();
                        foreach (var item in DataProvider.Ins.DB.Bill.Where(b => b.Status != 0 && b.TimeOut >= FirstDate && b.TimeOut < LastDate))
                        {
                            SelectableItem<Bill> bill = new SelectableItem<Bill>();
                            bill.IsSelected = false;
                            bill.Item = item;
                            if (item.Status < 0)
                            {
                                bill.Image = "/Resources/cancel.png";
                            }
                            else if (item.Status > 0)
                            {
                                bill.Image = "/Resources/checkout.png";
                            }
                            ListBill.Add(bill);
                        }
                        CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListBill);
                        view.Filter = UserFilter;
                        break;
                    }
                case 1:
                    {
                        ListBill = new ObservableCollection<SelectableItem<Bill>>();
                        foreach (var item in DataProvider.Ins.DB.Bill.Where(b => b.Status > 0 && b.TimeOut >= FirstDate && b.TimeOut < LastDate))
                        {
                            SelectableItem<Bill> bill = new SelectableItem<Bill>();
                            bill.IsSelected = false;
                            bill.Item = item;
                            bill.Image = "/Resources/checkout.png";
                            ListBill.Add(bill);
                        }
                        CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListBill);
                        view.Filter = UserFilter;
                        break;
                    }
                case 2:
                    {
                        ListBill = new ObservableCollection<SelectableItem<Bill>>();
                        foreach (var item in DataProvider.Ins.DB.Bill.Where(b => b.Status < 0 && b.TimeOut >= FirstDate && b.TimeOut < LastDate))
                        {
                            SelectableItem<Bill> bill = new SelectableItem<Bill>();
                            bill.IsSelected = false;
                            bill.Item = item;
                            bill.Image = "/Resources/cancel.png";
                            ListBill.Add(bill);
                        }
                        CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListBill);
                        view.Filter = UserFilter;
                        break;
                    }
                default:
                    MessageBox.Show("Error at filter");
                    break;
            }
        }
        //method bổ trợ tìm kiếm mã hóa đơn
        public bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchBill))
                return true;
            else
                return (item as SelectableItem<Bill>).Item.Id.ToString().IndexOf(SearchBill, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool _ChangePageCommandIsEnabled;
        public bool ChangePageCommandIsEnabled { get => _ChangePageCommandIsEnabled; set { _ChangePageCommandIsEnabled = value; OnPropertyChanged(); } }
    }
    //lớp bổ trợ để có thể thêm checkbox và hình ảnh cho Bill
    public class SelectableItem<T> : BaseViewModel
    {
        private bool _IsSelected;
        public bool IsSelected { get => _IsSelected; set { _IsSelected = value; OnPropertyChanged(); } }
        private T _Item;
        public T Item { get => _Item; set { _Item = value; OnPropertyChanged(); } }
        private string _Image;
        public string Image { get => _Image; set { _Image = value; OnPropertyChanged(); } }
    }
}
