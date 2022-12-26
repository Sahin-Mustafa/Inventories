using Inventories.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Inventories.Models
{
    public class RegisterModel : LoginModel
    {
        [Display(Name = "Çalışan Adı")]
        [Required(ErrorMessage = "Çalışan ismini girmelisiniz.")]
        public string Name { get; set; }

        [Display(Name = "Çalışan Soyadı")]
        [Required(ErrorMessage = "Çalışan ismini girmelisiniz.")]
        public string Surname { get; set; }

        [Display(Name= "Çalışanın işe giriş tarihi")]
        [Required(ErrorMessage = "Çalışanın işe giriş tarihini girmelisiniz.")]
        public DateTime? StartDateJob{ get; set; }

        [Required(ErrorMessage ="Bölüm seçmelisiniz.")]
        public int SelectedDepartman { get; set; }
        public SelectList? Departmans { get; set; }

    }

    
}
