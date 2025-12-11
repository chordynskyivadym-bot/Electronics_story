using System.Security.Cryptography;
using System.Text;

namespace electronics_store {
    internal class Authorization {
        private static string HashPassword(string password) {
            using (var sha256 = SHA256.Create()) {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        public static void Register() {
            Console.WriteLine("\n--- РЕЄСТРАЦІЯ ---");
            Console.Write("Введіть Email: ");
            string email = Console.ReadLine().Trim();

            List<User> users = CSV.LoadUsers();
            if (users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase))) {
                Console.WriteLine("Користувач з таким Email вже існує!");
                return;
            }

            Console.Write("Введіть пароль: ");
            string password = Console.ReadLine();

            User newUser = new User {
                Email = email,
                PasswordHash = HashPassword(password)
            };

            CSV.AppendUser(newUser);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Реєстрація успішна! Тепер ви можете увійти.");
            Console.ResetColor();
        }

        public static bool Login() {
            Console.WriteLine("\n--- АВТОРИЗАЦІЯ ---");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Пароль: ");
            string pass = Console.ReadLine();

            string inputHash = HashPassword(pass);
            List<User> users = CSV.LoadUsers();

            var user = users.FirstOrDefault(u => u.Email == email && u.PasswordHash == inputHash);

            if (!user.Equals(default(User))) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Вітаємо, {user.Email}!");
                Console.ResetColor();
                return true;
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Невірний логін або пароль.");
                Console.ResetColor();
                return false;
            }
        }
    }
}

