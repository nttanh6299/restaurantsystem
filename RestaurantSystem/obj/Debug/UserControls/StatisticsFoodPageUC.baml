   M S B A M L   `   `   `  ����K  GRestaurantSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RestaurantSystem.UserControlsRestaurantSystem.UserControls  5      8    2RestaurantSystem.UserControls.StatisticsFoodPageUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:RestaurantSystem.UserControls     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     statisticsfoodUCVM � DataContext# [ 5       � 	Resources 5        groupbox �� 
TargetType �� Property �� Value �� 
TargetType ��Name  alternatingListViewStyle	 �� Triggers
 P� Property P� Value��%�  &	       '�� �     &	 �    �� 5   
   " ��6!   .�5      ��  � ��
 �����6,   �� 5       � �� 5      �� 5      .R�5      �� $��18(�65   $
��Bold"�6C   ��6$   �� 6C   5      5      5      �� 5   
   " ��6   .�5       ��  � �� 5!      �� 5"      " ��6&   .R�5#      �� 
�������.+�5$      �� $ ContentHeader��6(   $��14(�6?   #��z��6M   #��z��6n   $��Center=�6�   $��10q�6�   5%      5&      5(      �� 5)       �@�OverridesDefaultStyle .  66   �� 5*       � ��
 �   �6+   �� 5+       � ��$ Segoe UI)�6+   �� 5,       � ��$ 13(�6)   5-      �� 5.   
   " ��61   .�5/      ��  � ��$ Center=�6;   6L   	 50      P� 51      
 �@��AlternationIndex$ 0��6C   . �52      ��  � ��
 �����6H   �� 53       � ��$ 1 0 1 1q�68   6J   �� 54       � ��
 �����6C   �� 55       � ��$ 16(�61   6>   �� 56       � ��$ 36��6/   6<   57      P� 58      
 �@��AlternationIndex$ 1��6C   . �59      ��  � ��
 �����6H   �� 5:       � ��$ 1 0 1 1q�68   6J   �� 5;       � ��
 �����6G   �� 5<       � ��$ 16(�61   6>   �� 5=       � ��$ 36��6/   6<   5>      P� 5?      
 �@J�IsMouseOver . . �5@      ��  � ��
 ��ح�6G   5A      P� 5B      
 �@��
IsSelected . . �5C      ��  � ��
 ��ح�6G   5D      5F      5G      .��5H      � 
�������.+�5I   
   �� $��THỐNG KÊ MÓN ĂN��6   $��25(�6,   $��2q�6:   .��5J      �  � RowDefinitions 5K      �� 5L      $
��auto �6$   64   �� 5M      6&   .+�5O      ��  �� Orientation$ 
Horizontal=�6   .+�5P      �� $��0 10 0 0q�6   $ ��Điều kiện thống kê��61   #��[ 6M   .��5Q      �� $ Vertical=�6%   .+�5R      �� $ 
Horizontal=�6)   .+�5S   "   �� $��15(�6,   $��Center=�6:   $��0 0 9 0q�6U   Từ ngày:6p   (  "System.Windows.Controls.DatePicker  5T   "   $��Center=�5U   -   $��15(�5V   -   $	��120��5W   -      SelectedDate 5T   -   �� *
FromDate+ �� UpdateSourceTrigger$ PropertyChanged=�5W   -   5Y      �� 5Z      $ Vertical=�6)   $��0 10 0 0q�6@   .+�5[   "   �� $ 
Horizontal=�6-   .+�5\   &   �� $��15(�60   $��Center=�6>   Đến ngày:6d     5]   &   $��Center=�5^   -   $��15(�5_   -   $	��120��5`   -    5]   1   �� *ToDate+$ PropertyChanged=�5`   -   �� 5b   &   $ 
Horizontal=�61   $	��400��6J   5c   N   5d   #   5e      5f      5g      �� 5h      $��	Thao tác��6   $	��640��5i      $��	10 10 0 0q�5j      #��[ 62   .��5k      � .+�5l      �� $ 
Horizontal=�6)   $��Right=�6B   .+�5m   "   �� $��16(�6)   $	��130��5o   )   
���   �$��0q�5q   )   ��5n   )   �� *LoadListCommand+.��5q   =   
Áp dụng6F   �� 5r   "   $��16(�6)   $
��10 0q�67   $	��130��5t   )   
��� � �$��0q�5v   )   ��5s   )   �� *ExcelCommand+.��5v   =   Xuất Excel6I   5w      5x      5y      5z      � 5|      $��1��6   $��0 10 0 0q�6$   .+�5}      �� $
��Auto=�6#   $��Hidden=�6F   .��5~      �� $
��0 10q�5�      $	��330��5�      $	��Top=�5�      #���  5�       �� AlternationCount$ 2��5�      ��5~   #   �� *List+ �� SelectedItem 5      �� *SelectedItem+ �� Mode$ TwoWay=� �� View 5�      �� 5�   "   .P�5�   &   �� $��Mã món��65    �� Width$	 150��6E    �� DisplayMemberBinding 6Q   �� *	Item.Id+6|   �� 5�   &   $��	Tên món��65   $	 300��6F    6R   �� *	Item.Name+6   �� 5�   &   $
��ĐVT��65   $	 150��6B    6N   �� *Item.Unit.Name+6�   �� 5�   &   $��
Đơn giá��65   $	 240��6F    6R   �� *
Item.Price+ �� StringFormat$ {0:#,#}��6�   �� 5�   &   $��Số lượng tổng��65   $	 210��6L    �� CellTemplate 5�   *   �� 5�   .   .R�5�   2   �� 
���  ����6<   �� *Count+6f   5�   /   5�   '   �� 5�   &   $	 210��65    6A   �� *a+6f   5�   #   5�      5�      5�      5�      5�      5�      5�      