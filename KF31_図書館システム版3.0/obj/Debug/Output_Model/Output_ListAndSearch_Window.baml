   M S B A M L   `   `   `  ����[  WKF31_図書館システム版3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:KF31_図書館システム版3._0.Output_Model.KF31_図書館システム版3._0.Output_Model  5   	   w@clr-namespace:KF31_図書館システム版3._0.UserControl_KF312KF31_図書館システム版3._0.UserControl_KF31  5
   
   P    JKF31_図書館システム版3._0.Output_Model.Output_ListAndSearch_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Nlocal<clr-namespace:KF31_図書館システム版3._0.Output_Model     5   	   Ouc@clr-namespace:KF31_図書館システム版3._0.UserControl_KF31     5
   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��
listoutput��5   	      MaterialDesignBody#���   5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     StockOutViewModel � DataContext# [ 5   	    � Title$ 出庫詳細��5   	   $	��510��6   $	��800��6#   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedWindowCommand+   CommandParameter 5      ��  �� ElementName$ 
listoutput��5      .��5      � ���#F2F2F2 � RowDefinitions 5    
   �� 5!      $
��auto �6   6,   �� 5"      6   �� 5#      $
��auto �6   6,   .+�5%   
   � $��0��6   ���#c7816f.+�5&      J   DKF31_図書館システム版3._0.UserControl_KF31.Hamburger_Control  
 � Tag 6#   �� *Title+$ 
listoutput��6R   5'      � 5(   
   $��1��6    5)      �� 5*      $��60 �6    6.   �� 5+      6"   .+�5-      #  MaterialDesignThemes.Wpf.Card  $��0��6"   .��5.      � $��	0 10 0 10q�6   .+�50      �� $��	35 5 15 5q�6   $��15(�62   $��25,0,0,0q�6@   $	��150��51      $��30��6'   $
��Left=�63    �� DisplayMemberPath$ StockOut_ID��52      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 出庫ID��55       & "MaterialDesignFloatingHintComboBox#��[ 56      ��53      �� *
StockOut+ �� SelectedItem 54      �� *SelectStockOut_Search+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�57      �� 5;      $��	209,0,0,0q�6   $��30,0,0,0q�62   $��15(�6E   $	��150��5<      $��30��6+   $
��Left=�67   $ status��5=      $ 状態��5@      #��[ 5A      ��5>      �� *Status+ 5?      �� *SelectStatus+$ TwoWay=�$ PropertyChanged=�5B      �� 5E      $��
379 5 15 5q�6   $��15(�63   $��25,0,0,0q�6A   $	��150��5F      $��30��6'   $
��Left=�63   $ LibretyName��5G      $ 図書館名��5J      #��[ 5K      ��5H      �� *	Libraty+ 5I      �� *SelectLibraty+$ TwoWay=�$ PropertyChanged=�5L      �� 5N      $��	0,0,160,0q�6   $	��100��60   ���#b0816f���#b0816f$��Right=�5O   
   ��6&   �� *SearchCommand+��6H   �� $ 
listoutput��.��6}   検索6�   �� 5P      $��0,0,35,0q�6   $	��100��6/   ���#b0816f���#b0816f$��Right=�5Q   
   ��6&   �� *Add_WindowCommand+��6L   �� $ 
listoutput��.��6�   戻る6�   5R      5S        5T      $��1��6"   $��	0 10 0 10q�6/   .��5U      �  � ColumnDefinitions 5V      �� 5W      $	��350 �6+   69   �� 5X      6-   .+�5Z      � $��0��6   .+�5[        $��20q�6/   $��Stretch=�6;   ���#F2F2F2.��5\      �� $
��Auto=�6+   $
��auto=�6N   .��5]   "   �� ��6+   �� *StockOutSearch+ 6R   �� *SelectItemList+$ OneWayToSource=� �� View 5^   &   �� 5_   *   .P�5`   .   �� $��出庫ID��6=    �� Width$
 auto��6K    �� DisplayMemberBinding 6Y   �� *StockOut_ID+6�   �� 5a   .   $��状態��6=   $
 auto��6I    6V   �� *Status_table.status+6�   �� 5b   .   $��日付��6=   $
 auto��6I    6V   �� *stockOut_Date+ �� StringFormat$ 
yyyy/MM/dd��6�   5c   +   5e   #   5f      5g      5h      � 5i      $��1��6   .+�5j        $��20q�6/   $��Stretch=�6;   ���#F2F2F2.��5k      �� $
��Auto=�6+   $
��auto=�6N   .��5l   "   �� ��6+   �� *StockOutDetail+ 5m   &   �� 5n   *   .P�5o   .   �� $��本ID��6=   $
 auto��6J    6X   �� *BookID+6�   �� 5p   .   $��タイトル��6=   $
 auto��6K    6X   �� *Book_table.Book_title+6�   �� 5q   .   $��数量��6=   $
 auto��6I    6V   �� *StockOut_Quantity+6�   5r   +   5t   #   5u      5v      5w      5x      5y      5z      � 5|   
   $��2��6   ���#99b9a4$��57��61   $��Bottom=�6=   5�      5�      