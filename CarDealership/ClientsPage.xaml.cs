using System;
using System.Windows;
using System.Windows.Controls;

namespace CarDealership
{
    public partial class ClientsPage : Page
    {
        private Client selectedClient;

        public ClientsPage()
        {
            InitializeComponent();
            LoadClients();
        }

        private void LoadClients()
        {
            clientsDataGrid.ItemsSource = Database.Clients;
        }

        private void clientsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedClient = clientsDataGrid.SelectedItem as Client;
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool isClientSelected = selectedClient != null;
            deleteButton.IsEnabled = isClientSelected;
            editButton.IsEnabled = isClientSelected;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClient == null) return;

            MessageBoxResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить клиента {selectedClient.FullName}?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Database.Clients.Remove(selectedClient);
                selectedClient = null;
                UpdateButtonsState();
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClient == null) return;

            var editWindow = new ClientEditWindow(selectedClient);
            if (editWindow.ShowDialog() == true)
            {
                clientsDataGrid.Items.Refresh();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Client newClient = new Client
            {
                Id = Database.Clients.Count > 0 ? Database.Clients[Database.Clients.Count - 1].Id + 1 : 1
            };

            var addWindow = new ClientEditWindow(newClient, true);
            if (addWindow.ShowDialog() == true)
            {
                Database.Clients.Add(newClient);
                clientsDataGrid.SelectedItem = newClient;
            }
        }
    }
} 