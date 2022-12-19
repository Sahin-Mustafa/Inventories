using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventories.Entities
{
    [Table("Departmans")]
    public class Departman
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string DepartmanName { get; set; }

        [Required]
        public string JobDescription { get; set; }

        public List<User> User { get; set; }
    }
}
