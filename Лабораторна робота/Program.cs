using System;
using System.Text;

namespace electronics_store {

    internal class Program {
        private static Product p1 = new Product();
        private static Product p2 = new Product();
        private static Product p3 = new Product();
        private static Product p4 = new Product();
        private static Product p5 = new Product();

        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;
            Login();
            MainMenu();
        }

        static void Login() {
            string correctUsername = "admin";
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

                if (p1.IsEmpty()) {
                    p1 = new Product(name, (int)price, 1, "Електроніка");
                }
                else if (p2.IsEmpty()) {
                    p2 = new Product(name, (int)price, 1, "Електроніка");
                }
                else if (p3.IsEmpty()) {
                    p3 = new Product(name, (int)price, 1, "Електроніка");
                }
                else if (p4.IsEmpty()) {
                    p4 = new Product(name, (int)price, 1, "Електроніка");
                }
                else if (p5.IsEmpty()) {
                    p5 = new Product(name, (int)price, 1, "Електроніка");
                }
                else {
                    Console.WriteLine("Немає місця для продуктів (максимум 5)");
                    break;
                }

                Console.WriteLine("================================");
                Console.WriteLine("Чи хочете додати ще один продукт 1 - Yes, 0 - No");
                int choice = (int)GetUserInput();

                if (choice == 1) {
                    
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
                Console.WriteLine("1. Додати товари");
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
                        AskForProduct();
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

        static void ShowProducts() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Загальна кількість продуктів: {GetProductsCount()}");
            Console.WriteLine("========= Наші товари =========");

            if (!p1.IsEmpty()) p1.ShowInfo();
            if (!p2.IsEmpty()) p2.ShowInfo();
            if (!p3.IsEmpty()) p3.ShowInfo();
            if (!p4.IsEmpty()) p4.ShowInfo();
            if (!p5.IsEmpty()) p5.ShowInfo();

            if (p1.IsEmpty() && p2.IsEmpty() && p3.IsEmpty() && p4.IsEmpty() && p5.IsEmpty()) {
                Console.WriteLine("Список товарів порожній.");
            }
            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися...");
            Console.ReadKey();
            Console.ResetColor();
        }
        static int GetProductsCount() {
            int count = 0;
            if (!p1.IsEmpty()) count++;
            if (!p2.IsEmpty()) count++;
            if (!p3.IsEmpty()) count++;
            if (!p4.IsEmpty()) count++;
            if (!p5.IsEmpty()) count++;
            return count;
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

            int count = GetProductsCount();
            if (count == 0) {
                Console.WriteLine("Дані відсутні.");
                return;
            }

            Console.Clear();
            int totalSum = 0;
            int totalQuantity = 0;
            double maxPrice = double.MinValue;
            double minPrice = double.MaxValue;
            int expensiveItemsCount = 0;

            if (!p1.IsEmpty()) {
                totalSum += p1.Price;
                totalQuantity++;
                if (p1.Price > maxPrice) maxPrice = p1.Price;
                if (p1.Price < minPrice) minPrice = p1.Price;
                if (p1.Price > 500) expensiveItemsCount++;
            }
            if (!p2.IsEmpty()) {
                totalSum += p2.Price;
                totalQuantity++;
                if (p2.Price > maxPrice) maxPrice = p2.Price;
                if (p2.Price < minPrice) minPrice = p2.Price;
                if (p2.Price > 500) expensiveItemsCount++;
            }
            if (!p3.IsEmpty()) {
                totalSum += p3.Price;
                totalQuantity++;
                if (p3.Price > maxPrice) maxPrice = p3.Price;
                if (p3.Price < minPrice) minPrice = p3.Price;
                if (p3.Price > 500) expensiveItemsCount++;
            }
            if (!p4.IsEmpty()) {
                totalSum += p4.Price;
                totalQuantity++;
                if (p4.Price > maxPrice) maxPrice = p4.Price;
                if (p4.Price < minPrice) minPrice = p4.Price;
                if (p4.Price > 500) expensiveItemsCount++;
            }
            if (!p5.IsEmpty()) {
                totalSum += p5.Price;
                totalQuantity++;
                if (p5.Price > maxPrice) maxPrice = p5.Price;
                if (p5.Price < minPrice) minPrice = p5.Price;
                if (p5.Price > 500) expensiveItemsCount++;
            }

            double averagePrice = (double)totalSum / totalQuantity;

            Console.WriteLine($"Загальна вартість складу: {totalSum}$");
            Console.WriteLine($"Загальна кількість товарів: {totalQuantity}");
            Console.WriteLine($"Середня ціна товару: {averagePrice:F2}$");
            Console.WriteLine($"Найдорожчий товар: {maxPrice}$");
            Console.WriteLine($"Найдешевший товар: {minPrice}$");
            Console.WriteLine($"Кількість дорогих товарів (>500$): {expensiveItemsCount}");

            Console.ResetColor();
            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутись...");
            Console.ReadKey();
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
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися...");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися...");
                    Console.ReadKey();
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