using MediatR;
using Planning.Domain.Exceptions.PlanningService;
using Planning.Domain.UnitOfWork;

namespace Planning.Application.Features.Plans.Command.DeletePlan
{
    public class DeletePlanCommandHandler : IRequestHandler<DeletePlanCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePlanCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeletePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = _unitOfWork.PlanRepository.Get(x => x.Id == request.Id);
            if (plan == null)
                throw new NotFoundException("Plan of given id does not exist.");

            _unitOfWork.PlanRepository.Remove(plan);
            await _unitOfWork.PlanRepository.SaveChangesAsync();
        }
    }
}
