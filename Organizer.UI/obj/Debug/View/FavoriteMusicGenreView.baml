   M S B A M L   `   `   `  ����G  COrganizer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Organizer.UI.ViewOrganizer.UI.View  5      .    (Organizer.UI.View.FavoriteMusicGenreView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Organizer.UI.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     RowHeaderWidth$ 0Q�5   -   $��10q�6@   ��5      �� *FavoriteMusicGenres+ �� SelectedItem 5      �� *SelectedFavoriteMusicGenre+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Favorite Music��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6=      DataGridColumnStyle1  +System.Windows.Controls.DataGridBoundColumn	   ElementStyle#	 [  5        DataGridEditingColumnStyle
   EditingElementStyle#
 [ 5         Binding 5      �� *Name+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��1��6   $��0 5 5 5q�6%   .+�5      �� $	��Add��6   $��5q�6B   $	��125��6M   ��6#   �� *
AddCommand+6M   �� 5      $��Remove��6   $��5q�6H   $	��125��6S   ��6&   �� *RemoveCommand+6S   5       �� 5"   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5#      �� $
��Save��6   $	��125��6$   $��10q�60   ��5$      �� *SaveCommand+5%      5&      5'      