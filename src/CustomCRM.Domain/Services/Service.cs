using CustomCRM.Domain.Commons;
using CustomCRM.Domain.Primitives;

namespace CustomCRM.Domain.Services
{
    public class Service : AggregateRoot
    {
        public ServiceId Id { get; set; }
        public string ServiceType { get; set; }
        public Difficult Difficult { get; set; }
        public Status Status { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }

        public Service(ServiceId id, string serviceType, Difficult difficult, Status status, decimal price, int quantity, string comment)
        {
            Id = id;
            if (string.IsNullOrEmpty(serviceType) || string.IsNullOrWhiteSpace(serviceType))
            {
                throw new ArgumentNullException("Cannot be empty.");
            }
            ServiceType = serviceType;
            Difficult = difficult;
            Status = status;
            if (price <= 0)
            {
                throw new ArgumentException("Cannot be below 0");
            }
            Price = price;
            if (quantity <= 0)
            {
                throw new ArgumentException("Cannot be below 0");
            }
            Quantity = quantity;
            Comment = comment;
        }

        private Service()
        {
        }

        public static Service Create(string serviceType, Difficult difficult, Status status, decimal price, int quantity, string comment)
        {
            return new Service(new ServiceId(Guid.NewGuid()), serviceType, difficult, status, price, quantity, comment);
        }

        public static Service Update(Guid id, string serviceType, Difficult difficult, Status status, decimal price, int quantity, string comment)
        {
            return new Service(new ServiceId(id), serviceType, difficult, status, price, quantity, comment);
        }

    }
}
