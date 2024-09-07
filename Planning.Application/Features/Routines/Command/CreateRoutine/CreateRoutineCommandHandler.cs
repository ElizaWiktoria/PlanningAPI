using AutoMapper;
using MediatR;
using Planning.Domain.Dtos.RoutineDtos;
using Planning.Domain.Models;
using Planning.Domain.UnitOfWork;

namespace Planning.Application.Features.Routines.Command.CreateRoutine
{
    public class CreateRoutineCommandHandler : IRequestHandler<CreateRoutineCommand, RoutineDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoutineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoutineDto> Handle(CreateRoutineCommand request, CancellationToken cancellationToken)
        {
            var routine = _mapper.Map<CreateRoutineDto, Routine>(request.CreateRoutineDto);

            await _unitOfWork.RoutineRepository.AddAsync(routine);
            await _unitOfWork.RoutineRepository.SaveChangesAsync();

            return _mapper.Map<RoutineDto>(routine);
        }
    }
}
