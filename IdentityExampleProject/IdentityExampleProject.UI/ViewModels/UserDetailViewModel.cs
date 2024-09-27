using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace IdentityExampleProject.UI.ViewModels
{
    public class UserDetailViewModel
    {
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Eski Şifre")]
        public string OldPassword { get; set; }
        [Display(Name = "Yeni Şifre")]
        public string NewPassword { get; set; }
    }
}
