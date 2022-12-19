using System.ComponentModel.DataAnnotations.Schema;

namespace Inventories.Entities
{
    [Table("MaterialUser")]
    public class MaterialUser
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int UserId { get; set; }
        public DateTime? AppropriateDate { get; set; }

        public Material Material { get; set; }
        public User User { get; set; }
    }
}
