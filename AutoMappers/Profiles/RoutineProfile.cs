using AutoMapper;
using PlanningAPI.Dtos.RoutineDtos;
using PlanningAPI.Models;

namespace PlanningAPI.AutoMappers.Profiles
{
    public class RoutineProfile : Profile
    {
        public RoutineProfile()
        {
            CreateMap<CreateRoutineDto, Routine>();
            CreateMap<string, DateOnly>().ConvertUsing(new StringToDateOnlyConverter());
        }
    }
}
