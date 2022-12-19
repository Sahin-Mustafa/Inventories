using Microsoft.AspNetCore.Mvc;

namespace Inventories.Controllers
{
    public class AppropriateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
