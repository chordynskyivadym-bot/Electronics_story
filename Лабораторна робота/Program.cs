using System.Text;

namespace Electronics_store
{
    internal class Program
    {
        /// <summary>
        /// Функція входу в програму
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Login();
            MainMenu();
        }

        /// <summary>
        /// Відображає меню авторизації та обробляє вибір користувача (Вхід, Реєстрація, Вихід).
        /// Працює в циклі до успішної авторизації.
        /// </summary>
        private static void Login()
        {
            bool authorization = false;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("=============================================");
                Console.WriteLine("==Ласкаво просимо до електронного магазину!==");
                Console.WriteLine("=============================================");
                Console.WriteLine("1. Увійти");
                Console.WriteLine("2. Зареєструватись");
                Console.WriteLine("3. Вийти");
                Console.ResetColor();
                double choice = GetUserInput("Введіть 1-3: ");
                switch (choice)
                {
                    case 1: authorization = Authorization.Login(); break;
                    case 2: Authorization.Register(); break;
                    case 3: Exit(); break;
                    default: Console.WriteLine("Введіть коректне число"); break;
                }

                if (!authorization)
                {
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб спробувати ще раз...");
                    Console.ReadKey();
                }
            }
            while (!authorization);
        }

        /// <summary>
        /// Зчитує числове значення, введене користувачем, із перевіркою формату.
        /// </summary>
        /// <param name="text">Текст підказки, що виводиться перед введенням (необов'язковий)</param>
        /// <returns>Введене користувачем число типу double.</returns>
        private static double GetUserInput(string text = "")
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ResetColor();
                    throw new FormatException("Ввід не може бути порожнім.");
                }
                double choice = double.Parse(input);
                Console.ResetColor();
                return choice;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Невірний формат вводу. Будь ласка, введіть число.");
                Console.ResetColor();
                return GetUserInput(text);
            }
        }

        /// <summary>
        /// Відображає головне меню магазину після успішної авторизації.
        /// Надає доступ до товарів, статистики, замовлень та інших розділів.
        /// </summary>
        static void MainMenu()
        {
            bool exit = true;
            while (exit)
            {
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
                switch (choice)
                {
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

        /// <summary>
        /// Підменю для керування товарами.
        /// Дозволяє додавати, переглядати, шукати, видаляти та редагувати товари.
        /// </summary>
        static void ProductsMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========= Товари =========");
            Console.WriteLine("1. Додати товари");
            Console.WriteLine("2. Показати всі товари");
            Console.WriteLine("3. Пошук товару");
            Console.WriteLine("4. Видалити товар");
            Console.WriteLine("5. Редагувати");
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
                    EditProduct();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Невірний вибір.");
                    return;
            }
        }

        /// <summary>
        /// Інтерактивна функція для додавання нового товару.
        /// Запитує у користувача дані (назву, ціну, кількість, категорію) та зберігає їх у файл.
        /// </summary>
        public static void AskForProduct()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введіть назву продукта: ");
                    string? name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Назва продукту не може бути порожньою.");
                        continue;
                    }
                    double price = GetUserInput("Введіть ціну продукта");
                    int quantity = (int)GetUserInput("Введіть кількість продукта");
                    Console.Write("Введіть категорію продукта: ");
                    string? category = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(category))
                    {
                        Console.WriteLine("Категорія продукту не може бути порожньою.");
                        continue;
                    }
                    var p = new Product { Name = name, Price = (int)price, Quantity = quantity, Category = category };

                    CSV.AppendProduct(p);
                    Console.WriteLine("Товар успішно додано!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Помилка: Вводьте коректні числа!");
                }
                Console.WriteLine("================================");
                Console.WriteLine("Чи хочете додати ще один продукт 1 - Yes, 0 - No");
                int choice = (int)GetUserInput();

                if (choice == 1)
                {
                    Console.Clear();
                }
                else if (choice == 0)
                {
                    Console.WriteLine("Ваші продукти:");
                    ShowProducts();
                    break;
                }
            }
        }

        /// <summary>
        /// Здійснює пошук товарів за назвою або категорією.
        /// Виводить результати у вигляді таблиці.
        /// </summary>
        static void SearchProduct() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n============= Пошук =============");

            Console.Write("Введіть назву або категорію для пошуку: ");
            string? query = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(query))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Пошуковий запит не може бути порожнім.");
                Console.ResetColor();
                Stop();
                return;
            }
            List<Product> products = CSV.LoadProducts();

            Console.WriteLine($"\nРезультати пошуку для: '{query}'");
            Console.WriteLine(new string('=', 75));
            Console.WriteLine($"| {"ID",-3} | {"Назва",-20} | {"Категорія",-12} | {"Ціна",14} | {"К-сть",9} |");
            Console.WriteLine(new string('=', 75));

            bool found = false;

            foreach (var product in products)
            {
                if (!string.IsNullOrEmpty(product.Name) && product.Name.ToLower().Contains(query.ToLower()))
                {
                    product.ShowInfo();
                    found = true;
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("На жаль, товарів не знайдено.");
            }
            Console.WriteLine(new string('=', 75));
            Stop();
            Console.ResetColor();
        }

        /// <summary>
        /// Видаляє товар із бази даних за його унікальним ідентифікатором (ID).
        /// </summary>
        static void DeleteProduct()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n--- Видалення товару ---");
            ShowProducts();
            Console.WriteLine("================================");
            Console.WriteLine("Введіть ID товару для видалення: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                List<Product> products = CSV.LoadProducts();
                Product toRemove = products.FirstOrDefault(product => product.Id == id);
                if (!toRemove.IsEmpty()) {
                    products.Remove(toRemove);
                    CSV.RewriteProducts(products);
                    Console.WriteLine("Товар успішно видалено.");
                }
                else
                {
                    Console.WriteLine("ID не знайдено.");
                }
            }
            Stop();
            Console.ResetColor();
        }

        /// <summary>
        /// Дозволяє змінити параметри існуючого товару (назву, ціну, кількість або категорію) за його ID.
        /// </summary>
        static void EditProduct()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nВведіть ID товару для редагування: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                List<Product> products = CSV.LoadProducts();
                Product product = products.FirstOrDefault(x => x.Id == id);

                if (!product.IsEmpty())
                {
                    Console.WriteLine($"Редагуємо: {product.Name}");

                    Console.Write("Нова назва: ");
                    string? value = Console.ReadLine();
                    if (!string.IsNullOrEmpty(value)) product.Name = value;

                    Console.Write("Нова ціна: ");
                    value = Console.ReadLine();
                    if (!string.IsNullOrEmpty(value) && int.TryParse(value, out int price)) product.Price = price;

                    Console.Write("Нова кількість: ");
                    value = Console.ReadLine();
                    if (!string.IsNullOrEmpty(value) && int.TryParse(value, out int quantity)) product.Quantity = quantity;

                    Console.Write("Нова категорія: ");
                    value = Console.ReadLine();
                    if (!string.IsNullOrEmpty(value)) product.Category = value;

                    CSV.RewriteProducts(products);
                    Console.WriteLine("Зміни збережено.");
                }
                else
                {
                    Console.WriteLine("Товар не знайдено.");
                }
                Stop();
            }
        }

        /// <summary>
        /// Виводить на екран повний список усіх товарів у вигляді відформатованої таблиці.
        /// </summary>
        static void ShowProducts()
        {
            Console.Clear();
            List<Product> products = CSV.LoadProducts();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Всього товарів: {products.Count}");
            Console.WriteLine("========= Наші товари =========");

            Console.WriteLine(new string('=', 75));
            Console.WriteLine($"| {"ID",-3} | {"Назва",-20} | {"Категорія",-12} | {"Ціна",14} | {"К-сть",9} |");
            Console.WriteLine(new string('=', 75));
            foreach (var product in products)
            {
                product.ShowInfo();
            }
            Console.WriteLine(new string('=', 75));
            if (products.Count == 0)
            {
                Console.WriteLine("Список товарів порожній.");
            }
            Stop();
            Console.ResetColor();
        }

        /// <summary>
        /// Обчислює та відображає статистичні дані магазину: загальну кількість товарів,
        /// сумарну вартість складу, середню ціну, а також найдорожчий та найдешевший товари.
        /// </summary>
        static void ShowStatistic()
        {
            List<Product> products = CSV.LoadProducts();
            Console.ForegroundColor = ConsoleColor.Blue;
            if (products.Count == 0) {
                Console.WriteLine("Немає даних для статистики.");
                return;
            }
            Console.WriteLine("\n======== СТАТИСТИКА ========");

            int count = products.Count;
            int totalStock = products.Sum(p => p.Quantity);
            double totalValue = products.Sum(p => p.Price * p.Quantity);
            double avgPrice = products.Average(p => p.Price);
            int minPrice = products.Min(p => p.Price);
            int maxPrice = products.Max(p => p.Price);

            Console.WriteLine($"Кількість товарів: {count}");
            Console.WriteLine($"Всього одиниць на складі: {totalStock}");
            Console.WriteLine($"Загальна вартість складу: {totalValue} грн");
            Console.WriteLine($"Середня ціна: {avgPrice:F2} грн");
            Console.WriteLine($"Діапазон цін: {minPrice} - {maxPrice} грн");

            Console.ResetColor();
            Stop();
        }

        /// <summary>
        /// Відображає поточні акції та знижки магазину.
        /// </summary>
        static void ShowActionsAndDiscounts()
        {
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

        /// <summary>
        /// Відображає контактну інформацію служби підтримки клієнтів.
        /// </summary>
        static void ShowCustomerSupport()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("====================================");
            Console.WriteLine("========ПІДТРИМКА КЛІЄНТІВ==========");
            Console.WriteLine("====================================");
            Console.WriteLine("Телефон: +380 97 000 4716");
            Console.WriteLine("Електронна пошта: c.hordynskyi.vadym@student.uzhnu.edu.ua");
            Console.WriteLine("====================================");
            Stop();
        }

        /// <summary>
        /// Функція паузи для очікування натискання клавіші користувачем.
        /// </summary>
        static void Stop()
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутись...");
            Console.ReadKey();
        }

        /// <summary>
        /// Функція виходу з програми з повідомленням.
        /// </summary>
        static void Exit()
        {
            Console.WriteLine("Вихід з програми. До побачення!");
            Console.ReadKey();
            Environment.Exit(1);
        }

        /// <summary>
        /// Симулює процес оформлення замовлення.
        /// Дозволяє обрати кількість техніки, розраховує загальну суму та автоматично нараховує знижку (10%, 15% або 20%).
        /// </summary>
        static void OrderElectronics()
        {
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