using FluentValidation;
using Planning.Application.Features.Plans.Command.CreatePlan;

namespace Planning.Application.Validators
{
    public class CreatePlanCommandValidator : AbstractValidator<CreatePlanCommand>
    {
        public CreatePlanCommandValidator()
        {
            RuleFor(x => x.CreatePlanDto.Name)
                .MinimumLength(3)
                .WithMessage("Name must be longer than 3 characters.");

            RuleFor(x => x.CreatePlanDto.RoutineId)
                .Must(BeGreaterThanZeroOrNull)
                .WithMessage("Value must be greater than 0 or null.");
        }

        private bool BeGreaterThanZeroOrNull(int? value)
        {
            return value == null || value > 0;
        }
    }
}
