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
    class RevenueNormalViewModel : BaseViewModel
    {
        private RevenuePageUC uc;
        private DateTime fromdate, todate;

        private ObservableCollection<Bill> _List;
        public ObservableCollection<Bill> List { get => _List; set { _List = value;OnPropertyChanged(); } }

        public ICommand LoadCommand { get; set; }

        public RevenueNormalViewModel()
        {
            LoadCommand = new RelayCommand<object>(p => true, p => Load());
        }

        void Load()
        {
            uc = new RevenuePageUC();
            fromdate = (uc.DataContext as RevenuePageViewModel).FromDate;
            todate = (uc.DataContext as RevenuePageViewModel).ToDate;
            List = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bill.Where(w => w.TimeOut >= fromdate && w.TimeOut < todate && w.Status > 0));
            (uc.DataContext as RevenuePageViewModel).UpdateList += RevenueNormalViewModel_UpdateList;
            (uc.DataContext as RevenuePageViewModel).ExportExcel += RevenueNormalViewModel_ExportExcel1;
        }

        private void RevenueNormalViewModel_ExportExcel1(object sender, string e)
        {
            if (!e.Equals("Normal"))
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
                    s.Range[s.Cells[1, 1], s.Cells[1, 8]].Merge();
                    s.Cells[1, 1].Value = "Danh sách hóa đơn thanh toán";
                    s.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    s.Cells[1, 1].Font.Size = 20;

                    s.Range[s.Cells[2, 1], s.Cells[2, 8]].Merge();
                    s.Cells[2, 1].Value = "Xuất ngày: " + DateTime.Now.ToShortDateString();
                    s.Cells[2, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //header table
                    s.Cells[3, 1] = "Mã HĐ";
                    s.Cells[3, 2] = "Ngày giờ vào";
                    s.Cells[3, 3] = "Ngày giờ ra";
                    s.Cells[3, 4] = "Bàn";
                    s.Cells[3, 5] = "NV lập";
                    s.Cells[3, 6] = "Giảm giá";
                    s.Cells[3, 7] = "Tiền thanh toán";
                    s.Cells[3, 8] = "Ghi chú";

                    //data
                    int i = 4;
                    foreach (var item in List)
                    {
                        s.Cells[i, 1] = item.Id;
                        s.Cells[i, 2] = item.TimeIn;
                        s.Cells[i, 3] = item.TimeOut;
                        s.Cells[i, 4] = item.TableFood.Name;
                        s.Cells[i, 5] = item.IdStaff;
                        s.Cells[i, 6] = item.Discount;
                        s.Cells[i, 7] = item.TotalPrice;
                        s.Cells[i, 8] = item.MoreInfo;
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

        private void RevenueNormalViewModel_UpdateList(object sender, EventArgs e)
        {
            fromdate = (uc.DataContext as RevenuePageViewModel).FromDate;
            todate = (uc.DataContext as RevenuePageViewModel).ToDate;
            List = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bill.Where(w => w.TimeOut >= fromdate && w.TimeOut < todate && w.Status>0));
        }
    }
}
