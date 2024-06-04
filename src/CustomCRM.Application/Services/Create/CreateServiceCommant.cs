using CustomCRM.Domain.Commons;
using MediatR;

namespace CustomCRM.Application.Services.Create
{
    public record CreateServiceCommant(string serviceType, Difficult difficult, decimal price, string currency, int quantity, string comment) : IRequest<Unit>;    
    
}
