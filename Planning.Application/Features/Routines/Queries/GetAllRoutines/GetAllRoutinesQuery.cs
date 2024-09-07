using MediatR;
using Planning.Domain.Dtos.RoutineDtos;

namespace Planning.Application.Features.Routines.Queries.GetAllRoutines
{
    public class GetAllRoutinesQuery : IRequest<IEnumerable<MinimalRoutine>>
    {
    }
}
