using CustomCRM.Application.Services.Create;
using CustomCRM.Application.Services.Delete;
using CustomCRM.Application.Services.GetAll;
using CustomCRM.Application.Services.GetById;
using CustomCRM.Application.Services.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomCRM.Api.Controllers
{
    [Route("servicesResult")]
    /*[Authorize]*/
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var deleteResult = await _sender.Send(new DeleteServiceCommand(id));
            return deleteResult.Match(result => Ok(result), errors => Problem(errors));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servicesResult = await _sender.Send(new GetAllServicesQuery());
            return servicesResult.Match(result => Ok(result), errors => Problem(errors));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateServiceCommand command)
        {
            var updateResult = await _sender.Send(command);
            return updateResult.Match(result => Ok(result), errors => Problem(errors));
        }
    }
}
