using CustomCRM.Application.Services.Responses;
using CustomCRM.Domain.Services;
using MediatR;
using ErrorOr;
using CustomCRM.Domain.Commons.Errors;

namespace CustomCRM.Application.Services.GetById
{
    public sealed class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, ErrorOr<ServiceResponse>>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServiceByIdQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
        }

        public async Task<ErrorOr<ServiceResponse>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            if (await _serviceRepository.GetByIdAsync(new ServiceId(request.id)) is not Service service) 
            {
                return ServiceErrors.ServiceNotFound;
            }

            return new ServiceResponse(
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
                );
        }
    }
}
