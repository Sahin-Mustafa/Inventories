using Inventories.Entities;
using Inventories.Helpers;
using Inventories.Models;
using Inventories.Models.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Inventories.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            int? userid = HttpContext.Session.GetInt32("userid");

            if (userid == null)
            {
                return RedirectToAction("Login", "Account");
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
                return RedirectToAction("Login", "Account");
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
        private static SelectList GetAllDepartmansView(RegisterModel model)
        {

            DepartmanManager departmanManager = new();
            List<Departman> departmen = departmanManager.GetAllDepartmans();
            model.Departmans = new SelectList(departmen, "Id", "DepartmanName");


            return model.Departmans;
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
