using CustomCRM.Domain.Commons;
using MediatR;

namespace CustomCRM.Application.Services.Update
{
    public record UpdateServiceCommand(
        Guid id,
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
