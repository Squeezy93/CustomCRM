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
            var service = Service.Create("full heroic", Domain.Commons.Difficult.Normal, Domain.Commons.Status.Unfinished, 5, "RUB", 1, "");            















            /*var service2 = Service.Create(new ServiceId(Guid.NewGuid()), "2", Domain.Commons.Difficult.Heroic, Domain.Commons.Status.Unfinished, 2, 2, "");
            Console.WriteLine(service2.Id);
            service2 = Service.Update(Guid.NewGuid(), "2", Domain.Commons.Difficult.Heroic, Domain.Commons.Status.Unfinished, 2, 2, "");
            Console.WriteLine(service2.Id);*/
        }
    }
}
