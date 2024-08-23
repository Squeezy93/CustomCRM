using CustomCRM.Domain.Commons.Enums;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.ValueObjects.Services;

namespace CustomCRM.Domain.Services
{
    public class Service : AggregateRoot
    {
        public ServiceId ServiceId { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }
        public ServiceType ServiceType { get; private set; }
        public Difficult Difficult { get; private set; }
        public Status Status { get; private set; }
        public Price Price { get; private set; }
        public Screenshot Screenshot { get; private set; }
        public int Quantity { get; private set; }
        public string Comment { get; private set; }
        
        public Service(
            ServiceId serviceId,
            ServiceType serviceType, 
            DateTime created,
            DateTime modified,
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
            Created = created;
            Modified = modified;
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
            DateTime created,
            DateTime modified,
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
            
            return new Service(new ServiceId(id), serviceType, created, modified, difficult, status, price, quantity, screenshot, comment);
        }

        private void IsValidQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity must be greater than 0.");
            }
        }

        private bool IsValidComment(string comment)
        {
            return string.IsNullOrWhiteSpace(comment);
        }
    }
}
