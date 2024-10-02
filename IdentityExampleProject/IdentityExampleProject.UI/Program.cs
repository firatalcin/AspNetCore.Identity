using IdentityExampleProject.UI.CustomValidations;
using IdentityExampleProject.UI.Features;
using IdentityExampleProject.UI.Models.Authentication;
using IdentityExampleProject.UI.Models.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityExampleProject.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("mssql"));
            });

            builder.Services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 5;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireDigit = false;

                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789 -._@+";
            })
                .AddPasswordValidator<CustomPasswordValidation>()
                .AddUserValidator<CustomUserValidation>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/User/Login");
                opt.LogoutPath = new PathString("/User/Logout");
                opt.Cookie = new CookieBuilder
                {
                    Name = "AspNetCoreIdentityExampleCookie",
                    HttpOnly = false,
                    MaxAge = TimeSpan.FromMinutes(2),
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.Always,
                };

                opt.SlidingExpiration = true;
                opt.Cookie.MaxAge = TimeSpan.FromMinutes(2);
                opt.AccessDeniedPath = new PathString("/authority/page");
            });

            builder.Services.AddAuthorization(opt =>
            {
                opt.AddPolicy("TimeControl", policy => policy.Requirements.Add(new TimeRequirement()));
            });
            builder.Services.AddSingleton<IAuthorizationHandler, TimeHandler>();
            builder.Services.AddScoped<IClaimsTransformation, UserClaimProvider>();

            builder.Services.AddScoped<IClaimsTransformation, UserClaimProvider>();
            builder.Services.AddAuthorization(x => x.AddPolicy("UserClaimNamePolicy", policy => policy.RequireClaim("username", "gncy")));
            builder.Services.AddAuthorization(x => x.AddPolicy("UserClaimPositionPolicy", policy => policy.RequireClaim("pozisyon", "admin")));
        .
        .
        .
    }
    }


    var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
