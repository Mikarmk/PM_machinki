   M S B A M L   `   `   `  ����  CarDealership    CarDealership.CarsPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .��5      �   � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ carsDataGrid��5
      $��0��6)      AutoGenerateColumns$ False��66      
IsReadOnly$
 True��5         SelectionMode$ Single=�6%      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $ 
Марка��6%   $	 100 6N    64   �� *Brand+6N     5      $ Модель��6%   $	 120 6O    65   �� *Model+6O     5      $ Год��6%   $ 70 6K    62   �� *Year+6K     5      $ Цвет��6%   $ 80 6M    63   �� *Color+6M     5      $ Цена��6%   $	 100 6f    63   �� *Price+	 �� StringFormat$	 {0:N2}��6f     5      $ № Заказа��6%   $ 80 6W    67   �� *OrderNumber+6W     5      $# ID Производителя��6%   $	 120 6b    6?   �� *ManufacturerId+6b   5      �� 5   
   $��1��6   
 �� Orientation$
 
Horizontal=�6"   $��Center=�6;   $��	0,10,0,10q�6X   .+�5      �� -   5         ��Name$ 
exitButton��5      $��
Выйти��6)   $	��100��69   $��5q�6E   6P   �� 5      -   5        $ deleteButton��5      $��Удалить��6+   $	��100��6=   $��5q�6I   6T   �� 5      -   5        $ 
editButton��5      $��Изменить��6)   $	��100��6<   $��5q�6H   6S   �� 5      -   5        $ 	addButton��5      $��Добавить��6(   $	��100��6;   $��5q�6G   6R   5      5      5      