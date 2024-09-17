using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using QuestRoomMVC.Models;

public static class InitializeDB
{
    public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roleNames = { "Admin", "User" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        if (userManager.FindByEmailAsync("admin@questroom.com").Result == null)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = "admin@questroom.com",
                Email = "admin@questroom.com",
                FullName = "Администратор"
            };

            var adminPassword = "Admin@123";
            var createAdmin = await userManager.CreateAsync(user, adminPassword);
            if (createAdmin.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}