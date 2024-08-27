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
        public IEnumerable<RoutineDto> GetAllRoutines()
            => _planningService.GetAllRoutines();

        /// <summary>
        /// Create routine
        /// </summary>
        /// <param name="createRoutineDto"></param>
        /// <returns></returns>
        [HttpPost("CreateRoutine")]
        public RoutineDto CreateRoutine(CreateRoutineDto createRoutineDto)
            => _planningService.CreateRoutine(createRoutineDto);

        /// <summary>
        /// Complete routine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("CompleteRoutine")]
        public DateOnly CompleteRoutine(int id)
            => _planningService.CompleteRoutine(id);

        /// <summary>
        /// Delete routine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteRoutine")]
        public void DeleteRoutine(int id)
            => _planningService.DeleteRoutine(id);

        /// <summary>
        /// Modify routine
        /// </summary>
        /// <param name="modifyRoutine"></param>
        /// <returns></returns>
        [HttpPut("ModifyRoutine")]
        public RoutineDto ModifyRoutine(ModifyRoutineDto modifyRoutine)
            => _planningService.ModifyRoutine(modifyRoutine);

        /// <summary>
        /// Create a plan
        /// </summary>
        /// <param name="createPlan"></param>
        /// <returns></returns>
        [HttpPost("CreatePlan")]
        public PlanDto CreatePlan(CreatePlanDto createPlan)
            => _planningService.CreatePlan(createPlan);


        /// <summary>
        /// Get plans
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPlans")]
        public IEnumerable<PlanDto> GetPlans()
            => _planningService.GetPlans();


        /// <summary>
        /// Delete routine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeletePlan")]
        public void DeletePlan(int id)
            => _planningService.DeletePlan(id);
    }
}
