using System.ComponentModel.DataAnnotations;

namespace Inventories.Models.Employee
{
    public class LoginModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        [MinLength(3, ErrorMessage = "En az üç karakterli bir kullanıcı adı giriniz")]
        public string Username { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [MinLength(8, ErrorMessage = "En az sekiz karakterli bir Şifre giriniz")]
        [MaxLength(16)]
        public string Password { get; set; }

    }
}
