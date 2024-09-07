using AutoMapper;
using Planning.Domain.Dtos.RoutineDtos;
using Planning.Domain.Models;

namespace Planning.Infrastructure.AutoMappers.AutoMappers.Profiles
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
