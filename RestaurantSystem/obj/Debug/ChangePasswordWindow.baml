   M S B A M L   `   `   `  ����K  GRestaurantSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:RestaurantSystemRestaurantSystem  5   	   +    %RestaurantSystem.ChangePasswordWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:RestaurantSystem     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5        $��
changepass��5   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   
    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	     changepassVM � DataContext# [ 5   	    � Title$ 1��5   	   $	��350��6   $	��400��6    $y�Visible=�6,    +� FocusedElement 5   	   ��  �� ElementName$ oldPass��.  (System.Windows.Interactivity.Interaction	   Triggers	 5      /  )System.Windows.Interactivity.EventTrigger  5   
   
   	EventName$
 MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *MouseMoveWindowCommand+   CommandParameter 5   $   �� $ 
changepass��5      .��5       ��  �� Orientation$ Vertical=�6   .+�5!   
   �� $��Center=�6   $��20(�61   $
��0 20q�6?   Thay đổi mật khẩu6`   �� 5"   
   $ Vertical=�6   $��Center=�6,   $��Center=�6I   $	��250��6d   $	��200��6p   .+�5#      G� -   5         G�Name$ oldPass��5#      $
��5 10q�6+   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mật khẩu cũ��5$       ) %MaterialDesignFloatingHintPasswordBox#��[ 5%      	 5&        5'      $
 PasswordChanged��6%   . 5(         60   �� *OldPassCommand+ 5)   $   �� $ oldPass��5+      5-      G� 5.      -   5        $ newPass��5.      $��5 10 5 5q�6+   $ Mật khẩu mới��5/      #��[ 50      	 51        52      $
 PasswordChanged��6%   . 53         60   �� *NewPassCommand+ 54   $   �� $ newPass��56      58      G� 59      -   5        $ 	reNewPass��59      $	��5 0q�6-   $% Nhập lại mật khẩu mới��5:      #��[ 5;      	 5<        5=      $
 PasswordChanged��6%   . 5>         60   �� *RePassCommand+ 5?   $   �� $ 	reNewPass��5A      5C      5D      �� 5E   
   $ 
Horizontal=�6   $��Center=�6.   .+�5F      �� $	��100��6   $	��5 0q�5I       �� 	IsDefault . ��5G      �� *	OKCommand+��5H      ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �.��5J   &   Xác nhận60   �� 5K      $	��100��6    �� IsCancel . ��5L      �� *CancelCommand+��5M      ��  �� *FindAncestor+" �.��5N   %   
Hủy bỏ6-   5O      5P      5Q      