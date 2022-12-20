using Inventories.Entities;
using Inventories.Models.Appropriate;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Helpers
{
    public class AppropriateManager
    {
        private DatabaseContext db = new DatabaseContext();

        internal List<BaseModel> GetAll()
        {
            List<MaterialUser> materialsUsers = db.MaterialsUsers.Include("Material").Include("User").Where(x => x.Id != 0).ToList();
            List<BaseModel> model = new List<BaseModel>();
            foreach (MaterialUser item in materialsUsers)
            {
                BaseModel baseModel = new BaseModel()
                {
                    Id = item.Id,
                    EmployeeFullName = $"{item.User.Name} {item.User.Surname}",
                    MaterialName = item.Material.MaterialName,
                    MaterialSerialNo = item.Material.SerialNo,
                    AppropriateDate = item.AppropriateDate
                };
                model.Add(baseModel);
            }
            return model;

        }
    }
}
