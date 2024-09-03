using PlanningAPI.Models;

namespace Planning.Domain.Interfaces.Repository
{
    public interface IRoutineRepository : IGenericRepository<Routine>
    {
        IEnumerable<Routine> GetRoutinesIncludingPlans();
    }
}
