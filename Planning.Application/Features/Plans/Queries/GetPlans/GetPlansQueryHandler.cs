using AutoMapper;
using MediatR;
using Planning.Domain.Dtos.PlanDtos;
using Planning.Domain.Models;
using Planning.Domain.UnitOfWork;

namespace Planning.Application.Features.Plans.Queries.GetPlans
{
    public class GetPlansQueryHandler : IRequestHandler<GetPlansQuery, IEnumerable<PlanDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPlansQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PlanDto>> Handle(GetPlansQuery request, CancellationToken cancellationToken)
        {
            var plans = await _unitOfWork.PlanRepository.GetPlansIncludingRoutineAsync();

            return _mapper.Map<IEnumerable<Plan>, IEnumerable<PlanDto>>(plans);
        }
    }
}
