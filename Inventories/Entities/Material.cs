using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventories.Entities
{
    [Table("Materials")]
    public class Material
    {
        public int Id { get; set; }

        [Display(Name = "Malzeme Adı")]
        [Required(ErrorMessage ="Malzeme adını girmelisiniz")]
        public string MaterialName { get; set; }

        [Display(Name = "Malzeme Açıklaması")]
        [Required(ErrorMessage = "Malzeme detayını girmelisiniz")]
        public string MaterialDescription { get; set; }

        [Display(Name="İkinci El mi?")]
        public bool IsSecondHane { get; set; }
        
        [Display(Name="Malzeme Fiyatı")]
        [Required(ErrorMessage ="Malzemenin alım fiyatını girmelisiniz")]
        public int Price { get; set; }

        [Display(Name = "Malzeme stok sayısı")]
        public int Stock { get; set; }

        [Display(Name = "Malzemenin seri numarası")]
        public string SerialNo { get; set; }

        public List<User> User{ get; set; }
    }
}
