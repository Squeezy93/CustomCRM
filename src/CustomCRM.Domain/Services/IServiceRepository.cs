namespace CustomCRM.Domain.Services
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAll();
        Task<Service> GetById(ServiceId Id);
        void Create(Service service);
        void Update(Service service);
        void Delete(Service service);
    }
}
