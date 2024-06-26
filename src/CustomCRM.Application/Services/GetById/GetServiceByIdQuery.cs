using CustomCRM.Application.Services.Responses;
using MediatR;

namespace CustomCRM.Application.Services.GetById
{
    public record GetServiceByIdQuery(Guid id) : IRequest<ServiceResponse>
    {
    }
}
