   M S B A M L   `   `   `  ����G  COrganizer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Organizer.UI.ViewOrganizer.UI.View  5      (    "Organizer.UI.View.FriendDetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Organizer.UI.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��	FirstName��6   $��
10 10 10 0q�6$   �� 5   
   $��1��6   $��10 0 10 10 q�5   E   ��5      �� *Friend.FirstName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5   E   �� 5   
   $��2��6   $��LastName��6   $��	10 0 10 0q�60   �� 5   
   $��3��6   $��10 0 10 10 q�5   E   ��5      �� *Friend.LastName+$ TwoWay=�$ PropertyChanged=�5   E   �� 5   
   $��4��6   $��Email��6   $��	10 0 10 0q�6-   �� 5   
   $��5��6   $��10 0 10 10 q�5    E   ��5      �� *Friend.Email+ �� TargetNullValue$  ��$ TwoWay=�$ PropertyChanged=�5    E   �� 5"   
   $��6��6   $��Favorite Music��6   $
��10 0q�66   �� 5#   
   $��7��6    �� DisplayMemberPath$ DisplayMember��5$       �� SelectedValuePath$ Id��5%      $��
10 0 10 10q�5'      ��5#       �� *
MusicGenre+ �� SelectedValue 5&      �� *Friend.FavoriteMusicGenreId+$ TwoWay=�5'      ]� 5(   
   $��8��6   $��10q�6!   .+�5)      �� $��Right=�6   .+�5*      �� $	��Add��6   $	��125��6'   $��10q�63   ��5+      �� *AddPhoneNumberCommand+�� 5,      $��Remove��6   $	��125��6*   $��10q�66   ��5-      �� *RemovePhoneNumberCommand+5.      &   System.Windows.Controls.DataGrid  5/         AutoGenerateColumns .     RowHeaderWidth$ 0Q�51   3   ��5/      �� *PhoneNumbers+	 �� SelectedItem	 50      �� *SelectedPhoneNumber+$ TwoWay=�
   Columns
 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ Phone Number��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6?      DataGridColumnStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  54        DataGridEditingColumnStyle   EditingElementStyle# [ 55         Binding 56      �� *Number+$ TwoWay=�$ PropertyChanged=�58      59      �� 5:   
   $��9��6    �� Orientation$ 
Horizontal=�6"   .+�5;      �� $
��Save��6   $	��125��6$   $��10q�60   ��5<      �� *SaveCommand+�� 5=      $��Delete��6   $	��125��6&   $��10q�62   ��5>      �� *DeleteCommand+5?      5@      5A      