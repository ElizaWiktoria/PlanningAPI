﻿using AutoMapper;
using MediatR;
using Planning.Domain.Dtos.RoutineDtos;
using Planning.Domain.Models;
using Planning.Domain.UnitOfWork;

namespace Planning.Application.Features.Routines.Queries.GetAllRoutines
{
    public class GetAllRoutinesQueryHandler : IRequestHandler<GetAllRoutinesQuery, IEnumerable<MinimalRoutine>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRoutinesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MinimalRoutine>> Handle(GetAllRoutinesQuery query, CancellationToken cancellationToken)
        {
            var routines = await _unitOfWork.RoutineRepository.GetAllAsync();//todo check

            return _mapper.Map<IEnumerable<Routine>, IEnumerable<MinimalRoutine>>(routines);
        }
    }
}
