using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış")]
        [Display(Name = "Email: ")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [Display(Name = "Şifre: ")]
        public string? Password { get; set; }
        [Display(Name = "Hatırla Beni: ")]
        public bool RememberMe { get; set; }
    }
}
