using Microsoft.AspNetCore.Mvc;
using PlanningAPI.Dtos.PlanDtos;
using PlanningAPI.Dtos.RoutineDtos;
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
        [HttpGet("routines")]
        public async Task<IEnumerable<MinimalRoutine>> GetAllRoutinesAsync()
            => await _planningService.GetAllRoutinesAsync();

        /// <summary>
        /// Create routine
        /// </summary>
        /// <param name="createRoutineDto"></param>
        /// <returns></returns>
        [HttpPost("routines")]
        public async Task<RoutineDto> CreateRoutineAsync(CreateRoutineDto createRoutineDto)
            => await _planningService.CreateRoutineAsync(createRoutineDto);

        /// <summary>
        /// Complete routine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("routines/{id}/complete")]
        [ProducesResponseType<DateOnly>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<DateOnly> CompleteRoutineAsync(int id)
            => await _planningService.CompleteRoutineAsync(id);

        /// <summary>
        /// Delete routine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("routines/{id}")]
        public async Task DeleteRoutineAsync(int id)
            => await _planningService.DeleteRoutineAsync(id);

        /// <summary>
        /// Modify routine
        /// </summary>
        /// <param name="modifyRoutineDto"></param>
        /// <returns></returns>
        [HttpPut("routines")]
        public async Task<RoutineDto> ModifyRoutineAsync(ModifyRoutineDto modifyRoutineDto)
            => await _planningService.ModifyRoutineAsync(modifyRoutineDto);

        /// <summary>
        /// Create a plan
        /// </summary>
        /// <param name="createPlan"></param>
        /// <returns></returns>
        [HttpPost("plans")]
        public async Task<PlanDto> CreatePlan(CreatePlanDto createPlan)
            => await _planningService.CreatePlanAsync(createPlan);


        /// <summary>
        /// Get plans
        /// </summary>
        /// <returns></returns>
        [HttpGet("plans")]
        public async Task<IEnumerable<PlanDto>> GetPlansAsync()
            => await _planningService.GetPlansAsync();


        /// <summary>
        /// Delete routine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("plan/{id}")]
        public async Task DeletePlanAsync(int id)
            => await _planningService.DeletePlanAsync(id);
    }
}
