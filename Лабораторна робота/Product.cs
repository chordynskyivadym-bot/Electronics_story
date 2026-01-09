namespace Electronics_store
{
    public struct Product
    {
        public Product(string name, int price, int quantity, string category)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
            Id = 0;
        }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Price { get; set; } = 0;

        public int Quantity { get; set; }

        public string Category { get; set; }

        /// <summary>
        /// Виводить форматовану інформацію про товар у консоль (один рядок таблиці).
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"| {Id,-3} | {Name,-20} | {Category,-12} | {Price,10} грн | {Quantity,5} шт. |");
        }

        /// <summary>
        /// Функція перевіряє, чи є товар порожнім (без назви).
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(Name);
        }

        /// <summary>
        /// Перетворює об'єкт товару у рядок формату CSV для запису у файл.
        /// </summary>
        /// <returns>Рядок, де поля розділені комами.</returns>
        public string ToCsv()
        {
            return $"{Id},{Name},{Price},{Quantity},{Category}";
        }
    }
}
