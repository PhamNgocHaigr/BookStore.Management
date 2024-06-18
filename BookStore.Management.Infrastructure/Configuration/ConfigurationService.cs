using BookStore.Management.Application;
using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.Services;
using BookStore.Management.DataAccess.Dapper;
using BookStore.Management.DataAccess.Data;
using BookStore.Management.DataAccess.Repository;
using BookStore.Management.Domain.Abstract;
using BookStore.Management.Domain.Entities;
using BookStore.Management.Infrastructure.Image;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace BookStore.Management.Infrastructure.Configuration
{
    public static class ConfigurationService
    {
        public static void ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                        .AddEntityFrameworkStores<ApplicationDbContext>()
                        .AddDefaultTokenProviders();
            
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "BookStoreCookie";
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.LoginPath = "/admin/authentication/login";
                options.SlidingExpiration = true; 

                //options.AccessDeniedPath = "/";
            });
            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 3;
            });
        }

        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<PasswordHasher<ApplicationUser>>();
            services.AddTransient<ISQLQueryHandler, SQLQueryHandler>();
            services.AddTransient<IUnitOfWork,UnitOfWork>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IBookService, BookService>();



        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

      
    }
}
