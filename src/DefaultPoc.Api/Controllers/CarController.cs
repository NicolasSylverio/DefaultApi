using DefaultPoc.Application.Cars.Commands.Register;
using DefaultPoc.Application.Cars.Queries.GetAll;
using DefaultPoc.Domain.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notifications.MediatR.Models;
using System.Net;

namespace DefaultPoc.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ApiBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// Register New Car
        /// </summary>
        /// <param name="command">Command for register new car</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Register Result</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Result>> RegisterCar([FromQuery] RegisterCarCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }

        /// <summary>
        /// Get All Registered Cars
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Returns enumerable of registered cars</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<Result<IEnumerable<GetAllCarViewModel>>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllCarQuery(), cancellationToken);

            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }
    }
}