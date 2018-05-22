namespace Loja.Domain.Products{
    
    public class Category{

        public int Id {get; private set;}
        public string Name {get; private set;}

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

            Name = name;
        }
    }
}