using PlanningAPI.Models;

namespace Planning.Domain.Interfaces.Repository
{
    public interface IPlanRepository : IGenericRepository<Plan>
    {
        Task<IEnumerable<Plan>> GetPlansIncludingRoutineAsync();
    }
}
