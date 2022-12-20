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

            RegisterModel model = GetAllDepartmansView();
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
            model = GetAllDepartmansView();
            return View(model);
        }
        private static RegisterModel GetAllDepartmansView()
        {
            RegisterModel model = new RegisterModel();
            model.Departmans = new List<SelectListItem>();
            DepartmanManager departmanManager = new();
            List<Departman> departmen = departmanManager.GetAllDepartmans();
            foreach (Departman item in departmen)
            {
                model.Departmans.Add(new SelectListItem { Text = item.DepartmanName, Value = item.Id.ToString() });
            }

            return model;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
