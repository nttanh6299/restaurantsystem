using RestaurantSystem.Model;
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
    class AEStaffViewModel : BaseViewModel
    {
        private List<Role> _Role;
        public List<Role> Role { get => _Role; set { _Role = value; OnPropertyChanged(); } }

        private Role _SelectedRole;
        public Role SelectedRole { get => _SelectedRole; set { _SelectedRole = value; OnPropertyChanged(); } }

        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        private void Load()
        {
         
                Role = new List<Role>(DataProvider.Ins.DB.Role);
            
        }

        public AEStaffViewModel()
        {
            Load();
            SelectedRole = Role[0];

            MouseMoveWindowCommand = new RelayCommand<Window>(p => { return p == null ? false : true; }, p => p.DragMove());

            OKCommand = new RelayCommand<Window>(p =>
            {
                if (string.IsNullOrEmpty(UserName))
                    return false;
                return true;
            }, p =>
            {
                //phát sinh id ngẫu nhiên sau đó sẽ thoát
                if (SelectedRole.Id == 1)
                {
                    Id = "QL" + DataProvider.RandomString(3);
                    while (DataProvider.Ins.DB.Staff.Where(a => a.Id == Id).Count() >= 1)
                    {
                        Id = "QL" + DataProvider.RandomString(3);
                    }
                }
                else
                {
                    Id = "NV" + DataProvider.RandomString(3);
                    while (DataProvider.Ins.DB.Staff.Where(a => a.Id == Id).Count() >= 1)
                    {
                        Id = "NV" + DataProvider.RandomString(3);
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
