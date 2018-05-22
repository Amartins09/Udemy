using Loja.Domain.Dtos;

namespace Loja.Domain.Products{

    public class ProductStore{
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductStore(IRepository<Product> productRepository, IRepository<Category> categoryRepository){
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public void Store(ProductDto dto){
            var category = _categoryRepository.GetById(dto.CategoryId);
            DomainException.When(category==null, "Categotia invalida");

            var product = _productRepository.GetById(dto.Id);
            if (product==null){
                product = new Product(dto.Name, category, dto.Price, dto.StockQuantityantity);
                _productRepository.Save(product);
            } else {
                product.Update(dto.Name, category, dto.Price, dto.StockQuantityantity);
            }
        }
    }
}