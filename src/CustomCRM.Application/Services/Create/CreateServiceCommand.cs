using CustomCRM.Domain.Commons;
using MediatR;

namespace CustomCRM.Application.Services.Create
{
    public record CreateServiceCommand(string serviceType,
        Difficult difficult,
        Status status,
        decimal amount,
        Currency currency, 
        int quantity, 
        string screenshotURL,
        string comment) : IRequest<Unit>;    
}

