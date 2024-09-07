using AutoMapper;
using Planning.Infrastructure.AutoMappers.AutoMappers.Profiles;

namespace Planning.Infrastructure.AutoMappers
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
