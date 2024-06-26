using CustomCRM.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CustomCRM.Application.Data
{
    public interface IApplicationDataContext
    {
        public DbSet<Service> Services { get; set; }
    }
}
