using Planning.Domain.Interfaces.Repository;
using Planning.Domain.UnitOfWork;
using Planning.Infrastructure.AutoMappers.DataContext;

namespace Planning.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContextEF _dbContext;
        private IRoutineRepository _routineRepository;
        private IPlanRepository _planRepository;

        public UnitOfWork(DataContextEF dbContext, IRoutineRepository routineRepository, IPlanRepository planRepository)
        {
            _dbContext = dbContext;
            _routineRepository = routineRepository;
            _planRepository = planRepository;
        }

        public IRoutineRepository RoutineRepository => _routineRepository;
        public IPlanRepository PlanRepository => _planRepository;

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