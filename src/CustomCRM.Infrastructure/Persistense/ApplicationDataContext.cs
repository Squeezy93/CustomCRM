using CustomCRM.Application.Data;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomCRM.Infrastructure.Persistense
{
    public class ApplicationDataContext : DbContext, IApplicationDataContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options, IPublisher publisher) : base(options)        
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDataContext).Assembly);
        }

        public DbSet<Service> Services { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<DomainEvent> domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.GetDomainEvents().Any())
                .SelectMany(e => e.GetDomainEvents());

            int result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }
    }
}
