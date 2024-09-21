using IdentityExampleProject.UI.Models.Authentication;
using Microsoft.AspNetCore.Identity;

namespace IdentityExampleProject.UI.CustomValidations
{
    public class CustomPasswordValidation : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (password.Length < 5)
                errors.Add(new IdentityError { Code = "PasswordLength", Description = "Lütfen şifreyi en az 5 karakter giriniz." });
            if (password.ToLower().Contains(user.UserName.ToLower()))
                errors.Add(new IdentityError { Code = "PasswordContainsUserName", Description = "Lütfen şifre içerisinde kullanıcı adını yazmayınız." });


            if (!errors.Any())
                return Task.FromResult(IdentityResult.Success);
            else
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }
    }
}
