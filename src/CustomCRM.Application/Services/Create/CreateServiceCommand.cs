using CustomCRM.Domain.Commons.Enums;
using CustomCRM.Domain.Commons.Enums.Services;
using ErrorOr;
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
        ) : IRequest<ErrorOr<Unit>>;    
}

