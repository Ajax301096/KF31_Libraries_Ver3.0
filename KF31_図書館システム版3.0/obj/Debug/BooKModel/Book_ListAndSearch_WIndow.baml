   M S B A M L   `   `   `  ����[  WKF31_図書館システム版3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:KF31_図書館システム版3._0.BooKModel+KF31_図書館システム版3._0.BooKModel  5   	   w@clr-namespace:KF31_図書館システム版3._0.UserControl_KF312KF31_図書館システム版3._0.UserControl_KF31  5	   	   K    EKF31_図書館システム版3._0.BooKModel.Book_ListAndSearch_WIndow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Klocal9clr-namespace:KF31_図書館システム版3._0.BooKModel     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   Iuc@clr-namespace:KF31_図書館システム版3._0.UserControl_KF31  5	   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5        $��	list_book��5   	      MaterialDesignBody#���   5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     BookViewModel � DataContext# [ 5   	    � Title$ 	本一覧��5   	   $	��510��6   $	��800��6"   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedWindowCommand+   CommandParameter 5      ��  �� ElementName$ 	list_book��5      .��5      � ���#F2F2F2 � RowDefinitions 5    
   �� 5!      $
��auto �6   6,   �� 5"      $
��auto �6   6,   �� 5#      6   .+�5%   
   � $��0��6   ���#c7816f.+�5&      J   DKF31_図書館システム版3._0.UserControl_KF31.Hamburger_Control  
 � Tag 6#   �� *Title+$ 	list_book��6Q   5'      #  MaterialDesignThemes.Wpf.Card  5(   
   $��1��6   $��5q�6+   ���#F2F2F2.��5)      � $��	0 10 0 10q�6   .+�5*      �� $��	15 5 15 5q�6    �� DisplayMemberPath$ CategoryName��6.   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ カテゴリ��5+       �� 
IsEditable .  & "MaterialDesignFloatingHintComboBox#��[ 69   ��5*   O   �� *
Category+ �� SelectedItem 6p   �� *Selection_Category+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5+   x   �� 5-      $	��200��6   $��	15 5 15 5q�6f   $2 ,キーワードを入力してください !��6y    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6&   �� *	KeySearch+$ PropertyChanged=�6�   �� 5.      $��	20,10,0,0q�6   $	��100��6,   ���#b0816f���#b0816f��5/      �� *BookSearchCommand+��6>   �� $ 	list_book��.��50      '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ DatabaseSearch=�6.   51      �� 52      $��
250,10,0,0q�6   ���#b0816f���#b0816f$��90��6X   $��35��6c   $��16(�6o   $
��Left=�6}   $��戻る��6�   ��53      �� *BackBookCommand+��6=   �� $ 	list_book��55      56        57   
   $��2��6   $��5q�6+   $��Stretch=�66   ���#F2F2F2.��58      �� $
��Auto=�6   $
��auto=�6>   .��59      �� ��6   �� *	BooksList+ 6=   �� *SelectedItem+$ OneWayToSource=� �� View 5:      �� 5;      .P�5<      �� $��本ID��6-    �� Width$
 auto��6:    �� DisplayMemberBinding 6H   �� *BookID+6r   �� 5=      $��タイトル��6-   $
 auto��6;    6H   �� *
Book_title+6v   �� 5>      $��カテゴリ��6-   $
 auto��6;    6H   �� *Category_table.CategoryName+6�   �� 5?      $��著者��6-   $
 auto��69    6F   �� *Book_Author+6u   �� 5@      $��	出版社��6-   $
 auto��6:    6G   �� *Publisher_table.PublisherName+6�   5A      5C      5D      5E      5I      5J      