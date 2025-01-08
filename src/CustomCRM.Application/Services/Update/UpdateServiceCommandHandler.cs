using CustomCRM.Application.Utilities.DateTimes;
using CustomCRM.Domain.Commons.Errors;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Services;
using CustomCRM.Domain.ValueObjects.Services;
using ErrorOr;
using MediatR;

namespace CustomCRM.Application.Services.Update
{
    public sealed class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, ErrorOr<Unit>>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public UpdateServiceCommandHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(_dateTimeProvider));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateServiceCommand command, CancellationToken cancellationToken)
        {
            var serviceId = new ServiceId(command.id); 
            var service = await _serviceRepository.GetByIdAsync(serviceId);

            if (service == null)
            {
                return ServiceErrors.ServiceNotFound;
            }

            if (ServiceType.Update(command.serviceType) is not ServiceType serviceType)
            {
                return ServiceErrors.ServiceTypeIsNotValid;
            }

            if (Price.Update(command.amount, command.currency) is not Price price)
            {
                return ServiceErrors.PriceIsNotValid;
            }

            if (Screenshot.Update(command.screenshot) is not Screenshot screenshot) 
            {
                return ServiceErrors.ScreenshotIsNotValid;
            }

            Service.Update(
                service.ServiceId.Value,
                serviceType,
                service.Created,
                _dateTimeProvider.GetMoscowTime(),
                command.difficult,
                command.status,
                price,
                command.quantity,
                screenshot,
                command.comment
                );

            _serviceRepository.Update(service);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
