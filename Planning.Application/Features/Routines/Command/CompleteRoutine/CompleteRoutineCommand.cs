using MediatR;

namespace Planning.Application.Features.Routines.Command.CompleteRoutine
{
    public class CompleteRoutineCommand : IRequest<DateOnly>
    {
        public int Id { get; set; }
    }
}
