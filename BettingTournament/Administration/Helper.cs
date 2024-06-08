using BettingTournament.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using static System.Formats.Asn1.AsnWriter;

namespace BettingTournament.Administration
{
    public static class Helper
    {
        public static async Task AddAdministratorAsync(IServiceProvider sp)
        {
            using (var scope = sp.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await CreateRolesAndAdminUser(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while creating roles and admin user.");
                }
            }
        }

        private static async Task CreateRolesAndAdminUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var powerUser = new ApplicationUser
            {
                UserName = "Admin",
            };

            string userPassword = "Admin@1234";
            var user = await userManager.FindByEmailAsync("admin@admin.com");

            if (user == null)
            {
                var createPowerUser = await userManager.CreateAsync(powerUser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(powerUser, "Admin");
                }
            }
        }
    }
}
