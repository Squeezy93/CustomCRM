using CustomCRM.Api.Middlewares;
using CustomCRM.Application;
using CustomCRM.Infrastructure;

namespace CustomCRM.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<GlobalExceptionHandler>();

            /*            app.UseHttpsRedirection();

                        app.UseAuthorization();*/
            app.MapControllers();

            app.Run();
        }
    }
}
