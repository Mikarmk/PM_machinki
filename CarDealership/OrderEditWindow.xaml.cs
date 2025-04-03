using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CarDealership
{
    public partial class OrderEditWindow : Window
    {
        private Order order;
        private bool isNewOrder;

        public OrderEditWindow(Order order, bool isNewOrder = false)
        {
            InitializeComponent();
            this.order = order;
            this.isNewOrder = isNewOrder;

            // Заполнение комбобоксов
            carComboBox.ItemsSource = Database.Cars;
            clientComboBox.ItemsSource = Database.Clients;
            employeeComboBox.ItemsSource = Database.Employees;

            // Настройка заголовка окна
            if (isNewOrder)
            {
                Title = "Создание нового заказа";
                titleTextBlock.Text = "Создание нового заказа";
            }

            LoadOrderData();
        }

        private void LoadOrderData()
        {
            carComboBox.SelectedValue = order.CarId;
            clientComboBox.SelectedValue = order.ClientId;
            employeeComboBox.SelectedValue = order.EmployeeId;
            orderDatePicker.SelectedDate = order.OrderDate;
            totalAmountTextBox.Text = order.TotalAmount.ToString();

            // Выбор статуса
            switch (order.Status)
            {
                case "В обработке":
                    statusComboBox.SelectedIndex = 0;
                    break;
                case "Завершен":
                    statusComboBox.SelectedIndex = 1;
                    break;
                case "Отменен":
                    statusComboBox.SelectedIndex = 2;
                    break;
                default:
                    statusComboBox.SelectedIndex = 0;
                    break;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                // Сохранение данных
                order.CarId = (int)carComboBox.SelectedValue;
                order.ClientId = (int)clientComboBox.SelectedValue;
                order.EmployeeId = (int)employeeComboBox.SelectedValue;
                order.OrderDate = orderDatePicker.SelectedDate.Value;
                order.TotalAmount = decimal.Parse(totalAmountTextBox.Text);
                order.Status = ((ComboBoxItem)statusComboBox.SelectedItem).Content.ToString();

                DialogResult = true;
                Close();
            }
        }

        private bool ValidateInput()
        {
            // Простая валидация
            if (carComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите автомобиль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (clientComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (employeeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (orderDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату заказа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!decimal.TryParse(totalAmountTextBox.Text, out decimal totalAmount) || totalAmount <= 0)
            {
                MessageBox.Show("Введите корректную сумму", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (statusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус заказа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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