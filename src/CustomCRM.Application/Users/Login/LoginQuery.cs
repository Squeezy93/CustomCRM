using MediatR;
using ErrorOr;

namespace CustomCRM.Application.Users.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<LoginQueryResponce>>
    {
    }
}
