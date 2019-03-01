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
    class LoginViewModel : BaseViewModel
    {
        //dùng xuyên suốt chương trình khi đã đăng nhập
        private static Staff _LoginAccount;
        public static Staff LoginAccount { get=>_LoginAccount; set { _LoginAccount = value; } }

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value;OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public ICommand CloseWindowCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }
        //locngo1978@gmail.com
        public LoginViewModel()
        {
            Password = "";

            //command đóng 
            CloseWindowCommand = new RelayCommand<Window>(p => true, p => p.Close());

            //command đăng nhập
            LoginCommand = new RelayCommand<Window>(p => {return p == null ? false : true; }, p =>Login(p));

            //command di chuyển cửa sổ màn hình đăng nhập
            MouseMoveWindowCommand = new RelayCommand<Window>(p => true, p => p.DragMove());
              
        }

        //method đăng nhập
        //khi đăng nhập thành công thì hide window login, show window manager
        void Login(Window p)
        {
            string pass = DataProvider.MD5Hash(DataProvider.EncodeTo64(Password));
            Staff account;
            
            account = DataProvider.Ins.DB.Staff.SingleOrDefault(acc => acc.UserName == UserName && acc.Password == pass);
            if (account != null)
            {
                //gán account vào biến static
                LoginAccount = account;
                p.Hide();
                ManageWindow f = new ManageWindow();
                f.ShowDialog();
                p.Show();
                Password = "";
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        
    }

    //lớp cho phép binding password box, khi logout thì password sẽ được clear
    public static class PasswordHelper
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password",
            typeof(string), typeof(PasswordHelper),
            new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach",
            typeof(bool), typeof(PasswordHelper), new PropertyMetadata(false, Attach));

        private static readonly DependencyProperty IsUpdatingProperty =
            DependencyProperty.RegisterAttached("IsUpdating", typeof(bool),
            typeof(PasswordHelper));

        public static void SetAttach(DependencyObject dp, bool value)
        {
            dp.SetValue(AttachProperty, value);
        }

        public static bool GetAttach(DependencyObject dp)
        {
            return (bool)dp.GetValue(AttachProperty);
        }

        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        private static bool GetIsUpdating(DependencyObject dp)
        {
            return (bool)dp.GetValue(IsUpdatingProperty);
        }

        private static void SetIsUpdating(DependencyObject dp, bool value)
        {
            dp.SetValue(IsUpdatingProperty, value);
        }

        private static void OnPasswordPropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            passwordBox.PasswordChanged -= PasswordChanged;

            if (!(bool)GetIsUpdating(passwordBox))
            {
                passwordBox.Password = (string)e.NewValue;
            }
            passwordBox.PasswordChanged += PasswordChanged;
        }

        private static void Attach(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox == null)
                return;

            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            SetIsUpdating(passwordBox, true);
            SetPassword(passwordBox, passwordBox.Password);
            SetIsUpdating(passwordBox, false);
        }
    }
}
