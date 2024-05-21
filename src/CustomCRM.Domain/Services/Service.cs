using CustomCRM.Domain.Commons;
using CustomCRM.Domain.Primitives;

namespace CustomCRM.Domain.Services
{
    public class Service : AggregateRoot
    {
        public ServiceId Id { get; set; }
        public string? ServiceType { get; set; }
        public Difficult Difficult { get; set; }
        public Status Status { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Comment { get; set; }

        public Service(ServiceId id, string serviceType, Difficult difficult, Status status, decimal price, int quantity, string comment)
        {
            Id = id;
            ServiceType = serviceType;
            Difficult = difficult;
            Status = status;
            Price = price;
            Quantity = quantity;
            Comment = comment;
        }

        private Service()
        { 
        }

        public static Service Update(ServiceId id, string serviceType, Difficult difficult, Status status, decimal price, int quantity, string comment)
        {
            return new Service(id, serviceType, difficult, status, price, quantity, comment);
        }

        public static Service Create(Guid id, string serviceType, Difficult difficult, Status status, decimal price, int quantity, string comment)
        {
            return new Service(new ServiceId(id), serviceType, difficult, status, price, quantity, comment);
        }
    }
}
