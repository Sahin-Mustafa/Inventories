using Inventories.Entities;
using Inventories.Models.Appropriate;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Helpers
{
    public class MaterialUserManager
    {
        private DatabaseContext db = new();

        internal void AddAppropriate(Create model)
        {
            MaterialUser materialUser = new MaterialUser()
            {
                MaterialId = model.SelectedMaterial,
                UserId = model.SelectedEmployee,
                AppropriateDate= DateTime.Now,
            };
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
            db.MaterialsUsers.Remove(materialUser);
            db.SaveChanges();
            
        }
    }
}
