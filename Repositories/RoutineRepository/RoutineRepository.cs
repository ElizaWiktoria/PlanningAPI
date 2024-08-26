using Microsoft.EntityFrameworkCore;
using PlanningAPI.DataContext;
using PlanningAPI.Models;

namespace PlanningAPI.Repositories.RoutineRepository
{
    public class RoutineRepository : GenericRepository<Routine>, IRoutineRepository
    {
        public RoutineRepository(DataContextEF dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Routine> GetRoutinesIncludingPlans()
        {
            return _dbContext.Routines
                .Include(x => x.Plans)
                .AsQueryable()
                .ToList();
        }
    }
}
