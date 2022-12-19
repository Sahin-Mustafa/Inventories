using Inventories.Entities;
using Inventories.Helpers;
using Inventories.Models.Material;
using Microsoft.AspNetCore.Mvc;

namespace Inventories.Controllers
{
    public class MaterialController : Controller
    {
        public IActionResult Index()
        {
            MaterialManager materialManager = new();
            List<Material> model = materialManager.GetAllMaterials();
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
                MaterialManager materialManager = new MaterialManager();
                materialManager.CreateMaterial(model);
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

            MaterialManager materialManager = new MaterialManager();
            Material material = materialManager.GetMaterialById(id);

            // Kayıt başkası tarafından silinmiş ise
            // note = null gelecek. Dolayısı ile Index e yönlendiririz.
            // Böylece veriler tekrar listelenir ve silinen kayıtlar gelmemiş olur.
            if (material == null)
            {
                return RedirectToAction(nameof(Index));
            }

            EditModel model = new EditModel()
            {
                MaterialName = material.MaterialName,
                MaterialDescription = material.MaterialDescription,
                IsSecondHane = material.IsSecondHane,
                Price = material.Price,
                Stock   = material.Stock,
                SerialNumber =material.SerialNo
                

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditModel model)
        {
            if (ModelState.IsValid)
            {
                MaterialManager materialManager = new MaterialManager();
                materialManager.EditById(id, model);

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
            MaterialManager materialManager = new MaterialManager();
            materialManager.RemoveById(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
