namespace Loja.Domain.Products{

    public class Product{

        public int Id {get; private set;}
        public string Name {get; private set;}
        public Category Category {get; private set;}
        public decimal Price {get; private set;}
        public int StockQuantityantity {get; private set;}

        public Product(string name, Category category, decimal price, int stockQuantityantity)
        {
            ValidateValues(name, category, price, stockQuantityantity);
            SetProperties(name, category, price, stockQuantityantity);
        }

        public void Update(string name, Category category, decimal price, int stockQuantityantity)
        {
            ValidateValues(name, category, price, stockQuantityantity);
            SetProperties(name, category, price, stockQuantityantity);
        }

        private void SetProperties(string name, Category category, decimal price, int stockQuantityantity)
        {
            Name = name;
            Category = category;
            Price = price;
            StockQuantityantity = stockQuantityantity;
        }

        private static void ValidateValues(string name, Category category, decimal price, int stockQuantityantity)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Nome do produto é obrigatorio");
            DomainException.When(category == null, "Categoria é obrigatorio");
            DomainException.When(price < 0, "Preço maior que 0");
            DomainException.When(stockQuantityantity < 0, "Não é permitido estoque negativo");
        }
    }    
}