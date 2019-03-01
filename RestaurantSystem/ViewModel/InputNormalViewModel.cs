using RestaurantSystem.Model;
using RestaurantSystem.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;

namespace RestaurantSystem.ViewModel
{
    class InputNormalViewModel : BaseViewModel
    {
        private StatisticsPageUC uc;
        private DateTime fromdate, todate;

        private ObservableCollection<InputInfo> _List;
        public ObservableCollection<InputInfo> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        public ICommand LoadCommand { get; set; }

        public InputNormalViewModel()
        {
            LoadCommand = new RelayCommand<object>(p => true, p => Load());
        }

        void Load()
        {
            uc = new StatisticsPageUC();
            fromdate = (uc.DataContext as StatisticsPageViewModel).FromDate;
            todate = (uc.DataContext as StatisticsPageViewModel).ToDate;
            List = new ObservableCollection<InputInfo>(DataProvider.Ins.DB.InputInfo.Include("Input").Where(w => w.Input.DateInput >= fromdate && w.Input.DateInput < todate));
            (uc.DataContext as StatisticsPageViewModel).UpdateList += InputNormalViewModel_UpdateList;
            (uc.DataContext as StatisticsPageViewModel).ExportExcel += InputNormalViewModel_ExportExcel;
        }

        private void InputNormalViewModel_ExportExcel(object sender, string e)
        {
            if (!e.Equals("InputNormal"))
                return;
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
                    s.Range[s.Cells[1, 1], s.Cells[1, 6]].Merge();
                    s.Cells[1, 1].Value = "Phiếu nhập tổng hợp";
                    s.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    s.Cells[1, 1].Font.Size = 20;

                    s.Range[s.Cells[2, 1], s.Cells[2, 6]].Merge();
                    s.Cells[2, 1].Value = "Xuất ngày: " + DateTime.Now.ToShortDateString();
                    s.Cells[2, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //header table
                    s.Cells[3, 1] = "Mã hàng hóa";
                    s.Cells[3, 2] = "Tên hàng hóa";
                    s.Cells[3, 3] = "ĐVT";
                    s.Cells[3, 4] = "Số lượng";
                    s.Cells[3, 5] = "Giá nhập";
                    s.Cells[3, 6] = "Ghi chú";

                    //data
                    int i = 4;
                    foreach (var item in List)
                    {
                        s.Cells[i, 1] = item.IdGoods;
                        s.Cells[i, 2] = item.Goods.Name;
                        s.Cells[i, 3] = item.Goods.Unit.Name;
                        s.Cells[i, 4] = item.Count;
                        s.Cells[i, 5] = item.InputPrice;
                        s.Cells[i, 6] = item.Input.MoreInfo;
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
               
        }

        private void InputNormalViewModel_UpdateList(object sender, EventArgs e)
        {
            fromdate = (uc.DataContext as StatisticsPageViewModel).FromDate;
            todate = (uc.DataContext as StatisticsPageViewModel).ToDate;
            List = new ObservableCollection<InputInfo>(DataProvider.Ins.DB.InputInfo.Include("Input").Where(w => w.Input.DateInput >= fromdate && w.Input.DateInput < todate));
        }
    }
}
