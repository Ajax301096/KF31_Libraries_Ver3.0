   M S B A M L   `   `   `  ����[  WKF31_図書館システム版3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullm;clr-namespace:KF31_図書館システム版3._0.Stock_Model-KF31_図書館システム版3._0.Stock_Model  5   	   w@clr-namespace:KF31_図書館システム版3._0.UserControl_KF312KF31_図書館システム版3._0.UserControl_KF31  5
   	   9    3KF31_図書館システム版3._0.Stock_Model.Stock   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Mlocal;clr-namespace:KF31_図書館システム版3._0.Stock_Model     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   Iuc@clr-namespace:KF31_図書館システム版3._0.UserControl_KF31  5
   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��
list_Stock��5   	      MaterialDesignBody#���   5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     StockViewModel � DataContext# [ 5   	    � Title$ 在庫一覧��5   	   $	��510��6   $	��800��6#   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedWindowCommand+   CommandParameter 5      ��  �� ElementName$ 
list_Stock��5      .��5      � ���#F2F2F2 � RowDefinitions 5    
   �� 5!      $
��auto �6   6,   �� 5"      6   �� 5#      $
��auto �6   6,   .+�5%   
   � $��0��6   ���#c7816f.+�5&      J   DKF31_図書館システム版3._0.UserControl_KF31.Hamburger_Control  
 � Tag 6#   �� *Title+$ 
list_Stock��6R   5'      � 5(   
   $��1��6    5)      �� 5*      $
��auto �6    60   �� 5+      6"   .+�5-      #  MaterialDesignThemes.Wpf.Card  $��5q�6"   $��0��6-   ���#F2F2F2.��5.      � $��	0 10 0 10q�6   .+�50      �� $��	35 5 15 5q�6   $��15(�62    �� DisplayMemberPath$ StockID��51      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 在庫ID��54       & "MaterialDesignFloatingHintComboBox#��[ 55      ��52      �� *Stocks+ �� SelectedItem 53      �� *Selected_Stock+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�56      �� 57      $��	15 5 15 5q�6Z   $ タイトル��6m    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6   �� *Title+$ PropertyChanged=�6�   ,	  &MaterialDesignThemes.Wpf.NumericUpDown	  59      $��
35 5 15 -5q�63   $ 数量��6G    	  Minimum$ 0��6k    	  Value 5:      �� *Value+$ TwoWay=�6?   �� 5>      $��20,0,0,0q�6   $��50��6/   ���#b0816f���#b0816f��5?      �� *ClearCommand+��66   �� $ 
list_Stock��.��5@      '
  !MaterialDesignThemes.Wpf.PackIcon
   
  Kind$ Broom=�62   5B      �� 5C      $��20,0,0,0q�6   $	��100��6/   ���#b0816f���#b0816f��5D      �� *SearchCommand+��67   �� $ 
list_Stock��.��6l   検索6p   �� 5E      $��20,0,0,0q�6   $	��100��6/   ���#b0816f���#b0816f��5F      �� *BackMainWindowCommand+��6@   �� $ 
list_Stock��.��6u   戻る6y   5G      5H        5I      $��1��6"   $��5q�6/   ���#F2F2F2.��5J      �� $
��Auto=�6   $
��auto=�6B   .��5K      �� ��6   �� *Stocks_Search+ 6E   �� *SelectedItem+$ OneWayToSource=� �� View 5L      �� 5M      .P�5N   "   �� $��在庫ID��61    �� Width$
 auto��6?    �� DisplayMemberBinding 6M   �� *	StockID+6x   �� 5O   "   $��タイトル��61   $	 150��6?    6K   �� *Book_table.Book_title+6�   �� 5P   "   $��数量��61   $
 auto��6=    6J   �� *
Quantity+6v   5Q      5S      5T      5U      5V      � 5X   
   $��2��6   ���#99b9a4$��57��61   $��Bottom=�6=   5\      5]      