using Inventories.Entities;
using Inventories.Helpers;
using Inventories.Models.Appropriate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventories.Controllers
{
    public class AppropriateController : Controller
    {
        public IActionResult Index()
        {
            AppropriateManager appropriateManager = new();
            List<BaseModel> model = appropriateManager.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Create model = new Create();
            LoadDropDown(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Create model)
        {
            if (ModelState.IsValid)
            {
                MaterialUserManager materialUserManager = new();
                materialUserManager.AddAppropriate(model);
                return RedirectToAction(nameof(Index));
            }
            LoadDropDown(model);
            return View(model);
        }



        private static void LoadDropDown(Create model)
        {
            MaterialManager materialManager = new();
            UserManager userManager = new();
            List<Material> materials = materialManager.GetAllMaterials();
            List<User> users = userManager?.GetAllUsers();
            users = users.Where(x => !x.Username.Contains("admin")).ToList();

            model.Materials = new SelectList(materials, nameof(Material.Id), nameof(Material.MaterialName));
            model.Employees = new SelectList(users, nameof(Entities.User.Id), nameof(Entities.User.Name));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            int? userid = HttpContext.Session.GetInt32("userid");

            if (userid == null)
            {
                return RedirectToAction("Login", "Account");
            }

            MaterialUserManager materialUserManager = new MaterialUserManager();
            MaterialUser materialUser = materialUserManager.GetById(id);

            // Kayıt başkası tarafından silinmiş ise
            // note = null gelecek. Dolayısı ile Index e yönlendiririz.
            // Böylece veriler tekrar listelenir ve silinen kayıtlar gelmemiş olur.
            if (materialUser == null)
            {
                return RedirectToAction(nameof(Index));
            }

            EditModel model = new EditModel()
            {
                EmployeeName = $"{materialUser.User.Name} {materialUser.User.Surname}",
                MaterialeName = materialUser.Material.MaterialName,
                MaterialeSerialNumber = materialUser.Material.SerialNo
            };

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
            MaterialUserManager materialUserManager = new MaterialUserManager();
            materialUserManager.RemoveById(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
