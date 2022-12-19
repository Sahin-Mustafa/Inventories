using Inventories.Entities;
using Inventories.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Inventories.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            UserManager userManager = new();
            List<User> model = userManager.GetAllUsers();
            return View(model);
        }
    }
}
