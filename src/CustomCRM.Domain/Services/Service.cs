using CustomCRM.Domain.Commons;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.ValueObjects.Services;

namespace CustomCRM.Domain.Services

{
    public class Service : AggregateRoot
    {
        public ServiceId Id { get; private set; }
        public ServiceType ServiceType { get; private set; }
        public Difficult Difficult { get; private set; }
        public Status Status { get; private set; }
        public Price Price { get; private set; }
        public int Quantity { get; private set; }
        public string Comment { get; private set; }

        private Service(ServiceId id, ServiceType serviceType, Difficult difficult, Status status, Price price, int quantity, string comment)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity cannot be negative or equal 0", nameof(quantity));
            }

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

        public static Service Create(string serviceType, Difficult difficult, Status status, decimal price, string currency, int quantity, string comment)
        {
            var serviceTypeObj = ServiceType.Create(serviceType);
            var priceObj = Price.Create(price, currency);

            return new Service(new ServiceId(Guid.NewGuid()), serviceTypeObj, difficult, status, priceObj, quantity, comment);
        }

        public static Service Update(Guid id, string serviceType, Difficult difficult, Status status, decimal price, string currency, int quantity, string comment)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid GUID", nameof(id));
            }

            //проверка на наличие в базе данных, если существует то обновляем, если нет то выкидываем ошибку

            var serviceTypeObj = ServiceType.Create(serviceType);
            var priceObj = Price.Create(price, currency);

            return new Service(new ServiceId(id), serviceTypeObj, difficult, status, priceObj, quantity, comment);
        }        
    }
}
