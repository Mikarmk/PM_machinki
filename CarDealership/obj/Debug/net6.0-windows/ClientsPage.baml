   M S B A M L   `   `   `  ����  CarDealership    CarDealership.ClientsPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .��5      �   � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ clientsDataGrid��5
      $��0��6,      AutoGenerateColumns$ False��69      
IsReadOnly$
 True��5         SelectionMode$ Single=�6%      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $ ФИО��6%   $	 150 6O    62   �� *
FullName+6O     5      $ Телефон��6%   $	 120 6P    66   �� *Phone+6P     5      $ Email��6%   $	 150 6N    64   �� *Email+6N     5      $ 
Адрес��6%   $ * 6P    64   �� *	Address+6P   5      �� 5   
   $��1��6   	 �� Orientation$	 
Horizontal=�6"   $��Center=�6;   $��	0,10,0,10q�6X   .+�5      �� -   5        
 ��Name$
 
exitButton��5      $��
Выйти��6)   $	��100��69   $��5q�6E   6P   �� 5      -   5        $
 deleteButton��5      $��Удалить��6+   $	��100��6=   $��5q�6I   6T   �� 5      -   5        $
 
editButton��5      $��Изменить��6)   $	��100��6<   $��5q�6H   6S   �� 5      -   5        $
 	addButton��5      $��Добавить��6(   $	��100��6;   $��5q�6G   6R   5      5      5      