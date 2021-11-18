using MediatR;
using Notifications.MediatR.Models;

namespace DefaultPoc.Application.Application.WeatherForecast.Get
{
    public class GetWeatherForecastQuery : IRequest<Result<Domain.Aggregates.WeatherForecast>>
    {

    }
}