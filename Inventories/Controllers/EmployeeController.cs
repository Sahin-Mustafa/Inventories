using Inventories.Entities;
using Inventories.Helpers;
using Inventories.Models.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Inventories.Controllers
{
    public class EmployeeController : Controller
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
                return RedirectToAction("Login", "Employee");
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
            model.Departmans = new SelectList(departmen, "Id", "DepartmanName");


            return model.Departmans;
        }


        [HttpGet]
        public IActionResult Index()
        {
            int? userid = HttpContext.Session.GetInt32("userid");

            if (userid == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            UserManager userManager = new();
            List<User> model = userManager.GetAllUsers();
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            int? userid = HttpContext.Session.GetInt32("userid");

            if (userid == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            UserManager userManager = new();
            User user = userManager.GetUserById(id);

            EditModel model = new EditModel()
            {
                Username= user.Username,
                Password= user.Password,
                Name=user.Name,
                Surname =user.Surname,
                StartDateJob = user.StartDateJob,
                IsBreak=user.IsBreak,
                DepartmanName=user.Departman.DepartmanName
                
            };
            model.EmploymentDate =model.IsBreak?user.EmploymentDate:null;
            model.Departmans = GetAllDepartmansView(model);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditModel model)
        {
            if (ModelState.IsValid)
            {
                UserManager userManager= new UserManager();
                userManager.EditById(id, model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return Edit(id);
        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            UserManager userManager= new UserManager();
            userManager.RemoveById(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
