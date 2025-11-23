namespace electronics_store {
     struct Product {
        public string Name { get; set; } = "";
        public int Price { get; set; } = 0;
        public int quantity;
        public string category { get; set; }
        public Product(string name, int price, int quantity, string category) {
            this.Name = name;
            this.Price = price;
            this.quantity = quantity;
            this.category = category;
        }
        public void ShowInfo() {
            Console.WriteLine($"Назва: {Name}, Ціна: {Price}, Кількість: {quantity}, Категорія: {category}");
        }
        public bool IsEmpty() {
            return String.IsNullOrWhiteSpace(Name);
        }
    }
}
