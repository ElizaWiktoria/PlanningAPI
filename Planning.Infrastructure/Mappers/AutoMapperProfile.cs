using AutoMapper;
using PlanningAPI.AutoMappers.Profiles;

namespace PlanningAPI.AutoMappers
{
    public class AutoMapperProfile
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RoutineProfile>();
                cfg.AddProfile<PlanProfile>();
            });
            return config;
        }
    }
}
