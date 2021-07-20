using Core.Entites;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "user@user.com",
                Email = "user@user.com",
                EmailConfirmed = true
            };
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Aa1234!");
                await userManager.AddToRoleAsync(defaultUser, Core.Enums.Roles.Basic.ToString());
            }
        }
        public static async Task SeedSuperAdminUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin@superadmin.com",
                Email = "superadmin@superadmin.com",
                EmailConfirmed = true
            };
            var user =await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Aa1234!");
                await userManager.AddToRolesAsync(defaultUser,
                    new List<string>
                    {
                        Core.Enums.Roles.SuperAdmin.ToString(),
                        Core.Enums.Roles.Admin.ToString(),
                        Core.Enums.Roles.Basic.ToString()
                    });
            }
            await roleManager.SeedClaimsForSuperUser();
        }
        private static async Task SeedClaimsForSuperUser(this RoleManager<IdentityRole> roleManager)
        {
            var superAdmindminRole = await roleManager.FindByNameAsync(Core.Enums.Roles.SuperAdmin.ToString());
            await roleManager.AddPermissionClaims(superAdmindminRole, "News");
        }
        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager,IdentityRole role,string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Core.Enums.Permissions.GeneratePermissions(module);
            foreach (var permissison in allPermissions)
            {
                if(!allClaims.Any(c=>c.Type=="Permission" && c.Value==permissison))
                {
                    await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim("Permission", permissison));
                }
            }

        }
        public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };
            var user = userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Aa1234!");
                await userManager.AddToRoleAsync(defaultUser, Core.Enums.Roles.Admin.ToString());
            }
        }
    }
}
