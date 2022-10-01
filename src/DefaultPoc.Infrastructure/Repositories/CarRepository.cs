using DefaultPoc.Domain.Aggregates;
using DefaultPoc.Domain.Enums;
using DefaultPoc.Domain.Interfaces;
using DefaultPoc.Domain.ViewModel;

namespace DefaultPoc.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        public CarRepository() { }

        public Task Create(Car request, CancellationToken cancellationToken)
            => Task.CompletedTask;

        public async Task<bool> Exists(string name, CancellationToken cancellationToken)
            => false;

        public async Task<IEnumerable<GetAllCarViewModel>> GetAll(CancellationToken cancellationToken)
            => new List<GetAllCarViewModel>
            {
                new GetAllCarViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Celta",
                    Brand = Brand.GM,
                    Model = "1.0",
                    Value = 20000
                },
                new GetAllCarViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Up",
                    Brand = Brand.VW,
                    Model = "1.0 TSI",
                    Value = 50000
                },
                new GetAllCarViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Jetta",
                    Brand = Brand.VW,
                    Model = "2.8 TSI",
                    Value = 70000
                },
                new GetAllCarViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Fusca",
                    Brand = Brand.VW,
                    Model = "1.4",
                    Value = 14000
                }
            };
    }
}