using Inventories.Entities;
using Inventories.Helpers;
using Inventories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Inventories.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            FakeData();
            return View();
        }

        private void FakeData()
        {
            DatabaseContext db = new DatabaseContext();

            if (db.Users.Any() == false)
            {
                User user = new User()
                {
                    Username = "admin",
                    Password = "adminadmin",
                };
                HttpContext.Session.SetString("username", user.Username);
                db.Users.Add(user);

                Departman departman = new Departman()
                {
                    DepartmanName = "Yönetici",
                    JobDescription = "Şirket yönetim kurul toplantılarına katılır ve karar alma mekanizmasında bulunur"
                };
                db.Departmans.Add(departman);
                Departman departman2 = new Departman()
                {
                    DepartmanName = "Satın Alma",
                    JobDescription = "Malzeme satın almadan sorumludur"
                };
                db.Departmans.Add(departman2);


                Material material = new Material()
                {
                    MaterialName = "Asus Monitör",
                    MaterialDescription = "27\" Asus bilgisayar monitörü",
                    IsSecondHane = false,
                    Price = 2772,
                    Stock = 5,
                    SerialNo = "A27CH43"
                };
                db.Materials.Add(material);

                Material material2 = new Material()
                {
                    MaterialName = "MSI Laptopp",
                    MaterialDescription = "17\" Ekranlı i-17 11TH GTX 3060 W11",
                    IsSecondHane = false,
                    Price = 16000,
                    Stock = 2,
                    SerialNo = "MSI45MONS"
                };
                db.Materials.Add(material2);
                db.SaveChanges();
            }

            db.Users.ToList();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


    
}