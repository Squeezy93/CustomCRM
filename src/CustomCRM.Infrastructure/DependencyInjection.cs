using CustomCRM.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomCRM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddDbContext<ApplicationDataContext>(options => options.UseNpgsql("Host=127.0.0.1;Port=5432;Database=customcrmdatabase,User Id=postgres;password=TrfnthbyfUfdtyrj1999"));
            return services;
        }
    }
}
