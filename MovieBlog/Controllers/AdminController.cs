using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBlog.Models;
using MovieBlog.Models.Admins;
using MovieBlog.ViewModels;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieBlog.Controllers
{
    public class AdminController : Controller
    {
        ApplicationContext db;

        public AdminController(ApplicationContext d)
        {

            db = d;
        }


        [HttpGet]
        public IActionResult Index()
        {
            Admin a = new Admin { Email = "mr.vahe24@mail.ru", Password = "123" };
            bool t = db.Admins.Any(x => x.Email == a.Email && x.Password == a.Password);
            if (!t)
            {
                db.Admins.Add(a);
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Admin user = await db.Admins.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return View("AdminMenu");
                }
                ModelState.AddModelError("", "Wrong Password or Login!");
            }
            return View(model);
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Admin");
        }
        [Authorize]
        public IActionResult AdminMenu()
        {
            return View();
        }
    }
}