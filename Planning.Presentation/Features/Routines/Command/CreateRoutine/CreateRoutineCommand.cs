using MediatR;
using PlanningAPI.Dtos.RoutineDtos;

namespace Planning.Application.Features.Routines.Command.CreateRoutine
{
    public class CreateRoutineCommand : IRequest<RoutineDto>
    {
        public required CreateRoutineDto CreateRoutineDto { get; set; }
    }
}
