using PlanningAPI.Dtos.PlanDtos;
using PlanningAPI.Dtos.RoutineDtos;

namespace PlanningAPI.Services.PlanningService
{
    public interface IPlanningService
    {
        Task<IEnumerable<MinimalRoutine>> GetAllRoutinesAsync();
        Task<RoutineDto> CreateRoutineAsync(CreateRoutineDto createRoutineDto);
        Task<DateOnly> CompleteRoutineAsync(int id);
        Task DeleteRoutineAsync(int id);
        Task<RoutineDto> ModifyRoutineAsync(ModifyRoutineDto modifyRoutine);
        Task<PlanDto> CreatePlanAsync(CreatePlanDto createPlan);
        Task<IEnumerable<PlanDto>> GetPlansAsync();
        Task DeletePlanAsync(int id);
    }
}
