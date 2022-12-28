using Inventories.Entities;
using Inventories.Models.Material;

namespace Inventories.Helpers
{
    public class MaterialManager
    {
        DatabaseContext db = new();
        public List<Material> GetAllMaterials()
        {
            List<Material> listMaterials = db.Materials.Where(x => x.Id != 0).ToList();
            return listMaterials;
        }
        public List<Material> GetAllMaterialsInStock()
        {
            List<Material> listMaterials = db.Materials.Where(x => x.Stock != 0).ToList();
            return listMaterials;
        }

        internal void CreateMaterial(CreateModel model)
        {
            Material material = new Material()
            {
                MaterialName = model.MaterialName,
                MaterialDescription = model.MaterialDescription,
                IsSecondHane = model.IsSecondHane,
                Price = model.Price,
                Stock = model.Stock,
                SerialNo = model.SerialNumber
            };
            db.Materials.Add(material);
            db.SaveChanges();
        }
        internal Material GetMaterialById(int id)
        {
            Material material = db.Materials.FirstOrDefault(x => x.Id == id);

            return material;

        }

        internal void EditById(int id, EditModel model)
        {
            Material material = GetMaterialById(id);
            material.MaterialName = model.MaterialName;
            material.MaterialDescription = model.MaterialDescription;
            material.IsSecondHane = model.IsSecondHane;
            material.Price = model.Price;
            material.Stock = model.Stock;
            material.SerialNo = model.SerialNumber;
            db.SaveChanges();
        }

        

        internal void RemoveById(int id)
        {
            Material material = GetMaterialById(id);
            db.Materials.Remove(material);
            db.SaveChanges();
        }
    }
}
