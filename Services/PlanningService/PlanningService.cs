using AutoMapper;
using PlanningAPI.Dtos.PlanDtos;
using PlanningAPI.Dtos.RoutineDtos;
using PlanningAPI.Models;
using PlanningAPI.UnitOfWork;

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

        public IEnumerable<Routine> GetAllRoutines()
        {
            return _unitOfWork.RoutineRepository.GetRoutinesIncludingPlans();
        }

        public Routine CreateRoutine(CreateRoutineDto createRoutineDto)
        {
            var routine = _mapper.Map<CreateRoutineDto, Routine>(createRoutineDto);
            _unitOfWork.RoutineRepository.Add(routine);
            _unitOfWork.RoutineRepository.SaveChanges();
            return routine;
        }

        public string CompleteRoutine(int id)
        {
            var routine = _unitOfWork.RoutineRepository.Get(x => x.Id == id);
            if (routine == null)
                throw new Exception("Routine of given id does not exist.");

            var today = DateOnly.FromDateTime(DateTime.Now);
            routine.LastDone = today;
            _unitOfWork.RoutineRepository.SaveChanges();

            return today.ToString("yyyy-MM-dd");
        }

        public bool DeleteRoutine(int id)
        {
            var routine = _unitOfWork.RoutineRepository.Get(x => x.Id == id);
            if (routine == null)
                throw new Exception("Routine of given id does not exist.");

            _unitOfWork.RoutineRepository.Remove(routine);
            var isDeleted = _unitOfWork.RoutineRepository.SaveChanges();
            return isDeleted;
        }

        public Routine ModifyRoutine(ModifyRoutineDto modifyRoutine)
        {
            var routine = _unitOfWork.RoutineRepository.Get(x => x.Id == modifyRoutine.Id);
            if (routine == null)
                throw new Exception("Routine of given id does not exist.");

            routine.FrequencyInDays = modifyRoutine.FrequencyInDays;
            routine.Name = modifyRoutine.Name;
            routine.LastDone = DateOnly.Parse(modifyRoutine.LastDone);

            _unitOfWork.RoutineRepository.SaveChanges();
            return routine;
        }

        public Plan CreatePlan(CreatePlanDto createPlanDto)
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

            return plan;
        }

        public IEnumerable<Plan> GetPlans()
        {
            return _unitOfWork.PlanRepository.GetAll();
        }

        public bool DeletePlan(int id)
        {
            var plan = _unitOfWork.PlanRepository.Get(x => x.Id == id);
            if (plan == null)
                throw new Exception("Plan of given id does not exist.");

            _unitOfWork.PlanRepository.Remove(plan);
            var isDeleted = _unitOfWork.PlanRepository.SaveChanges();
            return isDeleted;
        }
    }
}
