   M S B A M L   `   `   `  ����[  WKF31_図書館システム版3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullm;clr-namespace:KF31_図書館システム版3._0.Input_Model-KF31_図書館システム版3._0.Input_Model  5   	   w@clr-namespace:KF31_図書館システム版3._0.UserControl_KF312KF31_図書館システム版3._0.UserControl_KF31  5
   	   N    HKF31_図書館システム版3._0.Input_Model.input_ListandSearch_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Mlocal;clr-namespace:KF31_図書館システム版3._0.Input_Model     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   Iuc@clr-namespace:KF31_図書館システム版3._0.UserControl_KF31  5
   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��
list_input��5   	      MaterialDesignBody#���   5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     StockInViewModel � DataContext# [ 5   	    � Title$ 入庫一覧��5   	   $	��510��6   $	��800��6#   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedWindowCommand+   CommandParameter 5      ��  �� ElementName$ 
list_input��5      .��5       � ���#F2F2F2 � RowDefinitions 5!   
   �� 5"      $
��auto �6   6,   �� 5#      6   �� 5$      $
��auto �6   6,   .+�5&   
   � $��0��6   ���#c7816f.+�5'      J   DKF31_図書館システム版3._0.UserControl_KF31.Hamburger_Control  
 � Tag 6#   �� *Title+$ 
list_input��6R   5(      � 5)   
   $��1��6    5*      �� 5+      $��60 �6    6.   �� 5,      6"   .+�5.      #  MaterialDesignThemes.Wpf.Card  $��0��6"   .��5/      � $��	0 10 0 10q�6   .+�51      �� $��	35 5 15 5q�6   $��15(�62   $��25,0,0,0q�6@   $	��150��52      $��30��6'   $
��Left=�63    �� DisplayMemberPath$ 
StockIN_ID��53      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 入庫ID��56       & "MaterialDesignFloatingHintComboBox#��[ 57      ��54      �� *	StockIn+ �� SelectedItem 55      �� *SelectStockIn+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�58      �� 5<      $��	210,0,0,0q�6   $��30,0,0,0q�62   $��15(�6E   $	��150��5=      $��30��6+   $
��Left=�67   $ status��5>      $ 状態��5A      #��[ 5B      ��5?      �� *Status+ 5@      �� *SelectStatus+$ TwoWay=�$ PropertyChanged=�5C      �� 5E      $��	0,0,160,0q�6   $	��100��60   ���#b0816f���#b0816f$��Right=�5F   
   ��6&   �� *SearchCommand+��6H   �� $ 
list_input��.��6}   検索6�   �� 5G      $��0,0,35,0q�6   $	��100��6/   ���#b0816f���#b0816f$��Right=�5H   
   ��6&   �� *Add_WindowCommand+��6L   �� $ 
list_input��.��6�   戻る6�   5I      5J        5K      $��1��6"   $��	0 10 0 10q�6/   .��5L      �  � ColumnDefinitions 5M      �� 5N      $	��350 �6+   69   �� 5O      6-   .+�5Q      � $��0��6   .+�5R        $��20q�6/   $��Stretch=�6;   ���#F2F2F2.��5S      �� $
��Auto=�6+   $
��auto=�6N   .��5T   "   �� ��6+   �� *StockInSearch+ 6Q   �� *SelectItemList+$ OneWayToSource=� �� View 5U   &   �� 5V   *   .P�5W   .   �� $��入庫ID��6=    �� Width$
 auto��6K    �� DisplayMemberBinding 6Y   �� *
StockIN_ID+6�   �� 5X   .   $��状態��6=   $
 auto��6I    6V   �� *Status_table.status+6�   �� 5Y   .   $��日付��6=   $
 auto��6I    6V   �� *stockIn_Date+ �� StringFormat$ 
yyyy/MM/dd��6�   5Z   +   5\   #   5]      5^      5_      � 5`      $��1��6   .+�5a        $��20q�6/   $��Stretch=�6;   ���#F2F2F2.��5b      �� $
��Auto=�6+   $
��auto=�6N   .��5c   "   �� ��6+   �� *StockInDetail+ 5d   &   �� 5e   *   .P�5f   .   �� $��本ID��6=   $
 auto��6J    6X   �� *BookID+6�   �� 5g   .   $��タイトル��6=   $
 auto��6K    6X   �� *Book_table.Book_title+6�   �� 5h   .   $��数量��6=   $
 auto��6I    6V   �� *StockIn_Quantity+6�   5i   +   5k   #   5l      5m      5n      5o      5p      5q      � 5s   
   $��2��6   ���#99b9a4$��57��61   $��Bottom=�6=   5w      5x      