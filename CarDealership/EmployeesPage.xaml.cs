using System;
using System.Windows;
using System.Windows.Controls;

namespace CarDealership
{
    public partial class EmployeesPage : Page
    {
        private Employee selectedEmployee;

        public EmployeesPage()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            employeesDataGrid.ItemsSource = Database.Employees;
        }

        private void employeesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedEmployee = employeesDataGrid.SelectedItem as Employee;
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool isEmployeeSelected = selectedEmployee != null;
            deleteButton.IsEnabled = isEmployeeSelected;
            editButton.IsEnabled = isEmployeeSelected;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEmployee == null) return;

            MessageBoxResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить сотрудника {selectedEmployee.FullName}?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Database.Employees.Remove(selectedEmployee);
                selectedEmployee = null;
                UpdateButtonsState();
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEmployee == null) return;

            var editWindow = new EmployeeEditWindow(selectedEmployee);
            if (editWindow.ShowDialog() == true)
            {
                employeesDataGrid.Items.Refresh();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Employee newEmployee = new Employee
            {
                Id = Database.Employees.Count > 0 ? Database.Employees[Database.Employees.Count - 1].Id + 1 : 1
            };

            var addWindow = new EmployeeEditWindow(newEmployee, true);
            if (addWindow.ShowDialog() == true)
            {
                Database.Employees.Add(newEmployee);
                employeesDataGrid.SelectedItem = newEmployee;
            }
        }
    }
} 