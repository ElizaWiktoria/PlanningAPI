using FluentValidation;
using Planning.Application.Features.Routines.Command.DeleteRoutine;

namespace Planning.Application.Validators
{
    public class DeleteRoutineCommandValidator : AbstractValidator<DeleteRoutineCommand>
    {
        public DeleteRoutineCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
