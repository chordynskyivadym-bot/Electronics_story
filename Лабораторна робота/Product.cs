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

        public void ShowInfo()
        {
            Console.WriteLine($"| {Id,-3} | {Name,-20} | {Category,-12} | {Price,10} грн | {Quantity,5} шт. |");
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(Name);
        }

        public string ToCsv()
        {
            return $"{Id},{Name},{Price},{Quantity},{Category}";
        }
    }
}
