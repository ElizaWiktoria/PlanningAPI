using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Planning.Application.Features.Plans.Command.CreatePlan;
using Planning.Application.Features.Plans.Command.DeletePlan;
using Planning.Application.Features.Plans.Queries.GetPlans;
using Planning.Application.Features.Routines.Command.CompleteRoutine;
using Planning.Application.Features.Routines.Command.CreateRoutine;
using Planning.Application.Features.Routines.Command.DeleteRoutine;
using Planning.Application.Features.Routines.Command.ModifyRoutine;
using Planning.Application.Features.Routines.Queries.GetAllRoutines;
using Planning.Domain.Interfaces.Repository;
using Planning.Infrastructure.Repositories;
using PlanningAPI.AutoMappers;
using PlanningAPI.DataContext;
using PlanningAPI.Exceptions;
using PlanningAPI.UnitOfWork;

namespace PlanningApi.Startup
{
    public class ServiceRegistration
    {
        public static void Register(IServiceCollection services)
        {

            services.AddDbContext<DataContextEF>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection")
            );
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(CreatePlanCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeletePlanCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetPlansQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CompleteRoutineCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateRoutineCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeleteRoutineCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(ModifyRoutineCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllRoutinesQueryHandler).Assembly);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IRoutineRepository, RoutineRepository>();

            services.AddExceptionHandler<GlobalExceptionHandler>();

            // Auto Mapper Configurations
            var mapperConfig = new AutoMapperProfile().Configure();
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
