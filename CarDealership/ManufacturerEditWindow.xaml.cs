using System;
using System.Windows;

namespace CarDealership
{
    public partial class ManufacturerEditWindow : Window
    {
        private Manufacturer manufacturer;
        private bool isNewManufacturer;

        public ManufacturerEditWindow(Manufacturer manufacturer, bool isNewManufacturer = false)
        {
            InitializeComponent();
            this.manufacturer = manufacturer;
            this.isNewManufacturer = isNewManufacturer;

            // Настройка заголовка окна
            if (isNewManufacturer)
            {
                Title = "Добавление нового производителя";
                titleTextBlock.Text = "Добавление нового производителя";
            }

            LoadManufacturerData();
        }

        private void LoadManufacturerData()
        {
            nameTextBox.Text = manufacturer.Name;
            countryTextBox.Text = manufacturer.Country;
            contactInfoTextBox.Text = manufacturer.ContactInfo;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                // Сохранение данных
                manufacturer.Name = nameTextBox.Text;
                manufacturer.Country = countryTextBox.Text;
                manufacturer.ContactInfo = contactInfoTextBox.Text;

                DialogResult = true;
                Close();
            }
        }

        private bool ValidateInput()
        {
            // Простая валидация
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Введите название производителя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(countryTextBox.Text))
            {
                MessageBox.Show("Введите страну производителя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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