using RestaurantSystem.Model;
using RestaurantSystem.ResourcesXAML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantSystem.ViewModel
{
    class StatisticsPageViewModel : BaseViewModel, IUserControl
    {
        //biến chuỗi của để gửi qua viewmodel uc con
        private string stringEvent;

        //
        private object _SelectedViewModel;
        public object SelectedViewModel
        {
            get { return _SelectedViewModel; }
            set { _SelectedViewModel = value; OnPropertyChanged("SelectedViewModel");
                //khi thay đổi viewmodel thì list của uc load lại
                if (_UpdateList != null)
                    _UpdateList(this, new EventArgs());
            }
        }
        //property lưu viewmodel tạm
        private object _TempSelectedViewModel;
        public object TempSelectedViewModel
        {
            get { return _TempSelectedViewModel; }
            set { _TempSelectedViewModel = value; OnPropertyChanged("TempSelectedViewModel"); }
        }
        //khi radio button chi tiết đc nhấn thì chuyển sang usercontrol chi tiết
        private bool _IsDetail;
        public bool IsDetail { get => _IsDetail; set
            {
                _IsDetail = value;
                OnPropertyChanged();
                if(Index==0)
                {
                    if (IsDetail)
                    {
                        stringEvent = "InputDetail";
                        TempSelectedViewModel = new InputDetailViewModel();
                        SelectedViewModel = TempSelectedViewModel;
                    }
                    else
                    {
                        TempSelectedViewModel = null;
                        SelectedViewModel = TempSelectedViewModel;
                    }
                }
                else
                {
                    if (IsDetail)
                    {
                        stringEvent = "OutputDetail";
                        TempSelectedViewModel = new OutputDetailViewModel();
                        SelectedViewModel = TempSelectedViewModel;
                    }
                    else
                    {
                        TempSelectedViewModel = null;
                        SelectedViewModel = TempSelectedViewModel;
                    }
                }
            } }
        //khi radio button tổng hợp đc nhấn thì chuyển sang usercontrol tổng hợp
        private bool _IsNormal;
        public bool IsNormal { get => _IsNormal; set
            {
                _IsNormal = value;
                OnPropertyChanged();
                if(Index==0)
                {
                    if (IsNormal)
                    {
                        stringEvent = "InputNormal";
                        TempSelectedViewModel = new InputNormalViewModel();
                        SelectedViewModel = TempSelectedViewModel;
                    }
                    else
                    {
                        TempSelectedViewModel = null;
                        SelectedViewModel = TempSelectedViewModel;
                    }
                }                
                else
                {
                    if (IsNormal)
                    {
                        stringEvent = "OutputNormal";
                        TempSelectedViewModel = new OutputNormalViewModel();
                        SelectedViewModel = TempSelectedViewModel;
                    }
                    else
                    {
                        TempSelectedViewModel = null;
                        SelectedViewModel = TempSelectedViewModel;
                    }
                }
            } }
        //event load lại list và xuất excel
        private event EventHandler _UpdateList;
        public event EventHandler UpdateList { add { _UpdateList += value; } remove { _UpdateList -= value; } }
        private event EventHandler<string> _ExportExcel;
        public event EventHandler<string> ExportExcel { add { _ExportExcel += value; } remove { _ExportExcel -= value; } }


        private List<string> _Kind;
        public List<string> Kind { get => _Kind; set { _Kind = value;OnPropertyChanged();} }

        private DateTime _FromDate;
        public DateTime FromDate { get => _FromDate; set { _FromDate = value; OnPropertyChanged(); SelectedViewModel = TempSelectedViewModel; } }
        private DateTime _ToDate;
        public DateTime ToDate { get => _ToDate; set { _ToDate = value; OnPropertyChanged(); SelectedViewModel = TempSelectedViewModel;  } }

        private int _Index;
        public int Index { get => _Index; set { _Index = value; OnPropertyChanged(); IsDetail = IsNormal = false; } }

        public ICommand ExcelCommand { get; set; }

        public StatisticsPageViewModel()
        {
            stringEvent = null;
            Kind = new List<string>() { "Phiếu nhập", "Phiếu xuẩt" };
            Index = 0;
            FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1);

            //xuất excel, gửi event cho viewmodel của usercontrol
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
