using RestaurantSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RestaurantSystem.ViewModel
{
    class ChangePasswordViewModel:BaseViewModel
    {
        private string _OldPass;
        public string OldPass { get => _OldPass; set { _OldPass = value; OnPropertyChanged(); } }
        private string _NewPass;
        public string NewPass { get => _NewPass; set { _NewPass = value; OnPropertyChanged(); } }
        private string _RePass;
        public string RePass { get => _RePass; set { _RePass = value; OnPropertyChanged(); } }

        public ICommand OldPassCommand { get; set; }
        public ICommand NewPassCommand { get; set; }
        public ICommand RePassCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }

        public ChangePasswordViewModel()
        {
            OldPass = "";
            NewPass = "";
            RePass = "";
            //di chuyen window
            MouseMoveWindowCommand = new RelayCommand<Window>(p => true, p => p.DragMove());
            //binding password
            OldPassCommand = new RelayCommand<PasswordBox>(p => true, p => OldPass = p.Password);
            NewPassCommand = new RelayCommand<PasswordBox>(p => true, p => NewPass = p.Password);
            RePassCommand = new RelayCommand<PasswordBox>(p => true, p => RePass = p.Password);

            //thoat khoi window
            CancelCommand = new RelayCommand<Window>(p => true, p => p.Close());

            //change pass command
            OKCommand = new RelayCommand<Window>(p => 
            {
                if (string.IsNullOrEmpty(NewPass) || string.IsNullOrEmpty(RePass))
                    return false;
                return true;
            }, p => 
            {
                if(LoginViewModel.LoginAccount.Password.Equals(DataProvider.MD5Hash(DataProvider.EncodeTo64(OldPass))))
                {
                    if(NewPass.Equals(RePass))
                    {
                        var staff = DataProvider.Ins.DB.Staff.SingleOrDefault(s => s.Id == LoginViewModel.LoginAccount.Id);
                        staff.Password = DataProvider.MD5Hash(DataProvider.EncodeTo64(NewPass));
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Thay đổi mật khẩu thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        p.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại mật khẩu không chính xác, mời nhập lại!");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ vừa nhập không chính xác, mời nhập lại!");
                }
            });
        }
    }
}
