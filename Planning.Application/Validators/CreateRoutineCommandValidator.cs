using FluentValidation;
using Planning.Application.Features.Routines.Command.CreateRoutine;

namespace Planning.Application.Validators
{
    public class CreateRoutineCommandValidator : AbstractValidator<CreateRoutineCommand>
    {
        public CreateRoutineCommandValidator()
        {
            RuleFor(x => x.CreateRoutineDto.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Name must be longer than 3 characters.");

            RuleFor(x => x.CreateRoutineDto.FrequencyInDays)
                .GreaterThan(0)
                .WithMessage("Frequency must be greater than 0.");
        }
    }
}
