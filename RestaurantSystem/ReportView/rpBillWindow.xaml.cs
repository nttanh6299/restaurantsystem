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
using System.Windows.Shapes;

namespace RestaurantSystem.ReportView
{
    /// <summary>
    /// Interaction logic for rpBillWindow.xaml
    /// </summary>
    public partial class rpBillWindow : Window
    {
        List<BillInfo> listbillinfo;
        List<Bill_Detail> listbilldetail;
        Bill bill;
        public rpBillWindow(Bill bill)
        {
            InitializeComponent();
            listbilldetail = new List<Bill_Detail>();
            this.bill = bill;
            load();

        }
        void load()
        {
            
            {
                listbillinfo = new List<BillInfo>(DataProvider.Ins.DB.BillInfo.Where(w => w.IdBill == bill.Id));
            }
               
            foreach (var item in listbillinfo)
            {
                Bill_Detail b = new Bill_Detail()
                {
                    NameFood = item.Food.Name,
                    Quantity = (int)item.Count,
                    TotalPrice = (int)(item.Count*item.Food.Price)
                };
                listbilldetail.Add(b);
            }
            ReportDocument rp = new ReportDocument();
            try
            {
                rp.Load(System.Windows.Forms.Application.StartupPath + "\\ReportView\\rpBill.rpt");
                rp.SetDataSource(listbilldetail);
                rp.SetParameterValue("pIdBill", bill.Id);
                rp.SetParameterValue("pTable", bill.TableFood.Region.Name + " - " + bill.TableFood.Name);
                rp.SetParameterValue("pTimeIn", bill.TimeIn);
                rp.SetParameterValue("pTimeOut", bill.TimeOut);
                rp.SetParameterValue("pIdStaff", bill.IdStaff);
                rp.SetParameterValue("pDiscount", string.Format(bill.Discount.ToString()) + "%");
                rp.SetParameterValue("pTotalPrice", bill.TotalPrice);
                viewer.ViewerCore.ReportSource = rp;
            }
            catch
            {
                throw;
            }
            
        }
    }
}
