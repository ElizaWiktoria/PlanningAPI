using MediatR;
using PlanningAPI.Dtos.PlanDtos;

namespace Planning.Application.Features.Plans.Queries.GetPlans
{
    public class GetPlansQuery : IRequest<IEnumerable<PlanDto>>
    {
    }
}
