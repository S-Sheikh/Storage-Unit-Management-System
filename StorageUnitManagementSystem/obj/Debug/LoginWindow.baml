   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    StorageUnitManagementSystem-   'StorageUnitManagementSystem.LoginWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	      CleanCloseWindowButtonStyle(   "MahApps.Metro.Controls.MetroWindow    WindowCloseButtonStyle#  �   5   	    � Title$ Login��5	   	   $	��600��6   $	��800��6$      ShowMaxRestoreButton .   � WindowStartupLocation$ CenterScreen=�6N     AccentBaseColorBrush   	GlowBrush# �  5
      $��2q�5      .��5      � -   5        $��gdMain��5       � ColumnDefinitions 5   
   �� 5      $	��38* �6   �� 5      $
��197* �6   �� 5      $	��29* �6    � RowDefinitions 5   
   �� 5      $
��132* �6   �� 5      $	��54* �6   �� 5      $
��383* �6   .+�5   
   �� -   5         ��Name$ label3��5      $$��Storage Unit Management System��6    $��113.4,108,145.2,0q�6I   $	��Top=�6d   $��20(�6|   $
��Bold"�6�   $��1��6�   $��37��6�   $	��331��6�   $��Center=�6�   $��2��6�   � 5   
   $��65.4,34.8,59.2,139.4q�6   $��1��6-   $��2��6=   $��1��6N    5      �� 5      $
��146* �6#   �� 5      $
��321* �6#    5      �� 5      $	��58* �6    �� 5       $	��49* �6    �� 5!      $	��55* �6    �� 5"      $	��54* �6    �� 5#      $	��48* �6    .+�5%      �� -   5        $ label��5%      $��Login ��6#   $��57��64   $
��Left=�6?   $��53.4,22,0,0q�6Z   $	��Top=�6o   $
��Bold"�6�   $��1��6�   $��14(�6�   �� 5&      -   5        $ label1��5&      $��	Username:��6$   $��0,9.4,45.6,0q�68   $��1��6N   $	��Top=�6[   $��26��6s   $��Right=�6   $��66��6�   �� 5'      -   5        $ label2��5'      $��	Password:��6$   $��0,9.4,44.6,0q�68   $��2��6N   $	��Top=�6[   $��27��6s   $��Right=�6   $��62��6�   �� 5(      -   5         ��Name$ textBox��5(      $��23��6'   $��120,9.4,0,0q�63   $��1��6H   	 �� TextWrapping$
	 Wrap=�6U   $	��Top=�6i   $
��Left=�6�   $	��301��6�   $��2��6�   G� 5)      -   5        
 G�Name$
 textBox1��5)       G� PasswordChar$ *��6,   $��	ExtraBold"�6=   $��23��6U   $��120,9.4,0,0q�6a   $��2��6v   $	��Top=�6�   $
��Left=�6�   $	��301��6�   $��2��6�   �� 5*      -   5         ��Name$ btnLogin��5*        AccentedSquareButtonStyle#��[ 6'   #���  6[   $��1q�6�   $��Login��6�   $��1��6�   $
��Left=�6�   $��28.4,10,0,0q�6�   $��3��6�   $	��Top=�6  $	��117��6   �� 	IsDefault . +   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Normal=�6M  �� 5,      #���  6   $��2q�6K   $��-4,-6,-0.2,0q�6`   $	��266��6v   $	��Top=�6�   $��2��6�   $��5��6�   5.      50      51      