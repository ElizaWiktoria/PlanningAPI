using AutoMapper;
using Planning.Domain.Dtos.PlanDtos;
using Planning.Domain.Models;

namespace Planning.Infrastructure.AutoMappers.AutoMappers.Profiles
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<CreatePlanDto, Plan>()
                .ForMember(dest => dest.Routine, opt => opt.Ignore());

            CreateMap<PlanDto, Plan>()
                .ReverseMap();

            CreateMap<Plan, MinimalPlan>()
                .ReverseMap();
        }
    }
}
