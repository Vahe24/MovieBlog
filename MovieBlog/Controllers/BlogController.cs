using Microsoft.AspNetCore.Mvc;
using MovieBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlog.Controllers
{
    public class BlogController : Controller
    {
        ApplicationContext db;
        public BlogController(ApplicationContext d)
        {
            db = d;
        }
        [Route("Blog/OldBlogs/")]
        public IActionResult BlogIndex()
        {
            ViewBag.Blog = db.AdminBlogs.OrderByDescending(x => x.Time).ToList();
            return View();
        }
      
        public IActionResult BlogSingle(int id)
        {
            ViewBag.BlogPost = db.AdminBlogs.Find(id);
            return View();
        }
    }
}
