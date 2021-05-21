using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Enums;

namespace Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(nameof(Roles.SuperAdmin))).ConfigureAwait(false);
            await roleManager.CreateAsync(new IdentityRole(nameof(Roles.Admin))).ConfigureAwait(false);
            await roleManager.CreateAsync(new IdentityRole(nameof(Roles.Moderator))).ConfigureAwait(false);
            await roleManager.CreateAsync(new IdentityRole(nameof(Roles.Basic))).ConfigureAwait(false);
        }
    }
}
