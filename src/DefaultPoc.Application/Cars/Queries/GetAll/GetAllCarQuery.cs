using DefaultPoc.Domain.ViewModel;
using MediatR;
using Notifications.MediatR.Models;

namespace DefaultPoc.Application.Cars.Queries.GetAll
{
    public class GetAllCarQuery : IRequest<Result<IEnumerable<GetAllCarViewModel>>>
    {

    }
}