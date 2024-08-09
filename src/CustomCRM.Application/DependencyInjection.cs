using CustomCRM.Application.Common.Behaviors;
using CustomCRM.Application.Utilities.DateTimes;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CustomCRM.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            });            

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();

            services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

            return services;
        }
    }
}
