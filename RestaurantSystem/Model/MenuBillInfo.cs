using RestaurantSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Model
{
    //lớp các billinfo của bill
    public class MenuBillInfo : BaseViewModel
    {
        private int _IdBillInfo;
        public int IdBillInfo { get => _IdBillInfo; set { _IdBillInfo = value; OnPropertyChanged(); } }
        private Food _Food;
        public Food Food { get=> _Food; set { _Food = value;OnPropertyChanged(); } }
        private Unit _Unit;
        public Unit Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }
        private int _Count;
        public int Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }
        private int _TotalPrice;
        public int TotalPrice { get => _TotalPrice; set { _TotalPrice = value; OnPropertyChanged(); } }
    }
}
