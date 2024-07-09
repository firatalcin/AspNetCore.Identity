using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı boş bırakılamaz")]
        [Display(Name = "Kullanıcı Adı: ")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış")]
        [Display(Name = "Email: ")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Telefon boş bırakılamaz")]
        [Display(Name = "Telefon: ")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [Display(Name = "Şifre: ")]
        public string? Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Şifre aynı değildir.")]
        [Required(ErrorMessage = "Şifre tekrar boş bırakılamaz")]
        [Display(Name = "Şifre Tekrar: ")]
        public string? PasswordConfirm { get; set; }
    }
}
