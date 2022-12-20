using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventories.Models.Appropriate
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string EmployeeFullName { get; set; }
        public string MaterialName { get; set; }
        public string MaterialSerialNo { get; set; }
        public DateTime? AppropriateDate { get; set; }

        public int SelectedMaterial { get; set; }
        public SelectList Materials { get; set; }
        public int SelectedEmployee { get; set; }
        public SelectList Employees { get; set; }
    }
}
