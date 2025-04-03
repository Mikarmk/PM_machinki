using System;
using System.Windows;
using System.Windows.Controls;

namespace CarDealership
{
    public partial class OrdersPage : Page
    {
        private Order selectedOrder;

        public OrdersPage()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            ordersDataGrid.ItemsSource = Database.Orders;
        }

        private void ordersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedOrder = ordersDataGrid.SelectedItem as Order;
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool isOrderSelected = selectedOrder != null;
            deleteButton.IsEnabled = isOrderSelected;
            editButton.IsEnabled = isOrderSelected;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOrder == null) return;

            MessageBoxResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить заказ №{selectedOrder.Id}?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Database.Orders.Remove(selectedOrder);
                selectedOrder = null;
                UpdateButtonsState();
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOrder == null) return;

            var editWindow = new OrderEditWindow(selectedOrder);
            if (editWindow.ShowDialog() == true)
            {
                ordersDataGrid.Items.Refresh();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Order newOrder = new Order
            {
                Id = Database.Orders.Count > 0 ? Database.Orders[Database.Orders.Count - 1].Id + 1 : 1,
                OrderDate = DateTime.Now
            };

            var addWindow = new OrderEditWindow(newOrder, true);
            if (addWindow.ShowDialog() == true)
            {
                Database.Orders.Add(newOrder);
                ordersDataGrid.SelectedItem = newOrder;
            }
        }
    }
} 