using Application.Enums;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto.Prng.Drbg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
    public static class DefaultSuperAdmin
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                FirstName = "Mukesh",
                LastName = "Murugan",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email).ConfigureAwait(false);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!").ConfigureAwait(false);
                    await userManager.AddToRoleAsync(defaultUser, nameof(Roles.Basic)).ConfigureAwait(false);
                    await userManager.AddToRoleAsync(defaultUser, nameof(Roles.Moderator)).ConfigureAwait(false);
                    await userManager.AddToRoleAsync(defaultUser, nameof(Roles.Admin)).ConfigureAwait(false);
                    await userManager.AddToRoleAsync(defaultUser, nameof(Roles.SuperAdmin)).ConfigureAwait(false);
                }

            }
        }
    }
}
