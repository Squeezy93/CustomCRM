using CustomCRM.Application.Services.Responses;
using CustomCRM.Application.Utilities.DateTimes;
using CustomCRM.Domain.Services;
using ErrorOr;
using MediatR;

namespace CustomCRM.Application.Services.GetAll
{
    public sealed class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, ErrorOr<List<ServiceResponse>>>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetAllServicesQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
        }

        public async Task<ErrorOr<List<ServiceResponse>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceRepository.GetAllAsync();            

            var servicesResponce = services.Select(service => new ServiceResponse(
                service.ServiceId.Value,
                service.ServiceType.Value,
                service.Created,
                service.Modified,
                service.Difficult,
                service.Status,
                service.Price.Amount,
                service.Price.Currency,
                service.Quantity,
                service.Screenshot.Url,
                service.Comment
                )).ToList();

            return servicesResponce;
        }
    }
}
