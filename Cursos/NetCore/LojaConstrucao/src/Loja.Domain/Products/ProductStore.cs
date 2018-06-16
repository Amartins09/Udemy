namespace Loja.Domain.Products{

    public class ProductStore{
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductStore(IRepository<Product> productRepository, IRepository<Category> categoryRepository){
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public void Store(int id, string name, int categoryId, decimal price, int stockQuantity){
            var category = _categoryRepository.GetById(categoryId);
            DomainException.When(category==null, "Categotia invalida");

            var product = _productRepository.GetById(id);

            if (product==null){
                product = new Product(name, category, price, stockQuantity);
                _productRepository.Save(product);
            } else {
                product.Update(name, category, price, stockQuantity);
            }
        }
    }
}