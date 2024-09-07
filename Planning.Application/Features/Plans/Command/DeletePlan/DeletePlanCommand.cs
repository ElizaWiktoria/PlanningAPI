using MediatR;

namespace Planning.Application.Features.Plans.Command.DeletePlan
{
    public class DeletePlanCommand : IRequest
    {
        public int Id { get; set; }
    }
}
