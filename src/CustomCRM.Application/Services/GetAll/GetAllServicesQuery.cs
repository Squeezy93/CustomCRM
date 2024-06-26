using CustomCRM.Application.Services.Responses;
using MediatR;

namespace CustomCRM.Application.Services.GetAll
{
    public record GetAllServicesQuery : IRequest<List<ServiceResponse>>
    {
    }
}
