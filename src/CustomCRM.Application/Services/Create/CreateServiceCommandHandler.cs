using CustomCRM.Application.Utilities.DateTimes;
using CustomCRM.Domain.Commons.Enums;
using CustomCRM.Domain.Commons.Errors;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Services;
using CustomCRM.Domain.ValueObjects.Services;
using ErrorOr;
using MediatR;

namespace CustomCRM.Application.Services.Create
{
    public sealed class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, ErrorOr<Unit>>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateServiceCommandHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
        {
            if(ServiceType.Create(command.serviceType) is not ServiceType serviceType || command.serviceType is null)
            {
                return ServiceErrors.ServiceTypeIsNotValid;
            }
            if (Price.Create(command.amount, command.currency) is not Price price) 
            {
                return ServiceErrors.PriceIsNotValid;
            }                     

            var service = new Service(
                new ServiceId(Guid.NewGuid()),
                serviceType,
                _dateTimeProvider.GetMoscowTime(),
                _dateTimeProvider.GetMoscowTime(),
                command.difficult,
                Status.Waiting,
                price,
                command.quantity,
                Screenshot.Create(string.Empty),
                command.comment
                );

            _serviceRepository.Create(service);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;            
        }        
    }
}
