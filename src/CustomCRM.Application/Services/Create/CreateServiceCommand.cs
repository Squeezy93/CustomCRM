using CustomCRM.Domain.Commons;
using CustomCRM.Domain.ValueObjects.Services;
using MediatR;

namespace CustomCRM.Application.Services.Create
{
    public record CreateServiceCommand(string serviceType,
        Difficult difficult,
        Status status,
        decimal amount, 
        string currency, 
        int quantity, 
        string
        screenshotURL,
        string comment) : IRequest<Unit>;    
}
