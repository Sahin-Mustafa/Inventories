using Microsoft.EntityFrameworkCore;

namespace Inventories.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialUser> MaterialsUsers { get; set; }


        public DatabaseContext()
        {
            Database.EnsureCreated();
            FakeData();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-TGAGQ1J\\SQLEXPRESS;Database=InventoriesApp;Trusted_Connection=true;encrypt=false");
            }
        }
        private void FakeData()
        {
            if (this.Admins.Any() == false)
            {
                Admin admin = new Admin()
                {
                    Name = "admin",
                    Password = "adminadmin",
                };

                Admins.Add(admin);
            }

            if (this.Users.Any() == false)
            {
                Random gen = new Random();
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                for (int i = 0; i < 60; i++)
                {
                    
                    User user = new User()
                    {
                        Username = $"Personel{i}",
                        Password = $"personel{i}",
                        Name = $"Personel{i}",
                        Surname = $"Personel{i}",
                        StartDateJob = start.AddDays(gen.Next(range)),
                        IsBreak = gen.Next(2) == 1,
                        DepartmanId = gen.Next(1, 4),
                    };
                    if( user.IsBreak)
                    {
                        int quitDate = (DateTime.Now - user.StartDateJob).Days;
                        user.EmploymentDate = user.StartDateJob.AddDays(gen.Next(quitDate));
                    }

                    this.Users.Add(user);
                }


                Departman departman = new Departman()
                {
                    DepartmanName = "Yönetici",
                    JobDescription = "Şirket yönetim kurul toplantılarına katılır ve karar alma mekanizmasında bulunur"
                };
                this.Departmans.Add(departman);
                Departman departman2 = new Departman()
                {
                    DepartmanName = "Satın Alma",
                    JobDescription = "Malzeme satın almadan sorumludur"
                };
                this.Departmans.Add(departman2);
                Departman departman3 = new Departman()
                {
                    DepartmanName = "Saha Mühendisi",
                    JobDescription = "Satışı tamamlanan ürünlere teknik destek veirir"
                };
                this.Departmans.Add(departman3);


                Material material = new Material()
                {
                    MaterialName = "Asus Monitör",
                    MaterialDescription = "27\" Asus bilgisayar monitörü",
                    IsSecondHane = false,
                    Price = 2772,
                    Stock = 5,
                    SerialNo = "A27CH43"
                };
                this.Materials.Add(material);

                Material material2 = new Material()
                {
                    MaterialName = "MSI Laptopp",
                    MaterialDescription = "17\" Ekranlı i-17 11TH GTX 3060 W11",
                    IsSecondHane = false,
                    Price = 16000,
                    Stock = 2,
                    SerialNo = "MSI45MONS"
                };
                this.Materials.Add(material2);
                this.SaveChanges();
            }

            this.Users.ToList();
        }
    }
}