using Inventories.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Inventories.Models
{
    public class RegisterModel : LoginModel
    {

        [Required(ErrorMessage = "Çalışan ismini girmelisiniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Çalışan ismini girmelisiniz.")]
        public string Surname { get; set; }
        public bool IsBreak{ get; set; }

        [Display(Name= "Çalışanın işe giriş tarihi")]
        [Required(ErrorMessage = "Çalışanın işe giriş tarihini girmelisiniz.")]
        public DateTime StartDateJob{ get; set; }

        [Display(Name = "Employment date")]
        public DateTime? EmploymentDate { get; set; }

        [Required(ErrorMessage ="Bölüm seçmelisiniz.")]
        public string SelectedDepartman { get; set; }
        public List<SelectListItem>? Departmans { get; set; }

    }

    
}
