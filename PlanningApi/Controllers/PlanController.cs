using MediatR;
using Microsoft.AspNetCore.Mvc;
using Planning.Application.Features.Plans.Command.CreatePlan;
using Planning.Application.Features.Plans.Command.DeletePlan;
using Planning.Application.Features.Plans.Queries.GetPlans;
using PlanningAPI.Dtos.PlanDtos;

namespace PlanningAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create a plan
        /// </summary>
        /// <param name="createPlanDto"></param>
        /// <returns></returns>
        [HttpPost("plans")]
        [ProducesResponseType<PlanDto>(StatusCodes.Status200OK)]
        [ProducesResponseType<PlanDto>(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<PlanDto> CreatePlanAsync(CreatePlanDto createPlanDto)
            => await _mediator.Send(new CreatePlanCommand { CreatePlanDto = createPlanDto });


        /// <summary>
        /// Get plans
        /// </summary>
        /// <returns></returns>
        [HttpGet("plans")]
        [ProducesResponseType<IEnumerable<PlanDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<PlanDto>> GetPlansAsync()
            => await _mediator.Send(new GetPlansQuery { });


        /// <summary>
        /// Delete routine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("plan/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task DeletePlanAsync(int id)
            => await _mediator.Send(new DeletePlanCommand { Id = id });
    }
}
