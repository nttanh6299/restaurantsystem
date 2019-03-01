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
    class InputDetailViewModel : BaseViewModel
    {
        private StatisticsPageUC uc;
        private DateTime fromdate,todate;

        private ObservableCollection<InputInfo> _List;
        public ObservableCollection<InputInfo> List { get => _List; set { _List = value;OnPropertyChanged(); } }

        public ICommand LoadCommand { get; set; }

        public InputDetailViewModel()
        {
            LoadCommand = new RelayCommand<object>(p => true, p => Load());
        }
        //load ban đầu
        void Load()
        {
            //lấy những thứ cần của uc cha
            uc = new StatisticsPageUC();
            fromdate = (uc.DataContext as StatisticsPageViewModel).FromDate;
            todate = (uc.DataContext as StatisticsPageViewModel).ToDate;
            List = new ObservableCollection<InputInfo>(DataProvider.Ins.DB.InputInfo.Include("Input").Where(w => w.Input.DateInput >= fromdate && w.Input.DateInput < todate));

            (uc.DataContext as StatisticsPageViewModel).UpdateList += InputDetailViewModel_UpdateList;
            (uc.DataContext as StatisticsPageViewModel).ExportExcel += InputDetailViewModel_ExportExcel;
        }
        //khi button xuất excel của viewmodel cha đc nhấn thì list sẽ đc xuất
        private void InputDetailViewModel_ExportExcel(object sender, string e)
        {
            if (!e.Equals("InputDetail"))
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
                    s.Range[s.Cells[1, 1], s.Cells[1, 10]].Merge();
                    s.Cells[1, 1].Value = "Phiếu nhập chi tiết";
                    s.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    s.Cells[1, 1].Font.Size = 20;

                    s.Range[s.Cells[2, 1], s.Cells[2, 10]].Merge();
                    s.Cells[2, 1].Value = "Xuất ngày: " + DateTime.Now.ToShortDateString();
                    s.Cells[2, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //header table
                    s.Cells[3, 1] = "Mã phiếu";
                    s.Cells[3, 2] = "Ngày lập";
                    s.Cells[3, 3] = "Nhà cung cấp";
                    s.Cells[3, 4] = "Mã hàng hóa";
                    s.Cells[3, 5] = "Tên hàng hóa";
                    s.Cells[3, 6] = "ĐVT";
                    s.Cells[3, 7] = "Số lượng nhập";
                    s.Cells[3, 8] = "Giá nhập";
                    s.Cells[3, 9] = "NV lập phiếu";
                    s.Cells[3, 10] = "Ghi chú";

                    //data
                    int i = 4;
                    foreach (var item in List)
                    {
                        s.Cells[i, 1] = item.IdInput;
                        s.Cells[i, 2] = item.Input.DateInput;
                        s.Cells[i, 3] = item.Input.Supplier.Name;
                        s.Cells[i, 4] = item.IdGoods;
                        s.Cells[i, 5] = item.Goods.Name;
                        s.Cells[i, 6] = item.Goods.Unit.Name;
                        s.Cells[i, 7] = item.Count;
                        s.Cells[i, 8] = item.InputPrice;
                        s.Cells[i, 9] = item.Input.IdStaff;
                        s.Cells[i, 10] = item.Input.MoreInfo;
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

        //load lại list khi viewmodel cha có sự thay đổi
        private void InputDetailViewModel_UpdateList(object sender, EventArgs e)
        {
            fromdate = (uc.DataContext as StatisticsPageViewModel).FromDate;
            todate = (uc.DataContext as StatisticsPageViewModel).ToDate;
            List = new ObservableCollection<InputInfo>(DataProvider.Ins.DB.InputInfo.Include("Input").Where(w => w.Input.DateInput >= fromdate && w.Input.DateInput < todate));
        }
    }
}
