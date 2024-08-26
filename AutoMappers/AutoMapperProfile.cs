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

    public class StringToDateOnlyConverter : ITypeConverter<string, DateOnly>
    {
        public DateOnly Convert(string source, DateOnly destination, ResolutionContext context)
        {
            return DateOnly.Parse(source);
        }
    }
    public class DateOnlyToStringConverter : ITypeConverter<DateOnly, string>
    {
        public string Convert(DateOnly source, string destination, ResolutionContext context)
        {
            return source.ToString();
        }
    }
    public class StringToDateTimeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            return DateTime.Parse(source);
        }
    }
}
