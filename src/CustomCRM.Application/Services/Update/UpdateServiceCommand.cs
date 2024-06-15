using CustomCRM.Domain.Commons;
using CustomCRM.Domain.Services;
using MediatR;

namespace CustomCRM.Application.Services.Update
{
    public record UpdateServiceCommand(
        Guid serviceId, // как с внешки читается этот гуид
        string serviceType,
        Difficult difficult,
        Status status,
        decimal amount,
        Currency currency,
        int quantity,
        string screenshot,
        string comment
        ) : IRequest<Unit>; 
}
