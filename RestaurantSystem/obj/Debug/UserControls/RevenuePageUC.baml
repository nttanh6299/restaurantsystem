   M S B A M L   `   `   `  ����K  GRestaurantSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RestaurantSystem.UserControlsRestaurantSystem.UserControls  5      G(clr-namespace:RestaurantSystem.ViewModelRestaurantSystem.ViewModel  5      1    +RestaurantSystem.UserControls.RevenuePageUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:RestaurantSystem.UserControls     5      7vm(clr-namespace:RestaurantSystem.ViewModel     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     revenueUCVM � DataContext# [ 5       � 	Resources 5       �� DataType7  1RestaurantSystem.ViewModel.RevenueNormalViewModel1   +RestaurantSystem.UserControls.RevenueNormal7  1RestaurantSystem.ViewModel.RevenueDetailViewModel1   +RestaurantSystem.UserControls.RevenueDetail  groupbox �� 
TargetType �� Property �� Value��%y  (��       5      *, +)(�� 7     5      *, +)&	 n     �� 5   
   "  6   .R�5        6$   5      �� 5   
   "  6   .R�5        6$   5      �� 5   
   " ��6!   .�5      ��  � ��
 �����6,   �� 5       � �� 5      �� 5       .R�5!      �� $��18(�65   $
��Bold"�6C   ��6$   �� 6C   5"      5$      5%      5&      .��5'      � 
�������.+�5(   
   �� $��THỐNG KÊ HÓA ĐƠN��6   $��25(�6-   $��2q�6;   .��5)      �  � RowDefinitions 5*      �� 5+      $
��auto �6$   64   �� 5,      6&   .+�5.      �� 	 �� Orientation$	 
Horizontal=�6   .+�5/      �� $��0 10 0 0q�6   $ ��Điều kiện thống kê��61   #��[ 6M   .��50      �� $	 Vertical=�6%   .+�51      �� $	 
Horizontal=�6)   .+�52   "   �� $��15(�6,   $��Center=�6:   $��0 0 9 0q�6U   Từ ngày:6p   (  "System.Windows.Controls.DatePicker  53   "   $��Center=�54   -   $��15(�55   -   $	��120��56   -   
   SelectedDate
 53   -   �� *
FromDate+ �� UpdateSourceTrigger$ PropertyChanged=�56   -   58      �� 59      $	 Vertical=�6)   $��0 10 0 0q�6@   .+�5:   "   �� $	 
Horizontal=�6-   .+�5;   &   �� $��15(�60   $��Center=�6>   Đến ngày:6d     5<   &   $��Center=�5=   -   $��15(�5>   -   $	��120��5?   -   
 5<   1   �� *ToDate+$ PropertyChanged=�5?   -   �� 5A   &   $	 
Horizontal=�61   $	��400��6J   .+�5B   *   	� $��Center=�66   $��	100 0 2 0q�5E   2   ��5C   2   �� *DetailCommand+ d� 	IsChecked 5D   2   �� *
IsDetail+$ PropertyChanged=�5E   G   �� 5F   *   $��Center=�64   $��15(�6O   $��0 0 40 0q�6]   
Chi tiết6y   	� 5G   *   $��Center=�66   $��0 0 2 0q�5J   2   ��5H   2   �� *NormalCommand+ 5I   2   �� *
IsNormal+$ PropertyChanged=�5J   E   �� 5K   *   $��Center=�64   $��15(�6O   
Hóa đơn6f   5L   '   5M   #   5N      5O      5P      �� 5Q      $��	Thao tác��6   $	��640��5R      $��	10 10 0 0q�5S      #��[ 62   .��5T      � .+�5U      �� $	 
Horizontal=�6)   $��Right=�6B   .+�5V   "   �� $��16(�6)   $
��10 0q�67   $	��130��5X   )   
��� � �$��0q�5Z   )   ��5W   )   �� *ExcelCommand+.��5Z   =   Xuất Excel6I   5[      5\      5]      5^      � 5`      $��1��6   $��0 10 0 0q�6$   .+�5a      �� ��6%   �� *SelectedViewModel+6M   5b      5c      5d      5e      5f      