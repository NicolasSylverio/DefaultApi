using DefaultPoc.Domain.Interfaces;
using DefaultPoc.Domain.ViewModel;
using MediatR;
using Microsoft.Extensions.Logging;
using Notifications.MediatR.Models;
using System.Diagnostics;

namespace DefaultPoc.Application.Cars.Queries.GetAll
{
    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, Result<IEnumerable<GetAllCarViewModel>>>
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<GetAllCarQueryHandler> _logger;

        public GetAllCarQueryHandler
        (
            ICarRepository carRepository,
            ILogger<GetAllCarQueryHandler> logger
        )
        {
            _carRepository = carRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<GetAllCarViewModel>>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            var stopWatch = Stopwatch.StartNew();

            var cars = await _carRepository.GetAll(cancellationToken);

            _logger.LogInformation("Get All Cars Query, Elapsed Milliseconds: [{ElapsedMilliseconds}]", stopWatch.ElapsedMilliseconds);

            return Result<IEnumerable<GetAllCarViewModel>>.Success(cars);
        }
    }
}
