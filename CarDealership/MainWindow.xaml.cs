using System;
using System.Windows;
using System.Windows.Controls;

namespace CarDealership
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // По умолчанию показываем страницу с автомобилями
            ShowCarsPage();
        }

        private void ShowCarsPage()
        {
            mainFrame.Navigate(new CarsPage());
        }

        private void ShowClientsPage()
        {
            mainFrame.Navigate(new ClientsPage());
        }

        private void ShowEmployeesPage()
        {
            mainFrame.Navigate(new EmployeesPage());
        }

        private void ShowManufacturersPage()
        {
            mainFrame.Navigate(new ManufacturersPage());
        }

        private void ShowOrdersPage()
        {
            mainFrame.Navigate(new OrdersPage());
        }

        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            ShowCarsPage();
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            ShowClientsPage();
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            ShowEmployeesPage();
        }

        private void btnManufacturers_Click(object sender, RoutedEventArgs e)
        {
            ShowManufacturersPage();
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            ShowOrdersPage();
        }
    }
} 