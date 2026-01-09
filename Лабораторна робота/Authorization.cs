using System.Security.Cryptography;
using System.Text;

namespace Electronics_store
{
    internal class Authorization
    {
        /// <summary>
        /// Реєструє нового користувача в системі.
        /// Перевіряє унікальність Email та зберігає хеш пароля у файл users.csv.
        /// </summary>
        public static void Register()
        {
            Console.WriteLine("\n--- РЕЄСТРАЦІЯ ---");
            Console.Write("Введіть Email: ");
            string? email = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email не може бути порожнім!");
                Console.ResetColor();
                return;
            }

            List<User> users = CSV.LoadUsers();
            if (users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Користувач з таким Email вже існує!");
                return;
            }

            Console.Write("Введіть пароль: ");
            string? password = Console.ReadLine();

            if (string.IsNullOrEmpty(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Пароль не може бути порожнім!");
                Console.ResetColor();
                return;
            }

            User newUser = new User
            {
                Email = email,
                PasswordHash = HashPassword(password),
            };

            CSV.AppendUser(newUser);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Реєстрація успішна! Тепер ви можете увійти.");
            Console.ResetColor();
        }

        /// <summary>
        /// Перевіряє облікові дані користувача (Email та пароль) для входу в систему.
        /// </summary>
        /// <returns>Повертає true, якщо вхід успішний, та false, якщо дані невірні.</returns>
        public static bool Login()
        {
            Console.WriteLine("\n--- АВТОРИЗАЦІЯ ---");
            Console.Write("Email: ");
            string? email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email не може бути порожнім!");
                Console.ResetColor();
                return false;
            }

            Console.Write("Пароль: ");
            string? pass = Console.ReadLine();
            if (string.IsNullOrEmpty(pass))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Пароль не може бути порожнім!");
                Console.ResetColor();
                return false;
            }

            string inputHash = HashPassword(pass);
            List<User> users = CSV.LoadUsers();

            var user = users.FirstOrDefault(u => u.Email == email && u.PasswordHash == inputHash);

            if (!user.Equals(default(User)))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Вітаємо, {user.Email}!");
                Console.WriteLine("Ви успішно увійшли в систему.");
                Console.ReadKey();
                Console.ResetColor();
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Невірний логін або пароль.");
                Console.ResetColor();
                return false;
            }
        }

        /// <summary>
        /// Хешує пароль користувача, використовуючи алгоритм SHA256.
        /// Забезпечує безпеку збереження даних, перетворюючи пароль у незворотний рядок.
        /// </summary>
        /// <param name="password">Пароль у відкритому вигляді.</param>
        /// <returns>Повертає захешований пароль у форматі Base64.</returns>
        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
