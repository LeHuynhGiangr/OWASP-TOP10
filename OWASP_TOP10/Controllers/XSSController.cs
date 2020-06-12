using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OWASP_TOP10.Controllers
{
    public class XSSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string content)
        {
            return View();
        }
    }
}