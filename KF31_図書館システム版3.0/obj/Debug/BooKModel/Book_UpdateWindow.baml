   M S B A M L   `   `   `  ����[  WKF31_図書館システム版3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:KF31_図書館システム版3._0.BooKModel+KF31_図書館システム版3._0.BooKModel  5   	   w@clr-namespace:KF31_図書館システム版3._0.UserControl_KF312KF31_図書館システム版3._0.UserControl_KF31  5   	   C    =KF31_図書館システム版3._0.BooKModel.Book_UpdateWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Klocal9clr-namespace:KF31_図書館システム版3._0.BooKModel     5   	   Ouc@clr-namespace:KF31_図書館システム版3._0.UserControl_KF31     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5        $��update_book��5   	      MaterialDesignBody#���   5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     BookViewModel � DataContext# [ 5   
    � Title$ 本情報更新��5   	   $	��510��6   $	��800��6$   .��5      � .+�5   
   � ���#F2F2F2$��Center=�6$   $	��800��6A   6O   � 5   
   ���#e6e1dd$��Center=�6$   $	��750��6A   $	��350��6M   $��	0,50,0,45q�6Z   J   DKF31_図書館システム版3._0.UserControl_KF31.Hamburger_Control  5"   
   
 � Tag 6   �� *Title+ �� ElementName$ update_book��6O   � 5$   
   $��0��6   .+�5%      �� $��	本更新��6   ���#4c6462$��36(�68   $
��Bold"�6F   $��Center=�6X   $	��Top=�6u   $��	0,100,0,0q�6�   6�   5&      �� 5)   
   	 �� Padding$	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6P   $��35��6k   $��
63,172,0,0q�6w   $
��Wrap=�6�   $�� 本ID��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 5*   
   $
��Left=�6   ���#eee$��263,173,0,0q�6@   $	��Top=�6U   $	��168��6m   $��35��6y   
 �� DisplayMemberPath$
 BookID��5+      ��61   �� *Books+ �� SelectedItem 6O   �� *Selection_Book+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5.   
   $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6P   $��35��6k   $��
63,210,0,0q�6w   $
��Wrap=�6�   $�� タイトル��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 5/   
   $��0��6   ���#2a3837���#eee$
��Left=�6F   $��34��6a   $��263,212,0,0q�6m    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��201��6�   $��14(�6�   ��50      �� *Title+$ PropertyChanged=�6S   �� 54   
   $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6P   $��35��6k   $��
63,248,0,0q�6w   $
��Wrap=�6�   $��カテゴリ��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 55   
   $
��Left=�6   ���#eee$��263,249,0,0q�6@   $	��Top=�6U   $	��168��6m   $��35��6y   $
 CategoryName��56      ��67   �� *
Category+ 6X   �� *Selection_Category+$ TwoWay=�$ PropertyChanged=��� 58   
   $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6P   $��35��6k   $��
63,287,0,0q�6w   $
��Wrap=�6�   $�� 著者��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 59   
   $��0��6   ���#2a3837���#eee$��Center=�6F   $��35��6c   $��	0,288,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��276��6�   $��14(�6�   ��5:      �� *Author+$ PropertyChanged=�6U   �� 5=   
   $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6P   $��35��6k   $��
63,325,0,0q�6w   $
��Wrap=�6�   $��
 出版社��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 5>   
   $
��Left=�6   ���#eee$��263,326,0,0q�6@   $	��Top=�6U   $	��168��6m   $��35��6y   $
 PublisherID��5?      ��6/   �� *	Publisher+ 6Q   �� *Selection_Publisher+$ TwoWay=�$ PropertyChanged=��� 5B   
   $��更新��6   $
��Left=�6   $��17(�6:   $��520,373,0,0q�6H   $	��Top=�6]   $��90��6u   $��40��6�   ���#b0816f���#b0816f��5C      �� *BookUpdateCommand+��69   �� $ update_book���� 5E   
   $��630,373,0,97q�6   ���#b0816f���#b0816f$��90��6R   $��40��6]   $��16(�6i   $
��Left=�6w   $��戻る��6�   ��5F      �� *BackBookCommand+��65   �� $ update_book��� 5I   
   $��2��6   ���#99b9a4$��57��61   $��Bottom=�6=   5K      5L      