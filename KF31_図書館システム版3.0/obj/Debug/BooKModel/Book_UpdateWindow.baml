   M S B A M L   `   `   `  ����[  WKF31_図書館システム版3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:KF31_図書館システム版3._0.BooKModel+KF31_図書館システム版3._0.BooKModel  5   	   w@clr-namespace:KF31_図書館システム版3._0.UserControl_KF312KF31_図書館システム版3._0.UserControl_KF31  5   	   C    =KF31_図書館システム版3._0.BooKModel.Book_UpdateWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Klocal9clr-namespace:KF31_図書館システム版3._0.BooKModel     5   	   Ouc@clr-namespace:KF31_図書館システム版3._0.UserControl_KF31     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5        $��update_book��5   	      MaterialDesignBody#���   5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     BookViewModel � DataContext# [ 5   
    � Title$ 本情報更新��5   	   $	��510��6   $	��800��6$   .��5      � .+�5   
   � ���#F2F2F2$��Center=�6$   $	��800��6A   6O   � 5   
   ���#F0EBE7$��Center=�6$   $	��750��6A   $��
0,110,0,45q�6M   J   DKF31_図書館システム版3._0.UserControl_KF31.Hamburger_Control  5"   
   
 � Tag 6   �� *Title+ �� ElementName$ update_book��6O   �� 5%   
   	 �� Padding$	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6P   $��35��6k   $��
63,173,0,0q�6w   $
��Wrap=�6�   $�� 本ID��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 5&   
   $
��Left=�6   ���#eee$��263,173,0,0q�6@   $	��Top=�6U   $	��168��6m   $��39��6y   
 �� DisplayMemberPath$
 BookID��5'      ��63   �� *Books+ �� SelectedItem 6Q   �� *Selection_Book+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5*   
   $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6P   $��35��6k   $��
63,209,0,0q�6w   $
��Wrap=�6�   $�� タイトル��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 5+   
   $��0��6   ���#2a3837���#eee$
��Left=�6F   $��34��6a   $��263,212,0,0q�6m    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��201��6�   $��14(�6�   ��5,      �� *Title+$ PropertyChanged=�6U   �� 50   
   $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6P   $��36��6k   $��
63,245,0,0q�6w   $
��Wrap=�6�   $��カテゴリ��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 51   
   $
��Left=�6   ���#eee$��263,246,0,0q�6@   $	��Top=�6U   $	��168��6m   $��40��6y   $
 CategoryName��52      ��69   �� *
Category+ 6Z   �� *Selection_Category+$ TwoWay=�$ PropertyChanged=��� 54   
   $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6P   $��35��6k   $��
63,282,0,0q�6w   $
��Wrap=�6�   $�� 著者��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 55   
   $��0��6   ���#2a3837���#eee$��Center=�6F   $��30��6c   $��	0,288,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��275��6�   $��14(�6�   ��56      �� *Author+$ PropertyChanged=�6V   �� 59   
   $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6P   $��35��6k   $��
63,318,0,0q�6w   $
��Wrap=�6�   $��
 出版社��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 5:   
   $
��Left=�6   ���#eee$��263,320,0,0q�6@   $	��Top=�6U   $	��168��6m   $��40��6y   $
 PublisherID��5;      ��61   �� *	Publisher+ 6S   �� *Selection_Publisher+$ TwoWay=�$ PropertyChanged=��� 5>   
   $��更新��6   $
��Left=�6   $��28(�69   $��522,387,0,0q�6G   $	��Top=�6\   $	��117��6t   ���#b0816f���#4c6462���#F2F2F2$��56��6�   ��5?      �� *BookUpdateCommand+��6;   �� $ update_book��5A      5B      