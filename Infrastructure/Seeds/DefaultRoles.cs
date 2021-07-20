using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedASync(RoleManager<IdentityRole> roleManager)
        {
            if(!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Core.Enums.Roles.SuperAdmin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Core.Enums.Roles.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Core.Enums.Roles.Basic.ToString()));
            }
       
        }
    }
}
