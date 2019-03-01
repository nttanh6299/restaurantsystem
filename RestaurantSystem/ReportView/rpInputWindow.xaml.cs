using CrystalDecisions.CrystalReports.Engine;
using RestaurantSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RestaurantSystem.ReportView
{
    /// <summary>
    /// Interaction logic for rpInputWindow.xaml
    /// </summary>
    public partial class rpInputWindow : Window
    {
        List<InputInfo> list;
        List<Input_Detail> listdetail;
        Input input;
        public rpInputWindow(Input input)
        {
            InitializeComponent();
            this.input = input;
            load();
        }
        void load()
        {
            list = new List<InputInfo>();
            listdetail = new List<Input_Detail>();
            
            {
                list.AddRange(DataProvider.Ins.DB.InputInfo.Where(w => w.IdInput == input.Id));
            }              
            if (list == null || list.Count == 0)
                return;
            int i = 1;
            foreach (var item in list)
            {
                Input_Detail temp = new Input_Detail()
                {
                    STT=i,
                    Name = item.Goods.Name,
                    NameUnit = item.Goods.Unit.Name,
                    Count = (int)item.Count,
                    Price = (int)item.InputPrice
                };
                listdetail.Add(temp);
                i++;
            }
            ReportDocument rp = new ReportDocument();
            try
            {
                rp.Load(@"C:\Users\korim\source\repos\RestaurantSystem\RestaurantSystem\ReportView\rpInput.rpt");
                rp.SetDataSource(listdetail);
                rp.SetParameterValue("pSupplier", input.Supplier.Name);
                if(input.MoreInfo!=null)
                {
                    rp.SetParameterValue("pMoreInfo", input.MoreInfo);
                }
                else
                {
                    rp.SetParameterValue("pMoreInfo", " ");
                }
                rp.SetParameterValue("pDateInput", input.DateInput);
                rp.SetParameterValue("pId", input.Id);
                viewer.ViewerCore.ReportSource = rp;
            }
           catch
            {
                throw;
            }
        }
    }
}
