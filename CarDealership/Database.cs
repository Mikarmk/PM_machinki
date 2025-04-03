using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace CarDealership
{
    // Модели данных
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int OrderNumber { get; set; }
        public int ManufacturerId { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }

    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string ContactInfo { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }

    // Класс, имитирующий базу данных
    public static class Database
    {
        // Коллекции данных
        public static ObservableCollection<Car> Cars { get; private set; } = new ObservableCollection<Car>();
        public static ObservableCollection<Client> Clients { get; private set; } = new ObservableCollection<Client>();
        public static ObservableCollection<Employee> Employees { get; private set; } = new ObservableCollection<Employee>();
        public static ObservableCollection<Manufacturer> Manufacturers { get; private set; } = new ObservableCollection<Manufacturer>();
        public static ObservableCollection<Order> Orders { get; private set; } = new ObservableCollection<Order>();

        // Инициализация базы данных тестовыми данными
        static Database()
        {
            InitializeData();
        }

        private static void InitializeData()
        {
            // Производители
            Manufacturers.Add(new Manufacturer { Id = 1, Name = "Toyota", Country = "Япония", ContactInfo = "toyota@example.com" });
            Manufacturers.Add(new Manufacturer { Id = 2, Name = "BMW", Country = "Германия", ContactInfo = "bmw@example.com" });
            Manufacturers.Add(new Manufacturer { Id = 3, Name = "Mercedes", Country = "Германия", ContactInfo = "mercedes@example.com" });
            Manufacturers.Add(new Manufacturer { Id = 4, Name = "Ford", Country = "США", ContactInfo = "ford@example.com" });
            Manufacturers.Add(new Manufacturer { Id = 5, Name = "Honda", Country = "Япония", ContactInfo = "honda@example.com" });
            Manufacturers.Add(new Manufacturer { Id = 6, Name = "Audi", Country = "Германия", ContactInfo = "audi@example.com" });
            Manufacturers.Add(new Manufacturer { Id = 7, Name = "Volkswagen", Country = "Германия", ContactInfo = "vw@example.com" });
            Manufacturers.Add(new Manufacturer { Id = 8, Name = "Nissan", Country = "Япония", ContactInfo = "nissan@example.com" });

            // Автомобили (как на скриншоте)
            Cars.Add(new Car { Id = 1, Brand = "Toyota", Model = "Camry", Year = 2023, Color = "Black", Price = 25000.00m, OrderNumber = 1, ManufacturerId = 1 });
            Cars.Add(new Car { Id = 2, Brand = "BMW", Model = "X5", Year = 2024, Color = "White", Price = 50000.00m, OrderNumber = 2, ManufacturerId = 2 });
            Cars.Add(new Car { Id = 3, Brand = "Honda", Model = "Civic", Year = 2023, Color = "Red", Price = 20000.00m, OrderNumber = 3, ManufacturerId = 5 });
            Cars.Add(new Car { Id = 4, Brand = "Ford", Model = "Mustang", Year = 2024, Color = "Blue", Price = 45000.00m, OrderNumber = 4, ManufacturerId = 4 });
            Cars.Add(new Car { Id = 5, Brand = "Audi", Model = "A4", Year = 2023, Color = "Silver", Price = 35000.00m, OrderNumber = 5, ManufacturerId = 6 });
            Cars.Add(new Car { Id = 6, Brand = "Nissan", Model = "Altima", Year = 2024, Color = "Gray", Price = 30000.00m, OrderNumber = 6, ManufacturerId = 8 });
            Cars.Add(new Car { Id = 7, Brand = "Mercedes", Model = "C-Class", Year = 2023, Color = "Black", Price = 55000.00m, OrderNumber = 7, ManufacturerId = 3 });
            Cars.Add(new Car { Id = 8, Brand = "BMW", Model = "3 Series", Year = 2024, Color = "Red", Price = 40000.00m, OrderNumber = 8, ManufacturerId = 2 });
            Cars.Add(new Car { Id = 9, Brand = "Toyota", Model = "Corolla", Year = 2023, Color = "White", Price = 22000.00m, OrderNumber = 9, ManufacturerId = 1 });
            Cars.Add(new Car { Id = 10, Brand = "Honda", Model = "Accord", Year = 2024, Color = "Blue", Price = 28000.00m, OrderNumber = 10, ManufacturerId = 5 });
            Cars.Add(new Car { Id = 11, Brand = "Mercedes", Model = "E-Class", Year = 2023, Color = "Silver", Price = 60000.00m, OrderNumber = 11, ManufacturerId = 3 });
            Cars.Add(new Car { Id = 12, Brand = "Ford", Model = "Explorer", Year = 2024, Color = "Black", Price = 48000.00m, OrderNumber = 12, ManufacturerId = 4 });
            Cars.Add(new Car { Id = 13, Brand = "Audi", Model = "Q5", Year = 2023, Color = "Gray", Price = 40000.00m, OrderNumber = 13, ManufacturerId = 6 });
            Cars.Add(new Car { Id = 14, Brand = "Volkswagen", Model = "Golf", Year = 2024, Color = "White", Price = 32000.00m, OrderNumber = 14, ManufacturerId = 7 });
            Cars.Add(new Car { Id = 15, Brand = "Nissan", Model = "Rogue", Year = 2023, Color = "Red", Price = 27000.00m, OrderNumber = 15, ManufacturerId = 8 });

            // Клиенты
            Clients.Add(new Client { Id = 1, FullName = "Иванов Иван", Phone = "+7 (999) 123-4567", Email = "ivanov@mail.ru", Address = "Москва, ул. Ленина, 10" });
            Clients.Add(new Client { Id = 2, FullName = "Петрова Елена", Phone = "+7 (999) 765-4321", Email = "petrova@mail.ru", Address = "Санкт-Петербург, пр. Невский, 15" });
            Clients.Add(new Client { Id = 3, FullName = "Сидоров Алексей", Phone = "+7 (999) 555-7777", Email = "sidorov@mail.ru", Address = "Казань, ул. Баумана, 5" });

            // Сотрудники
            Employees.Add(new Employee { Id = 1, FullName = "Смирнов Андрей", Position = "Менеджер", Phone = "+7 (999) 111-2222", Salary = 60000 });
            Employees.Add(new Employee { Id = 2, FullName = "Козлова Мария", Position = "Продавец", Phone = "+7 (999) 222-3333", Salary = 45000 });
            Employees.Add(new Employee { Id = 3, FullName = "Новиков Дмитрий", Position = "Менеджер", Phone = "+7 (999) 333-4444", Salary = 55000 });

            // Заказы
            Orders.Add(new Order { Id = 1, CarId = 1, ClientId = 1, EmployeeId = 1, OrderDate = DateTime.Now.AddDays(-10), TotalAmount = 25000.00m, Status = "Завершен" });
            Orders.Add(new Order { Id = 2, CarId = 3, ClientId = 2, EmployeeId = 2, OrderDate = DateTime.Now.AddDays(-5), TotalAmount = 20000.00m, Status = "Завершен" });
            Orders.Add(new Order { Id = 3, CarId = 5, ClientId = 3, EmployeeId = 3, OrderDate = DateTime.Now.AddDays(-2), TotalAmount = 35000.00m, Status = "В обработке" });
        }
    }
} 