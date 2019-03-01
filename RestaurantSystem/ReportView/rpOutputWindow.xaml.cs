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
using RestaurantSystem.Model;
using CrystalDecisions.CrystalReports.Engine;

namespace RestaurantSystem.ReportView
{
    /// <summary>
    /// Interaction logic for rpOutputWindow.xaml
    /// </summary>
    public partial class rpOutputWindow : Window
    {
        List<OutputInfo> list;
        List<Output_Detail> listdetail;
        Output Output;
        public rpOutputWindow(Output Output)
        {
            InitializeComponent();
            this.Output = Output;
            load();
        }
        void load()
        {
            list = new List<OutputInfo>();
            listdetail = new List<Output_Detail>();
            
            {
                list.AddRange(DataProvider.Ins.DB.OutputInfo.Where(w => w.IdOutput == Output.Id));
            }
               
            if (list == null || list.Count == 0)
                return;
            int i = 1;
            foreach (var item in list)
            {
                Output_Detail temp = new Output_Detail()
                {
                    STT = i,
                    Name = item.Goods.Name,
                    NameUnit = item.Goods.Unit.Name,
                    Count = (int)item.Count
                };
                listdetail.Add(temp);
                i++;
            }
            ReportDocument rp = new ReportDocument();
            try
            {
                rp.Load(@"C:\Users\korim\source\repos\RestaurantSystem\RestaurantSystem\ReportView\rpOutput.rpt");
                rp.SetDataSource(listdetail);
                if (Output.MoreInfo != null)
                {
                    rp.SetParameterValue("pMoreInfo", Output.MoreInfo);
                }
                else
                {
                    rp.SetParameterValue("pMoreInfo", " ");
                }
                rp.SetParameterValue("pDateOutput", Output.DateOutput);
                rp.SetParameterValue("pId", Output.Id);
                viewer.ViewerCore.ReportSource = rp;
            }
            catch
            {
                throw;
            }
        }
    }
}
