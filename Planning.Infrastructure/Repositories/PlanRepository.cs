using Microsoft.EntityFrameworkCore;
using Planning.Domain.Interfaces.Repository;
using Planning.Domain.Models;
using Planning.Infrastructure.AutoMappers.DataContext;

namespace Planning.Infrastructure.Repositories
{
    public class PlanRepository : GenericRepository<Plan>, IPlanRepository
    {
        public PlanRepository(DataContextEF dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Plan>> GetPlansIncludingRoutineAsync()
        {
            return await _dbContext.Plans
                .Include(x => x.Routine)
                .AsQueryable()
                .ToListAsync();
        }
    }
}
