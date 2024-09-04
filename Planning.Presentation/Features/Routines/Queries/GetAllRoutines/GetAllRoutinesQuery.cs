using MediatR;
using PlanningAPI.Dtos.RoutineDtos;

namespace Planning.Application.Features.Routines.Queries.GetAllRoutines
{
    public class GetAllRoutinesQuery : IRequest<IEnumerable<MinimalRoutine>>
    {
    }
}
