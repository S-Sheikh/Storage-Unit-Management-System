   M S B A M L   `   `   `  ����   StorageUnitManagementSystem'    !StorageUnitManagementSystem.PopUp   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f9custom,http://metro.mahapps.com/winfx/xaml/controls    � Title$  PopUp��$	��500��$	��400�� � WindowStartupLocation$ CenterScreen=�   AccentBaseColorBrush(  "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   $��2q�   ShowMaxRestoreButton .     RightWindowCommands +  %MahApps.Metro.Controls.WindowCommands  .@��� $��About Us�� � 	Resources   MetroTabItem �� BasedOn �� 
TargetType+  %MahApps.Metro.Controls.ControlsHelper �� Property	 �� Value��%E   '��       7  �� 8   " ��.���  �@ HeaderFontSize$	 20Q�.��� $	��400��.+��� $��Update Details��$
��Bold"�$��18(�$��Center=�$	��Top=�$��0,0,0,50q��� $��LeaseID:��$��25��$��32,0,0,395.4q�$
��Left=�$��80��$��Bottom=��� -   
 ��Name$
 LeaseIDTxtBox��$��20��$��151,46,0,394.4q�$	��211��$
��Left=��� $��
Client ID:��$��25��$��32,87,277,354.4q��� -   $
 ClientIDTxtBox��$	��211��$��20��$
��Left=�$��151,86,0,354.4q��� $��Name:��$��25��$��32,131,277,310.4q��� -   $
 LeaseNameTxtBox��$	��211��$��20��$
��Left=�$��151,132,0,308.4q��� $��Surname:��$��25��$��32,177,277,264.4q��� -   $
 LeaseSurnameTxtBox��$��20��$��151,177,0,263.4q�$
��Left=�$	��211���� $��Amount Owed:��$��25��$��32,217,268,224.4q��� -   $
 LeaseOwedTxtBox��$	��211��$��20��$
��Left=�$��151,216,0,224.4q��� $��Amount Paid:��$��25��$��32,263,277,178.4q��� -   $
 LeasePaidTxtBox��$	��211��$��20��$
��Left=�$��151,262,0,178.4q��� $��
Date Paid:��$��25��$��32,304,291,137.4q��� -   $
 LeaseDateTxtBox��$	��211��$��20��$
��Left=�$��151,304,0,136.4q��� $��Unit Leased:��$��25��$��32,361,277,80.4q��� -   $
 LeaseUnitTxtBox��$	��211��$��20��$
��Left=�$��151,361,0,79.4q��� -	    ��Name$ 	UpdateBtn��$��Update��$	��100��$��30��$��149,404,140.6,32.4q�  AccentedSquareButtonStyle#��[ #���   $��1q�   ContentCharacterCasing$ Normal=�