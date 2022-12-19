using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventories.Entities
{
    [Table("Users")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? DepartmanId { get; set; }

        [Required]
        [StringLength(25)]
        public string Username { get; set; }

        [Required]
        [StringLength(25)]
        public string Password { get; set; }

        [StringLength(25)]
        public string? Name { get; set; }

        [StringLength(30)]
        public string? Surname { get; set; }

        public bool IsBreak { get; set; }

        public DateTime? StartDateJob { get; set; }

        public DateTime? EmploymentDate { get; set; }        

        //navigation property
        public Departman? Departman { get; set; }

        public List<Material> Material { get; set; }
    }
}
