using PlanningAPI.Dtos.PlanDtos;
using PlanningAPI.Dtos.RoutineDtos;
using PlanningAPI.Models;

namespace PlanningAPI.Services.PlanningService
{
    public interface IPlanningService
    {
        IEnumerable<Routine> GetAllRoutines();
        Routine CreateRoutine(CreateRoutineDto createRoutineDto);
        string CompleteRoutine(int id);
        bool DeleteRoutine(int id);
        Routine ModifyRoutine(ModifyRoutineDto modifyRoutine);
        Plan CreatePlan(CreatePlanDto createPlan);
        IEnumerable<Plan> GetPlans();
        bool DeletePlan(int id);
    }
}
