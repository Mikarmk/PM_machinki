using System;
using System.Windows;
using System.Windows.Controls;

namespace CarDealership
{
    public partial class CarsPage : Page
    {
        private Car selectedCar;

        public CarsPage()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            carsDataGrid.ItemsSource = Database.Cars;
        }

        private void carsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCar = carsDataGrid.SelectedItem as Car;
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool isCarSelected = selectedCar != null;
            deleteButton.IsEnabled = isCarSelected;
            editButton.IsEnabled = isCarSelected;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCar == null) return;

            MessageBoxResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить автомобиль {selectedCar.Brand} {selectedCar.Model}?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Database.Cars.Remove(selectedCar);
                selectedCar = null;
                UpdateButtonsState();
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCar == null) return;

            CarEditWindow editWindow = new CarEditWindow(selectedCar);
            if (editWindow.ShowDialog() == true)
            {
                // Обновление произойдет автоматически, так как используется ObservableCollection
                carsDataGrid.Items.Refresh();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Car newCar = new Car
            {
                Id = Database.Cars.Count > 0 ? Database.Cars[Database.Cars.Count - 1].Id + 1 : 1,
                Year = DateTime.Now.Year
            };

            CarEditWindow addWindow = new CarEditWindow(newCar, true);
            if (addWindow.ShowDialog() == true)
            {
                Database.Cars.Add(newCar);
                carsDataGrid.SelectedItem = newCar;
            }
        }
    }
} 