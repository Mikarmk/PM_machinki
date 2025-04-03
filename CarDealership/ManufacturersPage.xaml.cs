using System;
using System.Windows;
using System.Windows.Controls;

namespace CarDealership
{
    public partial class ManufacturersPage : Page
    {
        private Manufacturer selectedManufacturer;

        public ManufacturersPage()
        {
            InitializeComponent();
            LoadManufacturers();
        }

        private void LoadManufacturers()
        {
            manufacturersDataGrid.ItemsSource = Database.Manufacturers;
        }

        private void manufacturersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedManufacturer = manufacturersDataGrid.SelectedItem as Manufacturer;
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool isManufacturerSelected = selectedManufacturer != null;
            deleteButton.IsEnabled = isManufacturerSelected;
            editButton.IsEnabled = isManufacturerSelected;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedManufacturer == null) return;

            MessageBoxResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить производителя {selectedManufacturer.Name}?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Database.Manufacturers.Remove(selectedManufacturer);
                selectedManufacturer = null;
                UpdateButtonsState();
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedManufacturer == null) return;

            var editWindow = new ManufacturerEditWindow(selectedManufacturer);
            if (editWindow.ShowDialog() == true)
            {
                manufacturersDataGrid.Items.Refresh();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Manufacturer newManufacturer = new Manufacturer
            {
                Id = Database.Manufacturers.Count > 0 ? Database.Manufacturers[Database.Manufacturers.Count - 1].Id + 1 : 1
            };

            var addWindow = new ManufacturerEditWindow(newManufacturer, true);
            if (addWindow.ShowDialog() == true)
            {
                Database.Manufacturers.Add(newManufacturer);
                manufacturersDataGrid.SelectedItem = newManufacturer;
            }
        }
    }
} 