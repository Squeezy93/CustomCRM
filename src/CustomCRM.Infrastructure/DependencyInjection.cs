using CustomCRM.Application.Data;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Services;
using CustomCRM.Infrastructure.Persistense;
using CustomCRM.Infrastructure.Persistense.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomCRM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDataContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL connection string")));

            services.AddScoped<IApplicationDataContext>(a => a.GetRequiredService<ApplicationDataContext>());
            services.AddScoped<IUnitOfWork>(a => a.GetRequiredService<ApplicationDataContext>());

            services.AddScoped<IServiceRepository, ServiceRepository>();

            return services;
        }
    }
}
