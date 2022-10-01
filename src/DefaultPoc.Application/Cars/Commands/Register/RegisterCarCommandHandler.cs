using DefaultPoc.Domain.Aggregates;
using DefaultPoc.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Notifications.MediatR.Models;
using System.Diagnostics;

namespace DefaultPoc.Application.Cars.Commands.Register
{
    public class RegisterCarCommandHandler : IRequestHandler<RegisterCarCommand, Result>
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<RegisterCarCommandHandler> _logger;

        public RegisterCarCommandHandler
        (
            ICarRepository carRepository,
            ILogger<RegisterCarCommandHandler> logger
        )
        {
            _carRepository = carRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(RegisterCarCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Create new Car {name}", request.Name);
            var stopWatch = Stopwatch.StartNew();

            var exists = await _carRepository.Exists(request.Name!, cancellationToken);

            if (exists)
                return Result.Failure("Carro já registrado");

            var car = new Car
            (
                request.Brand!.Value,
                request.Name!,
                request.Model!,
                request.Value!.Value
            );

            await _carRepository.Create(car, cancellationToken);

            _logger.LogInformation("New Car Created, Elapsed Milliseconds: [{ElapsedMilliseconds}]", stopWatch.ElapsedMilliseconds);

            return Result.Success();
        }
    }
}