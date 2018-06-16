using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Loja.Web.Models;
using Loja.Domain.Products;
using Loja.Web.ViewModel;

namespace Loja.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryStore _categoryStore;

        public CategoryController(CategoryStore categoryStore){
            _categoryStore = categoryStore;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateOrEdit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel viewModel)
        {
            _categoryStore.Store(viewModel.Id, viewModel.Name);
            return View();
        }
    }
}
