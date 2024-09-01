using PlanningAPI.Models;

namespace PlanningAPI.Repositories.PlanRepository
{
    public interface IPlanRepository : IGenericRepository<Plan>
    {
        Task<IEnumerable<Plan>> GetPlansIncludingRoutineAsync();
    }
}
