namespace CustomCRM.Domain.Services
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAllAsync();
        Task<Service> GetByIdAsync(ServiceId Id);
        void Create(Service service);
        void Update(Service service);
        void Delete(Service service);
    }
}
