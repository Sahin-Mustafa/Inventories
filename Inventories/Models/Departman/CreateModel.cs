using System.ComponentModel.DataAnnotations;

namespace Inventories.Models.Departman
{
    public class CreateModel
    {
        [Display(Name = "Departman Adı")]
        [Required]
        public string DepartmanName { get; set; }

        [Display(Name = "Departmanın Açıklaması")]
        [Required]
        public string JobDescription { get; set; }
    }
}
