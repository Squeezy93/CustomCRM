using CustomCRM.Domain.Commons.Errors;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Services;
using ErrorOr;
using MediatR;

namespace CustomCRM.Application.Services.Delete
{
    public sealed class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, ErrorOr<Unit>>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteServiceCommandHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(DeleteServiceCommand command, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(new ServiceId(command.id));

            if (service is null)
            {
                return ServiceErrors.ServiceNotFound;
            }

            _serviceRepository.Delete(service);
            _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
