using CustomCRM.Domain.ValueObjects;

namespace CustomCRM.Domain.Services
{
    public class Service
    {
        public ServiceId Id { get; set; }
        public string? ServiceType { get; set; }
        public Difficult Difficult { get; set; }
        public Status Status { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Comment { get; set; }
    }
}
