using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace OWASP_TOP10.Controllers
{
    public class SqlInjectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(string category)
        {
            var service = new ProductDomain();
            var products = service.GetByCategoryName(category);
            return View(products);
        }
    }
}