using Planning.Domain.Interfaces.Repository;

namespace Planning.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRoutineRepository RoutineRepository { get; }
        IPlanRepository PlanRepository { get; }
        Task CommitAsync();
        void Commit();
        Task RollbackAsync();
        void Rollback();
    }
}
