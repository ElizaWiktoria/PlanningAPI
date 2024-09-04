using MediatR;
using PlanningAPI.Exceptions.PlanningService;
using PlanningAPI.UnitOfWork;

namespace Planning.Application.Features.Routines.Command.CompleteRoutine
{
    public class CompleteRoutineCommandHandler : IRequestHandler<CompleteRoutineCommand, DateOnly>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompleteRoutineCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DateOnly> Handle(CompleteRoutineCommand request, CancellationToken cancellationToken)
        {
            var routine = await _unitOfWork.RoutineRepository.GetAsync(x => x.Id == request.Id);
            if (routine == null)
                throw new NotFoundException("Routine of given id does not exist.");

            var today = DateOnly.FromDateTime(DateTime.Now);
            routine.LastDone = today;
            await _unitOfWork.RoutineRepository.SaveChangesAsync();

            return today;
        }
    }
}
