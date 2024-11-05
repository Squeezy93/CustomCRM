using CustomCRM.Application.Users.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomCRM.Api.Controllers
{
    [Microsoft.AspNetCore.Components.Route("users")]
    public class UsersController : ApiControllerBase
    {
        private readonly ISender _sender;

        public UsersController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery loginQuery)
        {
            var result = await _sender.Send(loginQuery);

            return result.Match(user => Ok(), errors => Problem(errors));
        }
    }
}
