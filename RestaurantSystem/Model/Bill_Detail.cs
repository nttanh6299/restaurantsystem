using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Model
{
    //lớp dùng để in hóa đơn bán hàng
    public class Bill_Detail
    {
        public string NameFood { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
