using DefaultPoc.Domain.Enums;
using MediatR;
using Notifications.MediatR.Models;

namespace DefaultPoc.Application.Cars.Commands.Register
{
    public class RegisterCarCommand : IRequest<Result>
    {
        public Brand? Brand { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
        public decimal? Value { get; set; }
    }
}