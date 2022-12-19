using System.ComponentModel.DataAnnotations;

namespace Inventories.Models.Departman
{
    public class CreateModel
    {
        [Required]
        public string DepartmanName { get; set; }

        [Required]
        public string JobDescription { get; set; }
    }
}
