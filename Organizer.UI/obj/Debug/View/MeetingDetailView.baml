   M S B A M L   `   `   `  ����G  COrganizer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Organizer.UI.ViewOrganizer.UI.View  5      J FOrganizer.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:Organizer.Model;assembly=Organizer.ModelOrganizer.Model 5      )    #Organizer.UI.View.MeetingDetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Organizer.UI.View     5      Hmodel6clr-namespace:Organizer.Model;assembly=Organizer.Model     5      X TXceed.Wpf.Toolkit, Version=3.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Title��6   $��
10 10 10 0q�6    �� 5   
   $��1��6   $��
10 0 10 10q�6o   ��6   �� *Meeting.Title+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6o   �� 5   
   $��2��6   $��Start��6   $
��10 0q�6-   &   Xceed.Wpf.Toolkit.DateTimePicker  5   
   $��3��6!   $��
10 0 10 10q�6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 6.   �� *Meeting.DateFrom+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��4��6   $	��End��6   $
��10 0q�6+     5   
   $��5��6!   $��
10 0 10 10q�6�    6.   �� *Meeting.DateTo+$ TwoWay=�$ PropertyChanged=�6�   � 5   
   $��6��6   $��10q�6    � 	Resources 5       �� DataType  Organizer.Model.Friend��%�   (��       5       *, +)�� 6   "  6   .R�5!      �� �� 6!   �6%   �� *	FirstName+ �� 6C   �6G   �� *
LastName+6d   5"      5#       � ColumnDefinitions 5$      �� 5%      �� 5&      $
��Auto �6#   �� 5'        5)      �� 5*      $
��Auto �6    �� 5+      .+�5.      �� $��Added Friends��6   �� 5/      $��1��6   ��6$   �� *AddedFriends+ �� SelectedItem 50      �� *SelectedAddedFriend+�� 52      $��1��6   $��1��6&   .+�53      �� $��<<��6   $��10q�6,   ��68   �� *AddFriendCommand+�� 54      $��>>��6   $��
10 0 10 10q�6,   ��6@   �� *RemoveFriendCommand+55      �� 57      $��Available Friends��6   $��2��60   �� 58      $��1��6   $��2��59   B   ��58   $   �� *AvailableFriends+ 59      �� *SelectedAvailableFriend+6B   5:      �� 5;   
   $��7��6    �� Orientation$ 
Horizontal=�6"   .+�5<      �� $
��Save��6   $��75��6$   $��10q�60   ��6<   �� *SaveCommand+�� 5=      $��Delete��6   $��75��6&   $��10q�62   ��6>   �� *DeleteCommand+5>      5?      5@      