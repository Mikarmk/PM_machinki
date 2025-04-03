using System;
using System.Windows;

namespace CarDealership
{
    public partial class CarEditWindow : Window
    {
        private Car car;
        private bool isNewCar;

        public CarEditWindow(Car car, bool isNewCar = false)
        {
            InitializeComponent();
            this.car = car;
            this.isNewCar = isNewCar;

            // Заполнение комбобокса производителей
            manufacturerComboBox.ItemsSource = Database.Manufacturers;

            // Настройка заголовка окна
            if (isNewCar)
            {
                Title = "Добавление нового автомобиля";
                titleTextBlock.Text = "Добавление нового автомобиля";
            }

            LoadCarData();
        }

        private void LoadCarData()
        {
            brandTextBox.Text = car.Brand;
            modelTextBox.Text = car.Model;
            yearTextBox.Text = car.Year.ToString();
            colorTextBox.Text = car.Color;
            priceTextBox.Text = car.Price.ToString();
            orderNumberTextBox.Text = car.OrderNumber.ToString();
            manufacturerComboBox.SelectedValue = car.ManufacturerId;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                // Сохранение данных
                car.Brand = brandTextBox.Text;
                car.Model = modelTextBox.Text;
                car.Year = int.Parse(yearTextBox.Text);
                car.Color = colorTextBox.Text;
                car.Price = decimal.Parse(priceTextBox.Text);
                car.OrderNumber = int.Parse(orderNumberTextBox.Text);
                car.ManufacturerId = (int)manufacturerComboBox.SelectedValue;

                DialogResult = true;
                Close();
            }
        }

        private bool ValidateInput()
        {
            // Простая валидация
            if (string.IsNullOrWhiteSpace(brandTextBox.Text))
            {
                MessageBox.Show("Введите марку автомобиля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(modelTextBox.Text))
            {
                MessageBox.Show("Введите модель автомобиля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!int.TryParse(yearTextBox.Text, out int year) || year < 1900 || year > DateTime.Now.Year + 1)
            {
                MessageBox.Show($"Введите корректный год выпуска (1900-{DateTime.Now.Year + 1})", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(colorTextBox.Text))
            {
                MessageBox.Show("Введите цвет автомобиля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!decimal.TryParse(priceTextBox.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Введите корректную цену", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!int.TryParse(orderNumberTextBox.Text, out int orderNumber) || orderNumber <= 0)
            {
                MessageBox.Show("Введите корректный номер заказа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (manufacturerComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите производителя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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