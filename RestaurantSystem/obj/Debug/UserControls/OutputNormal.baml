   M S B A M L   `   `   `  ����K  GRestaurantSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RestaurantSystem.UserControlsRestaurantSystem.UserControls  5      0    *RestaurantSystem.UserControls.OutputNormal   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:RestaurantSystem.UserControls     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5        $��normal��5	      .  (System.Windows.Interactivity.Interaction    Triggers  5
      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+   CommandParameter 5   $   ��  �� ElementName$ normal��5       � 	Resources 5       �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name   alternatingListViewStyle �� Triggers P� Property P� Value��%�  '��       &	  �    �� 5   
   " ��6   .�5      ��  � ��	 5      �� 5      "
 ��6&   .R�5      �� 
�������.+�5      �� $ ContentHeader��6(   $��14(�6?   #��z��6M   #��z��6n   $��Center=�6�   $��10q�6�   5      5      5      �� 5       �@�OverridesDefaultStyle	 .  66   �� 5       � ��
	 �   �6+   �� 5       � ��$	 Segoe UI)�6+   �� 5       � ��$	 13(�6)   5       �� 5!   
   " ��61   .�5"      ��  � ��$	 Center=�6;   6L    5#      P� 5$       �@��AlternationIndex$ 0��6C   . �5%      ��  � ��
	 �����6H   �� 5&       � ��$	 1 0 1 1q�68   6J   �� 5'       � ��
	 �����6C   �� 5(       � ��$	 16(�61   6>   �� 5)       � ��$	 36��6/   6<   5*      P� 5+       �@��AlternationIndex$ 1��6C   . �5,      ��  � ��
	 �����6H   �� 5-       � ��$	 1 0 1 1q�68   6J   �� 5.       � ��
	 �����6G   �� 5/       � ��$	 16(�61   6>   �� 50       � ��$	 36��6/   6<   51      P� 52       �@J�IsMouseOver . . �53      ��  � ��
	 ��ح�6G   54      P� 55       �@��
IsSelected . . �56      ��  � ��
	 ��ح�6G   57      59      5:      .��5;      � .+�5<   
   �� $
��Auto=�6   $��Hidden=�6:   .��5=      �� $
��0 10q�5?      $	��Top=�5@      $	��330��5A      #���   5B       �� AlternationCount$ 2��5C      ��5=      �� *List+ �� SelectedItem 5>      �� *SelectedItem+ �� Mode$ TwoWay=� �� View 5D      �� 5E      .P�5F      �� $��Mã hàng hóa��6)    �� Width$	 140��6>    �� DisplayMemberBinding 6J   �� *
Goods.Id+6v   �� 5G      $��Tên hàng hóa��6)   $	 200��6?    6K   �� *
Goods.Name+6y   �� 5H      $
��ĐVT��6)   $	 140��66    6B   �� *Goods.Unit.Name+6u   �� 5I      $��Số lượng xuất��6)   $	 200��6@    6L   �� *Count+ �� StringFormat$ {0:#,#}��6�   �� 5J      $��Ghi chú��6)   $	 600��6:    6F   �� *Output.MoreInfo+6y   5K      5M      5N      5O      5P      