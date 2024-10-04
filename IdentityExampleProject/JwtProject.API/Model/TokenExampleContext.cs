using Microsoft.EntityFrameworkCore;

namespace JwtProject.API.Model
{
    public class TokenExampleContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
