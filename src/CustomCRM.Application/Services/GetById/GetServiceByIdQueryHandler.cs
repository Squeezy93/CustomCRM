using CustomCRM.Application.Services.Responses;
using CustomCRM.Application.Utilities.DateTimes;
using CustomCRM.Domain.Services;
using MediatR;

namespace CustomCRM.Application.Services.GetById
{
    public sealed class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, ServiceResponse>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IDateTimeProvider _dateTimeProvider = new DateTimeProvider();

        public GetServiceByIdQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
        }

        public async Task<ServiceResponse> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            if (await _serviceRepository.GetByIdAsync(new ServiceId(request.id)) is not Service service) 
            {
                throw new ArgumentNullException(nameof(service));
            }

            return new ServiceResponse(
                service.ServiceId.Value, 
                service.ServiceType.Value,
                _dateTimeProvider.GetMoscowTime(),
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
