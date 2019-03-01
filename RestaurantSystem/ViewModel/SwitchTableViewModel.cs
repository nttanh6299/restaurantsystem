using RestaurantSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RestaurantSystem.ViewModel
{
    class SwitchTableViewModel : BaseViewModel
    {     
        public int Id { get; set; }
        //property bàn trong pos viewmodel
        private TableFood _CurrentTable;
        public TableFood CurrentTable { get => _CurrentTable; set { _CurrentTable = value; OnPropertyChanged(); } }

        private TableFood _SelectedTable;
        public TableFood SelectedTable { get => _SelectedTable; set { _SelectedTable = value; OnPropertyChanged(); } }

        public ICommand LoadedCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public SwitchTableViewModel()
        {           
            LoadedCommand = new RelayCommand<StackPanel>(p => true, p => Load(p));

            //hủy
            CancelCommand = new RelayCommand<Window>(p => true, p =>
            {
                Id = 0;
                SelectedTable = null;
                p.Close();
                });

            //xác nhận có đổi
            OKCommand = new RelayCommand<Window>(p =>
            {
                if (SelectedTable == null)
                    return false;
                return true;
            }, p =>
            {
                Id = 1;
                p.Close();
            });

        }

        //load bàn
        void Load(StackPanel p)
        {
            POSWindow fPos = new POSWindow();
            CurrentTable = (fPos.DataContext as POSViewModel).SelectedTable;
            fPos.Close();
            p.Children.Clear();
            
            {
                var listRegion = DataProvider.Ins.DB.Region.ToList();
                if (listRegion == null)
                    return;
                foreach (var region in listRegion)
                {
                    var listTable = DataProvider.Ins.DB.TableFood.Where(w => w.IdRegion == region.Id).ToList();
                    if (listTable == null)
                        continue;

                    Expander exp = new Expander()
                    {
                        Header = region.Name,
                        Width = 470,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                        Background = new SolidColorBrush(Colors.Transparent),
                        IsExpanded = true
                    };
                    WrapPanel wrap = new WrapPanel();
                    foreach (var item in listTable)
                    {
                        Button btn = new Button()
                        {
                            Tag = item,
                            Content = item.Name,
                            Width = 100,
                            Height = 60,
                            BorderThickness = new System.Windows.Thickness(0),
                            Margin = new System.Windows.Thickness(5)
                        };
                        btn.Click += Btn_Click;
                        if (item.Status == "Đang sử dụng" && item.Id != CurrentTable.Id)
                        {
                            btn.Background = new SolidColorBrush(Colors.Red);
                        }
                        else if (item.Id == CurrentTable.Id)
                        {
                            btn.IsEnabled = false;
                        }
                        else
                        {
                            btn.Background = new SolidColorBrush(Colors.Green);
                        }
                        wrap.Children.Add(btn);
                    }
                    exp.Content = wrap;
                    p.Children.Add(exp);
                }
            }
        }

        private void Btn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SelectedTable = (sender as Button).Tag as TableFood;
        }
    }
}
