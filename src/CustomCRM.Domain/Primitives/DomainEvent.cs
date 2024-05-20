using MediatR;

namespace CustomCRM.Domain.Primitives
{
    public record DomainEvent(Guid Id) : INotification
    {
    }
}
