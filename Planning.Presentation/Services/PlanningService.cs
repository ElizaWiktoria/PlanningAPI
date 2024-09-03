using AutoMapper;
using Planning.Domain.Interfaces.Services;
using PlanningAPI.Dtos.PlanDtos;
using PlanningAPI.Dtos.RoutineDtos;
using PlanningAPI.Exceptions.PlanningService;
using PlanningAPI.Models;
using PlanningAPI.UnitOfWork;

namespace Planning.Domain.Services
{
    public class PlanningService : IPlanningService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlanningService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MinimalRoutine>> GetAllRoutinesAsync()
        {
            var routines = await _unitOfWork.RoutineRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Routine>, IEnumerable<MinimalRoutine>>(routines);
        }

        public async Task<RoutineDto> CreateRoutineAsync(CreateRoutineDto createRoutineDto)
        {
            var routine = _mapper.Map<CreateRoutineDto, Routine>(createRoutineDto);

            await _unitOfWork.RoutineRepository.AddAsync(routine);
            await _unitOfWork.RoutineRepository.SaveChangesAsync();

            return _mapper.Map<RoutineDto>(routine);
        }

        public async Task<DateOnly> CompleteRoutineAsync(int id)
        {
            var routine = await _unitOfWork.RoutineRepository.GetAsync(x => x.Id == id);
            if (routine == null)
                throw new NotFoundException("Routine of given id does not exist.");

            var today = DateOnly.FromDateTime(DateTime.Now);
            routine.LastDone = today;
            await _unitOfWork.RoutineRepository.SaveChangesAsync();

            return today;
        }

        public async Task DeleteRoutineAsync(int id)
        {
            var routine = await _unitOfWork.RoutineRepository.GetAsync(x => x.Id == id);
            if (routine == null)
                throw new NotFoundException("Routine of given id does not exist.");

            _unitOfWork.RoutineRepository.Remove(routine);
            await _unitOfWork.RoutineRepository.SaveChangesAsync();
        }

        public async Task<RoutineDto> ModifyRoutineAsync(ModifyRoutineDto modifyRoutine)
        {
            var routine = await _unitOfWork.RoutineRepository.GetAsync(x => x.Id == modifyRoutine.Id);
            if (routine == null)
                throw new NotFoundException("Routine of given id does not exist.");

            routine.FrequencyInDays = modifyRoutine.FrequencyInDays;
            routine.Name = modifyRoutine.Name;
            routine.LastDone = DateOnly.Parse(modifyRoutine.LastDone);
            await _unitOfWork.RoutineRepository.SaveChangesAsync();

            return _mapper.Map<RoutineDto>(routine);
        }

        public async Task<PlanDto> CreatePlanAsync(CreatePlanDto createPlanDto)
        {
            var plan = _mapper.Map<CreatePlanDto, Plan>(createPlanDto);

            if (createPlanDto.RoutineId != null)
            {
                var routine = await _unitOfWork.RoutineRepository.GetAsync(x => x.Id == createPlanDto.RoutineId);
                if (routine == null)
                    throw new CreatePlanGivenRoutineNotFound("Routine of given id does not exist.");//todo illegal argument exception
                plan.Routine = routine;
            }

            await _unitOfWork.PlanRepository.AddAsync(plan);
            await _unitOfWork.PlanRepository.SaveChangesAsync();

            return _mapper.Map<Plan, PlanDto>(plan);
        }

        public async Task<IEnumerable<PlanDto>> GetPlansAsync()
        {
            var plans = await _unitOfWork.PlanRepository.GetPlansIncludingRoutineAsync();

            return _mapper.Map<IEnumerable<Plan>, IEnumerable<PlanDto>>(plans);
        }

        public async Task DeletePlanAsync(int id)
        {
            var plan = _unitOfWork.PlanRepository.Get(x => x.Id == id);
            if (plan == null)
                throw new NotFoundException("Plan of given id does not exist.");

            _unitOfWork.PlanRepository.Remove(plan);
            await _unitOfWork.PlanRepository.SaveChangesAsync();
        }
    }
}
