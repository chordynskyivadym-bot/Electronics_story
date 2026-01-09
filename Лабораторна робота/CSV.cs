using System.Text;

namespace Electronics_store
{
    public static class CSV
    {
        private const string ProductsFile = "products.csv";
        private const string UsersFile = "users.csv";
        private const string ProductHeader = "Id,Name,Price,Quantity,Category";
        private const string UserHeader = "Id,Username,Password";

        /// <summary>
        /// Зчитує список товарів із файлу products.csv.
        /// Парсить кожен рядок файлу та перетворює його на об'єкт структури Product.
        /// Обробляє помилки пошкоджених рядків.
        /// </summary>
        /// <returns>Повертає список об'єктів Product.</returns>
        public static List<Product> LoadProducts()
        {
            var list = new List<Product>();

            if (!File.Exists(ProductsFile))
            {
                File.WriteAllText(ProductsFile, ProductHeader + Environment.NewLine);
                return list;
            }

            var lines = File.ReadAllLines(ProductsFile);
            if (lines.Length == 0 || lines[0] != ProductHeader)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Шапка файлу products.csv пошкоджена або відсутня.");
                Console.ResetColor();
                File.WriteAllText(ProductsFile, ProductHeader + Environment.NewLine, Encoding.UTF8);
                return list;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                try
                {
                    var parts = line.Split(',');
                    if (parts.Length != 5)
                    {
                        continue;
                    }

                    var p = new Product
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Price = int.Parse(parts[2]),
                        Quantity = int.Parse(parts[3]),
                        Category = parts[4],
                    };
                    list.Add(p);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Помилка у рядку {i + 1}: {ex.Message}. Рядок пропущено.");
                    Console.ResetColor();
                }
            }

            return list;
        }

        /// <summary>
        /// Додає новий товар у кінець файлу products.csv, автоматично генеруючи для нього новий ID.
        /// </summary>
        /// <param name="p">Об'єкт товару, який потрібно зберегти.</param>
        public static void AppendProduct(Product p)
        {
            p.Id = GetNextId(ProductsFile);
            File.AppendAllText(ProductsFile, p.ToCsv() + Environment.NewLine, Encoding.UTF8);
        }

        /// <summary>
        /// Повністю перезаписує файл products.csv оновленим списком товарів.
        /// Використовується після видалення або редагування записів.
        /// </summary>
        /// <param name="products">Актуальний список товарів.</param>
        public static void RewriteProducts(List<Product> products)
        {
            var sb = new StringBuilder();
            sb.AppendLine(ProductHeader);
            foreach (var p in products)
            {
                sb.AppendLine(p.ToCsv());
            }

            File.WriteAllText(ProductsFile, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// Завантажує список користувачів із файлу users.csv.
        /// </summary>
        /// <returns>Повертає новий відредагований список.</returns>
        public static List<User> LoadUsers()
        {
            var list = new List<User>();
            if (!File.Exists(UsersFile))
            {
                File.WriteAllText(UsersFile, UserHeader + Environment.NewLine, Encoding.UTF8);
                return list;
            }

            var lines = File.ReadAllLines(UsersFile, Encoding.UTF8);

            foreach (var line in lines.Skip(1))
            {
                try
                {
                    var parts = line.Split(',');
                    if (parts.Length < 3)
                    {
                        continue;
                    }

                    list.Add(new User
                    {
                        Id = int.Parse(parts[0]),
                        Email = parts[1],
                        PasswordHash = parts[2],
                    });
                }
                catch
                {
                    continue;
                }
            }

            return list;
        }

        /// <summary>
        /// Додає нового користувача у файл users.csv з унікальним ID.
        /// </summary>
        /// <param name="user"></param>
        public static void AppendUser(User user)
        {
            user.Id = GetNextId(UsersFile);
            File.AppendAllText(UsersFile, user.ToCsv() + Environment.NewLine, Encoding.UTF8);
        }

        /// <summary>
        /// Генерує наступний унікальний ID для запису на основі максимального існуючого ID у файлі.
        /// </summary>
        /// <param name="filePath">Шлях до файлу (products.csv або users.csv).</param>
        /// <returns>Новий ідентифікатор.</returns>
        private static int GetNextId(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return 1;
            }

            var lines = File.ReadAllLines(filePath).Skip(1);
            int max = 0;
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (int.TryParse(parts[0], out int id))
                {
                    if (id > max)
                    {
                        max = id;
                    }
                }
            }

            return max + 1;
        }
    }
}
