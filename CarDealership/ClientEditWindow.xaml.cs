using System;
using System.Windows;

namespace CarDealership
{
    public partial class ClientEditWindow : Window
    {
        private Client client;
        private bool isNewClient;

        public ClientEditWindow(Client client, bool isNewClient = false)
        {
            InitializeComponent();
            this.client = client;
            this.isNewClient = isNewClient;

            // Настройка заголовка окна
            if (isNewClient)
            {
                Title = "Добавление нового клиента";
                titleTextBlock.Text = "Добавление нового клиента";
            }

            LoadClientData();
        }

        private void LoadClientData()
        {
            fullNameTextBox.Text = client.FullName;
            phoneTextBox.Text = client.Phone;
            emailTextBox.Text = client.Email;
            addressTextBox.Text = client.Address;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                // Сохранение данных
                client.FullName = fullNameTextBox.Text;
                client.Phone = phoneTextBox.Text;
                client.Email = emailTextBox.Text;
                client.Address = addressTextBox.Text;

                DialogResult = true;
                Close();
            }
        }

        private bool ValidateInput()
        {
            // Простая валидация
            if (string.IsNullOrWhiteSpace(fullNameTextBox.Text))
            {
                MessageBox.Show("Введите ФИО клиента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                MessageBox.Show("Введите телефон клиента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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