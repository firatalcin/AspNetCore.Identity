using Microsoft.AspNetCore.Identity;

namespace IdentityExampleProject.UI.Models.Authentication
{
    public class AppUser : IdentityUser<int>
    {
        public bool Gender { get; set; }
        public string Country { get; set; }
    }
}
