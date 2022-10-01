using FluentValidation;

namespace DefaultPoc.Application.Cars.Commands.Register
{
    public class RegisterCarCommandValidation : AbstractValidator<RegisterCarCommand>
    {
        public RegisterCarCommandValidation()
        {
            RuleFor(x => x.Model)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Brand)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Value)
                .NotNull()
                .GreaterThanOrEqualTo(0);
        }
    }
}