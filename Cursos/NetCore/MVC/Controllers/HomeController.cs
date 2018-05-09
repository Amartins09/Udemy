using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private IPeopleRepository _peopleRepository;

        /* Modelo SEM Dependency Injection
        public HomeController(IPeopleRepository repository)
        {
            _peopleRepository = new PeopleRepository("http://SQLServer:8080");
        } */

        /* Modelo COM Dependency Injection */
        public HomeController(IPeopleRepository repository)
        {
            _peopleRepository = repository;
        }

        public IActionResult Index()
        {
            ViewData["Name"] = _peopleRepository.getNameById(2);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
