using PlanningAPI.Models;

namespace PlanningAPI.Repositories.PlanRepository
{
    public interface IPlanRepository : IGenericRepository<Plan>
    {
        IEnumerable<Plan> GetPlansIncludingRoutine();
    }
}
