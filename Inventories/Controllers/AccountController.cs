using Inventories.Entities;
using Inventories.Helpers;
using Inventories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserManager userManager = new();
                User user = userManager.Authenticate(model.Username, model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("userid", user.Id);
                    HttpContext.Session.SetString("username", user.Username);
                    HttpContext.Session.SetString("ispurchasing", !user.Username.Contains("admin") ? user.Departman?.DepartmanName : "admin");
                    return RedirectToAction("Index", "Material");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Kullanıcı veya Şifre!");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            int? userid = HttpContext.Session.GetInt32("userid");

            if (userid == null)
            {
                return RedirectToAction("Login", "Account");
            }
            RegisterModel model = new RegisterModel();
            model.Departmans = GetAllDepartmansView(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            UserManager userManager = new();
            if (ModelState.IsValid)
            {
                //var selectedDepartman = model.SelectedDepartman; --> id string
                bool done = userManager.AddUser(model);

                ViewData["done"] = done;
            }
            model.Departmans = GetAllDepartmansView(model);
            return View(model);
        }
        private static SelectList GetAllDepartmansView(RegisterModel model)
        {
            
            DepartmanManager departmanManager = new();
            List<Departman> departmen = departmanManager.GetAllDepartmans();
            model.Departmans = new SelectList (departmen, "Id","DepartmanName");
            

            return model.Departmans;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            int? userid = HttpContext.Session.GetInt32("userid");

            if (userid == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
