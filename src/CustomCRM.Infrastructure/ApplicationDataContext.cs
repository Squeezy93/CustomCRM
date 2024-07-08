using CustomCRM.Application.Data;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Services;
using CustomCRM.Infrastructure.Persistance.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomCRM.Infrastructure
{
    public class ApplicationDataContext : DbContext, IApplicationDataContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public ApplicationDataContext(IPublisher publisher)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
        }
        public DbSet<Service?> Services { get; set; }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken()) 
        {
            IEnumerable<DomainEvent> domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.GetDomainEvents().Any())
                .SelectMany(e => e.GetDomainEvents());

            foreach (var domainEvent in domainEvents) 
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            int result = await base.SaveChangesAsync(cancellationToken); 
            return result;
        }
    }
}
