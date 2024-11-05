using CustomCRM.Domain.Users;
using CustomCRM.Infrastructure.Persistense;
using CustomCRM.Infrastructure.Persistense.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CustomCRM.Api.Extensions
{
    public static class MigrationExtension
    {
        public async static Task ApplyMigrationsAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<ApplicationDataContext>>();
            try
            {
                var applicationDataContext = scope.ServiceProvider.GetRequiredService<ApplicationDataContext>();
                await applicationDataContext.Database.MigrateAsync();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                await IdentitySeed.SeedDataAsync(userManager);

                logger.LogInformation("Migrations applied!");
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occured during seed migrations");
            }
        }
    }
}
