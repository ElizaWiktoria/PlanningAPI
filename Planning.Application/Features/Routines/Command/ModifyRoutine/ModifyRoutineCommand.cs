using MediatR;
using Planning.Domain.Dtos.RoutineDtos;

namespace Planning.Application.Features.Routines.Command.ModifyRoutine
{
    public class ModifyRoutineCommand : IRequest<RoutineDto>
    {
        public required ModifyRoutineDto ModifyRoutineDto {  get; set; }
    }
}
