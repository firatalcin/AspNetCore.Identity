using Microsoft.AspNetCore.Identity;

namespace IdentityExampleProject.UI.Models.Authentication
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreateDate { get; set; }
    }
}
