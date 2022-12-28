using Inventories.Entities;
using Inventories.Models.Appropriate;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Helpers
{
    public class MaterialUserManager
    {
        private DatabaseContext db = new();

        public void AddAppropriate(Create model)
        {
            MaterialUser materialUser = new MaterialUser()
            {
                MaterialId = model.SelectedMaterial,
                UserId = model.SelectedEmployee,
                AppropriateDate= DateTime.Now,
            };
            Material newStock = db.Materials.FirstOrDefault(x => x.Id == model.SelectedMaterial);
            newStock.Stock -= 1;
            db.MaterialsUsers.Add(materialUser);
            db.SaveChanges();
        }
        internal MaterialUser GetById(int id)
        {
            MaterialUser materialUser = db.MaterialsUsers.Include("Material").Include("User").Where(x => x.Id == id).FirstOrDefault();
            return materialUser;

        }

        internal void RemoveById(int id)
        {
            MaterialUser materialUser = GetById(id);
            Material newStock = db.Materials.FirstOrDefault(x => x.Id == id);
            newStock.Stock += 1;
            db.MaterialsUsers.Remove(materialUser);
            db.SaveChanges();
            
        }
    }
}
