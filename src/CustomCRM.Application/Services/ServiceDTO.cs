using CustomCRM.Domain.Commons;

namespace CustomCRM.Application.Services
{
    public class ServiceDTO
    {
        public Guid Id { get; set; }
        public string? ServiceType { get; set; }
        public Difficult Difficult { get; set; }
        public Status Status { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public int Quantity { get; set; }
        public string ScreenshotURL { get; set; }
        public string Comment { get; set; }
    }
}
