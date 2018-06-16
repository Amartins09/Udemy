namespace Loja.Domain.Products{

    public class Product{
        public string Name {get; private set;}
        public Category Category {get; private set;}
        public decimal Price {get; private set;}
        public int StockQuantity {get; private set;}

        private Product(){}

        public Product(string name, Category category, decimal price, int stockQuantity)
        {
            ValidateValues(name, category, price, stockQuantity);
            SetProperties(name, category, price, stockQuantity);
        }

        public void Update(string name, Category category, decimal price, int stockQuantity)
        {
            ValidateValues(name, category, price, stockQuantity);
            SetProperties(name, category, price, stockQuantity);
        }

        private void SetProperties(string name, Category category, decimal price, int stockQuantity)
        {
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
        }

        private static void ValidateValues(string name, Category category, decimal price, int stockQuantity)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Nome do produto é obrigatorio");
            DomainException.When(category == null, "Categoria é obrigatorio");
            DomainException.When(price < 0, "Preço maior que 0");
            DomainException.When(stockQuantity < 0, "Não é permitido estoque negativo");
        }

        public void RemoverFromStock(int quantity){
            DomainException.When((StockQuantity - quantity) < 0, "Quantidade insuficiente de estoque");
            StockQuantity -= quantity;
        }
    }    
}