using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ProductController: Controller
    {
        [HttpGet]
        public IActionResult Save(){
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Save(Product prod){
            if (!ModelState.IsValid) 
              ViewBag.Validacao = "Produto invalido para cadastro";

            return View(prod);
        }

        [HttpGet("{id:int}")]
        public int Get(int id)
        {
            return id;
        }

        [HttpGet]
        public string Path(){
            return HttpContext.Request.Path;
        }

        public IActionResult Error(){
            return new BadRequestResult();
        }

        [HttpGet]
        public string Params(){
            return HttpContext.Request.Query["param"];
        }
    }
}