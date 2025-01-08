using CustomCRM.Application;
using CustomCRM.Application.Data;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Services;
using CustomCRM.Domain.Users;
using CustomCRM.Infrastructure.Auth.Jwt;
using CustomCRM.Infrastructure.Persistense;
using CustomCRM.Infrastructure.Persistense.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CustomCRM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDataContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnectionString")));

            services.AddScoped<IApplicationDataContext>(a => a.GetRequiredService<ApplicationDataContext>());
            services.AddScoped<IUnitOfWork>(a => a.GetRequiredService<ApplicationDataContext>());

            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddIdentity(configuration);
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<ApplicationIdentityDataContext>(options => options.UseNpgsql(configuration.GetConnectionString("IdentityConnectionString")));

            services.TryAddSingleton(TimeProvider.System);
            
            var builder = services.AddIdentityCore<ApplicationUser>();
            //TODO:initialize builder by usertype and DI container
            builder.AddEntityFrameworkStores<ApplicationIdentityDataContext>();
            builder.AddSignInManager<SignInManager<ApplicationUser>>();

            return services;
        }
    }
}
