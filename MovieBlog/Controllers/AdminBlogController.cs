using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MovieBlog.Models;
using MovieBlog.Models.Blogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MovieBlog.Controllers
{
    public class AdminBlogController : Controller
    {
        ApplicationContext db;
        private readonly IHostingEnvironment _environment;
        public AdminBlogController(IHostingEnvironment IHostingEnvironment, ApplicationContext d)
        {
            _environment = IHostingEnvironment;
            db = d;
        }

        [HttpGet]
        public IActionResult AdminBlog()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminBlog = db.AdminBlogs.ToList();
                return View();
            }
            else
            {
                return Redirect("~/Admin/Index");
            }
        }
        [HttpPost]
        public IActionResult AdminBlog(Blog model)
        {
            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;

                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                       
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var FileExtension = Path.GetExtension(fileName);
                        newFileName = myUniqueFileName + FileExtension;
                        fileName = Path.Combine(_environment.WebRootPath, "Files") + $@"\{newFileName}";
                        model.ImagePath = "Files/" + newFileName;
                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                        //Blog m = new Blog { ImagePath = PathDB, Title = title, Autor = autor, Text = text, Time = DateTime.Now, BigText = bigtext };
                        db.Add(model);
                        db.SaveChanges();
                    }

                }
            }


            ViewBag.AdminBlog = db.AdminBlogs.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int hid)
        {
            Blog slider = db.AdminBlogs.Find(hid);
            if (slider != null)
            {
                db.AdminBlogs.Remove(slider);
                db.SaveChanges();
            }
            ViewBag.AdminBlog = db.AdminBlogs.ToList();
            return View("AdminBlog");
        }
    }
}
    

