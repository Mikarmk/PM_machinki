using System;
using System.Windows;

namespace CarDealership
{
    public partial class EmployeeEditWindow : Window
    {
        private Employee employee;
        private bool isNewEmployee;

        public EmployeeEditWindow(Employee employee, bool isNewEmployee = false)
        {
            InitializeComponent();
            this.employee = employee;
            this.isNewEmployee = isNewEmployee;

            // Настройка заголовка окна
            if (isNewEmployee)
            {
                Title = "Добавление нового сотрудника";
                titleTextBlock.Text = "Добавление нового сотрудника";
            }

            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            fullNameTextBox.Text = employee.FullName;
            positionTextBox.Text = employee.Position;
            phoneTextBox.Text = employee.Phone;
            salaryTextBox.Text = employee.Salary.ToString();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                // Сохранение данных
                employee.FullName = fullNameTextBox.Text;
                employee.Position = positionTextBox.Text;
                employee.Phone = phoneTextBox.Text;
                employee.Salary = decimal.Parse(salaryTextBox.Text);

                DialogResult = true;
                Close();
            }
        }

        private bool ValidateInput()
        {
            // Простая валидация
            if (string.IsNullOrWhiteSpace(fullNameTextBox.Text))
            {
                MessageBox.Show("Введите ФИО сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(positionTextBox.Text))
            {
                MessageBox.Show("Введите должность сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                MessageBox.Show("Введите телефон сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!decimal.TryParse(salaryTextBox.Text, out decimal salary) || salary < 0)
            {
                MessageBox.Show("Введите корректную зарплату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
} 