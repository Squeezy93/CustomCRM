using CustomCRM.Application.Services.Responses;
using ErrorOr;
using MediatR;

namespace CustomCRM.Application.Services.GetAll
{
    public record GetAllServicesQuery : IRequest<ErrorOr<List<ServiceResponse>>>
    {
    }
}
