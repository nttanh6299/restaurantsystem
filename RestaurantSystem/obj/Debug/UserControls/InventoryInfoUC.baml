   M S B A M L   `   `   `  ����K  GRestaurantSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RestaurantSystem.UserControlsRestaurantSystem.UserControls  5      3    -RestaurantSystem.UserControls.InventoryInfoUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:RestaurantSystem.UserControls     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5        $��window��5         MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     inventoryinfoUCVM � DataContext# [ 5       � 	Resources 5        groupbox �� 
TargetType �� Property �� Value �� 
TargetType ��Name  alternatingListViewStyle	 �� Triggers
 P� Property P� Value��%�  &	       '�� �     &	 �    �� 5   
   " ��6!   .�5      ��  � ��
 �����6,   �� 5       � ��$ 	25,20,5,5q�6'   �� 5       � �� 5      �� 5      .R�5      �� $
��Bold"�65   ��6$   �� 65   5      5      5       �� 5!   
   " ��6   .�5"      ��  � �� 5#      �� 5$      " ��6&   .R�5%      �� 
�������.+�5&      �� $ ContentHeader��6(   $��14(�6?   #��z��6M   #��z��6n   $��Center=�6�   $��10q�6�   5'      5(      5*      �� 5+       �@�OverridesDefaultStyle .  66   �� 5,       � ��
 �   �6+   �� 5-       � ��$ Segoe UI)�6+   �� 5.       � ��$ 13(�6)   5/      �� 50   
   " ��61   .�51      ��  � ��$ Center=�6;   6L   	 52      P� 53      
 �@��AlternationIndex$ 0��6C   . �54      ��  � ��
 �����6H   �� 55       � ��$ 1 0 1 1q�68   6J   �� 56       � ��
 �����6C   �� 57       � ��$ 16(�61   6>   �� 58       � ��$ 36��6/   6<   59      P� 5:      
 �@��AlternationIndex$ 1��6C   . �5;      ��  � ��
 �����6H   �� 5<       � ��$ 1 0 1 1q�68   6J   �� 5=       � ��
 �����6G   �� 5>       � ��$ 16(�61   6>   �� 5?       � ��$ 36��6/   6<   5@      P� 5A      
 �@J�IsMouseOver . . �5B      ��  � ��
 ��ح�6G   5C      P� 5D      
 �@��
IsSelected . . �5E      ��  � ��
 ��d�6L   5F      5H      5I      .��5J      � 
�������.+�5K   
   �� $��THÔNG TIN KHO HÀNG��6   $��25(�6/   $��2q�6=   .��5L      �  � RowDefinitions 5M      �� 5N      $
��auto �6$   64   �� 5O      6&   .+�5Q      �� $��0��6   $��Thông tin hàng hóa��5R      #��[ 5S      .��5T      �  � ColumnDefinitions 5U      �� 5V      61   �� 5W      61   �� 5X      61   .+�5Z      ��  �� Orientation$ Vertical=�6%   $��10q�6<   .+�5[      �� $
��25 1q�6&    �� 
IsReadOnly . $��17(�5^   %   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ID��5_   !    % !MaterialDesignFloatingHintTextBox#��[ 5`   !   ��5\   &   �� *Id+ �� UpdateSourceTrigger$ PropertyChanged=�5`   !   �� 5a      $
��25 1q�6&   $��17(�5c   %   $ Tên hàng hóa��5d   !   #��[ 5e   !   ��5b   &   �� *Name+$ PropertyChanged=�5e   !   5g      �� 5h      $��1��6%   $ Vertical=�65   $��10q�6L   .+�5i      �� $
��25 4q�5k   '   $��17(�5l   '    �� DisplayMemberPath$
 Name��5m   '   $ Đơn vị tính��5n   '   ��5i   '   �� *Unit+ �� SelectedItem 5j   '   �� *SelectedUnit+$ PropertyChanged=�5o      �� 5p      $
��25 1q�6&    . $��17(�5s   &   $ Số lượng tồn��5t   !   #��[ 5u   !   ��5q   &   �� *Count+$ PropertyChanged=�5u   !   5v      5w      5x      �� 5y      $��1��6   $3��-Danh sách hàng hóa và số lượng tồn��6(   $��	25,10,5,5q�6T   #��[ 6g   .��5z      �� .+�5{      �  5|      �� 5}   "   65   �� 5~   "   65   .+�5�      �� $��1��6)   $ 
Horizontal=�69   $��Right=�6R   .+�5�   "   �� $	��160��6)    � ToolTip$ Thêm đơn vị tính��5�   )   
��� � �$��0q�5�   )   ��5�   )   �� *AddUnitCommand+.��6L   Thêm đơn vị tính6^   �� 5�   "   $��80��6)   $ Thêm mới hàng hóa��5�   )   $��0q�5�   )   
��� � �$��10 0 0 0q�5�   )   ��5�   )   �� *
AddCommand+.��5�   ;   Thêm6A   �� 5�   "   $��80��6)   $ Sửa hàng hóa��64   $��0q�5�   )   
��� ���$��10 0 0 0q�5�   )   ��5�   )   �� *EditCommand+.��5�   ;   Sửa6@   �� 5�   "   $��80��6)   $ Xóa hàng hóa��64   $��0q�5�   )   
���  ��$
��10 0q�5�   )   ��5�   )   �� *DeleteCommand+.��5�   7   Xóa6<   �� 5�   "   $��0q�6)   $ Xuất Excel��5�   )   $��0 0 10 0q�5�   )   
��� � �$
��Left=�5�   )   ��5�   )   �� *ExcelCommand+.��5�   &   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 	FileExcel=�6>   5�   #   5�      5�      �� 5�      $
��Auto=�6'   $��Hidden=�6J   .��5�      �� $
��0 10q�6'   $	��370��5�   '   #���  5�        �� AlternationCount$ 2��5�   +   ��5�   '   �� *InventoryList+ 5�      �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5�   "   �� 5�   &   .P�5�   *   �� $��ID��69    �� Width$	 150��6E    �� CellTemplate 5�   .   �� 5�   2   .R�5�   6   �� 
���  ����6Q   �� *
Goods.Id+6m   5�   3   5�   +   �� 5�   *   $��Tên hàng hóa��69   $	 400��6O    �� DisplayMemberBinding 6[   �� *
Goods.Name+6�   �� 5�   *   $��Đơn vị tính��69   $	 300��6N    6Z   �� *	Unit.Name+6�   �� 5�   *   $��Số lượng tồn��69   $	 250��6O    6[   �� *Count+6�   �� 5�   *   $	 120��69    6E   �� *a+6j   5�   '   5�      5�      � 5�      .+�5�      �� $ 
Horizontal=�6)   $��Right=�6B   .+�5�   "   �� $��Center=�6,   $��25 0 0 0q�5�   ,   $��Seoge UI)�5�   ,   $��15(�5�   ,   Tổng số hàng hóa:6M   �� 5�   "   $��16(�6,   
���  ��$��Center=�5�   ,   $��5 0 0 0q�5�   o   ��6,   �� *CountOfGoods+$ PropertyChanged=�6�   5�      �� 5�      $
��Left=�6)   $��Bottom=�6D   .+�5�   "   �� $ Tìm kiếm��6*   $	��200��5�   *   $��14(�5�   *   $��10q�5�   *   ��5�   *   �� *SearchTextbox+$ PropertyChanged=�.��5�   6   .  (System.Windows.Interactivity.Interaction   Triggers 5�   &   /  )System.Windows.Interactivity.EventTrigger  5�   *      	EventName$ TextChanged��69   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�   .   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6D   �� *SearchCommand+    CommandParameter  5�   $   �� ! �� ElementName$! CommentTextBox��5�   +   .��5�   >   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      