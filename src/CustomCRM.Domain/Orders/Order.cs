using CustomCRM.Domain.Commons.Enums;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Raids;
using CustomCRM.Domain.Services;

namespace CustomCRM.Domain.Orders
{
    public class Order : AggregateRoot
    {
        public OrderId? Id { get; set; }
        public List<Raid> Raids { get; set; }
        public List<Service>? Services { get; set; }
        public DateTime DateTimeOfCreation { get ; private set; }
        public string? OrderShopId { get; set; } 
        public string? ShopName { get; set; }
        public string? NickServer {  get; set; }
        public decimal TotalPrice { get; private set; }        
        public Status Status { get; set; }
        public string Comment { get; set; }
        //public int ManagerId { get; set; }
        
        public Order(OrderId id, List<Raid> raids, List<Service> services, DateTime dateTimeOfCreation, string orderShopId, string shopName, string nickServer,
             decimal totalPrice, Status status, string comment)
        {
            Id = id;
            Raids = raids;
            Services = services;
            DateTimeOfCreation = dateTimeOfCreation;
            OrderShopId = orderShopId;
            ShopName = shopName;
            NickServer = nickServer; 
            TotalPrice = totalPrice;            
            Status = status;
            Comment = comment;
        }

        private Order() 
        { 
        }

        public static decimal FullOrderPrice(List<Service> services)
        {
            decimal total = 0;
            
            return total;
        }

        public static Order Create(List<Raid> raids, List<Service> services, DateTime dateTimeOfCreation, string orderShopId, string shopName, string nickServer,
             decimal totalPrice, Status status, string comment)
        {
            return new Order(new OrderId(Guid.NewGuid()), raids, services, dateTimeOfCreation, orderShopId, shopName, nickServer, totalPrice, status, comment);
        }
        public static Order Update(Guid id, List<Raid> raids, List<Service> services, DateTime dateTimeOfCreation, string orderShopId, string shopName, string nickServer,
             decimal totalPrice, Status status, string comment)
        {
            return new Order(new OrderId(id), raids, services, dateTimeOfCreation, orderShopId, shopName, nickServer, totalPrice, status, comment);
        }
    }
}
