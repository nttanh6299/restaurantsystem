using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ResourcesXAML
{
    //lớp cho phép chuyển đổi usercontrol trong 1 grid
    public interface IUserControl
    {
        bool ChangePageCommandIsEnabled { get; set; }
    }
}
