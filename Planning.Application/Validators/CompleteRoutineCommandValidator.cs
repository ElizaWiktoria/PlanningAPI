using FluentValidation;
using Planning.Application.Features.Routines.Command.CompleteRoutine;

namespace Planning.Application.Validators
{
    public class CompleteRoutineCommandValidator : AbstractValidator<CompleteRoutineCommand>
    {
        public CompleteRoutineCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
