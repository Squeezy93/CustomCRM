using CustomCRM.Domain.Commons;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.ValueObjects.Services;

namespace CustomCRM.Domain.Services

{
    public class Service : AggregateRoot
    {
        public ServiceId? ServiceId { get; private set; }
        public DateTime DateTime { get; private set; }
        public ServiceType? ServiceType { get; private set; }
        public Difficult Difficult { get; private set; }
        public Status Status { get; private set; }
        public Price? Price { get; private set; }
        public Screenshot Screenshot { get; private set; }
        public int Quantity { get; private set; }
        public string Comment { get; private set; }

        public Service(
            ServiceId serviceId,
            ServiceType serviceType, 
            DateTime dateTime,
            Difficult difficult, 
            Status status, 
            Price price, 
            int quantity, 
            Screenshot screenshot, 
            string comment
            )
        {
            IsValidQuantity(quantity);

            ServiceId = serviceId;
            ServiceType = serviceType;
            DateTime = dateTime;
            Difficult = difficult;
            Status = status;            
            Price = price;
            Quantity = quantity;
            Screenshot = screenshot;
            Comment = IsValidComment(comment) ? string.Empty : comment;
        }

        //EF
        private Service()
        {
        }

        public static Service Update(
            Guid id, 
            ServiceType serviceType,
            DateTime dateTime,
            Difficult difficult, 
            Status status, 
            Price price, 
            int quantity, 
            Screenshot screenshot, 
            string comment
            )
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid GUID", nameof(id));
            }

            //проверка на наличие в базе данных, если существует - обновляем, если нет - выкидываем ошибку


            return new Service(new ServiceId(id), serviceType, dateTime, difficult, status, price, quantity, screenshot, comment);
        }

        private bool IsValidQuantity(int quantity)
        {
            if(quantity <= 0)
            {
                throw new ArgumentException("Quantity cannot be negative or equal 0", nameof(quantity));                
            }

            return true;
        }

        private bool IsValidComment(string comment)
        {
            return string.IsNullOrWhiteSpace(comment) || string.IsNullOrEmpty(comment);
        }
    }
}
