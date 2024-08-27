using AutoMapper;
using PlanningAPI.Dtos.RoutineDtos;
using PlanningAPI.Models;

namespace PlanningAPI.AutoMappers.Profiles
{
    public class RoutineProfile : Profile
    {
        public RoutineProfile()
        {
            CreateMap<CreateRoutineDto, Routine>()
                .ReverseMap();
            CreateMap<Routine, MinimalRoutine>()
                .ReverseMap();
            CreateMap<Routine, RoutineDto>()
                .ReverseMap();
        }
    }
}
