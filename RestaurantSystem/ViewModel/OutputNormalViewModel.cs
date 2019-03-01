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
    class OutputNormalViewModel : BaseViewModel
    {
        private StatisticsPageUC uc;
        private DateTime fromdate, todate;

        private ObservableCollection<OutputInfo> _List;
        public ObservableCollection<OutputInfo> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        public ICommand LoadCommand { get; set; }

        public OutputNormalViewModel()
        {
            LoadCommand = new RelayCommand<object>(p => true, p => Load());
        }

        void Load()
        {
            uc = new StatisticsPageUC();
            fromdate = (uc.DataContext as StatisticsPageViewModel).FromDate;
            todate = (uc.DataContext as StatisticsPageViewModel).ToDate;
            List = new ObservableCollection<OutputInfo>(DataProvider.Ins.DB.OutputInfo.Include("Output").Where(w => w.Output.DateOutput >= fromdate && w.Output.DateOutput < todate));
            (uc.DataContext as StatisticsPageViewModel).UpdateList += OutputNormalViewModel_UpdateList;
            (uc.DataContext as StatisticsPageViewModel).ExportExcel += OutputNormalViewModel_ExportExcel;
        }

        private void OutputNormalViewModel_ExportExcel(object sender, string e)
        {
            if (!e.Equals("OutputNormal"))
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
                    s.Range[s.Cells[1, 1], s.Cells[1, 5]].Merge();
                    s.Cells[1, 1].Value = "Phiếu xuất tổng hợp";
                    s.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    s.Cells[1, 1].Font.Size = 20;

                    s.Range[s.Cells[2, 1], s.Cells[2, 5]].Merge();
                    s.Cells[2, 1].Value = "Xuất ngày: " + DateTime.Now.ToShortDateString();
                    s.Cells[2, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //header table
                    s.Cells[3, 1] = "Mã hàng hóa";
                    s.Cells[3, 2] = "Tên hàng hóa";
                    s.Cells[3, 3] = "ĐVT";
                    s.Cells[3, 4] = "Số lượng xuất";
                    s.Cells[3, 5] = "Ghi chú";
                    //data
                    int i = 4;
                    foreach (var item in List)
                    {
                        s.Cells[i, 1] = item.IdGoods;
                        s.Cells[i, 2] = item.Goods.Name;
                        s.Cells[i, 3] = item.Goods.Unit.Name;
                        s.Cells[i, 4] = item.Count;
                        s.Cells[i, 5] = item.Output.MoreInfo;
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

        private void OutputNormalViewModel_UpdateList(object sender, EventArgs e)
        {
            fromdate = (uc.DataContext as StatisticsPageViewModel).FromDate;
            todate = (uc.DataContext as StatisticsPageViewModel).ToDate;
            List = new ObservableCollection<OutputInfo>(DataProvider.Ins.DB.OutputInfo.Include("Output").Where(w => w.Output.DateOutput >= fromdate && w.Output.DateOutput < todate));
        }

    }
}
