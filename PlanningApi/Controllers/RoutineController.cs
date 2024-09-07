using MediatR;
using Microsoft.AspNetCore.Mvc;
using Planning.Application.Features.Routines.Command.CompleteRoutine;
using Planning.Application.Features.Routines.Command.CreateRoutine;
using Planning.Application.Features.Routines.Command.DeleteRoutine;
using Planning.Application.Features.Routines.Command.ModifyRoutine;
using Planning.Application.Features.Routines.Queries.GetAllRoutines;
using Planning.Domain.Dtos.RoutineDtos;

namespace PlanningAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoutineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all routines
        /// </summary>
        /// <returns></returns>
        [HttpGet("routines")]
        [ProducesResponseType<IEnumerable<MinimalRoutine>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<MinimalRoutine>> GetAllRoutinesAsync()
            => await _mediator.Send(new GetAllRoutinesQuery { });

        /// <summary>
        /// Create routine
        /// </summary>
        /// <param name="createRoutineDto"></param>
        /// <returns></returns>
        [HttpPost("routines")]
        [ProducesResponseType<RoutineDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<RoutineDto> CreateRoutineAsync(CreateRoutineDto createRoutineDto)
            => await _mediator.Send(new CreateRoutineCommand { CreateRoutineDto = createRoutineDto });

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
            => await _mediator.Send(new CompleteRoutineCommand { Id = id });

        /// <summary>
        /// Delete routine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("routines/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task DeleteRoutineAsync(int id)
            => await _mediator.Send(new DeleteRoutineCommand { Id = id });

        /// <summary>
        /// Modify routine
        /// </summary>
        /// <param name="modifyRoutineDto"></param>
        /// <returns></returns>
        [HttpPut("routines")]
        [ProducesResponseType<RoutineDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<RoutineDto> ModifyRoutineAsync(ModifyRoutineDto modifyRoutineDto)
            => await _mediator.Send(new ModifyRoutineCommand { ModifyRoutineDto = modifyRoutineDto });
    }
}
