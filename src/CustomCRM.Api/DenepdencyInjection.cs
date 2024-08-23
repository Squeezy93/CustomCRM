using CustomCRM.Api.Middlewares;

namespace CustomCRM.Api
{
    public static class DenepdencyInjection 
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<GlobalExceptionHandler>();

            return services;
        }
    }
}
