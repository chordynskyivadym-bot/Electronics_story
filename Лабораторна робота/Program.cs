namespace electronics_store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int valueNotebook = 1000;
            int valueSmartphone = 500;
            int valueTablet = 700;
            int valueHeadphone = 400;
            int valueTV = 1200;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=== Магазин електроніки ===");
            Console.ResetColor();
            Console.WriteLine($"1. Ноутбук, {valueNotebook}$"); 
            Console.WriteLine($"2. Смартфон, {valueSmartphone}$");
            Console.WriteLine($"3. Планшет, {valueTablet}$");
            Console.WriteLine($"4. Навушники, {valueHeadphone}$");
            Console.WriteLine($"5. Телевізор, {valueTV} $");

            Console.Write("\nВиберіть кількість ноутбуків: ");
            int countNotebook = int.Parse(Console.ReadLine());
            Console.Write("Виберіть кількість смартфонів: ");
            int countSmartphone = int.Parse(Console.ReadLine());
            Console.Write("Виберіть кількість планшетів: ");
            int countTablet = int.Parse(Console.ReadLine());
            Console.Write("Виберіть кількість навушників: ");
            int countHeadphone = int.Parse(Console.ReadLine());
            Console.Write("Виберіть кількість телевізорів: ");
            int countTV = int.Parse(Console.ReadLine());

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

            Random random = new Random();
            int discount = random.Next(5, 30);
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
        }
    }
}
