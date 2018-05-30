using Loja.Domain.Dtos;

namespace Loja.Domain.Products{

    public class CategoryStore{

        public IRepository<Category> _categoryRepository { get; }

        public CategoryStore(IRepository<Category> categoryRepository){
            _categoryRepository = categoryRepository;
        }

        public void Store(int id, string name){
            var category = _categoryRepository.GetById(id);

            if (category==null){
                category = new Category(name);
                _categoryRepository.Save(category);
            } else {
                category.Update(name);
            }
        }
    }
}