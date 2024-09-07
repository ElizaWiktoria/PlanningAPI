using MediatR;
using Planning.Domain.Dtos.PlanDtos;

namespace Planning.Application.Features.Plans.Command.CreatePlan
{
    public class CreatePlanCommand : IRequest<PlanDto>
    {
        public required CreatePlanDto CreatePlanDto { get; set; }
    }
}
