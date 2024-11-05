using CustomCRM.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace CustomCRM.Infrastructure.Persistense.Seeds
{
    public class IdentitySeed
    {
        public static async Task SeedDataAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<ApplicationUser>
            {
                new ()
                {
                    DisplayName = "Ivan I.",
                    UserName = "IvanIvanov",
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Email = "ivanivanov@streammingapp.com"
                },
                new ()
                {
                    DisplayName = "Petr I.",
                    UserName = "PetrIvanov",
                    FirstName = "Petr",
                    LastName = "Ivanov",
                    Email = "petrivanov@streammingapp.com"
                }
            };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "qwertyXX123!1");
                }
            }
        }
    }
}
