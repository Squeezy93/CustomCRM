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
            var service1 = Service.Create( "1", Domain.Commons.Difficult.Normal, Domain.Commons.Status.Unfinished, 1, 1, "");
            var service2 = Service.Create( "2", Domain.Commons.Difficult.Heroic, Domain.Commons.Status.Unfinished, 2, 2, "");
            Console.WriteLine(service1.Id);
            Console.WriteLine(service2.Id);
            service2 = Service.Update(service2.Id.Id, "3", Domain.Commons.Difficult.Heroic, Domain.Commons.Status.Unfinished, 2, 2, "");
            Console.WriteLine(service2.ServiceType);
            Console.WriteLine(service2.Id);
            var order = Order.Create(new List<Domain.Raids.Raid>(), new List<Service>(), DateTime.Now, "ASd", "ASD", "lox-lox", 0, "asd", Domain.Commons.Status.Unfinished, "0");
            order.Services.Add(service1);
            order.Services.Add(service2);
            var price = order.FullOrderPrice(order.Services);
            Console.WriteLine(price);














            /*var service2 = Service.Create(new ServiceId(Guid.NewGuid()), "2", Domain.Commons.Difficult.Heroic, Domain.Commons.Status.Unfinished, 2, 2, "");
            Console.WriteLine(service2.Id);
            service2 = Service.Update(Guid.NewGuid(), "2", Domain.Commons.Difficult.Heroic, Domain.Commons.Status.Unfinished, 2, 2, "");
            Console.WriteLine(service2.Id);*/
        }
    }
}
