   M S B A M L   `   `   `  ����  CarDealership    CarDealership.OrdersPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .��5      �   � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ordersDataGrid��5
      $��0��6+      AutoGenerateColumns$ False��68      
IsReadOnly$
 True��5         SelectionMode$ Single=�6%      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $ ID Автомобиля��6%   $	 100 6V    6<   �� *CarId+6V     5      $ ID Клиента��6%   $	 100 6V    69   �� *
ClientId+6V     5      $ ID Сотрудника��6%   $	 100 6[    6<   �� *
EmployeeId+6[     5      $ Дата заказа��6%   $	 120 6y    6:   �� *	OrderDate+	 �� StringFormat$	 {0:dd.MM.yyyy}��6y     5      $ 
Сумма��6%   $	 100 6m    64   �� *TotalAmount+$	 {0:N2}��6m     5      $ Статус��6%   $ * 6P    65   �� *Status+6P   5      �� 5   
   $��1��6   
 �� Orientation$
 
Horizontal=�6"   $��Center=�6;   $��	0,10,0,10q�6X   .+�5      �� -   5         ��Name$ 
exitButton��5      $��
Выйти��6)   $	��100��69   $��5q�6E   6P   �� 5      -   5        $ deleteButton��5      $��Удалить��6+   $	��100��6=   $��5q�6I   6T   �� 5      -   5        $ 
editButton��5      $��Изменить��6)   $	��100��6<   $��5q�6H   6S   �� 5      -   5        $ 	addButton��5      $��Добавить��6(   $	��100��6;   $��5q�6G   6R   5      5      5      