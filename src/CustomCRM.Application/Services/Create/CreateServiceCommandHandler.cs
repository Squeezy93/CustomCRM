using CustomCRM.Application.Utilities.DateTimes;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Services;
using CustomCRM.Domain.ValueObjects.Services;
using MediatR;

namespace CustomCRM.Application.Services.Create
{
    public sealed class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Unit>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider = new DateTimeProvider();

        public CreateServiceCommandHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
        {
            if(ServiceType.Create(command.serviceType) is not ServiceType serviceType)
            {
                throw new InvalidOperationException(nameof(serviceType));
            }
            if (Price.Create(command.amount, command.currency) is not Price price) 
            {
                throw new InvalidOperationException(nameof(price));
            }                     

            var service = new Service(
                new ServiceId(Guid.NewGuid()),
                serviceType,
                _dateTimeProvider.GetMoscowTime(), 
                command.difficult,
                Domain.Commons.Status.Waiting,
                price,
                command.quantity,
                Screenshot.Create(string.Empty),
                command.comment
                );

            _serviceRepository.Create(service);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;            
        }        
    }
}
