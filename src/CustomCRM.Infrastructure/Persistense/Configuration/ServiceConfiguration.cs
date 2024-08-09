using CustomCRM.Domain.Services;
using CustomCRM.Domain.ValueObjects.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomCRM.Infrastructure.Persistense.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(s => s.ServiceId);

            builder.Property(s => s.ServiceId)
                .HasConversion(serviceId => serviceId.Value, value => new ServiceId(value));

            builder.Property(s => s.Screenshot)
                .HasConversion(screenshot => screenshot.Url, value => Screenshot.Create(value));

            builder.OwnsOne(e => e.Price);

            builder.Property(s => s.ServiceType)
                .HasConversion(serviceType => serviceType.Value, value => ServiceType.Create(value));
        }
    }
}
