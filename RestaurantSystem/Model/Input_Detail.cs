using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Model
{
    //lớp dùng cho việc in hóa đơn nhập
    public class Input_Detail
    {
        public int STT { get; set; }
        public string Name { get; set; }
        public string NameUnit { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
