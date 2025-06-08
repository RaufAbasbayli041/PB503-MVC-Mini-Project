using CAConferenceManagement.DB;
using CAConferenceManagement.Helpers.Enum.Role;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CAConferenceManagement.Helpers
{
    public static class DBHelper
    {
        public static async Task SetRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = System.Enum.GetNames(typeof(RoleStatus));

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

        }
    }
}
