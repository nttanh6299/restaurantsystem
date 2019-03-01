using RestaurantSystem.Model;
using RestaurantSystem.ResourcesXAML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;

namespace RestaurantSystem.ViewModel
{
    class StatisticsFoodViewModel : BaseViewModel, IUserControl
    {
        private ObservableCollection<SelectableFood<Food>> _List;
        public ObservableCollection<SelectableFood<Food>> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private List<BillInfo> _ListBillInfo;
        public List<BillInfo> ListBillInfo { get => _ListBillInfo; set { _ListBillInfo = value; OnPropertyChanged(); } }

        private DateTime _FromDate;
        public DateTime FromDate { get => _FromDate; set { _FromDate = value; OnPropertyChanged(); } }
        private DateTime _ToDate;
        public DateTime ToDate { get => _ToDate; set { _ToDate = value; OnPropertyChanged();} }

        public ICommand LoadListCommand { get; set; }
        public ICommand ExcelCommand { get; set; }

        public StatisticsFoodViewModel()
        {
            FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1);

            //load list 
            LoadListCommand = new RelayCommand<object>(p => true, p => Load());

            //xuất excel
            ExcelCommand = new RelayCommand<object>(p => 
            {
                var temp = List;
                if (temp !=null && temp.Count>0)
                    return true;
                return false;
            }, p =>
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog1.Filter = "Excel (*.xlsx)|*.xlsx";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                    Excel.Worksheet s = null;
                    try
                    {
                        s = wb.ActiveSheet;
                        s.Name = "Dữ liệu xuất";
                        s.Range[s.Cells[1, 1], s.Cells[1, 5]].Merge();
                        s.Cells[1, 1].Value = "Thống kê lượng món ăn";
                        s.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        s.Cells[1, 1].Font.Size = 16;

                        s.Range[s.Cells[2, 1], s.Cells[2, 5]].Merge();
                        s.Cells[2, 1].Value = "Xuất ngày: " + DateTime.Now.ToShortDateString();
                        s.Cells[2, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        //header table
                        s.Cells[3, 1] = "Mã món";
                        s.Cells[3, 2] = "Tên món";
                        s.Cells[3, 3] = "ĐVT";
                        s.Cells[3, 4] = "Đơn giá";
                        s.Cells[3, 5] = "Số lượng tổng";

                        //data
                        int i = 4;
                        foreach (var item in List)
                        {
                            s.Cells[i, 1] = item.Item.Id;
                            s.Cells[i, 2] = item.Item.Name;
                            s.Cells[i, 3] = item.Item.Unit.Name;
                            s.Cells[i, 4] = item.Item.Price;
                            s.Cells[i, 5] = item.Count;
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

        void Load()
        {
            ListBillInfo = DataProvider.Ins.DB.BillInfo.Include("Food").Where(w=>w.Bill.Status>0 && w.Bill.TimeOut>=FromDate && w.Bill.TimeOut<ToDate).ToList();
            List = new ObservableCollection<SelectableFood<Food>>();
            var temp = ListBillInfo.GroupBy(g => g.Food, (key,list)=> new {Key = key,Count = list.Sum(s=>s.Count) }).OrderByDescending(o=>o.Count);
            foreach (var item in temp)
            {
                SelectableFood<Food> i = new SelectableFood<Food>();
                i.Count = (int)item.Count;
                i.Item = item.Key;
                List.Add(i);
            }
        }

        private bool _ChangePageCommandIsEnabled;
        public bool ChangePageCommandIsEnabled { get => _ChangePageCommandIsEnabled; set { _ChangePageCommandIsEnabled = value; OnPropertyChanged(); } }
    }
    //lớp food có số lượng food đc chế biến
    public class SelectableFood<T> : BaseViewModel
    {
        private int _Count;
        public int Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }
        private T _Item;
        public T Item { get => _Item; set { _Item = value;OnPropertyChanged(); } }
    }

}
