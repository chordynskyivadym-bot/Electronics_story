namespace electronics_store {
    internal class Program {
        static void Main(string[] args) {
            
            MainMenu();
            
        }
        static double GetUserInput(string text = "Введіть число ") {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(text + " ");

                bool isNumber = Double.TryParse(Console.ReadLine(), out double choice);

                if (!isNumber) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ви ввели не число!");
                    Console.ResetColor();
                    GetUserInput();
                }

                Console.ResetColor();

                return choice;
        }
        static void MainMenu() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("====================================");
            Console.WriteLine("===========ГОЛОВНЕ МЕНЮ=============");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Товари");
            Console.WriteLine("2. Оформити замовлення");
            Console.WriteLine("3. Акції та знижки");
            Console.WriteLine("4. Підтримка клієнтів");
            Console.WriteLine("5. Вихід");
            Console.WriteLine("====================================");
            Console.ResetColor();

            double choice = GetUserInput("Введіть число від 1-5 ");
            switch (choice) {
                case 1:
                    Showproducts();
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 2:
                    OrderElectronics();
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 3:
                    ShowActionsAndDiscounts();
                    break;
                case 4:
                    ShowCustomerSupport();
                    break;
                case 5:
                    Console.WriteLine("Вихід з програми. До побачення!");
                    Console.ReadKey();
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
                    break;    
            }
        }
        static void Showproducts() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========= Наші товари =========");
            Console.WriteLine("1. Ноутбук");
            Console.WriteLine("2. Смартфон");
            Console.WriteLine("3. Планшет");
            Console.WriteLine("4. Навушники");
            Console.WriteLine("5. Телевізор");
            Console.WriteLine("6. Вийти у головне меню");
            Console.WriteLine("================================");
            Console.ResetColor();

            double choice = GetUserInput("Введіть число від 1-6: ");

            switch (choice) {
                case 1:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 2:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 3:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 4:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 5:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 6:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
                    return;
            }
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
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 2:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 3:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 4:
                    Console.WriteLine("Функція в розробці...");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                    Console.ReadKey();
                    MainMenu();
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
            string? inputNotebook = Console.ReadLine();
            int countNotebook = int.TryParse(inputNotebook, out int nb) ? nb : 0;
            Console.Write("Виберіть кількість смартфонів: ");
            string? inputSmartphone = Console.ReadLine();
            int countSmartphone = int.TryParse(inputSmartphone, out int sp) ? sp : 0;
            Console.Write("Виберіть кількість планшетів: ");
            string? inputTablet = Console.ReadLine();
            int countTablet = int.TryParse(inputTablet, out int tb) ? tb : 0;
            Console.Write("Виберіть кількість навушників: ");
            string? inputHeadphone = Console.ReadLine();
            int countHeadphone = int.TryParse(inputHeadphone, out int hp) ? hp : 0;
            Console.Write("Виберіть кількість телевізорів: ");
            string? inputTV = Console.ReadLine();
            int countTV = int.TryParse(inputTV, out int tv) ? tv : 0;

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
            } else if (totalPrice >= 6000) {
                discount = 15;
            } else if (totalPrice >= 3000) {
                discount = 10;
            } else {
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
