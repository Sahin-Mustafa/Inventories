using Inventories.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Inventories.Models
{
    public class RegisterModel : LoginModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsBreak{ get; set; }

        [Display(Name= "Start date of work")]
        public DateTime StartDateJob{ get; set; }

        [Display(Name = "Employment date")]
        public DateTime? EmploymentDate { get; set; }

        public string SelectedDepartman { get; set; }
        public List<SelectListItem>? Departmans { get; set; }

    }

    
}
