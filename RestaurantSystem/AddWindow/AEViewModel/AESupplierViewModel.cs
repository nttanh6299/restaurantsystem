using RestaurantSystem.Model;
using RestaurantSystem.UserControls;
using RestaurantSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RestaurantSystem.AddWindow.AEViewModel
{
    class AESupplierViewModel : BaseViewModel
    {
        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }
        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }

        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public AESupplierViewModel()
        {          
            MouseMoveWindowCommand = new RelayCommand<Window>(p => { return p == null ? false : true; }, p => p.DragMove());

            OKCommand = new RelayCommand<Window>(p => 
            {
                if (string.IsNullOrEmpty(Name))
                    return false;
                return true;
            }, p => 
            {
                
                {
                    Id = "NCC" + DataProvider.RandomString(3);
                    while (DataProvider.Ins.DB.Supplier.Where(a => a.Id == Id).Count() >= 1)
                    {
                        Id = "NCC" + DataProvider.RandomString(3);
                    }
                }
                    p.Close();
            });

            ExitCommand = new RelayCommand<Window>(p => true, p => 
            {
                Id = null;
                p.Close();
            });
        }
    }
}
