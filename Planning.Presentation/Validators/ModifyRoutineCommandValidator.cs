using FluentValidation;
using Planning.Application.Features.Routines.Command.ModifyRoutine;

namespace Planning.Application.Validators
{
    public class ModifyRoutineCommandValidator : AbstractValidator<ModifyRoutineCommand>
    {
        public ModifyRoutineCommandValidator()
        {
            RuleFor(x => x.ModifyRoutineDto.Name)
                .MinimumLength(3)
                .WithMessage("Name must be longer than 3 characters.");

            RuleFor(x => x.ModifyRoutineDto.FrequencyInDays)
                .GreaterThan(0)
                .WithMessage("Frequency must be greater than 0.");

            RuleFor(x => x.ModifyRoutineDto.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
