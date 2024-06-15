using CustomCRM.Domain.Services;
using MediatR;

namespace CustomCRM.Application.Services.GetAll
{
    public sealed class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, List<ServiceDTO>>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetAllServicesQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
        }
        public async Task<List<ServiceDTO>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceRepository.GetAllAsync();

            var serviceDtos = services.Select(service => new ServiceDTO
            {
                Id = service.ServiceId.Value,
                ServiceType = service.ServiceType.Value,
                Difficult = service.Difficult,
                Status = service.Status,
                Amount = service.Price.Amount,
                Currency = service.Price.Currency,
                Quantity = service.Quantity,
                ScreenshotURL = service.Screenshot.Url,
                Comment = service.Comment
            }).ToList();

            return serviceDtos;
        }
    }
}
