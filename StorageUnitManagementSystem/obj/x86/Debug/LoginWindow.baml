   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   V RStorageUnitManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:StorageUnitManagementSystemStorageUnitManagementSystem 5   	   -   'StorageUnitManagementSystem.LoginWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   ;local)clr-namespace:StorageUnitManagementSystem     5   	     � Title$  Login��5	   	   $	��600��6   $	��800��6$   (   "MahApps.Metro.Controls.MetroWindow   ShowMaxRestoreButton .   � WindowStartupLocation$ CenterScreen=�6N      AccentBaseColorBrush   	GlowBrush# �   5
      $��2q�5      .��5      � -   5        $��gdMain��5       � ColumnDefinitions 5   
   �� 5      $	��38* �6   �� 5      $
��197* �6   �� 5      $	��29* �6    � RowDefinitions 5   
   �� 5      $
��132* �6   �� 5      $	��54* �6   �� 5      $
��383* �6   .+�5   
   �� 
���   �$��2q�6%   $��13,25,107,0q�69   $	��266��6N   $	��Top=�6[   $��2��6s   $��1��6�   ._�5      � $��	-1,1,1,-1q�6    5      �� 5      $
��146* �6'   �� 5      $
��321* �6'    5      �� 5      $	��58* �6$   �� 5       $	��49* �6$   �� 5!      $	��55* �6$   �� 5"      $	��54* �6$   �� 5#      $	��48* �6$   .+�5%      �� -   5         ��Name$ label��5%      $��Login ��6'   $��44��68   $
��Left=�6C   $��
113,22,0,0q�6^   $	��Top=�6r   $
��Bold"�6�   $��1��6�   $��26��6�   �� 5&      -   5        $ label1��5&      $��	Username:��6(   $��	0,10,11,0q�6<   $��1��6O   $	��Top=�6\   $��26��6t   $��Right=�6�   $��66��6�   �� 5'      -   5        $ label2��5'      $��	Password:��6(   $��	0,10,10,0q�6<   $��2��6O   $	��Top=�6\   $��26��6t   $��Right=�6�   $��62��6�   �� 5(      -   5         ��Name$ textBox��5(      $��1��6+   $��23��6;   $��	10,10,0,0q�6G   $��1��6Z    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $
��Left=�6�   $	��301��6�   �� 5)      -   5        $ textBox1��5)      $��1��6,   $��23��6<   $��	10,10,0,0q�6H   $��2��6[   $
 Wrap=�6h   $	��Top=�6|   $
��Left=�6�   $	��301��6�   �� 5*      -   5        	 ��Name$	 btnLogin��5*      $��Login��6+   $��1��6;   $
��Left=�6K   $��	63,10,0,0q�6f   $��3��6y   $	��Top=�6�   $	��117��6�   $��20��6�   �� 5+      -   5        
 ��Name$
 	textBlock��5+      $��1��6/   $��Right=�6?   $��
0,22,102,0q�6[   $��4��6o   $
��Wrap=�6|   $	��Top=�6�   $��16��6�   $
��Auto��6�   �� 5,      -	   5        $��www.google.com?�5,       .�6b   
register5.      5/      �� 50      -
   5        $
 
textBlock1��50      $��87��60   $��1��6;   $��	0,22,10,0q�6K   $��4��6^   $
��Wrap=�6k   $	��Top=�6   $��Right=�6�   $��16��6�   �� 51      -   5        $��www.google.com?�51       .�6h   forgot password53      54      56      57      �� 58   
   -   5        $ label3��58      $$��Storage Unit Management System��6    $��83,10,177,0q�6I   $��1��6^   $	��Top=�6k   $��20(�6�   $
��Bold"�6�   $��1��6�   $��37��6�   $	��331��6�   $��Center=�6�   5:      5;      