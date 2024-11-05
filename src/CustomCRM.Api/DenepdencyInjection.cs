using CustomCRM.Api.Common.Errors;
using CustomCRM.Api.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CustomCRM.Api
{
    public static class DenepdencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, CustomCRMProblemDetailsFactory>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setup =>
            {
                var openApiSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Положи только твой токен в инпут, не пиши bearer впереди него!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(openApiSecurityScheme.Reference.Id, openApiSecurityScheme);
                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { openApiSecurityScheme, Array.Empty<string>()}
            });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["IdentityTokenKey"])),
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });

            services.AddTransient<GlobalExceptionHandler>();

            services.AddAuthorization();

            return services;
        }
    }
}
