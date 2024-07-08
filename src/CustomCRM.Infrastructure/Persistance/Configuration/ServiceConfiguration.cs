using CustomCRM.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomCRM.Infrastructure.Persistance.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(s => s.ServiceId);

            builder.Property(s => s.ServiceId)
                .HasConversion(serviceId => serviceId.Value, value => new ServiceId(value));
        }
    }
}
