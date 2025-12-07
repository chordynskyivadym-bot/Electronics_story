using System;
using System.Text;

namespace electronics_store {

    internal class Program {

        static List<Product> products = new List<Product>();
        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;
            Login();
            SeedData();
            MainMenu();
        }
        static void SeedData() {
            products.Add(new Product("Ноутбук Asus", 25000, 5, "Ноутбуки"));
            products.Add(new Product("Мишка Logitech", 800, 20, "Аксесуари"));
            products.Add(new Product("iPhone 13", 30000, 3, "Смартфони"));
            products.Add(new Product("Монітор LG", 7500, 10, "Монітори"));
            products.Add(new Product("Клавіатура", 1200, 15, "Аксесуари"));
        }
        static void Login() {
            string correctUsername = "Vadim";
            string correctPassword = "12345";
            int attempts = 0;
            int maxAttempts = 3;
            do {
                Console.Write("Введіть ваш логін: ");
                string inputUsername = Console.ReadLine();
                Console.Write("Введіть ваш пароль: ");
                string inputPassword = Console.ReadLine();
                if (inputUsername == correctUsername && inputPassword == correctPassword) {
                    Console.WriteLine("Вхід успішний! Ласкаво просимо до магазину електроніки.");
                    Console.ReadKey();
                    return;
                }
                else {
                    attempts++;
                    Console.WriteLine($"Невірний логін або пароль. Спроба {attempts} з {maxAttempts}.");
                }
            } while (attempts < maxAttempts);
            Console.WriteLine("Перевищено максимальну кількість спроб. Вихід з програми.");
            Exit();
        }

        static double GetUserInput(string text = "") {
            try {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                double choice = double.Parse(Console.ReadLine());
                Console.ResetColor();
                return choice;
            }
            catch (FormatException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Невірний формат вводу. Будь ласка, введіть число.");
                Console.ResetColor();
                return GetUserInput(text);
            }
        }

        public static void AskForProduct() {
            while (true) {
                Console.Write("Введіть назву продукта: ");
                string name = Console.ReadLine();
                double price = GetUserInput("Введіть ціну продукта");
                int quantity = (int)GetUserInput("Введіть кількість продукта");
                Console.Write("Введіть категорію продукта: ");
                string category = Console.ReadLine();
                products.Add(new Product(name, (int)price, quantity, category));

                Console.WriteLine("================================");
                Console.WriteLine("Чи хочете додати ще один продукт 1 - Yes, 0 - No");
                int choice = (int)GetUserInput();

                if (choice == 1) {
                    Console.Clear();
                }
                else if (choice == 0) {
                    Console.WriteLine("Ваші продукти:");
                    ShowProducts();
                    break;
                }
            }
        }

        static void MainMenu() {
            bool exit = true;
            while (exit) {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("====================================");
                Console.WriteLine("===========ГОЛОВНЕ МЕНЮ=============");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Товари");
                Console.WriteLine("2. Статистика");
                Console.WriteLine("3. Оформити замовлення");
                Console.WriteLine("4. Акції та знижки");
                Console.WriteLine("5. Підтримка клієнтів");
                Console.WriteLine("6. Вихід");
                Console.WriteLine("====================================");
                Console.ResetColor();

                double choice = GetUserInput("Введіть число від 1-6 ");
                switch (choice) {
                    case 1:
                        ProductsMenu();
                        break;
                    case 2:
                        ShowStatistic();
                        break;
                    case 3:
                        OrderElectronics();
                        break;
                    case 4:
                        ShowActionsAndDiscounts();
                        break;
                    case 5:
                        ShowCustomerSupport();
                        break;
                    case 6:
                        exit = false;
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
                        break;
                }
            }
        }
        static void ProductsMenu() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========= Товари =========");
            Console.WriteLine("1. Додати товари");
            Console.WriteLine("2. Показати всі товари");
            Console.WriteLine("3. Пошук товару");
            Console.WriteLine("4. Видалити товар");
            Console.WriteLine("5. Сортування товарів");
            Console.WriteLine("6. Повернутись до головного меню");
            Console.WriteLine("================================");
            Console.ResetColor();
            double choice = GetUserInput("Введіть число від 1-6: ");
            switch (choice) {
                case 1:
                    AskForProduct();
                    break;
                case 2:
                    ShowProducts();
                    break;
                case 3:
                    SearchProduct();
                    break;
                case 4:
                    DeleteProduct();
                    break;
                case 5:
                    SortProduct();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Невірний вибір.");
                    return;
            }
        }
        static void SearchProduct() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n============= Пошук =============");
            string query = Console.ReadLine();
            Console.WriteLine($"Шукаємо: {query}");
            bool found = false;

            Console.WriteLine("Результати:");
            foreach (var p in products) {
                if (p.Name.ToLower().Contains(query)) {
                    p.ShowInfo();
                    found = true;
                }
            }
            if(!found) {
                Console.WriteLine("Товар не знайдено.");
            }
            Stop();
            Console.ResetColor();
        }
        static void DeleteProduct() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n--- Видалення товару ---");
            ShowProducts();
            Console.WriteLine("================================");
            int idToDelete = (int)GetUserInput("Введіть ID товару для видалення: ");
            if(idToDelete <= 0 || idToDelete > products.Count) {
                Console.WriteLine("Невірний ID товару.");
                Stop();
                return;
            }
            products.RemoveAt(idToDelete);
            Console.WriteLine("Товар успішно видалено.");
            Stop();
            Console.ResetColor();
        }
        static void SortProduct() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n======= Сортування товарів =======");
            Console.WriteLine("1. За ціною");
            Console.WriteLine("2. За назвою");
            Console.WriteLine("===================================");
            double choice = GetUserInput("Введіть число від 1-2: ");
            switch (choice) {
                case 1:
                    SortByPrice();
                    break;
                case 2:
                    SortByName();
                    break;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
            Console.ResetColor();
            Console.WriteLine("Товари відсортовані.");
            ShowProducts();
        }
        static void SortByPrice() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--- Сортування за ЦІНОЮ (Bubble Sort) ---");
            int n = products.Count;

            for (int i = 0; i < n - 1; i++) {
                for (int j = 0; j < n - i - 1; j++) {
                    if (products[j].Price > products[j + 1].Price) {
                        Product temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Список відсортовано від найдешевшого до найдорожчого!");
            Console.ResetColor();
        }
        static void SortByName() {
            Console.WriteLine("\n======= Сортування товарів за назвою =======");
            int n = products.Count;
            for (int i = 0; i < n - 1; i++) {
                for (int j = 0; j < n - i - 1; j++) {
                    if (String.Compare(products[j].Name, products[j + 1].Name) > 0) {
                        Product temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                }
            }
        }
        static void ShowProducts() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Всього товарів: {products.Count}");
            Console.WriteLine("========= Наші товари =========");

            Console.WriteLine(new string('=', 75));
            Console.WriteLine($"| {"ID",-3} | {"Назва",-20} | {"Категорія",-12} | {"Ціна",14} | {"К-сть",9} |");
            Console.WriteLine(new string('=', 75));
            foreach (var product in products) {
                product.ShowInfo();
            }
            Console.WriteLine(new string('=', 75));
            if (products.Count == 0) {
                Console.WriteLine("Список товарів порожній.");
            }
            Stop();
            Console.ResetColor();
        }
        static void ShowStatistic() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========= Статистика =========");
            Console.WriteLine("1. Подивитися продукти");
            Console.WriteLine("2. Фінансовий звіт");
            Console.WriteLine("3. Повернутись до головного меню");
            Console.WriteLine("================================");
            double choice = GetUserInput("Введіть число від 1-3: ");
            switch (choice) {
                case 1:
                    ShowProducts();
                    break;
                case 2:
                    Financial();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Невірний вибір.");
                    return;
            }
            Console.ResetColor();
        }

        static void Financial() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("========= Фінансовий звіт =========");

            if (products.Count == 0) {
                Console.WriteLine("Дані відсутні.");
                return;
            }

            Console.Clear();
            int totalSum = 0;
            int totalQuantity = 0;
            double maxPrice = double.MinValue;
            double minPrice = double.MaxValue;
            int expensiveItemsCount = 0;

            for(int i = 0; i < products.Count; i++) {
                totalSum += products[i].Price * products[i].Quantity;
                totalQuantity += products[i].Quantity;
                if (products[i].Price > maxPrice) {
                    maxPrice = products[i].Price;
                }
                if (products[i].Price < minPrice) {
                    minPrice = products[i].Price;
                }
                if (products[i].Price > 5000) {
                    expensiveItemsCount++;
                }
            }
            double averagePrice = (double)totalSum / totalQuantity;

            Console.WriteLine($"Загальна вартість складу: {totalSum}$");
            Console.WriteLine($"Загальна кількість товарів: {totalQuantity}");
            Console.WriteLine($"Середня ціна товару: {averagePrice:F2}$");
            Console.WriteLine($"Найдорожчий товар: {maxPrice}$");
            Console.WriteLine($"Найдешевший товар: {minPrice}$");
            Console.WriteLine($"Кількість дорогих товарів (>500$): {expensiveItemsCount}");

            Console.ResetColor();
            Stop();
        }

        static void ShowActionsAndDiscounts() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("====================================");
            Console.WriteLine("==========АКЦІЇ ТА ЗНИЖКИ===========");
            Console.WriteLine("====================================");
            Console.WriteLine("1.Знижка - 10 % на смартфони Samsung");
            Console.WriteLine("2.Купи ноутбук — отримай мишку у подарунок");
            Console.WriteLine("3.Акція Чорна П’ятниця — до - 50");
            Console.WriteLine("4.Розпродаж телевізорів LG");
            Console.WriteLine("5.Назад до головного меню");
            Console.WriteLine("====================================");
            Console.ResetColor();
            double choice = GetUserInput("Введіть число від 1-5: ");

            switch (choice) {
                case 1:
                    Console.WriteLine("Функція в розробці...");
                    Stop();
                    break;
                case 2:
                    Console.WriteLine("Функція в розробці...");
                    Stop();
                    break;
                case 3:
                    Console.WriteLine("Функція в розробці...");
                    Stop();
                    break;
                case 4:
                    Console.WriteLine("Функція в розробці...");
                    Stop();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }

        static void ShowCustomerSupport() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("====================================");
            Console.WriteLine("========ПІДТРИМКА КЛІЄНТІВ==========");
            Console.WriteLine("====================================");
            Console.WriteLine("Телефон: +380 44 123 4567");
            Console.WriteLine("Електронна пошта: support@store.com");
            Console.WriteLine("====================================");
            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутись...");
            Console.ReadKey();
        }
        static void Stop() {
            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутись...");
            Console.ReadKey();
        }
        static void Exit() {
            Console.WriteLine("Вихід з програми. До побачення!");
            Console.ReadKey();
            Environment.Exit(1);
        }

        static void OrderElectronics() {
            int valueNotebook = 1000;
            int valueSmartphone = 500;
            int valueTablet = 700;
            int valueHeadphone = 400;
            int valueTV = 1200;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=== Каталог для замовлення ===");
            Console.ResetColor();
            Console.WriteLine($"1. Ноутбук, {valueNotebook}$");
            Console.WriteLine($"2. Смартфон, {valueSmartphone}$");
            Console.WriteLine($"3. Планшет, {valueTablet}$");
            Console.WriteLine($"4. Навушники, {valueHeadphone}$");
            Console.WriteLine($"5. Телевізор, {valueTV} $");

            Console.Write("\nВиберіть кількість ноутбуків: ");
            int countNotebook = (int)GetUserInput();
            Console.Write("Виберіть кількість смартфонів: ");
            int countSmartphone = (int)GetUserInput();
            Console.Write("Виберіть кількість планшетів: ");
            int countTablet = (int)GetUserInput();
            Console.Write("Виберіть кількість навушників: ");
            int countHeadphone = (int)GetUserInput(); ;
            Console.Write("Виберіть кількість телевізорів: ");
            int countTV = (int)GetUserInput();

            int totalPriceNotebook = valueNotebook * countNotebook;
            int totalPriceSmartphone = valueSmartphone * countSmartphone;
            int totalPriceTablet = valueTablet * countTablet;
            int totalPriceHeadphone = valueHeadphone * countHeadphone;
            int totalPriceTV = valueTV * countTV;

            int totalPrice = totalPriceNotebook + totalPriceSmartphone + totalPriceTablet + totalPriceHeadphone + totalPriceTV;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nЗагальна вартість: {totalPrice} $");
            Console.ResetColor();

            int discount;
            if (totalPrice >= 10000) discount = 20;
            else if (totalPrice >= 6000) discount = 15;
            else if (totalPrice >= 3000) discount = 10;
            else discount = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nВаша знижка: {discount}%");
            Console.ResetColor();
            double discountAmount = totalPrice * (discount / 100.0);

            double finalPrice = totalPrice - discountAmount;
            finalPrice = Math.Round(finalPrice, 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nЦіна зі знижкою: {finalPrice} $");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n=== Ваші деталі покупки ===");
            Console.ResetColor();
            if (countNotebook > 0) Console.WriteLine($"Ноутбуки: {countNotebook} шт.");
            if (countSmartphone > 0) Console.WriteLine($"Смартфони: {countSmartphone} шт.");

            Console.WriteLine("\nДякуємо за покупку!");
            Console.ReadKey();
        }
    }
}