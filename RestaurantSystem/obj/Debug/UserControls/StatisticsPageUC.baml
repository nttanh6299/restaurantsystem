   M S B A M L   `   `   `  ����K  GRestaurantSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RestaurantSystem.UserControlsRestaurantSystem.UserControls  5      G(clr-namespace:RestaurantSystem.ViewModelRestaurantSystem.ViewModel  5      4    .RestaurantSystem.UserControls.StatisticsPageUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:RestaurantSystem.UserControls     5      7vm(clr-namespace:RestaurantSystem.ViewModel     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     statisticsUCVM � DataContext# [ 5       � 	Resources 5       �� DataType5  /RestaurantSystem.ViewModel.InputDetailViewModel/   )RestaurantSystem.UserControls.InputDetail5  /RestaurantSystem.ViewModel.InputNormalViewModel/   )RestaurantSystem.UserControls.InputNormal6  0RestaurantSystem.ViewModel.OutputDetailViewModel0   *RestaurantSystem.UserControls.OutputDetail6  0RestaurantSystem.ViewModel.OutputNormalViewModel0	   *RestaurantSystem.UserControls.OutputNormal  groupbox �� 
TargetType �� Property �� Value��%  (��       5      *, +)(�� 7     5      *, +)(�� n     5      *, +)(�� �     5      *, +)&	 �     �� 5   
   "  6   .R�5        6"   5      �� 5   
   "  6   .R�5        6"   5      �� 5   
   "  6   .R�5        6#   5      �� 5   
   "  6   .R�5       	  6#   5!      �� 5"   
   " ��6!   .�5#      ��  � ��
 �����6,   �� 5$       � �� 5%      �� 5&      .R�5'      �� $��18(�65   $
��Bold"�6C   ��6$   �� 6C   5(      5*      5+      5,      .��5-      � 
�������.+�5.   
   �� $)��#THỐNG KÊ PHIẾU NHẬP - XUẤT��6   $��25(�67   $��2q�6E   .��5/      �  � RowDefinitions 50      �� 51      $
��auto �6$   64   �� 52      6&   .+�54      �� 	 �� Orientation$	 
Horizontal=�6   .+�55      �� $��0 10 0 0q�6   $ ��Điều kiện thống kê��61   #��[ 6M   .��56      �� $	 Vertical=�6%   .+�57      �� $	 
Horizontal=�6)   .+�58   "   �� $��15(�6,   $��Center=�6:   $��0 0 9 0q�6U   Từ ngày:6p   (
  "System.Windows.Controls.DatePicker
  59   "   $��Center=�5:   -   $��15(�5;   -   $	��120��5<   -   
 
  SelectedDate
 59   -   �� *
FromDate+ �� UpdateSourceTrigger$ PropertyChanged=�5<   -   �� 5>   "   $��	100 0 2 0q�5@   +   $	��200��5A   +   ��5>   +   �� *Kind+ �� SelectedIndex 5?   +   �� *Index+$ PropertyChanged=�5A   9   5B      �� 5C      $	 Vertical=�6)   $��0 10 0 0q�6@   .+�5D   "   �� $	 
Horizontal=�6-   .+�5E   &   �� $��15(�60   $��Center=�6>   Đến ngày:6d   
  5F   &   $��Center=�5G   -   $��15(�5H   -   $	��120��5I   -   
 5F   1   �� *ToDate+$ PropertyChanged=�5I   -   �� 5K   &   $	 
Horizontal=�61   $	��400��6J   .+�5L   *   	� $��Center=�66   $��	100 0 2 0q�5N   2    d� 	IsChecked 5M   2   �� *
IsDetail+$ PropertyChanged=�5N   G   �� 5O   *   $��Center=�64   $��15(�6O   $��0 0 40 0q�6]   
Chi tiết6y   	� 5P   *   $��Center=�66   $��0 0 2 0q�5R   2    5Q   2   �� *
IsNormal+$ PropertyChanged=�5R   E   �� 5S   *   $��Center=�64   $��15(�6O   Tổng hợp6g   5T   '   5U   #   5V      5W      5X      �� 5Y      $��	Thao tác��6   $	��640��5Z      $��	10 10 0 0q�5[      #��[ 62   .��5\      � .+�5]      �� $	 
Horizontal=�6)   $��Right=�6B   .+�5^   "   �� $��16(�6)   $
��10 0q�67   $	��130��5`   )   
��� � �$��0q�5b   )   ��5_   )   �� *ExcelCommand+.��5b   =   Xuất Excel6I   5c      5d      5e      5f      � 5h      $��1��6   $��0 10 0 0q�6$   .+�5i      �� ��6%   �� *SelectedViewModel+6M   5j      5k      5l      5m      5n      