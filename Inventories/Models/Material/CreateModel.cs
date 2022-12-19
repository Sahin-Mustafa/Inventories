using System.ComponentModel.DataAnnotations;

namespace Inventories.Models.Material
{
    public class CreateModel
    {
        [Display(Name = "Malzeme Adı")]
        [Required(ErrorMessage = "Malzeme adını girmelisiniz")]
        public string MaterialName { get; set; }

        [Display(Name = "Malzeme Açıklaması")]
        [Required(ErrorMessage = "Malzeme detayını girmelisiniz")]
        public string MaterialDescription { get; set; }

        [Display(Name = "İkinci El mi?")]
        public bool IsSecondHane { get; set; }

        [Display(Name = "Malzeme Fiyatı")]
        [Required(ErrorMessage = "Malzemenin alım fiyatını girmelisiniz")]
        public int Price { get; set; }

        [Display(Name = "Malzeme stok sayısı")]
        [Required(ErrorMessage = "Malzemenin stok sayısını girmelisiniz")]
        public int Stock { get; set; }

        [Display(Name = "Malzeme seri numarası")]
        [Required(ErrorMessage = "Malzemenin stok sayısını girmelisiniz")]
        public string SerialNumber { get; set; }
    }
}
