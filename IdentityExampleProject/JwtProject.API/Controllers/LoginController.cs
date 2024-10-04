using JwtProject.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly TokenExampleContext _context;
        readonly IConfiguration _configuration;
        public LoginController(TokenExampleContext content, IConfiguration configuration)
        {
            _context = content;
            _configuration = configuration;
        }
        [HttpPost("[action]")]
        public async Task<bool> Create([FromForm] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        [HttpPost("action")]
        public async Task<Token> Login([FromForm] UserLogin userLogin)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userLogin.Email && x.Password == userLogin.Password);
            if (user != null)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                //Refresh token Users tablosuna işleniyor.
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                await _context.SaveChangesAsync();

                return token;
            }
            return null;
        }
    }
}
