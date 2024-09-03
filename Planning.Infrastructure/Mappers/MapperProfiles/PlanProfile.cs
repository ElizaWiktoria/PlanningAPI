using AutoMapper;
using PlanningAPI.Dtos.PlanDtos;
using PlanningAPI.Models;

namespace PlanningAPI.AutoMappers.Profiles
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
