using AutoMapper;
using PlanningAPI.Dtos.PlanDtos;
using PlanningAPI.Dtos.RoutineDtos;
using PlanningAPI.Models;
using PlanningAPI.UnitOfWork;
using System.Numerics;

namespace PlanningAPI.Services.PlanningService
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

        public IEnumerable<RoutineDto> GetAllRoutines()
        {
            var routines = _unitOfWork.RoutineRepository.GetRoutinesIncludingPlans();
            var routinesDto = _mapper.Map<IEnumerable<Routine>, IEnumerable<RoutineDto>>(routines);

            return routinesDto;
        }

        public RoutineDto CreateRoutine(CreateRoutineDto createRoutineDto)
        {
            var routine = _mapper.Map<CreateRoutineDto, Routine>(createRoutineDto);
            _unitOfWork.RoutineRepository.Add(routine);
            _unitOfWork.RoutineRepository.SaveChanges();

            var routineDto = _mapper.Map<RoutineDto>(routine);
            return routineDto;
        }

        public DateOnly CompleteRoutine(int id)
        {
            var routine = _unitOfWork.RoutineRepository.Get(x => x.Id == id);
            if (routine == null)
                throw new Exception("Routine of given id does not exist.");

            var today = DateOnly.FromDateTime(DateTime.Now);
            routine.LastDone = today;
            _unitOfWork.RoutineRepository.SaveChanges();

            return today;
        }

        public void DeleteRoutine(int id)
        {
            var routine = _unitOfWork.RoutineRepository.Get(x => x.Id == id);
            if (routine == null)
                throw new Exception("Routine of given id does not exist.");

            _unitOfWork.RoutineRepository.Remove(routine);
            var isDeleted = _unitOfWork.RoutineRepository.SaveChanges();
            return;
        }

        public RoutineDto ModifyRoutine(ModifyRoutineDto modifyRoutine)
        {
            var routine = _unitOfWork.RoutineRepository.Get(x => x.Id == modifyRoutine.Id);
            if (routine == null)
                throw new Exception("Routine of given id does not exist.");

            routine.FrequencyInDays = modifyRoutine.FrequencyInDays;
            routine.Name = modifyRoutine.Name;
            routine.LastDone = DateOnly.Parse(modifyRoutine.LastDone);

            _unitOfWork.RoutineRepository.SaveChanges();
            var routineDto = _mapper.Map<RoutineDto>(routine);
            return routineDto;
        }

        public PlanDto CreatePlan(CreatePlanDto createPlanDto)
        {
            var plan = _mapper.Map<CreatePlanDto, Plan>(createPlanDto);

            if (createPlanDto.RoutineId != null)
            {
                var routine = _unitOfWork.RoutineRepository.Get(x => x.Id == createPlanDto.RoutineId);
                if (routine == null)
                    throw new Exception("Routine of given id does not exist.");
                plan.Routine = routine;
            }

            _unitOfWork.PlanRepository.Add(plan);
            _unitOfWork.PlanRepository.SaveChanges();

            var planDto = _mapper.Map<Plan, PlanDto>(plan);

            return planDto;
        }

        public IEnumerable<PlanDto> GetPlans()
        {
            var plans = _unitOfWork.PlanRepository.GetPlansIncludingRoutine();
            var plansDto = _mapper.Map<IEnumerable<Plan>, IEnumerable<PlanDto>>(plans);
            return plansDto;
        }

        public void DeletePlan(int id)
        {
            var plan = _unitOfWork.PlanRepository.Get(x => x.Id == id);
            if (plan == null)
                throw new Exception("Plan of given id does not exist.");

            _unitOfWork.PlanRepository.Remove(plan);
            _unitOfWork.PlanRepository.SaveChanges();
            return;
        }
    }
}
