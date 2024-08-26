using PlanningAPI.Repositories.PlanRepository;
using PlanningAPI.Repositories.RoutineRepository;

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
