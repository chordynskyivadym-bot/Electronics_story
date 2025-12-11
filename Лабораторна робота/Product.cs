namespace electronics_store {
    public struct Product {
        private static int Id_Start;
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Price { get; set; } = 0;
        public int Quantity { get; set; }
        public string Category { get; set; }
        public Product(string name, int price, int quantity, string category) {
            Id = ++Id_Start;
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }
        public void ShowInfo() {
            Console.WriteLine($"| {Id,-3} | {Name,-20} | {Category,-12} | {Price,10} грн | {Quantity,5} шт. |");
        }
        public bool IsEmpty() {
            return String.IsNullOrWhiteSpace(Name);
        }
        public string ToCsv() {
            return $"{Id},{Name},{Price},{Quantity},{Category}";
        }
    }
}
