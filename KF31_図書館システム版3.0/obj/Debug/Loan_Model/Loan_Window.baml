   M S B A M L   `   `   `  ����[  WKF31_図書館システム版3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:KF31_図書館システム版3._0.Loan_Model,KF31_図書館システム版3._0.Loan_Model  5   	   w@clr-namespace:KF31_図書館システム版3._0.UserControl_KF312KF31_図書館システム版3._0.UserControl_KF31  5	   	   >    8KF31_図書館システム版3._0.Loan_Model.Loan_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:KF31_図書館システム版3._0.Loan_Model     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Iuc@clr-namespace:KF31_図書館システム版3._0.UserControl_KF31  5	   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      -   5        $
��Loan��5         MaterialDesignBody#���   5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5       � WindowStartupLocation$ CenterScreen=�5       � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5        LoanViewModel � DataContext# [ 5       � Title$ 貸出管理��5   	   $	��510��6   $	��800��6#   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   � $��0��6   ���#c7816f.+�5      J   DKF31_図書館システム版3._0.UserControl_KF31.Hamburger_Control  
 � Tag 6#   �� *Title+	 �� ElementName$
	 Loan��6L   5       � 5!   
   $��1��6   ���#F2F2F2.+�5"      �� $	��750��6   $	��350��6$   ���#E6E1DD$��Center=�6@   $��Center=�6]   �� 5#      $��予約処理��6   $
��Left=�6$   $	��116��6?   $��140,177,0,0q�6L   ���#b0816f���#4c6462���#F2F2F2$	��Top=�6�   $	��200��6�   $��40(�6�   ��5$      �� *LoanOrderCommand+��67   �� $
	 Loan���� 5%      $��貸出一覧��6   $��Center=�6$   $	��116��6A   $��250,177,0,0q�6N   ���#b0816f���#4c6462���#F2F2F2$	��Top=�6�   $	��200��6�   $��40(�6�   ��5&      �� *LoanListCommand+��66   �� $
	 Loan���� 5'      $��貸出管理��6   $
��Bold"�6#   $��Center=�65   $��0,29,0,0q�6R   $	��Top=�6d   $��40(�6|   ���#4C6462$��52��6�   $	��208��6�   5)      � 5*   
   $��2��6   $	��800��6   $��50��6(   $��Center=�65   $	��Top=�6R   ���#99b9a46j   5+      5,      