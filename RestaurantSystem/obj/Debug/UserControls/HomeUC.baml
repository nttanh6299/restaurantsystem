   M S B A M L   `   `   `  ����K  GRestaurantSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RestaurantSystem.UserControlsRestaurantSystem.UserControls  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      *    $RestaurantSystem.UserControls.HomeUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:RestaurantSystem.UserControls     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     homeUCVM � DataContext# [ 5       � 	Resources 5        link �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value
 �� 
TargetType ��Name��%   &	       '�� :    �� 5   
   " ��6   .�5      ��  �@�Cursor$
 Hand��6'   66   �� 5       � ��$ 16(�6)   66   �� 5       � ��
 ���F�6?   �� 5       � ��$ Center=�62   6C    5      P� 5       �@J�IsMouseOver	 . . �5      ��  � ��
 ��  �6B   5      5!      �� 5"   
   " ��6   .�5#      ��  � �� 5$      �� 5%      "
 ��6&   .R�5&      �� 
�������.+�5'      �� $ ContentHeader��6(   $��14(�6?   #��z��6M   #��z��6n   $��Center=�6�   $��10q�6�   5(      5)      5+      �� 5,       �@�OverridesDefaultStyle .  66   �� 5-       � ��
 �   �6+   �� 5.       � ��$ Segoe UI)�6+   �� 5/       � ��$ 13(�6)   50      51      .��52      � 
�������.+�53   
   �� $��Hoạt động hôm nay��6   $��25(�6.   $��2q�6<   .��54      �  � RowDefinitions 55      �� 56      $
��auto �6$   64   �� 57      $
��auto �6$   64   �� 58      6&   .+�5;      � $��0��6   
������� � ColumnDefinitions 5<      �� 5=      6-   �� 5>      6-   �� 5?      6-   �� 5@      6-   .+�5B      � $��0��6   
���  ��$��5q�6<    5C      �� 5D      $
��auto �6/   6>   �� 5E      61   .+�5G      �� $��/Resources/Money.png��6    $��10q�6>   6L   �� 5H      $��1��6%    �� Orientation$ Vertical=�5I   )   $��Center=�5J   )   $	��5 7q�5K   )   .+�5L      �� $*��$Tổng tiền thanh toán hóa đơn��6(   $��18(�6L   
�������6o   �� 5M      
�������$��20(�6�   $
��Bold"�6�   ��6(   �� *
TotalPrice+ �� UpdateSourceTrigger$ PropertyChanged=� �� StringFormat$ {0:#,#}��6�   5N      5O      � 5P      $��1��6   
��� ���$��5q�6?    5Q      �� 5R      $
��auto �6/   6>   �� 5S      61   .+�5U      �� $��/Resources/Bill.png��6    $��10q�6=   6K   �� 5V      $��1��6%   $ Vertical=�5W   )   $��Center=�5X   )   $	��5 7q�5Y   )   .+�5Z      �� $&�� Số hóa đơn đã thanh toán��6(   $��18(�6H   
�������6k   �� 5[      
�������$��20(�6{   $
��Bold"�6�   ��6(   �� *	BillCount+$ PropertyChanged=�6�   5\      5]      � 5^      $��2��6   
��� � �$��5q�6>    5_      �� 5`      $
��auto �6/   6>   �� 5a      61   .+�5c      �� $(��"/Resources/Cancel Subscription.png��6    $��10q�6L   6Z   �� 5d      $��1��6%   $ Vertical=�5e   )   $��Center=�5f   )   $	��5 7q�5g   )   .+�5h      �� $ ��Số hóa đơn bị hủy��6(   $��18(�6A   
�������6d   �� 5i      
�������$��20(�6|   $
��Bold"�6�   ��6(   �� *
BillCancel+$ PropertyChanged=�6�   5j      5k      � 5l      $��3��6   
���   �$��5q�6>    5m      �� 5n      $
��auto �6/   6>   �� 5o      61   .+�5q      �� $��/Resources/Table.png��6    $��10q�6>   6L   �� 5r      $��1��6%   $ Vertical=�5s   )   $��Center=�5t   )   $	��5 7q�5u   )   .+�5v      �� $*��$Số bàn đang được sử dụng��6(   $��18(�6H   
�������6k   �� 5w      
�������$��20(�6{   $
��Bold"�6�   ��6(   �� *	SeatCount+$ PropertyChanged=�6�   5x      5y      5z      � 5|      $��1��6   $
��0 20q�6$    5}      �� 5~      6-   �� 5      6-   �� 5�      6-   .+�5�      �� $��Video hướng dẫn��6   $��
0 10 10 10q�69   $��18(�5�      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Accent=�5�        MaterialDesignGroupBox#���  5�      .��5�      �� $ Vertical=�6%   .+�5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $��/Resources/youtube.png��6(   $��25��6H   $
��10 0q�6S   6c   �� 5�   "   #��[ 6,   )'Hướng dẫn bán hàng trong Cashier6l   5�      �� 5�      $ 
Horizontal=�6)    � Cursor$
 Hand��6B   .+�5�   "   �� $��/Resources/youtube.png��6(   $��25��6H   $
��10 0q�6S   6c   �� 5�   "   #��[ 6,   &$Hướng dẫn nhập kho/xuất kho6g   5�      �� 5�      $ 
Horizontal=�6)   $
 Hand��6B   .+�5�   "   �� $��/Resources/youtube.png��6(   $��25��6H   $
��10 0q�6S   6c   �� 5�   "   #��[ 6,   0.Hướng dẫn chức năng thêm, sửa, xóa6n   5�      �� 5�      $ 
Horizontal=�6)   $
 Hand��6B   .+�5�   "   �� $��/Resources/youtube.png��6(   $��25��6H   $
��10 0q�6S   6c   �� 5�   "   #��[ 6,   *(Hướng dẫn định lượng món ăn6g   5�      �� 5�      $ 
Horizontal=�6)   $
 Hand��6B   .+�5�   "   �� $��/Resources/youtube.png��6(   $��25��6H   $
��10 0q�6S   6c   �� 5�   "   #��[ 6,   Hướng dẫn thống kê6^   5�      5�      5�      �� 5�      $��1��6   $��Mẹo vặt��5�      $
��0 10q�61   $��18(�5�      $
 Dark=�5�      #���  5�      .��5�      �� $ Vertical=�6%   .+�5�      �� Chưa có tin65   5�      5�      �� 5�      $��2��6   $��Kinh nghiệm quản lý��5�      $��
10 10 0 10q�6=   $��18(�5�      $ PrimaryLight=�5�      #���  5�      .��5�      �� $ Vertical=�6%   .+�5�      �� $ 
Horizontal=�6)   $
 Hand��6B   .+�5�   "   �� $��/Resources/search.png��6(   $��25��6G   $
��10 0q�6R   6b   �� 5�   "   #��[ 6,   &$Kinh nghiệm quản lý nhân viên6i   5�      �� 5�      $ 
Horizontal=�6)   $
 Hand��6B   .+�5�   "   �� $��/Resources/search.png��6(   $��25��6G   $
��10 0q�6R   6b   �� 5�   "   #��[ 6,   $"Kinh nghiệm quản lý kho hàng6h   5�      5�      5�      5�      � 5�      $��2��6   $
��0 10q�6$    5�      �� 5�      $
��auto �6(   68   �� 5�      6*   .+�5�      �  5�      �� 5�      61   �� 5�      61   .+�5�      �� $ 
Horizontal=�6%   $��0��6>   .+�5�      �� 
��� � � � ToolTip$ Xuất Excel��5�   %   $��35��5�   %   $��
0 10 10 10q�5�   %   $��0q�5�   %   ��5�   %   �� *ExcelCommand+.��5�   "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 	FileExcel=�6:   $	��Top=�6K   5�      �� 5�      -   5         ��Name$ CommentTextBox��5�   &   $��
10 0 10 10q�5�   &   $��14(�5�   &   $	��120��5�   &   
����  �)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm mã hóa đơn��5�   &   ��5�   &   �� *
SearchBill+$ PropertyChanged=�.��5�   W   .  (System.Windows.Interactivity.Interaction   Triggers 5�   "   /  )System.Windows.Interactivity.EventTrigger  5�   &      	EventName$ TextChanged��65   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�   *   6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 6@   �� *SearchCommand+ 	  CommandParameter 5�   $   ��  �� ElementName$ CommentTextBox��5�   '   .��5�   :   5�      5�      �� 5�      $��1��6%   $ 
Horizontal=�65   $��Right=�6N   $��Center=�6j   .+�5�      (
  "System.Windows.Controls.DatePicker
  $	��130��5�   )   $��10q�5�   )   $��16(�5�   )   $ Ngày bắt đầu��5�   )    
  SelectedDate 5�   )   �� *	FirstDate+$ PropertyChanged=�5�   )   �� 5�      $��Center=�6(   $��1q�6C   -6Q   
  5�      $	��130��5�   )   $��10q�5�   )   $��16(�5�   )   $ Ngày kết thúc��5�   )    5�   )   �� *
LastDate+$ PropertyChanged=�5�   )   �� 5�      $��16(�5�   '   $	��120��5�   '   $��
0 10 10 10q�5�   '   ��5�   '   �� *KindFilterList+ �� SelectedIndex 5�   '   �� *SelectedIndex+$ PropertyChanged=�5�   =   �� 5�      $( "Thời gian tính từ 00h:00m:00s��5�   %   
���   �$��0q�5�   %   $��
0 10 10 10q�5�   %   ��5�   %   �� *FilterCommand+.��5�   "     $ Filter=�6:   5�      5�      5�      �� 5�      $
��Auto=�6#   $��Hidden=�6F   ��. $��1��6�   .��5�      ��  � OverridesDefaultStyle . $��0q�5�   #   ��5�   #   �� *
ListBill+  �� SelectedItem  5�   #   �� *SelectedBill+$ PropertyChanged=�! �� Mode$! OneWayToSource=���5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Center=�6S   5�   #   " �� View" 5�      �� 5   "   .P�5  &   �� .��5  *   �� ��5  .   �� 5  2   .R�5  6   � 
�������.+�5  :   �� $��8 0 0 0q�6C   # d� 	IsChecked# 5  C   �� *	IsChecked+$ PropertyChanged=�6�   5  7   5	  3   5  +   $ �� CellTemplate$ 5  *   �� 5  .   .R�5  2   �� # 6;   �� *
IsSelected+$ PropertyChanged=�6�   5  /   5  '   �� 5  &   $��Mã hóa đơn��65   % �� Width$	% 100��6I   & �� DisplayMemberBinding& 6U   �� *	Item.Id+6�   �� 5  &   $��Ngày giờ vào��65   $	% 190��6K   & 6W   �� *Item.TimeIn+6�   �� 5  &   $��Ngày giờ ra��65   $	% 190��6J   & 6V   �� *Item.TimeOut+6�   �� 5  &   $
��Bàn��65   $	% 120��6B   & 6N   �� *Item.TableFood.Name+6�   �� 5  &   $��Trạng thái��65   $	% 100��6I   $ 5  *   �� 5  .   .R�5  2   �� $��15��68   ��6C   �� *Image+6^   5  /   5  '   �� 5  &   $��Giảm giá��65   $	% 150��6G   & 6S   �� *Item.Discount+6�   �� 5  &   $��Thanh toán��65   $	% 200��6I   & 6U   �� *Item.TotalPrice+$ {0:#,#}��6�   �� 5  &   $	% 175��65   $ 5   *   �� 5!  .   .R�5"  2   �� $ 
Horizontal=�6=   .+�5#  6   �� 
������ $ Sửa hóa đơn��5&  =   $��0q�5'  =   ��5$  =   �� *EditCommand+' �� Source#' [ ��5%  =   �� ( �� RelativeSource( �� ) �� Mode$
) Self=�* �� Path$* DataContext�.��5(  :   �� $��/Resources/edit.png��6@   $��15��6]   6j   5)  7   �� 5*  6   
������ $ In hóa đơn��5-  =   $��0q�5.  =   ��5+  =   �� *PrintCommand+#' [ ��5,  =   �� ( �� $
) Self=�$* DataContext�.��5/  :   �� $��/Resources/print.png��6@   $��15��6^   6k   50  7   �� 51  6   
������ $ Xóa hóa đơn��54  =   $��0q�55  =   ��52  =   �� *DeleteCommand+#' [ ��53  =   �� ( �� $
) Self=�$* DataContext�.��56  :   �� $��/Resources/trash.png��6@   $��15��6^   6k   57  7   58  3   59  /   5;  '   5<  #   5>     5?     5@     5A     5B     5C     5D     