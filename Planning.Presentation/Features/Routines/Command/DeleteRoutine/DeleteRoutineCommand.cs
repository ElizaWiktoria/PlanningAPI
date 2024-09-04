using MediatR;

namespace Planning.Application.Features.Routines.Command.DeleteRoutine
{
    public class DeleteRoutineCommand : IRequest
    {
        public int Id { get; set; }
    }
}
