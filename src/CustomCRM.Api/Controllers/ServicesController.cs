using CustomCRM.Application.Services.Create;
using CustomCRM.Application.Services.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomCRM.Api.Controllers
{
    [Route("services")]
    public class ServicesController : ApiControllerBase
    {
        private readonly ISender _sender;

        public ServicesController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateServiceCommand command)
        {
            var createResult =  await _sender.Send(command);
            return createResult.Match(result => Created(), errors => Problem(errors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var serviceResult = await _sender.Send(new GetServiceByIdQuery(id));
            return serviceResult.Match(result => Ok(result), errors => Problem(errors));
        }
    }
}
