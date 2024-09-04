using AutoMapper;
using MediatR;
using PlanningAPI.Dtos.PlanDtos;
using PlanningAPI.Exceptions.PlanningService;
using PlanningAPI.Models;
using PlanningAPI.UnitOfWork;

namespace Planning.Application.Features.Plans.Command.CreatePlan
{
    public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, PlanDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePlanCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PlanDto> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = _mapper.Map<CreatePlanDto, Plan>(request.CreatePlanDto);

            if (request.CreatePlanDto.RoutineId != null)
            {
                var routine = await _unitOfWork.RoutineRepository.GetAsync(x => x.Id == request.CreatePlanDto.RoutineId);
                if (routine == null)
                    throw new IllegalArgumentException("Routine of given id does not exist.");
                plan.Routine = routine;
            }

            await _unitOfWork.PlanRepository.AddAsync(plan);
            await _unitOfWork.PlanRepository.SaveChangesAsync();

            return _mapper.Map<Plan, PlanDto>(plan);
        }
    }
}
