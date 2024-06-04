using CustomCRM.Domain.Commons;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.ValueObjects.Services;

namespace CustomCRM.Domain.Services

{
    public class Service : AggregateRoot
    {
        public ServiceId? Id { get; private set; }
        public ServiceType? ServiceType { get; private set; }
        public Difficult Difficult { get; private set; }
        public Status Status { get; private set; }
        public Price? Price { get; private set; }
        public Screenshot Screenshot { get; private set; }
        public int Quantity { get; private set; }
        public string Comment { get; private set; }

        private Service(ServiceId serviceId, ServiceType serviceType, Difficult difficult, Status status, Price price, int quantity, Screenshot screenshot, string comment)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity cannot be negative or equal 0", nameof(quantity));
            }

            Id = serviceId;            
            ServiceType = serviceType;
            Difficult = difficult;
            Status = status;            
            Price = price;
            Screenshot = screenshot;
            Quantity = quantity;
            Comment = comment;
        }

        //EF
        private Service()
        {
        }

        public static Service Create(string serviceType, Difficult difficult, decimal price, string currency, int quantity, string comment)
        {
            var serviceTypeValue = ServiceType.Create(serviceType);
            var priceValue = Price.Create(price, currency);
            var screenshotValue = Screenshot.Create(String.Empty);
            var status = Status.Waiting;

            return new Service(new ServiceId(Guid.NewGuid()), serviceTypeValue, difficult, status, priceValue, quantity, screenshotValue, comment);
        }

        public static Service Update(Guid id, string serviceType, Difficult difficult, Status status, decimal price, string currency, int quantity, string screenshotURL, string comment)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid GUID", nameof(id));
            }

            //проверка на наличие в базе данных, если существует - обновляем, если нет - выкидываем ошибку

            var serviceTypeValue = ServiceType.Update(serviceType);
            var priceValue = Price.Update(price, currency);
            var screenshotValue = Screenshot.Update(screenshotURL);

            return new Service(new ServiceId(id), serviceTypeValue, difficult, status, priceValue, quantity, screenshotValue, comment);
        }        
    }
}
