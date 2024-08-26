using PlanningAPI.Models;

namespace PlanningAPI.Repositories.RoutineRepository
{
    public interface IRoutineRepository : IGenericRepository<Routine>
    {
        IEnumerable<Routine> GetRoutinesIncludingPlans();
    }
}
