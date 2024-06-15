using CustomCRM.Domain.Commons;
using MediatR;

namespace CustomCRM.Application.Services.Create
{
    public record CreateServiceCommand(
        string serviceType,
        Difficult difficult,
        decimal amount,
        Currency currency, 
        int quantity,        
        string comment
        ) : IRequest<Unit>;    
}

