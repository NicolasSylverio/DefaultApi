using DefaultPoc.Application.Application.WeatherForecast.Get;
using DefaultPoc.Domain.Aggregates;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notifications.MediatR.Models;
using System.Net;

namespace DefaultPoc.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController
        (
            ILogger<WeatherForecastController> logger,
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<WeatherForecast>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result<WeatherForecast>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Result<WeatherForecast>>> Get([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetWeatherForecastQuery());

            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }
    }
}