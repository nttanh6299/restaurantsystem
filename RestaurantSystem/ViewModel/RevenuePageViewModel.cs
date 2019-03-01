using RestaurantSystem.ResourcesXAML;
using RestaurantSystem.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantSystem.ViewModel
{
    class RevenuePageViewModel : BaseViewModel, IUserControl
    {
        private string stringEvent;

        private object _SelectedViewModel;
        public object SelectedViewModel
        {
            get { return _SelectedViewModel; }
            set
            {
                _SelectedViewModel = value; OnPropertyChanged("SelectedViewModel");
                if (_UpdateList != null)
                    _UpdateList(this, new EventArgs());
            }
        }
        private object _TempSelectedViewModel;
        public object TempSelectedViewModel
        {
            get { return _TempSelectedViewModel; }
            set { _TempSelectedViewModel = value; OnPropertyChanged("TempSelectedViewModel"); }
        }

        private bool _IsDetail;
        public bool IsDetail
        {
            get => _IsDetail; set
            {
                _IsDetail = value;
                OnPropertyChanged();
                if (IsDetail)
                {
                    stringEvent = "Detail";
                    TempSelectedViewModel = new RevenueDetailViewModel();
                    SelectedViewModel = TempSelectedViewModel;
                }
                else
                {
                    TempSelectedViewModel = null;
                    SelectedViewModel = TempSelectedViewModel;
                }
            }
        }

        private bool _IsNormal;
        public bool IsNormal
        {
            get => _IsNormal; set
            {
                _IsNormal = value;
                OnPropertyChanged();
                if (IsNormal)
                {
                    stringEvent = "Normal";
                    TempSelectedViewModel = new RevenueNormalViewModel();
                    SelectedViewModel = TempSelectedViewModel;
                }
                else
                {
                    TempSelectedViewModel = null;
                    SelectedViewModel = TempSelectedViewModel;
                }
            }
        }
        private event EventHandler _UpdateList;
        public event EventHandler UpdateList { add { _UpdateList += value; } remove { _UpdateList -= value; } }
        private event EventHandler<string> _ExportExcel;
        public event EventHandler<string> ExportExcel { add { _ExportExcel += value; } remove { _ExportExcel -= value; } }

        private DateTime _FromDate;
        public DateTime FromDate { get => _FromDate; set { _FromDate = value; OnPropertyChanged(); SelectedViewModel = TempSelectedViewModel; } }
        private DateTime _ToDate;
        public DateTime ToDate { get => _ToDate; set { _ToDate = value; OnPropertyChanged(); SelectedViewModel = TempSelectedViewModel; } }

        public ICommand ExcelCommand { get; set; }

        public RevenuePageViewModel()
        {
            stringEvent = null;
            FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1);

            ExcelCommand = new RelayCommand<object>(p =>
            {
                if (IsNormal || IsDetail)
                    return true;
                return false;
            }, p =>
             {               
                     if (_ExportExcel != null)
                         _ExportExcel(this, stringEvent);

             });

            ChangePageCommandIsEnabled = true;
        }

        private bool _ChangePageCommandIsEnabled;
        public bool ChangePageCommandIsEnabled { get => _ChangePageCommandIsEnabled; set { _ChangePageCommandIsEnabled = value; OnPropertyChanged(); } }
    }
}
