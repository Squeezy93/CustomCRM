using CustomCRM.Application.Data;
using CustomCRM.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CustomCRM.Infrastructure.Persistense.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IApplicationDataContext _context;

        public ServiceRepository(IApplicationDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Service service) => _context.Services.Add(service);        

        public void Update(Service service) => _context.Services.Update(service);

        public void Delete(Service service) => _context.Services.Remove(service);

        public async Task<List<Service>> GetAllAsync() => await _context.Services.ToListAsync();

        public async Task<Service> GetByIdAsync(ServiceId Id) => 
            await _context.Services.SingleOrDefaultAsync(c => c.ServiceId == Id);        
    }
}
