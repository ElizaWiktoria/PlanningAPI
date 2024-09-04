using MediatR;
using PlanningAPI.Exceptions.PlanningService;
using PlanningAPI.UnitOfWork;

namespace Planning.Application.Features.Routines.Command.DeleteRoutine
{
    public class DeleteRoutineCommandHandler : IRequestHandler<DeleteRoutineCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoutineCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteRoutineCommand request, CancellationToken cancellationToken)
        {
            var routine = await _unitOfWork.RoutineRepository.GetAsync(x => x.Id == request.Id);
            if (routine == null)
                throw new NotFoundException("Routine of given id does not exist.");

            _unitOfWork.RoutineRepository.Remove(routine);
            await _unitOfWork.RoutineRepository.SaveChangesAsync();
        }
    }
}
