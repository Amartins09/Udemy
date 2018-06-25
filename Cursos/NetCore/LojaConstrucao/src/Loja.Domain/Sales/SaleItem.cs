using System;
using System.Collections.Generic;
using Loja.Domain.Products;

namespace Loja.Domain.Sales{

    public class SaleItem : Entity {

        public Product Product {get; set;}
        public decimal Price {get; set;}
        public int Quantity {get; set;}
        public decimal Total  {get; set;}

        private SaleItem() { }

        public SaleItem(Product product, int quantity){
            DomainException.When(product == null, "Produto é obrigatorio");
            DomainException.When(quantity < 1, "Quantidade invalida");

            Product = product;
            Price = Product.Price;
            Quantity = quantity;
            Total = Price * Quantity;
        }
    }
}