using PlanningAPI.DataContext;
using PlanningAPI.Repositories.PlanRepository;
using PlanningAPI.Repositories.RoutineRepository;

namespace PlanningAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContextEF _dbContext;
        private IRoutineRepository? _routineRepository;
        private IPlanRepository? _planRepository;

        public UnitOfWork(DataContextEF dbContext)
        {
            _dbContext = dbContext;
        }

        public IRoutineRepository RoutineRepository => _routineRepository ??= new RoutineRepository(_dbContext);
        public IPlanRepository PlanRepository => _planRepository ??= new PlanRepository(_dbContext);

        public void Commit()
            => _dbContext.SaveChanges();

        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();

        public void Rollback()
            => _dbContext.Dispose();

        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
