using DefaultPoc.Domain.Aggregates;
using DefaultPoc.Domain.ViewModel;

namespace DefaultPoc.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task Create(Car request, CancellationToken cancellationToken);

        Task<bool> Exists(string name, CancellationToken cancellationToken);

        Task<IEnumerable<GetAllCarViewModel>> GetAll(CancellationToken cancellationToken);
    }
}