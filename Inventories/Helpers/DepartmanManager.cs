using Inventories.Entities;
using Inventories.Models.Departman;

namespace Inventories.Helpers
{
    public class DepartmanManager
    {
        private DatabaseContext db = new();


        public List<Departman> GetAllDepartmans()
        {
            List<Departman> departmans = db.Departmans.Where(x=>x.Id != 0).ToList();
            return departmans;
        }

        internal void CreateDepartman(CreateModel model)
        {
            
            Departman departman = new Departman()
            {
                DepartmanName = model.DepartmanName,
                JobDescription = model.JobDescription,
            };
            db.Departmans.Add(departman);
            db.SaveChanges();
        }

        internal void EditById(int id, EditModel model)
        {
            Departman departman = GetDepartmanById(id);
            departman.DepartmanName = model.DepartmanName;
            departman.JobDescription = model.JobDescription;

            db.SaveChanges();
        }

        internal Departman GetDepartmanById(int id)
        {
            Departman departman = db.Departmans.FirstOrDefault(x => x.Id == id);

            return departman;
        }

        internal void RemoveById(int id)
        {
            Departman departman = GetDepartmanById(id);
            db.Departmans.Remove(departman);
            db.SaveChanges();
        }
    }
}
