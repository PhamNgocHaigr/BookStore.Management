using BookStore.Management.DataAccess.Data;
using BookStore.Management.Domain.Entities;
using BookStore.Management.Domain.Setting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Management.DataAccess
{
    public static class ConfigurationService
    {
        public static async Task AutoMigration(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                //appContext.Database.EnsureCreated();
                await appContext.Database.MigrateAsync();
            }
        }

        public static async Task SeedData(this WebApplication webApplication, IConfiguration configuration)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


                var defaultUser = configuration.GetSection("DefaultUsers")?.Get<DefaultUser>() ?? new DefaultUser();
                var defaultRole = configuration.GetValue<string>("DefaultRole") ?? "SuperAdmin";

                try
                {
                    if (!await roleManager.RoleExistsAsync(defaultRole))
                    {
                        await roleManager.CreateAsync(new IdentityRole(defaultRole));
                    }

                    var existUser = await userManager.FindByNameAsync(defaultUser.UserName);

                    if (existUser == null)
                    {
                        var user = new ApplicationUser
                        {
                            UserName = defaultUser?.UserName,
                            IsActive = true,
                            Address = "",
                            AccessFailedCount = 0,
                        };
                        var identityUser = await userManager.CreateAsync(user, defaultUser.Password);
                        if (identityUser.Succeeded)
                        {
                            //add Role
                            await userManager.AddToRoleAsync(user, defaultRole);
                        }
                    }
                }
                catch (Exception)
                { 
                    throw;
                }      
            }
        }
    }
}
