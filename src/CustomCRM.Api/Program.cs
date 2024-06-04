using CustomCRM.Domain.Orders;
using CustomCRM.Domain.Services;

namespace CustomCRM.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {/*
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();*/
            var service = Service.Create("Full heroic", Domain.Commons.Difficult.Heroic, 4, "RUB", 1, "");
            Console.WriteLine(service.Id.Id);
            
            service = Service.Update(Guid.NewGuid(), "Full heroic", Domain.Commons.Difficult.Heroic, Domain.Commons.Status.Ongoing, 5, "RUB", 5, "imgur.com", " 123");
            Console.WriteLine(service.Id.Id);            
        }
    }
}
