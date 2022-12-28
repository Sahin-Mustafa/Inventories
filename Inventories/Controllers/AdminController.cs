using Inventories.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventories.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Admin model)
        {
            if (ModelState.IsValid)
            {
                DatabaseContext db = new DatabaseContext();
                Admin user = db.Admins.FirstOrDefault(x => x.Name == model.Name && x.Password == model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("userid", user.Id);
                    HttpContext.Session.SetString("username", user.Name);
                    HttpContext.Session.SetString("ispurchasing", user.Name);
                    return RedirectToAction("Index", "Material");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Kullanıcı veya Şifre!");
                }
            }
            return View(model);
        }
    }
}
