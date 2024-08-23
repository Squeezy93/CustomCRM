using CustomCRM.Application.Services.Responses;
using MediatR;
using ErrorOr;

namespace CustomCRM.Application.Services.GetById
{
    public record GetServiceByIdQuery(Guid id) : IRequest<ErrorOr<ServiceResponse>>
    {
    }
}
