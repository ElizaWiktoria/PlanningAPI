using Planning.Domain.Interfaces.Repository;

namespace PlanningAPI.UnitOfWork
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
