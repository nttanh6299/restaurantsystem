   M S B A M L   `   `   `  ����K  GRestaurantSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RestaurantSystem.UserControlsRestaurantSystem.UserControls  5      /    )RestaurantSystem.UserControls.StaffPageUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:RestaurantSystem.UserControls     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     	staffUCVM � DataContext# [ 5       � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name  groupbox  alternatingListViewStyle	 �� Triggers
 P� Property P� Value��%�  '��       &	 �    &	 �    �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� 
�������.+�5      �� $ ContentHeader��6(   $��14(�6?   #��z��6M   #��z��6n   $��Center=�6�   $��10q�6�   5      5      5      �� 5       �@�OverridesDefaultStyle .  66   �� 5        � ��
 �   �6+   �� 5!       � ��$ Segoe UI)�6+   �� 5"       � ��$ 13(�6)   5#      �� 5$   
   " ��6!   .�5%      ��  � ��
 �����6,   �� 5&       � ��$ 	25,20,5,5q�6'   �� 5'       � �� 5(      �� 5)      .R�5*      �� $
��Bold"�65   ��6$   �� 65   5+      5-      5.      �� 5/   
   " ��61   .�50      ��  � ��$ Center=�6;   6L   	 51      P� 52      
 �@��AlternationIndex$ 0��6C   . �53      ��  � ��
 �����6H   �� 54       � ��$ 1 0 1 1q�68   6J   �� 55       � ��
 �����6C   �� 56       � ��$ 16(�61   6>   �� 57       � ��$ 36��6/   6<   58      P� 59      
 �@��AlternationIndex$ 1��6C   . �5:      ��  � ��
 �����6H   �� 5;       � ��$ 1 0 1 1q�68   6J   �� 5<       � ��
 �����6G   �� 5=       � ��$ 16(�61   6>   �� 5>       � ��$ 36��6/   6<   5?      P� 5@      
 �@J�IsMouseOver . . �5A      ��  � ��
 ��ح�6G   5B      P� 5C      
 �@��
IsSelected . . �5D      ��  � ��
 ��d�6L   5E      5G      5H      .��5I      � 
�������.+�5J   
   �� $��NHÂN VIÊN��6   $��25(�6&   $��2q�64   .��5K      �  � RowDefinitions 5L      �� 5M      $
��auto �6$   64   �� 5N      6&   .+�5P      �� $��0��6   $��Thông tin nhân viên��5Q      #��[ 5R      .��5S      �  � ColumnDefinitions 5T      �� 5U      61   �� 5V      61   �� 5W      61   .+�5Y      ��  �� Orientation$ Vertical=�6%   $��10q�6<   .+�5Z      �� $
��25 1q�6&    �� 
IsReadOnly . $��17(�5]   %   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ID��5^   !    % !MaterialDesignFloatingHintTextBox#��[ 5_   !   ��5[   &   �� *Id+ �� UpdateSourceTrigger$ PropertyChanged=�5_   !   �� 5`      $
��25 1q�6&    . $��17(�5b   &   $ Tên đăng nhập��5d   !   #��[ 5e   !   ��5c   &   �� *
UserName+$ PropertyChanged=�5e   !   5f      �� 5g      $��1��6%   $ Vertical=�65   $��10q�6L   .+�5h      �� $
��25 1q�6&   $��17(�5i   &   $ Tên nhân viên��5k   !   #��[ 5l   !   ��5j   &   �� *Name+$ PropertyChanged=�5l   !   �� 5m      $ Quyền hành��6D    �� DisplayMemberPath$
 Name��5n   '   $
��25 7q�5p   '   $��17(�5q   &   ��5m   '   �� *Role+ �� SelectedItem 5o   '   �� *SelectedRole+$ PropertyChanged=�5q   6   5r      � 5s      $��2��6   .+�5t      �� 5v      5w      5x      5y      �� 5z      $��1��6   $!��Danh sách các nhân viên��6(   $��	25,10,5,5q�6I   #��[ 6\   .��5{      �� .+�5|      �  5}      �� 5~   "   65   �� 5   "   65   .+�5�      �� $��0��6)   $ 
Horizontal=�69   .+�5�   "   �� $��15(�6,   $��Center=�6:   $��	25 0 10 0q�6U   Sắp xếp theo:6w   �� 5�   "   $��15(�5�   +   $	��120��5�   +   ��5�   +   �� *	ListOrder+ �� SelectedIndex 5�   +   �� *
IndexOrder+$ PropertyChanged=�.  (System.Windows.Interactivity.Interaction   Triggers 5�   &   /  )System.Windows.Interactivity.EventTrigger  5�   *      	EventName$ SelectionChanged��69   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�   .   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6D   �� *OrderByCommand+   CommandParameter 5�   $   ��  �� ElementName$ cmbOrder��5�   +   5�   #   5�      �� 5�      -   5         ��Name$ cmbOrder��5�   '   $��10 0 0 0q�5�   '   $��15(�5�   '   $	��120��5�   '   ��5�   '   �� *ListOrderKind+ 5�   '   �� *Index+$ PropertyChanged=� 5�   "     5�   &   $ SelectionChanged��65   . 5�   *      6@   �� *OrderCommand+ 5�   $   �� $ cmbOrder��5�   '   5�      �� 5�      $��1��6)   $ 
Horizontal=�69   $��Right=�6R   .+�5�   "   �� $��80��6)    � ToolTip$ Thêm nhân viên��5�   )   
��� � �$��0q�5�   )   ��5�   )   �� *
AddCommand+.��6H   Thêm6N   �� 5�   "   $��80��6)   $ Sửa nhân viên��5�   *   
��� ���$��0q�5�   )   $��10 0 0 0q�5�   )   ��5�   )   �� *EditCommand+.��5�   ;   Sửa6@   �� 5�   "   $��80��6)   $ Sửa nhân viên��5�   *   
���  ��$��0q�5�   )   $
��10 0q�5�   )   ��5�   )   �� *DeleteCommand+.��5�   7   Xóa6<   5�      5�      �� 5�      $
��Auto=�6'   $��Hidden=�6J   .��5�      �� $��10q�5�   +   $	��370��5�   +   #���  5�   +    �� AlternationCount$ 2��5�   +   ��5�   +   �� *List+ 5�   +   �� *SelectedItem+ �� Mode$ TwoWay=� �� View 5�   "   �� 5�   &   .P�5�   *   �� $��ID��69     �� Width$	  150��6E   ! �� CellTemplate! 5�   .   �� 5�   2   .R�5�   6   �� 
���  ����6@   �� *Id+6g   5�   3   5�   +   �� 5�   *   $��Tên đăng nhập��69   $	  350��6P   " �� DisplayMemberBinding" 6\   �� *
UserName+6�   �� 5�   *   $��Tên nhân viên��69   $	  450��6P   " 6\   �� *Name+6�   �� 5�   *   $��Quyền hành��69   $	  250��6M   " 6Y   �� *	Role.Name+6�   5�   '   5�      5�      � 5�      .+�5�      �� $ 
Horizontal=�6)   $��Right=�6B   .+�5�   "   �� $��Center=�6,   $��25 0 0 0q�5�   ,   $��15(�5�   ,   Tổng số nhân viên:6N   �� 5�   "   $��15(�5�   ,   $��Center=�5�   ,   
���  ��$
��5 0 q�5�   ,   ��5�   ,   �� *CountOfStaff+$ PropertyChanged=�5�   <   5�      �� 5�      $ 
Horizontal=�6)   $
��Left=�6B   .+�5�   "   �� $ Tìm kiếm��6*   $	��200��5�   *   $��14(�5�   *   $��10q�5�   *   ��5�   *   �� *SearchTextbox+$ PropertyChanged=�.��5�   6    5�   &     5�   *   $ TextChanged��69   . 5�   .      6D   �� *SearchCommand+ 5�   $   �� $ CommentTextBox��5�   +   .��5�   >   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      