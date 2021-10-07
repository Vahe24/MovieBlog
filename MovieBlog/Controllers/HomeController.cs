using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieBlog.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlog.Controllers
{
    
    public class HomeController : Controller
    {
        ApplicationContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ApplicationContext d)
        {
            db = d;
            _logger = logger;
        }
        [Route("MovieCesar")]
        public IActionResult Index()
        {
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
