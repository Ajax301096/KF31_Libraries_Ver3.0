   M S B A M L   `   `   `  ����[  WKF31_図書館システム版3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:KF31_図書館システム版3._0.Output_Model.KF31_図書館システム版3._0.Output_Model  5   	   w@clr-namespace:KF31_図書館システム版3._0.UserControl_KF312KF31_図書館システム版3._0.UserControl_KF31  5	   	   B    <KF31_図書館システム版3._0.Output_Model.Output_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Nlocal<clr-namespace:KF31_図書館システム版3._0.Output_Model     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   Iuc@clr-namespace:KF31_図書館システム版3._0.UserControl_KF31  5	   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      -   5        $��Output_Main��5         MaterialDesignBody#���   5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5       � WindowStartupLocation$ CenterScreen=�5       � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5        OutPutViewModel � DataContext# [ 5       � Title$ 出庫管理画面��5   	   $	��510��6   $	��800��6%   .��5      � ���#F2F2F2$��Center=�6    $	��800��6=   .+�5   
   J   DKF31_図書館システム版3._0.UserControl_KF31.Hamburger_Control  
 � Tag 6   �� *Title+ �� ElementName$ Update_Employ��6Q   � 5!   
   ���#F0EBE7$��Center=�6$   $	��750��6A   $��	0,96,0,74q�6M   	 � ColumnDefinitions	 5"      �� 5#      $
��407* �6#   �� 5$      $	��12* �6#   �� 5%      $
��331* �6#   5'      � 5*   
   ���#99b9a4$��51��6$   $��	0,459,0,0q�60   �� 5-   
   $��登録��6   $��Center=�6   $	��105��6;   $��-450,240,0,0q�6H   ���#b0816f���#4c6462���#F2F2F2$	��Top=�6�   $	��115��6�   $��30(�6�   �� 5.   
   $��更新��6   $��Center=�6   $	��105��6;   $��	0,240,0,0q�6H   ���#b0816f���#4c6462���#F2F2F2$	��Top=�6�   $	��116��6�   $��30(�6�   �� 5/   
   $
��Left=�6   $	��105��6,   $��567,240,0,0q�69   ���#b0816f���#4c6462���#F2F2F2$	��Top=�6�   $	��115��6�   $��30(�6�   ��50      �� 51      
 �� TextAlignment$
 Center=�6   一覧�� 52      表示53      55      �� 57   
   $��出庫管理��6   $��Center=�6   $��	0,120,0,0q�6<   ���#4c6462$	��Top=�6d   $��50(�6|   $
��Bold"�6�   5:      5;      