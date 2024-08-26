using Microsoft.AspNetCore.Mvc;
using PlanningAPI.Dtos.PlanDtos;
using PlanningAPI.Dtos.RoutineDtos;
using PlanningAPI.Models;
using PlanningAPI.Services.PlanningService;

namespace PlanningAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanningController : ControllerBase
    {
        private readonly IPlanningService _planningService;

        public PlanningController(IPlanningService routineService)
        {
            _planningService = routineService;
        }

        /// <summary>
        /// Get all routines
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRoutines")]
        public IEnumerable<Routine> GetAllRoutines()
            => _planningService.GetAllRoutines();

        /// <summary>
        /// Create routine
        /// </summary>
        /// <param name="createRoutineDto"></param>
        /// <returns></returns>
        [HttpPost("CreateRoutine")]
        public Routine CreateRoutine(CreateRoutineDto createRoutineDto)
            => _planningService.CreateRoutine(createRoutineDto);

        /// <summary>
        /// Complete routine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("CompleteRoutine")]
        public string CompleteRoutine(int id)
            => _planningService.CompleteRoutine(id);

        /// <summary>
        /// Delete routine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteRoutine")]
        public bool DeleteRoutine(int id)
            => _planningService.DeleteRoutine(id);

        /// <summary>
        /// Modify routine
        /// </summary>
        /// <param name="modifyRoutine"></param>
        /// <returns></returns>
        [HttpPut("ModifyRoutine")]
        public Routine ModifyRoutine(ModifyRoutineDto modifyRoutine)
            => _planningService.ModifyRoutine(modifyRoutine);

        /// <summary>
        /// Create a plan
        /// </summary>
        /// <param name="createPlan"></param>
        /// <returns></returns>
        [HttpPost("CreatePlan")]
        public Plan CreatePlan(CreatePlanDto createPlan)
            => _planningService.CreatePlan(createPlan);


        /// <summary>
        /// Get plans
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPlans")]
        public IEnumerable<Plan> GetPlans()
            => _planningService.GetPlans();


        /// <summary>
        /// Delete routine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeletePlan")]
        public bool DeletePlan(int id)
            => _planningService.DeletePlan(id);
    }
}
