using ErrorOr;
using MediatR;

namespace CustomCRM.Application.Services.Delete
{
    public record DeleteServiceCommand(Guid id) : IRequest<ErrorOr<Unit>>
    {
    }
}
