using Microsoft.EntityFrameworkCore;
using Planning.Domain.Interfaces.Repository;
using Planning.Domain.Models;
using Planning.Infrastructure.AutoMappers.DataContext;

namespace Planning.Infrastructure.Repositories
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
