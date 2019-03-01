using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Model
{
    //lớp dùng cho in hóa đơn xuất
    public class Output_Detail
    {
        public int STT { get; set; }
        public string Name { get; set; }
        public string NameUnit { get; set; }
        public int Count { get; set; }
    }
}
