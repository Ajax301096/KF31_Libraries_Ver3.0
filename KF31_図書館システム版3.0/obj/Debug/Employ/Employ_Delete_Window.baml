   M S B A M L   `   `   `  ����[  WKF31_図書館システム版3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:KF31_図書館システム版3._0.Employ(KF31_図書館システム版3._0.Employ  5   	   w@clr-namespace:KF31_図書館システム版3._0.UserControl_KF312KF31_図書館システム版3._0.UserControl_KF31  5	   	   C    =KF31_図書館システム版3._0.Employ.Employ_Delete_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:KF31_図書館システム版3._0.Employ     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   Iuc@clr-namespace:KF31_図書館システム版3._0.UserControl_KF31  5	   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      -   5        $��delete_employ��5         MaterialDesignBody#���   5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5       � WindowStartupLocation$ CenterScreen=�5       � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5        EmployViewModel � DataContext# [ 5       � Title$ 社員更新��5   	   $	��510��6   $	��800��6#   .��5      � .+�5   
   � ���#F2F2F2$��Center=�6$   $	��800��6A   .+�5      � ���#F0EBE7$��Center=�6(   $	��750��6E   $��
0,110,0,67q�6Q   � 5      .+�5!      J   DKF31_図書館システム版3._0.UserControl_KF31.Hamburger_Control  
 � Tag 6'   �� *Title+ �� ElementName$ delete_employ��6Y   5"      � 5&      ���#99b9a4$��51��6(   $��	0,459,0,0q�64   �� 5)      $��社員削除��6   $��Center=�6#   $��	0,120,0,0q�6@   ���#4c6462$	��Top=�6h   $��40(�6�   $
��Bold"�6�   �� 5-      	 �� Padding$	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6T   $��35��6o   $��
63,173,0,0q�6{   $
��Wrap=�6�   $��	 社員ID��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 5.      $
��Left=�6   ���#eee$��263,173,0,0q�6D   $	��Top=�6Y   $	��168��6q   $��39��6}   
 �� DisplayMemberPath$
 EmployID��5/      ��65   �� *	Employs+ �� SelectedItem 6U   �� *Select_EmID+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 52      $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6T   $��35��6o   $��
63,209,0,0q�6{   $
��Wrap=�6�   $��
 社員名��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 53      ���#2a3837���#eee$
��Left=�6@   $��34��6[   $��263,212,0,0q�6g   $
��Wrap=�6|   $	��Top=�6�   $	��201��6�   $��14(�6�   $	 	20,10,0,0q�54      ��6*   �� *Em_DisplayName+$ PropertyChanged=�6q   �� 58      $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6T   $��36��6o   $��
63,245,0,0q�6{   $
��Wrap=�6�   $��
 メール��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 59      ���#2a3837���#eee$
��Left=�6@   $��31��6[   $��263,246,0,0q�6g   $
��Wrap=�6|   $	��Top=�6�   $	��296��6�   $��14(�6�   $	 	20,10,0,0q�5:      ��6*   �� *
Em_Email+$ PropertyChanged=�6k   �� 5=      $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6T   $��35��6o   $��
63,282,0,0q�6{   $
��Wrap=�6�   $�� 入社年月日��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   (  "System.Windows.Controls.DatePicker  5>      {�.  $��7��6+   $
��Left=�68   $��30��6S   $	��Top=�6`   $	��132��6x   $��	20,10,0,0q�5?      $��263,284,0,0q�6k      SelectedDate 6!   �� *Em_Hiredate+$ PropertyChanged=�6k   �� 5B      $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6T   $��35��6o   $��
63,318,0,0q�6{   $
��Wrap=�6�   $�� 住所��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 5C      ���#2a3837���#f2f2f2$
��Left=�6C   $��35��6^   $��263,318,0,0q�6j   $
��Wrap=�6   $	��Top=�6�   $	��401��6�   $��14(�6�   $	 	20,10,0,0q�5D      ��6,   �� *
Em_Address+$ PropertyChanged=�6o   �� 5G      $	 0,5,0,0q�6   ���#2a3837���#cad2c5$
��Left=�6T   $��35��6o   $��
63,354,0,0q�6{   $
��Wrap=�6�   $�� 役職��6�   $	��Top=�6�   $	��200��6�   $��23(�6�   $
��Bold"�6�   �� 5H      $
��Left=�6   ���#eee$��263,354,0,0q�6D   $	��Top=�6Y   $	��160��6q   $��35��6}   $��20,0,0,0q�5I      {�.  $
 possitionName��66   ��6X   �� *
Possitions+ 6{   �� *Select_Possition+$ TwoWay=�$ PropertyChanged=��� 5L      $��削除��6   $
��Left=�6"   $��28(�6=   $��522,387,0,0q�6K   $	��Top=�6`   $	��117��6x   ���#b0816f���#4c6462���#F2F2F2$��56��6�   ��5M      �� *Delete_Command+�� 5P      $��戻る��6   $
��Left=�6"   $��28(�6=   $��656,387,0,0q�6K   $	��Top=�6`   $	��117��6x   ���#b0816f���#b0816f$��56��6�   ��5Q      �� *BackEmployCommand+��5R      �� $ delete_employ��5X      5Y      5[      