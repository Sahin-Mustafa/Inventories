using Inventories.Entities;
using Inventories.Helpers;
using Inventories.Models.Departman;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inventories.Controllers
{
    public class DepartmanController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            DepartmanManager departmanManager = new();
            List<Departman> model = departmanManager.GetAllDepartmans();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            int? userid = HttpContext.Session.GetInt32("userid");

            if (userid == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateModel model)
        {
            int? userid = HttpContext.Session.GetInt32("userid");

            if (userid == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                DepartmanManager departmanManager = new DepartmanManager();
                departmanManager.CreateDepartman(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Hata var");
            }

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

            DepartmanManager departmanManager = new DepartmanManager();
            Departman departman = departmanManager.GetDepartmanById(id);

            // Kayıt başkası tarafından silinmiş ise
            // note = null gelecek. Dolayısı ile Index e yönlendiririz.
            // Böylece veriler tekrar listelenir ve silinen kayıtlar gelmemiş olur.
            if (departman == null)
            {
                return RedirectToAction(nameof(Index));
            }

            EditModel model = new EditModel()
            {
                DepartmanName = departman.DepartmanName,
                JobDescription = departman.JobDescription

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditModel model)
        {
            if (ModelState.IsValid)
            {
                DepartmanManager departmanManager = new DepartmanManager();
                departmanManager.EditById(id, model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return Edit(id);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            DepartmanManager departmanManager = new DepartmanManager();
            departmanManager.RemoveById(id);

            return RedirectToAction(nameof(Index));
        }

    }
}

