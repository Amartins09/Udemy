using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Loja.Domain;
using Loja.Domain.Products;
using Loja.Web.ViewsModels;

namespace Loja.Web.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class CategoryController : Controller
    {
        private readonly CategoryStore _categoryStore;
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(CategoryStore categoryStore, IRepository<Category> categoryRepository){
            _categoryStore = categoryStore;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepository.All();

            var ViewsModels = categories.Select(c => new CategoryViewModel{ Id = c.Id, Name = c.Name });
            return View(ViewsModels);
        }

        public IActionResult CreateOrEdit(int id)
        {
            if(id > 0)
            {
                var category = _categoryRepository.GetById(id);
                var categoryViewModel = new CategoryViewModel { Id = category.Id, Name = category.Name };
                return View(categoryViewModel);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel viewModel)
        {
            _categoryStore.Store(viewModel.Id, viewModel.Name);
            return RedirectToAction("Index");
        }
    }
}
