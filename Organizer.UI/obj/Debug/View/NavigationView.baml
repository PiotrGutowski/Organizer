   M S B A M L   `   `   `  ����G  COrganizer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Organizer.UI.ViewOrganizer.UI.View  5      &     Organizer.UI.View.NavigationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Organizer.UI.View     5        � 	Resources  5	         NavigationContainerStyle �� 
TargetType �� Property �� Value  NaviItemTemplate �� 
TargetType �Name �� Triggers P� Property P� Value��%  &	        &	 m     �� 5
   
   " ��61   .�5      ��  � ��$
 Left=�64   �� 5       � ��$ 2q�6'   5      �� 5   
   .R�5      �� $��16(�5      ��5      �� *DisplayMember+��5      �� *OpenDetailViewCommand+��5      �� 5      " ��6&   .R�5      � $
 grid��6   .+�5      �� #��z��6/   #��z��5   N   5       5      P� 5       �@J�IsMouseOver . . �5   "   ��  �@�Cursor$
 Hand��6;   �� 5   "    � ��$
 Bold"�6?   5      P� 5       � �� . . �5   "   ��  � ��$ Normal"�6?   5      5!      5#      5$      5%      .��5&      � 	 � RowDefinitions	 5'   
   �� 5(      $	��300 �6   �� 5)      .+�5+   
   �� $��Friends��6   .��5,   
   �� $
��Auto=�6   $
��Auto=�5-      .��5.      �� #��[  5/      #��[ 50      $��10q�51      ��5.      �� *	Friends+51      52      53      �� 54   
   $��Meetings��6   $��1��6%   .��55      �� $
��Auto=�6   $
��Auto=�56      .��57      �� #��[  58      #��[ 59      $��10q�5:      ��57      �� *
Meetings+5:      5;      5<      5=      5>      