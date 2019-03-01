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
    class RevenueDetailViewModel : BaseViewModel
    {
        private RevenuePageUC uc;
        private DateTime fromdate, todate;

        private ObservableCollection<BillInfo> _List;
        public ObservableCollection<BillInfo> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        public ICommand LoadCommand { get; set; }

        public RevenueDetailViewModel()
        {
            LoadCommand = new RelayCommand<object>(p => true, p => Load());
        }
        void Load()
        {
            uc = new RevenuePageUC();
            fromdate = (uc.DataContext as RevenuePageViewModel).FromDate;
            todate = (uc.DataContext as RevenuePageViewModel).ToDate;
            List = new ObservableCollection<BillInfo>(DataProvider.Ins.DB.BillInfo.Where(w => w.Bill.TimeOut >= fromdate && w.Bill.TimeOut < todate && w.Bill.Status > 0));
            (uc.DataContext as RevenuePageViewModel).UpdateList += RevenueDetailViewModel_UpdateList;
            (uc.DataContext as RevenuePageViewModel).ExportExcel += RevenueDetailViewModel_ExportExcel1;
        }

        private void RevenueDetailViewModel_ExportExcel1(object sender, string e)
        {
            if (!e.Equals("Detail"))
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
                    s.Cells[3, 1] = "Mã món";
                    s.Cells[3, 2] = "Tên món";
                    s.Cells[3, 3] = "ĐVT";
                    s.Cells[3, 4] = "Đơn giá";
                    s.Cells[3, 5] = "Số lượng";
                    s.Cells[3, 6] = "Mã HĐ";
                    s.Cells[3, 7] = "Thời gian ra";
                    s.Cells[3, 8] = "Bàn";
                    s.Cells[3, 9] = "NV lập";
                    //data
                    int i = 4;
                    foreach (var item in List)
                    {
                        s.Cells[i, 1] = item.IdFood;
                        s.Cells[i, 2] = item.Food.Name;
                        s.Cells[i, 3] = item.Food.Unit.Name;
                        s.Cells[i, 4] = item.Food.Price;
                        s.Cells[i, 5] = item.Count;
                        s.Cells[i, 6] = item.IdBill;
                        s.Cells[i, 7] = item.Bill.TimeOut;
                        s.Cells[i, 8] = item.Bill.TableFood.Name;
                        s.Cells[i, 9] = item.Bill.IdStaff;
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

        private void RevenueDetailViewModel_UpdateList(object sender, EventArgs e)
        {
            fromdate = (uc.DataContext as RevenuePageViewModel).FromDate;
            todate = (uc.DataContext as RevenuePageViewModel).ToDate;
            List = new ObservableCollection<BillInfo>(DataProvider.Ins.DB.BillInfo.Where(w => w.Bill.TimeOut >= fromdate && w.Bill.TimeOut < todate && w.Bill.Status>0));
        }

    }
}
