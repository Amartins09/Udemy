namespace Loja.Domain.Products{
    
    public class Category : Entity{
        
        public string Name {get; private set;}

        public Category(){}

        public Category(string name)
        {
            ValidateAndSetProperties(name);
        }

        public void Update(string name){
            ValidateAndSetProperties(name);
        }

        private void ValidateAndSetProperties(string name)
        {
            DomainException.When(string.IsNullOrEmpty(name), "O nome da Categoria é obrigatorio");
            DomainException.When(name.Length < 3, "Tamanho invalido");

            Name = name;
        }
    }
}