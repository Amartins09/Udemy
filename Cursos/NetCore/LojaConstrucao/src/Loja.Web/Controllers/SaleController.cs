using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Loja.Domain;
using Loja.Domain.Products;
using Loja.Domain.Sales;
using Loja.Web.ViewsModels;

namespace Loja.Web.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private readonly SaleFactory _saleFactory;
        private readonly IRepository<Product> _productRepository;
    

        public SaleController(SaleFactory saleFactory, IRepository<Product> productRepository)
        {
            _saleFactory = saleFactory;
            _productRepository = productRepository;
        }
        
        public IActionResult Create()
        {
            var products = _productRepository.All();
            
            var productsViewModel = products.Select(c => new ProductViewModel{ Id = c.Id, Name = c.Name });
            return View(new SaleViewModel{Products = productsViewModel});
        }

        [HttpPost]
        public IActionResult Create(SaleViewModel viewModel)
        {
            _saleFactory.Create(viewModel.ClientName, viewModel.ProductId, viewModel.Quantity);
            return Ok();
        }
    }
}