using AutoMapper;
using MediatR;
using Planning.Domain.Dtos.RoutineDtos;
using Planning.Domain.Exceptions.PlanningService;
using Planning.Domain.UnitOfWork;

namespace Planning.Application.Features.Routines.Command.ModifyRoutine
{
    public class ModifyRoutineCommandHandler : IRequestHandler<ModifyRoutineCommand, RoutineDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModifyRoutineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoutineDto> Handle(ModifyRoutineCommand request, CancellationToken cancellationToken)
        {
            var routine = await _unitOfWork.RoutineRepository.GetAsync(x => x.Id == request.ModifyRoutineDto.Id);
            if (routine == null)
                throw new NotFoundException("Routine of given id does not exist.");

            routine.FrequencyInDays = request.ModifyRoutineDto.FrequencyInDays;
            routine.Name = request.ModifyRoutineDto.Name;
            routine.LastDone = DateOnly.Parse(request.ModifyRoutineDto.LastDone);
            await _unitOfWork.RoutineRepository.SaveChangesAsync();

            return _mapper.Map<RoutineDto>(routine);
        }
    }
}
