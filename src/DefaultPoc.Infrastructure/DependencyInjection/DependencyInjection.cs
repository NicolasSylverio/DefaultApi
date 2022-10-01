using DefaultPoc.Domain.Interfaces;
using DefaultPoc.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DefaultPoc.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IWeatherForecastRepositories, WeatherForecastRepository>();

            return services;
        }
    }
}