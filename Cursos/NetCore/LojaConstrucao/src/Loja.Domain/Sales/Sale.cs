using System;
using System.Collections.Generic;
using Loja.Domain.Products;

namespace Loja.Domain.Sales {

    public class Sale: Entity{

        public string ClientName {get; private set;}
        public DateTime CreateOn {get; private set;}
        public decimal Total {get; private set;}
        public SaleItem Item  {get; private set;}

        private Sale() {}

        public Sale(string clientName, Product product, int quantity){
            DomainException.When(string.IsNullOrEmpty(clientName), "Nome do cliente é obrigatorio");
            Item = new SaleItem(product, quantity);
            CreateOn = DateTime.Now;
            ClientName = clientName;    
        }
    }
}