namespace electronics_store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int valueNotebook = 1000;
            int valueSmartphone = 500;
            int valueTablet = 700;
            int valueРeadphone = 400;
            int valueTV = 1200;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=== Магазин електроніки ===");
            Console.ResetColor();
            Console.WriteLine($"1. Ноутбук, {valueNotebook}"); 
            Console.WriteLine($"2. Смартфон, {valueSmartphone}");
            Console.WriteLine($"3. Планшет, {valueTablet}");
            Console.WriteLine($"4. Навушники, {valueРeadphone}");
            Console.WriteLine($"5. Телевізор, {valueTV}");
        }
    }
}
