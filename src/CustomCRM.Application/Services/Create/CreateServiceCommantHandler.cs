using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Services;
using MediatR;

namespace CustomCRM.Application.Services.Create
{
    public sealed class CreateServiceCommantHandler : IRequestHandler<CreateServiceCommant, Unit>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateServiceCommantHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<Unit> Handle(CreateServiceCommant command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
