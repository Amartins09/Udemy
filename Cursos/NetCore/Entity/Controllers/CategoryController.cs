using System.Linq;
using Entity.Data;
using Entity.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Entity.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context){
            _context = context;
        }

        public IActionResult Index(int id){
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;

            var CategorySelected = _context.Categories.FirstOrDefault(c => c.Id == id);
            return View(CategorySelected);
        }

        [HttpPost]
        public IActionResult Register(Category category){
            if (category.Id == 0)
                _context.Categories.Add(category);
            else{
                var categorySaved = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
                categorySaved.Name = category.Name;
                _context.Categories.Update(categorySaved);
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id){
            var CategorySelected = _context.Categories.FirstOrDefault(c => c.Id == id);
            _context.Categories.Remove(CategorySelected);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}