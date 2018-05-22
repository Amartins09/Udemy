using Loja.Domain.Dtos;

namespace Loja.Domain.Products{

    public class CategoryStore{

        public IRepository<Category> _categoryRepository { get; }

        public CategoryStore(IRepository<Category> categoryRepository){
            _categoryRepository = categoryRepository;
        }

        public void Store(CategoryDto dto){
            var category = _categoryRepository.GetById(dto.Id);

            if (category==null){
                category = new Category(dto.Name);
                _categoryRepository.Save(category);
            } else {
                category.Update(dto.Name);
            }
        }
    }
}