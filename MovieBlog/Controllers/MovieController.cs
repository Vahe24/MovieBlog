using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlog.Controllers
{
    public class MovieController : Controller
    {
        ApplicationContext db;
        public MovieController(ApplicationContext d)
        {
            db = d;
        }
        [Route("Movie/Watch/")]
        public IActionResult MovieIndex()
        {
            var result = db.AdminMovies.OrderByDescending(x => x.Latest).ToList();
            return View(result);
        }
       

        //[HttpGet]
        //public IActionResult Search(string prefix)
        //{

        //    //var result = db.AdminMovies.Where(p => EF.Functions.Like(p.Title, $"%{prefix}%"))
        //    //    .OrderByDescending(x => x.Latest).ToList();
        //    var result = db.AdminMovies.Where(p => p.Title.Contains(prefix) || p.Text.Contains(prefix))
        //        .OrderByDescending(x => x.Latest).ToList();

        //    return View("MovieIndex", result);
        //}

        [HttpGet]
        public JsonResult Search(string prefix)
        {
            List<MovieBlog.Models.Movies.Movie> result = new List<Models.Movies.Movie>();
            if (prefix !=null)
            {
                result = db.AdminMovies.Where(p => p.Title.Contains(prefix) || p.Text.Contains(prefix))
                                    .OrderByDescending(x => x.Latest).ToList();
            }
            else
            {
                result = db.AdminMovies.OrderByDescending(x => x.Latest).ToList();
            }          
            return Json(result);
        }
        //public IActionResult MovieSingle(int id)
        //{
        //    ViewBag.MoviePost = db.AdminMovies.Find(id);
        //    return View();
        //}
    }
}
