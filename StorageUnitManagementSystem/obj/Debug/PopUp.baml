   M S B A M L   `   `   `  ����  StorageUnitManagementSystem'    !StorageUnitManagementSystem.PopUp   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f9custom,http://metro.mahapps.com/winfx/xaml/controls  5        � Title$  PopUp��5	      $	��500��6   $	��400��6     � WindowStartupLocation$ CenterScreen=�6-      AccentBaseColorBrush(  "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   6R   $��2q�5
         ShowMaxRestoreButton .     RightWindowCommands 5      +  %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� $��About Us��6   5       � 	Resources 5        MetroTabItem �� BasedOn �� 
TargetType+  %MahApps.Metro.Controls.ControlsHelper �� Property	 �� Value��%o   '��       7  �� 5   
   8   " ��68   .�5      ��  �@ HeaderFontSize$	 20Q�6E   6R   5      5      .��5      � $	��400��6   .+�5   
   �� $��Update Details��6   $
��Bold"�6)   $��18(�6;   $��Center=�6I   $	��Top=�6f   $��0,0,0,50q�6~   6�   �� 5   
   $��LeaseID:��6   $��25��6#   $��32,0,0,395.4q�6/   $
��Left=�6E   $��80��6`   $��Bottom=�6k   �� 5   
   -   5        
 ��Name$
 LeaseIDTxtBox��5      $��20��6)   $��151,46,0,394.4q�65   $	��211��6M   $
��Left=�6Y   �� 5   
   $��
Client ID:��6   $��25��6%   $��32,87,277,354.4q�61   �� 5   
   -   5        $
 ClientIDTxtBox��5      $	��211��6*   $��20��66   $
��Left=�6B   $��151,86,0,354.4q�6]   �� 5   
   $��Name:��6   $��25��6    $��32,131,277,310.4q�6,   �� 5    
   -   5        $
 LeaseNameTxtBox��5       $	��211��6+   $��20��67   $
��Left=�6C   $��151,132,0,308.4q�6^   �� 5!   
   $��Surname:��6   $��25��6#   $��32,177,277,264.4q�6/   �� 5"   
   -   5        $
 LeaseSurnameTxtBox��5"      $��20��6.   $��151,177,0,263.4q�6:   $
��Left=�6S   $	��211��6n   �� 5#   
   $��Amount Owed:��6   $��25��6'   $��32,217,268,224.4q�63   �� 5$   
   -   5        $
 LeaseOwedTxtBox��5$      $	��211��6+   $��20��67   $
��Left=�6C   $��151,216,0,224.4q�6^   �� 5%   
   $��Amount Paid:��6   $��25��6'   $��32,263,277,178.4q�63   �� 5&   
   -   5        $
 LeasePaidTxtBox��5&      $	��211��6+   $��20��67   $
��Left=�6C   $��151,262,0,178.4q�6^   �� 5'   
   $��
Date Paid:��6   $��25��6%   $��32,304,291,137.4q�61   �� 5(   
   -   5        $
 LeaseDateTxtBox��5(      $	��211��6+   $��20��67   $
��Left=�6C   $��151,304,0,136.4q�6^   �� 5)   
   $��Unit Leased:��6   $��25��6'   $��32,361,277,80.4q�63   �� 5*   
   -   5        $
 LeaseUnitTxtBox��5*      $	��211��6+   $��20��67   $
��Left=�6C   $��151,361,0,79.4q�6^   �� 5+   
   -	   5         ��Name$ 	UpdateBtn��5+      $��Update��6$   $	��100��65   $��30��6A   $��149,404,140.6,32.4q�6M     AccentedSquareButtonStyle#��[ 6i   #���   6�   $��1q�6�      ContentCharacterCasing$ Normal=�6�   6  5,      5-      