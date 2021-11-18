using DefaultPoc.Application.Application.WeatherForecast.Get;
using MediatR;
using Notifications.MediatR.Models;

namespace DefaultPoc.Application.Application.WeatherForecast
{
    public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastQuery, Result<Domain.Aggregates.WeatherForecast>>
    {

        public GetWeatherForecastHandler()
        {

        }

        public async Task<Result<Domain.Aggregates.WeatherForecast>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            return Result<Domain.Aggregates.WeatherForecast>.Success(new Domain.Aggregates.WeatherForecast());
        }
    }
}