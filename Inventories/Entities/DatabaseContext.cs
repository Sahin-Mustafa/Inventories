using Microsoft.EntityFrameworkCore;

namespace Inventories.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Material> Materials{ get; set; }
        //public DbSet<MaterialUser> MaterialUser { get; set; }


        public DatabaseContext()
        {
                Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-TGAGQ1J\\SQLEXPRESS;Database=InventoriesApp;Trusted_Connection=true;encrypt=false");
            }
        }

    }
}