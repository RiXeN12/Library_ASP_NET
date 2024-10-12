using Library_NPR321.Models;
using Microsoft.AspNetCore.Identity;

namespace Library_NPR321.Data
{
    public static class Seeder
    {
        public static async void SeedData(this IApplicationBuilder builder)
        {
            using(var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
               
                if(!roleManager.Roles.Any())
                {
                    var adminRole = new IdentityRole
                    {
                        Name = Settings.AdminRole,
                        NormalizedName = Settings.AdminRole.ToUpper()
                    };

                    var userRole = new IdentityRole
                    {
                        Name = Settings.UserRole,
                        NormalizedName = Settings.UserRole.ToUpper()
                    };

                    await roleManager.CreateAsync(adminRole);
                    await roleManager.CreateAsync(userRole);

                    var admin = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "admin@gmail.com",
                        UserName = "admin",
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    };

                    await userManager.CreateAsync(admin, "qwe123");

                    var user = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "user@gmail.com",
                        UserName = "user",
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    };

                    await userManager.CreateAsync(user, "qwerty123");

                    await userManager.AddToRoleAsync(admin, Settings.AdminRole);
                    await userManager.AddToRoleAsync(user, Settings.UserRole);
                }
            }
        }
    }
}
