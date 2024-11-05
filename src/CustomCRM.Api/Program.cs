using CustomCRM.Api.Extensions;
using CustomCRM.Api.Middlewares;
using CustomCRM.Application;
using CustomCRM.Infrastructure;

namespace CustomCRM.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddPresentation(builder.Configuration)
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                await app.ApplyMigrationsAsync();
            }
            app.UseMiddleware<GlobalExceptionHandler>();

            app.MapControllers();

            app.Run();
        }
    }
}
