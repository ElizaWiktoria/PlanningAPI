using PlanningAPI.Dtos.PlanDtos;
using PlanningAPI.Dtos.RoutineDtos;
using PlanningAPI.Models;

namespace PlanningAPI.Services.PlanningService
{
    public interface IPlanningService
    {
        IEnumerable<RoutineDto> GetAllRoutines();
        RoutineDto CreateRoutine(CreateRoutineDto createRoutineDto);
        DateOnly CompleteRoutine(int id);
        void DeleteRoutine(int id);
        RoutineDto ModifyRoutine(ModifyRoutineDto modifyRoutine);
        PlanDto CreatePlan(CreatePlanDto createPlan);
        IEnumerable<PlanDto> GetPlans();
        void DeletePlan(int id);
    }
}
