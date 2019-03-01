using RestaurantSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Model
{
    //lớp tồn kho
    public class Inventory : BaseViewModel
    {
        private Goods _Goods;
        public Goods Goods { get => _Goods; set { _Goods = value; OnPropertyChanged(); } }
        private Unit _Unit;
        public Unit Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }
        private int _Count;
        public int Count { get=>_Count; set { _Count = value;OnPropertyChanged(); } }
    }
}
