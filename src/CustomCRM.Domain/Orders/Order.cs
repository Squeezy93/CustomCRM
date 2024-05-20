using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Raids;
using CustomCRM.Domain.Services;
using CustomCRM.Domain.ValueObjects;

namespace CustomCRM.Domain.Orders
{
    public class Order : AggregateRoot
    {
        public OrderId? Id { get; set; }
        public List<Raid> Raids { get; set; }
        public List<Service>? Services { get; set; }
        public DateTime DateTimeOfCreation { get; set; }
        public string? OrderShopId { get; set; }
        public string? ShopName { get; set; }
        public string? NickServer {  get; set; }
        //public decimal? TotalPrice { get; set; }
        public string ScreenShoot {  get; set; }
        public Status Status { get; set; }
        public string Comment { get; set; }
        //public int ManagerId { get; set; }
        
        public Order()
        {

        }
    }
}
