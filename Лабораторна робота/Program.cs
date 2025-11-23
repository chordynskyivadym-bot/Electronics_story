
using System.Text;

namespace electronics_store {
    internal class Program {
        static Dictionary<string, int> products = [];
        private static Product p1, p2, p3, p4, p5;
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
                    products.Add(name, (int)price);
                }
                else if (p2.IsEmpty()) { 
                    p2 = new Product(name, (int)price, 1, "Електроніка");
                    products.Add(name, (int)price);
                }
                else if (p3.IsEmpty()) { 
                    p3 = new Product(name, (int)price, 1, "Електроніка");
                    products.Add(name, (int)price);
                }
                else if (p4.IsEmpty()) { 
                    p4 = new Product(name, (int)price, 1, "Електроніка");
                    products.Add(name, (int)price);
                }
                else if (p5.IsEmpty()) { 
                    p5 = new Product(name, (int)price, 1, "Електроніка");
                    products.Add(name, (int)price);
                }
                else {
                    Console.WriteLine("Немає місця для продуктів");
                    break;
                }

                Console.WriteLine("================================");
                Console.WriteLine("Чи хочете додати ще один продукт 1 - Yes, 0 - No");
                int choice = (int)GetUserInput();

                if (choice == 1) {
                    AskForProduct();
                    break;
                }
                else if (choice == 0) {
                    Console.WriteLine("Ваші продукти:");

                    if (!p1.IsEmpty()) p1.ShowInfo();
                    if (!p2.IsEmpty()) p2.ShowInfo();
                    if (!p3.IsEmpty()) p3.ShowInfo();
                    if (!p4.IsEmpty()) p4.ShowInfo();
                    if (!p5.IsEmpty()) p5.ShowInfo();
                    Console.WriteLine("Натисніть будь-яку кнопку, щоб продовжити");
                    Console.ReadKey();
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

                double choice = GetUserInput("Введіть число від 1-5 ");
                switch (choice) {
                    case 1: AskForProduct();
                            MainMenu(); ; break;
                    case 2: ShowStatistic();
                            MainMenu(); break;
                    case 3: OrderElectronics();
                            MainMenu(); break;
                    case 4: ShowActionsAndDiscounts();
                            MainMenu(); break;
                    case 5: ShowCustomerSupport();
                            MainMenu(); break;
                    case 6: exit = false;
                            Exit(); break;
                    default:
                        Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
                        MainMenu();
                        break;
                }
            }
        }
        static void ShowProducts() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========= Наші товари =========");
            foreach (var product in products) {
                Console.WriteLine($"Назва: {product.Key}, Ціна: {product.Value}$");
            }
            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутись...");
            Console.ReadKey();
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
                    Console.WriteLine($"Загальна кількість продуктів: {products.Count}");
                    ShowProducts();
                    break;
                case 2:
                    Financial();
                    break;
                case 3:
                    MainMenu();
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
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
            foreach (var p in products) {
                totalSum += p.Value;
                totalQuantity += 1;

                if (p.Value > maxPrice) maxPrice = p.Value;
                if (p.Value < minPrice) minPrice = p.Value;
                if (p.Value > 500) expensiveItemsCount++;
            }
            double averagePrice = (double)totalSum / totalQuantity;

            Console.WriteLine($"Загальна вартість складу: {totalSum}$");
            Console.WriteLine($"Загальна кількість товарів: {totalQuantity}");
            Console.WriteLine($"Середня ціна товару: {averagePrice}$");
            Console.WriteLine($"Найдорожчий товар: {maxPrice}$");
            Console.WriteLine($"Найдешевший товар: {minPrice}$");
            Console.WriteLine($"Кількість дорогих товарів (>500$): {expensiveItemsCount}");

            Console.ResetColor();
            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутись...");
            Console.ReadKey();
        }
        //static void Showproducts() {
        //    Console.ForegroundColor = ConsoleColor.Cyan;
        //    Console.WriteLine("========= Наші товари =========");
        //    Console.WriteLine("1. Ноутбук");
        //    Console.WriteLine("2. Смартфон");
        //    Console.WriteLine("3. Планшет");
        //    Console.WriteLine("4. Навушники");
        //    Console.WriteLine("5. Телевізор");
        //    Console.WriteLine("6. Вийти у головне меню");
        //    Console.WriteLine("================================");
        //    Console.ResetColor();

        //    double choice = GetUserInput("Введіть число від 1-6: ");

        //    switch (choice) {
        //        case 1:
        //            Console.WriteLine("Функція в розробці...");
        //            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
        //            Console.ReadKey();
        //            break;
        //        case 2:
        //            Console.WriteLine("Функція в розробці...");
        //            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
        //            Console.ReadKey();
        //            break;
        //        case 3:
        //            Console.WriteLine("Функція в розробці...");
        //            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
        //            Console.ReadKey();
        //            break;
        //        case 4:
        //            Console.WriteLine("Функція в розробці...");
        //            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
        //            Console.ReadKey();
        //            break;
        //        case 5:
        //            Console.WriteLine("Функція в розробці...");
        //            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
        //            Console.ReadKey();
        //            break;
        //        case 6:
        //            MainMenu();
        //            break;
        //        default:
        //            Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
        //            MainMenu();
        //            return;
        //    }
        //}
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
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    break;
                case 5:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
                    return;
            }
        }
        static void ShowCustomerSupport() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("====================================");
            Console.WriteLine("========ПІДТРИМКА КЛІЄНТІВ==========");
            Console.WriteLine("====================================");
            Console.WriteLine("Якщо у вас є питання або потрібна допомога, зв'яжіться з нашою службою пітримки клієнтів:");
            Console.WriteLine("Телефон: +380 44 123 4567");
            Console.WriteLine("Електронна пошта: c.hordynskyi.vadym@student.uzhnu.edu.ua");
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
            Console.WriteLine("=== Наші товари ===");
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
            Console.WriteLine($"\nВартість ноутбуків: {totalPriceNotebook} $");
            int totalPriceSmartphone = valueSmartphone * countSmartphone;
            Console.WriteLine($"Вартість смартфонів: {totalPriceSmartphone} $");
            int totalPriceTablet = valueTablet * countTablet;
            Console.WriteLine($"Вартість планшетів: {totalPriceTablet} $");
            int totalPriceHeadphone = valueHeadphone * countHeadphone;
            Console.WriteLine($"Вартість навушників: {totalPriceHeadphone} $");
            int totalPriceTV = valueTV * countTV;
            Console.WriteLine($"Вартість телевізорів: {totalPriceTV} $");

            int totalPrice = totalPriceNotebook +
                totalPriceSmartphone +
                totalPriceTablet +
                totalPriceHeadphone +
                totalPriceTV;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nЗагальна вартість: {totalPrice} $");
            Console.ResetColor();


            int discount;
            if (totalPrice >= 10000) {
                discount = 20;
            }
            else if (totalPrice >= 6000) {
                discount = 15;
            }
            else if (totalPrice >= 3000) {
                discount = 10;
            }
            else {
                discount = 0;
            }
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Ноутбуки: {countNotebook} шт. - {totalPriceNotebook} $");
            Console.WriteLine($"Смартфони: {countSmartphone} шт. - {totalPriceSmartphone} $");
            Console.WriteLine($"Планшети: {countTablet} шт. - {totalPriceTablet} $");
            Console.WriteLine($"Навушники: {countHeadphone} шт. - {totalPriceHeadphone} $");
            Console.WriteLine($"Телевізори: {countTV} шт. - {totalPriceTV} $");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nПіднесення загальної вартості до кореня:");
            double roundedFinalPrice = Math.Sqrt(finalPrice);
            roundedFinalPrice = Math.Round(roundedFinalPrice, 2);
            Console.WriteLine($"Округлена ціна: {roundedFinalPrice} $");
            Console.ResetColor();

            Console.WriteLine("\nДякуємо за покупку!");
            Console.ReadKey();
        }
    }
}