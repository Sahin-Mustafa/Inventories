using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Inventories.Models.Employee
{
    public class EditModel : RegisterModel
    {
        [Display(Name = "Çalışan işten Çıktı mı?")]
        public bool IsBreak { get; set; }

        [Display(Name = "Çalışanın işten çıkış tarihi")]
        public DateTime? EmploymentDate { get; set; }
        public string DepartmanName { get; set; }

    }
}
