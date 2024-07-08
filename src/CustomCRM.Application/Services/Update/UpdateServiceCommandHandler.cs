using CustomCRM.Application.Utilities.DateTimes;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Services;
using CustomCRM.Domain.ValueObjects.Services;
using MediatR;

namespace CustomCRM.Application.Services.Update
{
    public sealed class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Unit>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider = new DateTimeProvider();

        public UpdateServiceCommandHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(UpdateServiceCommand command, CancellationToken cancellationToken)
        {
            var serviceId = new ServiceId(command.id); // правильно ли оформлено
            var service = await _serviceRepository.GetByIdAsync(serviceId);

            if (service == null)
            {
                throw new NullReferenceException(nameof(service));
            }

            if (ServiceType.Update(command.serviceType) is not ServiceType serviceType)
            {
                throw new InvalidOperationException(nameof(serviceType));
            }

            if (Price.Update(command.amount, command.currency) is not Price price)
            {
                throw new InvalidOperationException(nameof(price));
            }

            if (Screenshot.Update(command.screenshot) is not Screenshot screenshot) 
            {
                throw new InvalidOperationException(nameof(screenshot));
            }

            service = Service.Update(
                service.ServiceId.Value,
                serviceType,
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
